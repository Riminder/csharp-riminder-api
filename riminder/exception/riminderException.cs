using System;

namespace riminder.exception
{
    [System.Serializable]
    public class RiminderException : System.Exception
    {
        public RiminderException() { }
        public RiminderException(string message) : base(message) { }
        public RiminderException(string message, System.Exception inner) : base(message, inner) { }
        protected RiminderException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
