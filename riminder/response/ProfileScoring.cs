using System;
using System.Collections.Generic;

namespace riminder.response
{
    public class ProfileScoringList : List<ProfileScoringListElem>, IResponse
    {
        public ProfileScoringList() : base()
        { }
    }
    public class ProfileScoringListElem
    {
        public string filter_id;
        public string filter_reference;
        public ScoringTemplate template;
        public float score;
        public int rating;
        public string stage;
    }

}