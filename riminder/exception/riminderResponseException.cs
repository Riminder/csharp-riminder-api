using System;
using System.Net;
using System.Collections.Generic;
using RestSharp;
using Newtonsoft.Json;

namespace riminder.exp
{
    [System.Serializable]
    public class RiminderResponseException : RiminderException
    {
        public HttpStatusCode code {get;}
        public string message {get;}
        public string apiMessage {get;}
        public IRestResponse response {get;}
        public Uri url {get;}

        private static string extractApiErrorMessage(string rawResp)
        {
            var apiMessage = "";
            try
            {
                var r = JsonConvert.DeserializeObject<Dictionary<string, object>>(rawResp);
                apiMessage = (string)r["message"];
            }
            catch (JsonException)
            {
                apiMessage = "...";
            }
            return apiMessage;
        }

        static string gen_error_message(IRestResponse resp)
        {
            var response = resp;
            var code = resp.StatusCode;
            var message = resp.ErrorMessage;
            // Try to get error message from api if possible.
            var apiMessage = extractApiErrorMessage(resp.Content);

            return String.Format("Invalid response: {0}:{1} -> {2} ({3})", (int)code, code, message, apiMessage);
        }

        public RiminderResponseException(IRestResponse resp): base(gen_error_message(resp))
        {
            response = resp;
            code = resp.StatusCode;
            message = resp.ErrorMessage;
            url = resp.ResponseUri;

            // Try to get error message from api if possible.
            apiMessage = extractApiErrorMessage(resp.Content);
        }

        public RiminderResponseException() { }
        public RiminderResponseException(string message) : base(message) { }
        public RiminderResponseException(string message, System.Exception inner) : base(message, inner) { }
        protected RiminderResponseException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
