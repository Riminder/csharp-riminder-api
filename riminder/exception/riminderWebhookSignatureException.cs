using System;

namespace Riminder.exp
{
    [System.Serializable]
    public class RiminderWebhookSignatureException : RiminderException
    {
        static string gen_error_message(string bad_sign)
        {
            return String.Format("Invalid signature: {0} is invalid.", bad_sign);
        }

        public string bad_sign { get; }

        public RiminderWebhookSignatureException(string bad_sign, string useless) : base(gen_error_message(bad_sign))
        {
            this.bad_sign = bad_sign;
        }

        public RiminderWebhookSignatureException() { }
        public RiminderWebhookSignatureException(string message) : base(message) { }
        public RiminderWebhookSignatureException(string message, System.Exception inner) : base(message, inner) { }
        protected RiminderWebhookSignatureException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}