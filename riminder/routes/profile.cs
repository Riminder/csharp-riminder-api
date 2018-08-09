using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace riminder.route
{

    public class Profile
    {
        private RestClientW _client;
        private const string _start_timestamp = "1407423743";

        public Structured json;
        public Documents documents;
        public Parsing parsing;
        public Scoring scoring;
        public Stage stage;
        public Rating rating;

        public Profile(object client)
        {
            _client = (RestClientW)client;

            json = new Structured(_client);
            documents = new Documents(_client);
            parsing = new Parsing(_client);
            scoring = new Scoring(_client);
            stage = new Stage(_client);
            rating = new Rating(_client);
        }

        public response.Profile_post add(string source_id, string file_path, string profile_reference, long timestamp_reception, response.TrainingMetadatas training_metadatas)
        {
            training_metadatas.is_valid(isExp:true);
            var body = new Dictionary<string, object>
            {
                {"source_id", source_id}
            };
            RequestUtils.addIfNotNull(ref body, "profile_reference", profile_reference);
            RequestUtils.addIfNotNull(ref body, "timestamp_reception", timestamp_reception);
            RequestUtils.addIfNotNull(ref body, "training_metadata", training_metadatas);

            var resp = _client.post<response.Profile_post>("profile", body, file_path);
            return resp.data;
        }

        public response.ProfileList list(List<string> source_ids, 
            string date_start = _start_timestamp, 
            string date_end = null, 
            int page = 1, 
            string seniority = RequestConstant.Seniority.ALL,
            string filter_id = null,
            string filter_reference = null,
            string stage = null,
            int rating = 1,
            string sort_by = RequestConstant.Sortby.RECEPTION,
            string order_by = RequestConstant.Orderby.DESC)
            {
                var query = new Dictionary<string, string> {
                    {"source_ids", JsonConvert.SerializeObject(source_ids)},
                    {"date_start", date_start},
                    {"date_end", date_end},
                    {"page", page.ToString()},
                    {"rating", rating.ToString()},
                    {"seniority", seniority},
                    {"stage", stage},
                    {"sort_by", sort_by},
                    {"order_by", order_by}
                };
                RequestUtils.addIfNotNull(ref query, "filter_id", filter_id);
                RequestUtils.addIfNotNull(ref query, "filter_reference", filter_reference);

                var resp = _client.get<response.ProfileList>("profiles", query);
                return resp.data;
            }

        public response.Profile_get get(string source_id, string profile_id = null, string profile_reference = null)
        {
            // To avoid a line of about 30000 column.
            var mess = String.Format("One beetween profile_id and profile_reference has to be not null or empty. (profile_id: {0} profile_reference: {1})", profile_id, profile_reference);
            RequestUtils.assert_id_ref_notNull(profile_id, profile_reference, mess);
            
            var query = new Dictionary<string, string>
            {
                {"source_id", source_id}
            };
            RequestUtils.addIfNotNull(ref query, "profile_id", profile_id);
            RequestUtils.addIfNotNull(ref query, "profile_reference", profile_reference);

            var resp = _client.get<response.Profile_get>("profile", args: query);
            return resp.data;
        }

        public class Documents
        {
            private RestClientW _client;
            public Documents(object client)
            {
                _client = (RestClientW)client;
            }

            public response.ProfileDocument_list list(string source_id, string profile_id = null, string profile_reference = null)
            {
                // To avoid a line of about 30000 column.
                var mess = String.Format("One beetween profile_id and profile_reference has to be not null or empty. (profile_id: {0} profile_reference: {1})", profile_id, profile_reference);
                RequestUtils.assert_id_ref_notNull(profile_id, profile_reference, mess);

                var query = new Dictionary<string, string>
                {
                    {"source_id", source_id}
                };
                RequestUtils.addIfNotNull(ref query, "profile_id", profile_id);
                RequestUtils.addIfNotNull(ref query, "profile_reference", profile_reference);

                var resp = _client.get<response.ProfileDocument_list>("profile/documents", args: query);
                return resp.data;
            }
        }

        public class Parsing
        {
            private RestClientW _client;
            public Parsing(object client)
            {
                _client = (RestClientW)client;
            }

            public response.ProfileParsing list(string source_id, string profile_id = null, string profile_reference = null)
            {
                // To avoid a line of about 30000 column.
                var mess = String.Format("One beetween profile_id and profile_reference has to be not null or empty. (profile_id: {0} profile_reference: {1})", profile_id, profile_reference);
                RequestUtils.assert_id_ref_notNull(profile_id, profile_reference, mess);

                var query = new Dictionary<string, string>
                {
                    {"source_id", source_id}
                };
                RequestUtils.addIfNotNull(ref query, "profile_id", profile_id);
                RequestUtils.addIfNotNull(ref query, "profile_reference", profile_reference);

                var resp = _client.get<response.ProfileParsing>("profile/parsing", args: query);
                return resp.data;
            }
        }

        public class Scoring
        {
            private RestClientW _client;
            public Scoring(object client)
            {
                _client = (RestClientW)client;
            }

            public response.ProfileScoringList list(string source_id, string profile_id = null, string profile_reference = null)
            {
                // To avoid a line of about 30000 column.
                var mess = String.Format("One beetween profile_id and profile_reference has to be not null or empty. (profile_id: {0} profile_reference: {1})", profile_id, profile_reference);
                RequestUtils.assert_id_ref_notNull(profile_id, profile_reference, mess);

                var query = new Dictionary<string, string>
                {
                    {"source_id", source_id}
                };
                RequestUtils.addIfNotNull(ref query, "profile_id", profile_id);
                RequestUtils.addIfNotNull(ref query, "profile_reference", profile_reference);

                var resp = _client.get<response.ProfileScoringList>("profile/scoring", args: query);
                return resp.data;
            }
        }

        public class Stage
        {
            private RestClientW _client;
            public Stage(object client)
            {
                _client = (RestClientW)client;
            }

            public response.ProfileStage set(string source_id, string stage,
                string profile_id = null, string profile_reference = null, 
                string filter_id = null, string filter_reference = null)
            {
                // To avoid a line of about 30000 column.
                var mess = String.Format("One beetween profile_id and profile_reference has to be not null or empty. (profile_id: {0} profile_reference: {1})", profile_id, profile_reference);
                RequestUtils.assert_id_ref_notNull(profile_id, profile_reference, mess);
                mess = String.Format("One beetween filter_id and filter_reference has to be not null or empty. (filter_id: {0} filter_reference: {1})", filter_id, filter_reference);
                RequestUtils.assert_id_ref_notNull(filter_id, filter_reference, mess);

                var bodyParams = new Dictionary<string, object>
                {
                    {"source_id", source_id},
                    {"stage", stage}
                };
                RequestUtils.addIfNotNull(ref bodyParams, "profile_id", profile_id);
                RequestUtils.addIfNotNull(ref bodyParams, "profile_reference", profile_reference);
                RequestUtils.addIfNotNull(ref bodyParams, "filter_id", filter_id);
                RequestUtils.addIfNotNull(ref bodyParams, "filter_reference", filter_reference);

                var resp = _client.patch<response.ProfileStage>("profile/stage", args: bodyParams);
                return resp.data;
            }
        }

        public class Rating
        {
            private RestClientW _client;
            public Rating(object client)
            {
                _client = (RestClientW)client;
            }

            public response.ProfileRating set(string source_id, string rating,
                string profile_id = null, string profile_reference = null,
                string filter_id = null, string filter_reference = null)
            {
                // To avoid a line of about 30000 column.
                var mess = String.Format("One beetween profile_id and profile_reference has to be not null or empty. (profile_id: {0} profile_reference: {1})", profile_id, profile_reference);
                RequestUtils.assert_id_ref_notNull(profile_id, profile_reference, mess);
                mess = String.Format("One beetween filter_id and filter_reference has to be not null or empty. (filter_id: {0} filter_reference: {1})", filter_id, filter_reference);
                RequestUtils.assert_id_ref_notNull(filter_id, filter_reference, mess);

                var bodyParams = new Dictionary<string, object>
                {
                    {"source_id", source_id},
                    {"rating", rating}
                };
                RequestUtils.addIfNotNull(ref bodyParams, "profile_id", profile_id);
                RequestUtils.addIfNotNull(ref bodyParams, "profile_reference", profile_reference);
                RequestUtils.addIfNotNull(ref bodyParams, "filter_id", filter_id);
                RequestUtils.addIfNotNull(ref bodyParams, "filter_reference", filter_reference);

                var resp = _client.patch<response.ProfileRating>("profile/rating", args: bodyParams);
                return resp.data;
            }
        }

        public class Structured
        {
            private RestClientW _client;
            public Structured(object client)
            {
                _client = (RestClientW)client;
            }

            public response.ProfileRating check(string source_id, string rating,
                string profile_id = null, string profile_reference = null,
                string filter_id = null, string filter_reference = null)
            {
                // To avoid a line of about 30000 column.
                var mess = String.Format("One beetween profile_id and profile_reference has to be not null or empty. (profile_id: {0} profile_reference: {1})", profile_id, profile_reference);
                RequestUtils.assert_id_ref_notNull(profile_id, profile_reference, mess);
                mess = String.Format("One beetween filter_id and filter_reference has to be not null or empty. (filter_id: {0} filter_reference: {1})", filter_id, filter_reference);
                RequestUtils.assert_id_ref_notNull(filter_id, filter_reference, mess);

                var bodyParams = new Dictionary<string, object>
                {
                    {"source_id", source_id},
                    {"rating", rating}
                };
                RequestUtils.addIfNotNull(ref bodyParams, "profile_id", profile_id);
                RequestUtils.addIfNotNull(ref bodyParams, "profile_reference", profile_reference);
                RequestUtils.addIfNotNull(ref bodyParams, "filter_id", filter_id);
                RequestUtils.addIfNotNull(ref bodyParams, "filter_reference", filter_reference);

                var resp = _client.patch<response.ProfileRating>("profile/rating", args: bodyParams);
                return resp.data;
            } 
        }
    }
}