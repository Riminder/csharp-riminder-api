using System;
using System.Collections.Generic;

namespace Riminder.response
{
    public class WebhookActionStage : IWebhookMessage
    {
        public string type;
        public string EventName
        {
            get { return type; }
        }
        public string message;
        public WebhookProfile profile;
        public WebhookFilter filter;
        public string stage;
    }

    public class WebhookActionRating : IWebhookMessage
    {
        public string type;
        public string EventName
        {
            get {return type;}
        }
        public string message;
        public WebhookProfile profile;
        public WebhookFilter filter;
        public int rating;
    }
}