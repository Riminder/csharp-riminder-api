using System;

namespace riminder.route
{
    class Webhook
    {
        private RestClientW _client;
        private string _key;

        class Events
        {
            const string PROFILE_PARSE_SUCCESS = "profile.parse.success";
            const string PROFILE_PARSE_ERROR = "profile.parse.error";
            const string PROFILE_SCORE_SUCCESS = "profile.score.success";
             
        }

        public Webhook(ref RestClientW client, string key)
        {
            _client = client;
            _key = key;
        }

        public response.WebhookCheck check()
        {
            var resp = _client.post<response.WebhookCheck>("webhook/check");
            return resp.data;
        }

    }
}