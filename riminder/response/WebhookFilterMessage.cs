using System;
using System.Collections.Generic;

namespace riminder.response
{
    class WebhookFilterTrain : IWebhookMessage
    {
        public string type;
        public string EventName
        {
            get { return type; }
        }
        public string message;
        public WebhookFilter filter;
    }

    class WebhookFilterScore : IWebhookMessage
    {
        public string type;
        public string EventName
        {
            get { return type; }
        }
        public string message;
        public WebhookFilter filter;
    }
}