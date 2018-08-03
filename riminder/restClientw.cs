using System;
using System.Collections.Generic;

using RestSharp;
using Newtonsoft.Json;


namespace riminder
{
    using RequestQueryArgs = Dictionary<string, string>;

    class RestClientW
    {
        private RestSharp.RestClient client {get;}

        private void fill_default_header(Dictionary<string, string> headers_to_add)
        {
            foreach (var header in headers_to_add)
            {
                client.AddDefaultHeader(header.Key, header.Value);
            }
        }

        private void fill_query_params(ref RestRequest req, RequestQueryArgs args)
        {
            if (args == null) 
                return;
            foreach(var arg in args)
            {
                req.AddQueryParameter(arg.Key, arg.Value);
            }
        }

        public RestClientW(Uri base_uri, Dictionary<string, string> def_headers)
        {
            client = new RestClient(base_uri);
            fill_default_header(def_headers);
        }

        public T get<T>(string endpoint, RequestQueryArgs args = null)
        {
            var req = new RestRequest(endpoint, Method.GET);
            fill_query_params(ref req, args);
            IRestResponse resp = client.Execute(req);
            T respObj = JsonConvert.DeserializeObject<T>(resp.Content);
            return respObj;
        }
    }
}