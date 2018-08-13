using System;
using System.Collections.Generic;

namespace Riminder.response
{
    class BaseResponse<T> : IResponse
    {
        public T data;
        public string message;
        public int code;
    }
}