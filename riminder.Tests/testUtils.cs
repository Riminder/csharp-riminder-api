using System.Collections.Generic;
using System;

using Newtonsoft.Json;

using Riminder;

namespace Riminder.UnitTests
{
    public class TestHelper
    {
        private static TestHelper instance = null;
        private static readonly object mutx = new object();

        private static List<string> _stage_list = new List<string>
        {
            {global::Riminder.RequestConstant.Stage.LATER},
            {global::Riminder.RequestConstant.Stage.NEW},
            {global::Riminder.RequestConstant.Stage.NO},
            {null},
            {null}
        };

        string _source_id;
        string _profile_id;
        string _profile_reference;
        string _filter_id;
        string _filter_reference;

        string _webhook_key;
        string _secret_key;
        string _source_name;
        string _cv_path;
        string _cv_dir;
        Riminder _client;

        TestHelper()
        {
            _webhook_key = "som reallllllllly good key";
            _secret_key = "";
            _source_name = "sdk_test";
            _cv_path = "./assets/cv_test00.jpg";
            _cv_dir = "./assets/for_batch"; 

            _profile_id = "cecd9fa83b7e2c5c8e8af17839cadde6fa807c3e";
            _profile_reference = "5279";
            _client = new Riminder(_secret_key, _webhook_key);
        }

        public static TestHelper Instance
        {
            get
            {
                lock(mutx)
                {
                    if (instance == null)
                        instance = new TestHelper();
                    return instance;
                }
            }
        }

        public Riminder Client
        {
            get
            {
                return _client;
            }
        }

        public string CvPath
        {
            get { return _cv_path; }
        }

        public string CvDir
        {
            get { return _cv_dir; }
        }

        public string Source_id
        {
            get
            {
                if (_source_id != null)
                    return _source_id;
                var sources = _client.source.list();
                if (_source_name != null)
                {
                    var source_tmp = sources.Find(x => _source_name == x.name);
                    if (source_tmp.source_id != null)
                        _source_id = source_tmp.source_id;
                    else
                        throw new global::Riminder.exp.RiminderArgumentException(string.Format("Source {0} not found", _source_name));
                }
                else
                    _source_id = sources[0].source_id;
                return _source_id;
            }
        }

        private void getFilter()
        {
            var filters = _client.filter.list();
            var filter = filters.Find(x => x.filter_id != null && x.filter_reference != null);
            if (filter.filter_id == null)
                throw new global::Riminder.exp.RiminderArgumentException(string.Format("No valid filter found."));
            
            _filter_id = filter.filter_id;
            _filter_reference = filter.filter_reference;
        }

        public string Filter_id
        {
            get
            {
                if (_filter_id != null)
                    return _filter_id;
                getFilter();
                return _filter_id;                
            }
        }

        public string Filter_reference
        {
            get
            {
                if (_filter_reference != null)
                    return _filter_reference;
                getFilter();
                return _filter_reference;    
            }
        }

        private void getProfile()
        {
            List<string> source_ids = new List<string> {this.Source_id};
            var profiles = _client.profile.list(source_ids);
            var profile = profiles.profiles.Find(x => x.profile_id != null && x.profile_reference != null);
            if (profile.profile_id == null)
                 throw new global::Riminder.exp.RiminderArgumentException(string.Format("No valid profile found."));
            _profile_id = profile.profile_id;
            _profile_reference = profile.profile_reference;
        }

        public string Profile_id
        {
            get
            {
                if (_profile_id != null)
                    return _profile_id;
                getProfile();
                return _profile_id; 
            }
        }

        public string Profile_reference
        {
            get
            {
                if (_profile_reference != null)
                    return _profile_reference;
                getProfile();
                return _profile_reference; 
            }
        }

        public static bool check_date(global::Riminder.response.Date date)
        {
            if (date.date == null && date.timezone == null)
            {
                return true;
            }
            return date.date != null && date.timezone != null;
        }

        public global::Riminder.response.TrainingMetadatas gen_metadatas()
        {
            var rnd = new Random();
            var res = new global::Riminder.response.TrainingMetadatas();
            var elem = new global::Riminder.response.TrainingMetadata();
            elem.filter_reference = this.Filter_reference;
            elem.stage = _stage_list[rnd.Next(0, _stage_list.Count)];
            elem.rating = rnd.Next(1, 5);
            if (elem.stage != null)
                elem.stage_timestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            if (elem.rating < 5)
                elem.rating_timestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            res.Add(elem);
            return res;
        }

        public static global::Riminder.response.ProfileJson gen_profileJson()
        {
            var profileJson = new global::Riminder.response.ProfileJson()
            {
                name = "Salvor Hardin",
                email = "sssalvorrr.54haaardiiin@gmail.com",
                phone = "0678524695",
                summary = "Former mayor of Terminus I resolve one of the first Sheldon Crisis.",
                location_details = new global::Riminder.response.ProfileJson.LocationDetails()
                {
                    text = "Terminus, Terminus"
                },
                experiences = new List<global::Riminder.response.ProfileJson.Experience>()
                {
                    {new global::Riminder.response.ProfileJson.Experience
                    {
                        start = "21/1/45",
                        end = "12/12/55",
                        title = "Mayor",
                        company = "Fondation",
                        location = null,
                        location_details = new global::Riminder.response.ProfileJson.LocationDetails()
                        {
                            text = "Terminus, Terminus"
                        },
                        description = "Save the Fondation."
                    }}
                },
                educations = new List<global::Riminder.response.ProfileJson.Education>()
                {
                    {new global::Riminder.response.ProfileJson.Education
                    {
                        start = "21/1/30",
                        end = "12/12/40",
                        title = "something",
                        school = "Fondation hard school",
                        location = null,
                        location_details = new global::Riminder.response.ProfileJson.LocationDetails()
                        {
                            text = "Terminus, Terminus"
                        },
                        description = "..."
                    }}
                },
                skills = new List<string>()
                {
                    "diplomacy", "Politics", "Future Science", "Flight"
                },
                languages = new List<string>()
                {
                    "English"
                },
                interests = new List<string>()
                {
                    "cigar", "Fondation"
                },
                urls = new global::Riminder.response.ProfileJson.Urls()
                {
                    from_resume = new List<string>(),
                    linkedin = null,
                }
                
            };
            return profileJson;
        }

        public Dictionary<string, string> gen_encodedHeaders()
        {
            var payload = new global::Riminder.response.WebhookProfileParse()
            {
                type = global::Riminder.route.Webhook.EventNames.PROFILE_PARSE_SUCCESS,
                message = "Yey it's parsed ! :) (not actually a true message)",
                profile = new global::Riminder.response.WebhookProfile()
                {
                    profile_id = "some complicated id",
                    profile_reference = "some simple reference"
                }
            };
            var json_payload = JsonConvert.SerializeObject(payload);
            var byte_json_payload = System.Text.Encoding.UTF8.GetBytes(json_payload);
            var byte_key = System.Text.Encoding.UTF8.GetBytes(_webhook_key);
            
            var hasher = new System.Security.Cryptography.HMACSHA256(byte_key);

            var encoded_sign = hasher.ComputeHash(byte_json_payload);

            var b64_sign = System.Convert.ToBase64String(encoded_sign);
            var b64_payload = System.Convert.ToBase64String(byte_json_payload);
            var res = String.Concat(b64_sign, ".", b64_payload);

            return new Dictionary<string, string>(){{"HTTP-RIMINDER-SIGNATURE", res}};
        }    
    

    }
}
