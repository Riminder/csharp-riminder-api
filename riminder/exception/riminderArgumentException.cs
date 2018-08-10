using System;

namespace Riminder.exp
{
    [System.Serializable]
    public class RiminderArgumentException : RiminderException
    {
        public RiminderArgumentException() { }
        public RiminderArgumentException(string message) : base(message) { }
        public RiminderArgumentException(string message, System.Exception inner) : base(message, inner) { }
        protected RiminderArgumentException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}