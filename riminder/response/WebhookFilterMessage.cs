using System;
using System.Collections.Generic;

namespace Riminder.response
{
    public class WebhookFilterTrain : IWebhookMessage
    {
        public string type;
        public string EventName
        {
            get { return type; }
        }
        public string message;
        public WebhookFilter filter;
    }

    public class WebhookFilterScore : IWebhookMessage
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