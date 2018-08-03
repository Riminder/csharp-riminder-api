using System;
using System.Collections.Generic;
using System.Net;

namespace riminder.response
{
    public interface IResponse
    {
        HttpStatusCode statuscode {get;}
        string message {get;}
    }
}