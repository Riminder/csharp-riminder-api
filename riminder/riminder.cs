using System;
using System.Collections.Generic;
using RestSharp;


namespace Riminder
{
    public class Riminder
    {
        private static string DEFAULT_URL = "https://www.riminder.net/sf/public/api/";
        private static string DEFAULT_HOST_BASE = "v1.0";

        private static Dictionary<string, string>  DEFAULT_HEADERS = new Dictionary<string, string>{
            {"X-API-KEY", ""}
        };

        private string _secret_key;
        private string _webhook_key;
        private Uri _url;
        private string _host_base;
        private Dictionary<string,string> _headers;
        private RestClientW _client;

        public global::Riminder.route.Source source {get;}
        public global::Riminder.route.Filter filter {get;}
        public global::Riminder.route.Profile profile {get;}
        public global::Riminder.route.Webhook webhooks {get;}

        private static string setstringWthDefault(string value, string dft)
        {
            if (value == null)
                return dft;
            return value;
        }

        public Riminder(string secret_key, string webhook_key = null, string url = null, string host_base = null)
        {
            _secret_key = secret_key;
            _webhook_key = webhook_key;
            _headers = DEFAULT_HEADERS;

            var tmp_url = "";
            // To be able to modify host (test purposes for example)
            tmp_url = setstringWthDefault(url, DEFAULT_URL);
            _host_base = setstringWthDefault(host_base, DEFAULT_HOST_BASE);

            _url = new Uri(String.Concat(tmp_url + _host_base));
            _headers["X-API-KEY"] = _secret_key;
            _client = new RestClientW(_url, _headers);

            source = new global::Riminder.route.Source(_client);
            filter = new global::Riminder.route.Filter(_client);
            profile = new global::Riminder.route.Profile(_client);
            webhooks = new global::Riminder.route.Webhook(_client, _webhook_key);
        }
    }
}