// Fixme: Find a better name.
using System;
using System.Collections.Generic;

namespace Riminder.response
{
    public class ProfileJson
    {
        public string name;
        public string email;
        public string phone;
        public string summary;
        public LocationDetails location_details;
        public List<Experience> experiences;
        public List<Education> educations;
        public List<string> skills;
        public List<string> languages;
        public List<string> interests;
        public Urls urls;

        // Different from profile parsing one.
        public class Experience
        {
            public string start;
            public string end;
            public string title;
            public string company;
            public string location;
            public LocationDetails location_details;
            public string description;
        }

        // Different from interpretability one.
        public class Education
        {
            public string start;
            public string end;
            public string title;
            public string school;
            public string location;
            public LocationDetails location_details;
            public string description;
        }

        public class LocationDetails
        {
            public string text;
            public float lng;
            public float lat;
            public string gmaps; 
        }

        public class Urls
        {
            public List<string> from_resume;
            public string linkedin;
            public string twitter;
            public string facebook;
            public string github;
            public string picture;
        }
    }

    public class Date
    {
        public string date { get; set; }
        public int timezone_type { get; set; }

        public string timezone { get; set; }
    }

    public class ScoringTemplate
    {
        public string name;
    }

    // Used in InterpretabilityProfile class.
    public class WordScore
    {
        public string word;
        public string score;
    }

    public class RevealProfile
    {
        public List<Experience> experiences;
        public List<Education> educations;

        // Different from the other ones.
        public class Experience
        {
            public int startDate;
            public int endDate;
            public string score;
            public List<WordScore> title;
            public List<WordScore> description;
            public List<WordScore> company;
        }

        // Different from profile json one.
        public class Education
        {
            public int startDate;
            public int endDate;
            public string score;
            public List<WordScore> title;
            public List<WordScore> description;
            public List<WordScore> school;
        }
    }

    public class RevealSkills
    {
        public List<WordScore> hardSkills;
        public List<WordScore> specialSkills;
        public List<WordScore> transversalSkills;
        public List<WordScore> softSkills;
    }

    // It can be part of request sometimes.
    public class TrainingMetadatas : List<TrainingMetadata>
    {
        public TrainingMetadatas() : base()
        { }

        public bool is_valid(bool isExp = false)
        {
            foreach (var metadata in this)
            {
                if (!metadata.is_valid(isExp))
                    return false;
            }
            return true;
        }
    }

    public class TrainingMetadata
    {
        public string filter_reference;
        public string stage;
        public long stage_timestamp;
        public int rating;
        public long rating_timestamp;

        public bool is_valid(bool isExp = false)
        {
            if (RequestUtils.is_empty(filter_reference))
            {
                if (isExp)
                    throw new exp.RiminderArgumentException(String.Format("Training metadata must have filter_reference not empty and not null (filter_reference: {0}).", filter_reference));
                return false;
            }
            return true;
        }
    }

    public class WebhookProfile
    {
        public string profile_id;
        public string profile_reference;
    }

    public class WebhookFilter
    {
        public string filter_id;
        public string filter_reference;
    }
}