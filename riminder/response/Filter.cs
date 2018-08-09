using System;
using System.Collections.Generic;

namespace riminder.response
{
    public class Filter_get: IResponse
    {
        public class Template
        {
            public string name;
        }

        public class Stage
        {
            public int count_no;
            public int count_yes;
            public int count_later;
        }

        public string filter_id {get; set;}
        public string filter_reference {get; set;}
        public string name {get; set;}
        public string description {get; set;}
        public string score_threshold {get; set;}
        public Template template {get; set;}
        public string seniority {get; set;}
        public List<string> countries {get; set;}
        public Boolean archive {get; set;}
        public Date date_creation {get; set;}
        public List<string> skills {get; set;}
        public Stage stages {get; set;}

    }
    
    public class FilterList : List<FilterListElem>, IResponse
    {
        public FilterList() : base()
        { }
    }

    public class FilterListElem
    {
        public string filter_id;
        public string filter_reference;
        public string name;
        public bool archive;
        public Date date_creation;
    }
}