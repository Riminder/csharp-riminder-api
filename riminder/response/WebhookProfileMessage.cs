using System;
using System.Collections.Generic;

namespace riminder.response
{
    class WebhookProfileParse
    {
        public string type;
        public string message;
        public WebhookProfile profile;
    }

    class WebhookProfileScore
    {
        public string type;
        public string message;
        public WebhookProfile profile;
        public WebhookFilter filter;
        float score;
    }
}