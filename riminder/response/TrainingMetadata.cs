using System;
using System.Collections.Generic;

namespace riminder.response
{
    // It can be part of request sometimes.
    class TrainingMetadatas : List<TrainingMetadata>
    {
        public TrainingMetadatas() : base()
        { }
        
        public bool is_valid(bool isExp=false)
        {
            foreach (var metadata in this)
            {
                if (!metadata.is_valid(isExp))
                    return false;
            }
            return true;
        }
    }

    class TrainingMetadata
    {
        public string filter_reference;
        public string stage;
        public long stage_timestamp;
        public int rating;
        public long rating_timestamp;

        public bool is_valid(bool isExp=false)
        {
            if (RequestUtils.is_empty(filter_reference)){
                if (isExp) 
                    throw new exp.RiminderArgumentException(String.Format("Training metadata must have filter_refence not empty and not null (filter_reference: {0}).", filter_reference));
                return false;
            }
            return true;
        }
    }
}