using System;
using System.Collections.Generic;
using System.IO;

using RestSharp;
using Newtonsoft.Json;


namespace riminder
{
    using RequestQueryArgs = Dictionary<string, string>;
    using RequestBodyParams = Dictionary<string, object>;

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

        private void add_file_to_req(ref RestRequest req, string file_path)
        {
            if (RequestUtils.is_empty(file_path))
                return;
            try
            {
                var tmpfile = File.OpenRead(file_path);
                tmpfile.Close();
            }
            catch (Exception ex)
            {
                throw new exp.RiminderFileUploadException(file_path, ex.Message);
            }
            
            var filename = Path.GetFileName(file_path);
            req.AddFile(filename, file_path);
        }

        private void fill_body_params(ref RestRequest req, RequestBodyParams bodyp, bool isJson = true)
        {
            if (bodyp == null)
                return;
            if (!isJson)
            {
                req.AddBody(bodyp);
                return;
            }
            req.AddJsonBody(bodyp); 
        }

        private response.BaseResponse<T> deserializeResponse<T>(string response)
        {
            response.BaseResponse<T> respObj = null;
            try
            {
                respObj = JsonConvert.DeserializeObject<response.BaseResponse<T>>(response);
            }
            catch (JsonException e)
            {
                throw new exp.RiminderResponseParsingException("Cannot parse api's response.", e);
            }
            return respObj;
        }

        private static void check_response(IRestResponse resp)
        {
            if (!resp.IsSuccessful)
                throw new riminder.exp.RiminderResponseException(resp);
        }

        public RestClientW(Uri base_uri, Dictionary<string, string> def_headers)
        {
            client = new RestClient(base_uri);
            fill_default_header(def_headers);
        }

        public response.BaseResponse<T> get<T>(string endpoint, RequestQueryArgs args = null)
        {
            var req = new RestRequest(endpoint, Method.GET);
            fill_query_params(ref req, args);
            
            IRestResponse resp = client.Execute(req);
            check_response(resp);

            return deserializeResponse<T>(resp.Content);
        }

        public response.BaseResponse<T> post<T>(string endpoint, RequestBodyParams args = null, string file_path = null, bool isbodyjson = true)
        {
            var req = new RestRequest(endpoint, Method.POST);
            fill_body_params(ref req, args, isbodyjson);
            add_file_to_req(ref req, file_path);

            IRestResponse resp = client.Execute(req);
            check_response(resp);

            return deserializeResponse<T>(resp.Content);
        }

        public response.BaseResponse<T> patch<T>(string endpoint, RequestBodyParams args = null, bool isbodyjson = true)
        {
            var req = new RestRequest(endpoint, Method.PATCH);
            fill_body_params(ref req, args, isbodyjson);

            IRestResponse resp = client.Execute(req);
            check_response(resp);

            return deserializeResponse<T>(resp.Content);
        }
    }
}