using System;
using System.Collections.Generic;

namespace Riminder.response
{
    public class WebhookProfileParse : IWebhookMessage
    {
        public string type;
        public string EventName
        {
            get { return type; }
        }
        public string message;
        public WebhookProfile profile;
    }

    public class WebhookProfileScore : IWebhookMessage
    {
        public string type;
        public string EventName
        {
            get { return type; }
        }
        public string message;
        public WebhookProfile profile;
        public WebhookFilter filter;
        float score;
    }
}