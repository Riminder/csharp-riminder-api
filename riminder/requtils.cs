using System;
using System.Collections.Generic;

namespace riminder
{
    class RequestUtils
    {
        public static Dictionary<string, object>addIfNotNull(ref Dictionary<string, object> to_fill, string key, object value)
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
                throw new riminder.exp.RiminderArgumentException(message);
        }

        public class Seniority
        {
            public const string ALL = "all";
            public const string SENIOR = "senior";
            public const string JUNIOR = "junior";
        }

        public class Sortby
        {
            public const string RECEPTION = "reception";
            public const string RANKING = "ranking";
        }

        public class Orderby
        {
            public const string DESC = "desc";
            public const string ASC = "asc";
        }

        public class Stage
        {
            public const string NEW = "new"; 
            public const string YES = "yes";
            public const string LATER = "later";
            public const string NO = "no";
        }

        public static string Base64Decode(string input)
        {
            var input_b64byte = System.Convert.FromBase64String(input);
            return System.Text.Encoding.UTF8.GetString(input_b64byte);
        }
    }
}