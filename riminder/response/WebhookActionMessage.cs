using System;
using System.Collections.Generic;

namespace riminder.response
{
    class WebhookActionStage : IWebhookMessage
    {
        public string type;
        public string EventName
        {
            get { return type; }
        }
        public string message;
        public WebhookProfile profile;
        public WebhookFilter filter;
        string stage;
    }

    class WebhookActionRating : IWebhookMessage
    {
        public string type;
        public string EventName
        {
            get {return type;}
        }
        public string message;
        public WebhookProfile profile;
        public WebhookFilter filter;
        int rating;
    }
}