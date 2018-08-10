using System;
using System.Collections.Generic;
using System.Net;

namespace Riminder.response
{
    // An interface to group all webhook message.
    public interface IWebhookMessage
    { 
        string EventName {get;}
    }
}