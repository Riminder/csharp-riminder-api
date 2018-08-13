using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Riminder.route
{
    public class Webhook
    {
        private const string HEADER_SIGNATURE_KEY = "HTTP-RIMINDER-SIGNATURE";

        // Hanlder for webhooks events
        public delegate void WebhookHandler(string eventName, response.IWebhookMessage webhook_data);

        // To be able to store response parser and avoid a big switch
        public delegate response.IWebhookMessage WebhookMessageParser(JToken token);

        private RestClientW _client;
        private string _key;
        private Dictionary<string, WebhookHandler> _handlers;
        
        // _typeobj contains function to pass from a JToken to the 
        // good struct for the event. 
        private Dictionary<string, WebhookMessageParser> _typeobj;

        public class EventNames
        {
            public const string PROFILE_PARSE_SUCCESS = "profile.parse.success";
            public const string PROFILE_PARSE_ERROR = "profile.parse.error";
            public const string PROFILE_SCORE_SUCCESS = "profile.score.success";
            public const string PROFILE_SCORE_ERROR = "profile.score.error";
            public const string FILTER_TRAIN_START = "filter.train.start";
            public const string FILTER_TRAIN_SUCCESS = "filter.train.success";
            public const string FILTER_TRAIN_ERROR = "filter.train.error";
            public const string FILTER_SCORE_START = "filter.score.start";
            public const string FILTER_SCORE_SUCCESS = "filter.score.success";
            public const string FILTER_SCORE_ERROR = "filter.score.error";
            public const string ACTION_RATING_SUCCESS = "action.rating.success";
            public const string ACTION_RATING_ERROR = "action.rating.error";
            public const string ACTION_STAGE_SUCCESS = "action.stage.success";
            public const string ACTION_STAGE_ERROR = "action.stage.error";
        }

        public Webhook(object client, string key)
        {
            _client = (RestClientW)client;
            _key = key;
            _handlers = new Dictionary<string, WebhookHandler>
            {
                {EventNames.PROFILE_PARSE_SUCCESS, null},
                {EventNames.PROFILE_PARSE_ERROR, null},
                {EventNames.PROFILE_SCORE_SUCCESS, null},
                {EventNames.PROFILE_SCORE_ERROR, null},
                {EventNames.FILTER_TRAIN_START, null},
                {EventNames.FILTER_TRAIN_SUCCESS, null},
                {EventNames.FILTER_TRAIN_ERROR, null},
                {EventNames.FILTER_SCORE_START, null},
                {EventNames.FILTER_SCORE_SUCCESS, null},
                {EventNames.FILTER_SCORE_ERROR, null},
                {EventNames.ACTION_RATING_SUCCESS, null},
                {EventNames.ACTION_RATING_ERROR, null},
                {EventNames.ACTION_STAGE_SUCCESS, null},
                {EventNames.ACTION_STAGE_ERROR, null},
            };

            _typeobj = new Dictionary<string, WebhookMessageParser>
            {
                {EventNames.PROFILE_PARSE_SUCCESS, (JToken token) => token.ToObject<response.WebhookProfileParse>()},
                {EventNames.PROFILE_PARSE_ERROR, (JToken token) => token.ToObject<response.WebhookProfileParse>()},
                {EventNames.PROFILE_SCORE_SUCCESS, (JToken token) => token.ToObject<response.WebhookProfileScore>()},
                {EventNames.PROFILE_SCORE_ERROR, (JToken token) => token.ToObject<response.WebhookProfileScore>()},
                {EventNames.FILTER_TRAIN_START, (JToken token) => token.ToObject<response.WebhookFilterTrain>()},
                {EventNames.FILTER_TRAIN_SUCCESS, (JToken token) => token.ToObject<response.WebhookFilterTrain>()},
                {EventNames.FILTER_TRAIN_ERROR, (JToken token) => token.ToObject<response.WebhookFilterTrain>()},
                {EventNames.FILTER_SCORE_START, (JToken token) => token.ToObject<response.WebhookFilterScore>()},
                {EventNames.FILTER_SCORE_SUCCESS, (JToken token) => token.ToObject<response.WebhookFilterScore>()},
                {EventNames.FILTER_SCORE_ERROR, (JToken token) => token.ToObject<response.WebhookFilterScore>()},
                {EventNames.ACTION_RATING_SUCCESS, (JToken token) => token.ToObject<response.WebhookActionRating>()},
                {EventNames.ACTION_RATING_ERROR, (JToken token) => token.ToObject<response.WebhookActionRating>()},
                {EventNames.ACTION_STAGE_SUCCESS, (JToken token) => token.ToObject<response.WebhookActionStage>()},
                {EventNames.ACTION_STAGE_ERROR, (JToken token) => token.ToObject<response.WebhookActionStage>()},
            };

        }

        public response.WebhookCheck check()
        {
            var resp = _client.post<response.WebhookCheck>("webhook/check");
            return resp.data;
        }

        public void setHandler(string eventName, WebhookHandler callback)
        {
            if (!_handlers.ContainsKey(eventName))
                throw new exp.RiminderArgumentException(String.Format("'{0}' is not a valid event name.", eventName));
            _handlers[eventName] = callback;
        }

        public bool isHandlerPresent(string eventName)
        {
            if (!_handlers.ContainsKey(eventName))
                throw new exp.RiminderArgumentException(String.Format("'{0}' is not a valid event name.", eventName));
            return _handlers[eventName] != null;
        }

        public void removeHandler(string eventName)
        {
            if (!_handlers.ContainsKey(eventName))
                throw new exp.RiminderArgumentException(String.Format("'{0}' is not a valid event name.", eventName));
            _handlers[eventName] = null;
        }

        private static string getSignatureHeader(Dictionary<string, string> headers = null, string signatureHeader = null)
        {
            if (headers != null && headers.ContainsKey(HEADER_SIGNATURE_KEY))
                return headers[HEADER_SIGNATURE_KEY];

            if (signatureHeader != null)
                return signatureHeader;
            throw new exp.RiminderArgumentException("A signature header must be given.");
        }

        // Perform strstr operations.
        private static string customstrstr(string input, string to_change, string to)
        {
            var res = "";
            foreach (var c in input)
            {
                var tmpc = c;
                for (int i = 0; i < to_change.Length; i++)
                {
                    var c_to_replace = to_change[i];
                    if (c == c_to_replace && i < to.Length)
                        tmpc = to[i];
                }
                res += tmpc;
            }
            return res;
        }

        private static string base64urlDecode(string input)
        {
            return RequestUtils.Base64Decode(customstrstr(input, "-_", "+/"));
        }

        private bool isSignatureValid(string payload, string sign)
        {
            var byte_payload = System.Text.Encoding.UTF8.GetBytes(payload);
            var byte_key = System.Text.Encoding.UTF8.GetBytes(_key);
            var byte_sign = System.Text.Encoding.UTF8.GetBytes(sign);
            var hasher = new System.Security.Cryptography.HMACSHA256(byte_key);

            var expectedsign_byte = hasher.ComputeHash(byte_payload);
            var expectedsign = System.Text.Encoding.UTF8.GetString(expectedsign_byte);

            return expectedsign.Equals(sign) ? true : false;
        }

        private response.IWebhookMessage parseData(string json_data)
        {
            var data = JObject.Parse(json_data);
            var type = data["type"].Value<string>();
            
            if (!_typeobj.ContainsKey(type))
                throw new exp.RiminderResponseParsingException(String.Format("{0} is not a valid event.", type));
            return _typeobj[type](data);
        }

        public void handle(Dictionary<string, string> headers = null, string signatureHeader = null)
        {
            var signatureHeaderRaw = getSignatureHeader(headers, signatureHeader);
            var tmp = signatureHeaderRaw.Split('.', 2);
            var sign = base64urlDecode(tmp[0]);
            var data_json = base64urlDecode(tmp[1]);

            if (!isSignatureValid(data_json, sign))
                throw new exp.RiminderWebhookSignatureException(sign, "...");
            var data = parseData(data_json);
            var callback = _handlers[data.EventName];

            if (callback != null)
                callback(data.EventName, data);

        }

    }
}