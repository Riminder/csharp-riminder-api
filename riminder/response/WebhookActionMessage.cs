using System;
using System.Collections.Generic;

namespace riminder.response
{
    class WebhookActionStage
    {
        public string type;
        public string message;
        public WebhookProfile profile;
        public WebhookFilter filter;
        string stage;
    }

    class WebhookActionRating
    {
        public string type;
        public string message;
        public WebhookProfile profile;
        public WebhookFilter filter;
        int rating;
    }
}