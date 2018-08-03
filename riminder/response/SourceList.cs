using System;
using System.Collections.Generic;

namespace riminder.response
{
    class SourceListElem
    {
        string source_id {get; set;}
        string name {get; set;}
        string type {get; set;}
        Boolean archive {get; set;}
        int count_source {get; set;}
        DateTime date_creation { get; set; }
    }
    
}