// Fixme: Find a better name.
using System;
using System.Collections.Generic;

namespace riminder.response
{
    class ProfileJson
    {
        public string name;
        public string email;
        public string phone;
        public string summary;
        public LocationDetails location_details;
        public Experience experiences;
        public Educations educations;
        public List<string> skills;
        public List<string> languages;
        public List<string> interests;
        public Urls urls;

        // Diferent from profile parsing one.
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

        public class Educations
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

    class Date
    {
        public string date { get; set; }
        public int timezone_type { get; set; }

        public string timezone { get; set; }
    }

    class ScoringTemplate
    {
        public string name;
    }

    // It can be part of request sometimes.
    class TrainingMetadatas : List<TrainingMetadata>
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

    class TrainingMetadata
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

    class WebhookProfile
    {
        public string profile_id;
        public string profile_reference;
    }

    class WebhookFilter
    {
        public string filter_id;
        public string filter_reference;
    }
}