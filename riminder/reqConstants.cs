using System;

namespace Riminder
{
    public class RequestConstant
    {
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
            public const string NEW = "NEW";
            public const string YES = "YES";
            public const string LATER = "LATER";
            public const string NO = "NO";
        }
    }
}