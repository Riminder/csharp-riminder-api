using System;
using System.Collections.Generic;

namespace riminder.response
{
    class BaseResponse<T> : IResponse
    {
        public T data;
        public string message;
        public int code;
    }
}