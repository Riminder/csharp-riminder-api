using System;

namespace riminder.exp
{
    [System.Serializable]
    public class RiminderResponseParsingException : RiminderException
    {
        public RiminderResponseParsingException() { }
        public RiminderResponseParsingException(string message) : base(message) { }
        public RiminderResponseParsingException(string message, System.Exception inner) : base(message, inner) { }
        protected RiminderResponseParsingException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}