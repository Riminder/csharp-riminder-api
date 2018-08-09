using System;
using System.Collections.Generic;

namespace riminder.response
{
    public class Source_get: IResponse
    {
        public string source_id;
        public string name;
        public string type;
        public Boolean archive;
        public int count_source;
        public Date date_creation;
    }

    public class SourceList : List<SourceListElem>, IResponse
    {
        public SourceList() : base()
        { }
    }
    public class SourceListElem
    {
        public string source_id;
        public string name;
        public string type;
        public Boolean archive;
        public Date date_creation;
    }

}