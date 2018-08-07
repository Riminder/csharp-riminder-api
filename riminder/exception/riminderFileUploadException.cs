using System;

namespace riminder.exp
{
    [System.Serializable]
    public class RiminderFileUploadException : RiminderException
    {
        static string gen_error_message(string filepath, string reason)
        {
            return String.Format("Cannot upload file '{0}': {1}", filepath, reason);
        }

        public string filepath {get;}
        public string reason {get;}

        public RiminderFileUploadException(string filepath, string reason): base(gen_error_message(filepath, reason))
        {
            this.filepath = filepath;
            this.reason = reason;
        }

        public RiminderFileUploadException() { }
        public RiminderFileUploadException(string message) : base(message) { }
        public RiminderFileUploadException(string message, System.Exception inner) : base(message, inner) { }
        protected RiminderFileUploadException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}