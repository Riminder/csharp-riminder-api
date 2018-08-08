using System;
using System.Collections.Generic;

namespace riminder.response
{
    class WebhookFilterTrain
    {
        public string type;
        public string message;
        public WebhookFilter filter;
    }

    class WebhookFilterScore
    {
        public string type;
        public string message;
        public WebhookFilter filter;
    }
}