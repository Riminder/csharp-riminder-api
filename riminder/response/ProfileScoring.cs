using System;
using System.Collections.Generic;

namespace riminder.response
{
    class ProfileScoringList : List<ProfileScoringListElem>, IResponse
    {
        public ProfileScoringList() : base()
        { }
    }
    class ProfileScoringListElem
    {
        public string filter_id;
        public string filter_reference;
        public ScoringTemplate template;
        public float score;
        public int rating;
        public string stage;
    }

}