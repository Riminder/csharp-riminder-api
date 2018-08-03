using System;

namespace riminder.response
{
    class Source: IResponse
    {
        public string source_id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public Boolean archive { get; set; }
        public int count_source { get; set; }
        public Date date_creation { get; set; }
    }
}