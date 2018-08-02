using System;
using System.Collections.Generic;
using RestSharp;


namespace riminder
{
    class Riminder
    {
        private static string DEFAULT_HOST = "https://www.riminder.net/sf/public/api/";
        private static string DEFAULT_HOST_BASE = "v1.0/";

        private static Dictionary<string, string>  DEFAULT_HEADERS = new Dictionary<string, string>{
            {"X-API-KEY", ""}
        };

        private string _secret_key;
        private string _webhook_key;
        private string _host;
        private string _host_base;
        private Dictionary<string,string> _headers;

        public Riminder(string secret_key, string webhook_key, string host = null, string host_base = null)
        {
            _secret_key = secret_key;
            _webhook_key = webhook_key;
            _host = DEFAULT_HOST;
            _host_base = DEFAULT_HOST_BASE;
            _headers = DEFAULT_HEADERS;

            // To be able to modify host (test purposes for example)
            if (host != null) 
                _host = host;
            if (host_base != null)
                _host_base = host;

            _headers["X-API-KEY"] = _secret_key;
        }
    }
}