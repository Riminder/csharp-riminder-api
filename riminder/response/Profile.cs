using System;

namespace riminder.response
{
    class Profile_post : IResponse
    {
        public string profile_reference;
        public string file_id;
        public string file_name;
        public string file_size;
        public string extension;
        public Date date_reception;
    }

    class Profile_get: IResponse
    {
        public string profile_id;
        public string profile_reference;
        public string name;
        public string email;
        public string phone;
        public string address;
        public string source_id;
        public Date date_reception;
        public Date date_creation;
    }

    class ProfileList : IResponse
    {
        public int page;
        public int maxPage;
        public int count_profiles;
    }

    class ProfileListElem
    {
        public class Source
        {
            public string source_id;
            public string name;
            public string type;
        }

        public string profile_id;
        public string profile_reference;
        public string name;
        public string email;
        public string seniority;
        public Date date_reception;
        public Date date_creation;
        public Source source;
        public float score;
        public string stage;
        public int rating;
    }
}