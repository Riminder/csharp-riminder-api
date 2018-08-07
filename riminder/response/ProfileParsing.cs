using System;
using System.Collections.Generic;

namespace riminder.response
{
    class ProfileParsing
    {
        public List<string> hard_skills;
        public List<string> soft_skills;
        public List<string> languages;
        public string seniority;
        public List<Experience> experiences;
        public List<Education> educations;

        public class Experience
        {  
            public string title;
            public string description;
            public string company;
            public string location;
            public string start_date;
            public string end_date; 
        }

        public class Education
        {
            public string title;
            public string description; 
            public string school;
            public string location;
            public string start_date;
            public string end_date;
        }
    }
}