using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("riminder.Tests")]
namespace Riminder
{
    class RequestUtils
    {
        public static Dictionary<string, object> addIfNotNull(ref Dictionary<string, object> to_fill, string key, object value)
        {
            if (value == null)
                return to_fill;
            to_fill[key] = value;
            return to_fill;
        }

        public static Dictionary<string, string> addIfNotNull(ref Dictionary<string, string> to_fill, string key, string value)
        {
            if (value == null)
                return to_fill;
            to_fill[key] = value;
            return to_fill;
        }

        public static bool is_empty(string a)
        {
            return (a == "" || a == null) ? true : false;
        }

        // FIXME: find a better name
        // Ensure that an identifier (*_id or *_reference) has been pass and is not.
        // null or empty
        public static void assert_id_ref_notNull(string id, string reff, string message="")
        {
            if (is_empty(id) && is_empty(reff))
                throw new global::Riminder.exp.RiminderArgumentException(message);
        }

        public static string Base64Decode(string input)
        {
            var input_b64byte = System.Convert.FromBase64String(input);
            return System.Text.Encoding.UTF8.GetString(input_b64byte);
        }
    }
}