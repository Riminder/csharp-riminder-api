using Xunit;
using System;
using System.IO;
using System.Collections.Generic; 
using Newtonsoft.Json;

namespace Riminder.UnitTests.route
{
    public class Profile_Add
    {
        public TestHelper thelper;
        public Riminder client;

        public Profile_Add()
        {
            thelper = TestHelper.Instance;
            client = thelper.Client;
        }

        [Fact]
        public void TestOK_minArg()
        {
            var resp = client.profile.add(thelper.Source_id, thelper.CvPath);
            Assert.Equal(resp.file_name, Path.GetFileName(thelper.CvPath));
        }

        [Fact]
        public void TestOK_maxArg()
        {
            Random rnd = new Random();
            var resp = client.profile.add(thelper.Source_id, thelper.CvPath,
                rnd.Next(0, 99999).ToString(),
                1533831171, 
                thelper.gen_metadatas());
            Assert.Equal(resp.file_name, Path.GetFileName(thelper.CvPath));
        }
    }

    public class Profile_List
    {
        public TestHelper thelper;
        public Riminder client;

        public Profile_List()
        {
            thelper = TestHelper.Instance;
            client = thelper.Client;
        }

        [Fact]
        public void TestOK_minArg()
        {
            var sids = new List<string>() {thelper.Source_id};
            client.profile.list(source_ids:sids);
        }

        [Fact]
        public void TestOK_maxArg()
        {
            var sids = new List<string>() { thelper.Source_id };
            client.profile.list(source_ids: sids,
            date_start: 1060445571,
            date_end: 1533831171,
            page: 1,
            seniority: global::Riminder.RequestConstant.Seniority.JUNIOR,
            filter_id: thelper.Filter_id,
            stage: (string)global::Riminder.RequestConstant.Stage.NEW,
            sort_by: (string)global::Riminder.RequestConstant.Sortby.RANKING,
            order_by: (string)global::Riminder.RequestConstant.Orderby.ASC);
        }

        [Fact]
        public void TestOK_maxArg_ref()
        {
            var sids = new List<string>() { thelper.Source_id };
            client.profile.list(source_ids: sids,
            date_start: 1060445571,
            date_end: 1533831171,
            page: 1,
            seniority: global::Riminder.RequestConstant.Seniority.JUNIOR,
            filter_reference: thelper.Filter_reference,
            stage: (string)global::Riminder.RequestConstant.Stage.NEW,
            sort_by: (string)global::Riminder.RequestConstant.Sortby.RANKING,
            order_by: (string)global::Riminder.RequestConstant.Orderby.ASC);
        }
    }

    public class Profile_Get
    {
        public TestHelper thelper;
        public Riminder client;

        public Profile_Get()
        {
            thelper = TestHelper.Instance;
            client = thelper.Client;
        }

        [Fact]
        public void TestOK()
        {
            client.profile.get(thelper.Source_id, thelper.Profile_id);
        }

        [Fact]
        public void TestKO_badsource()
        {
            Assert.Throws<global::Riminder.exp.RiminderResponseException>(
                () => client.profile.get("zap", thelper.Profile_id)
            );
        }

        [Fact]
        public void TestKO_noIDref()
        {
            Assert.Throws<global::Riminder.exp.RiminderArgumentException>(
                () => client.profile.get(thelper.Source_id)
            );
        }

        [Fact]
        public void TestKO_badid()
        {
            Assert.Throws<global::Riminder.exp.RiminderResponseException>(
                () => client.profile.get(thelper.Source_id, "lol")
            );
        }

        [Fact]
        public void TestKO_badref()
        {
            Assert.Throws<global::Riminder.exp.RiminderResponseException>(
                () => client.profile.get(thelper.Source_id, profile_reference:"lol")
            );
        }

        [Fact]
        public void TestOK_ref()
        {
            client.profile.get(thelper.Source_id, profile_reference: thelper.Profile_reference);
        }
    }

    public class Profile_DocumentList
    {
        public TestHelper thelper;
        public Riminder client;

        public Profile_DocumentList()
        {
            thelper = TestHelper.Instance;
            client = thelper.Client;
        }

        [Fact]
        public void TestKO_noIDref()
        {
            Assert.Throws<global::Riminder.exp.RiminderArgumentException>(
                () => client.profile.documents.list(thelper.Source_id)
            );
        }

        [Fact]
        public void TestOK()
        {
            client.profile.documents.list(thelper.Source_id, thelper.Profile_id);
        }

        [Fact]
        public void TestKO_badsource()
        {
            Assert.Throws<global::Riminder.exp.RiminderResponseException>(
                () => client.profile.documents.list("zap", thelper.Profile_id)
            );
        }

        [Fact]
        public void TestKO_badid()
        {
            Assert.Throws<global::Riminder.exp.RiminderResponseException>(
                () => client.profile.documents.list(thelper.Source_id, "lol")
            );
        }

        [Fact]
        public void TestKO_badref()
        {
            Assert.Throws<global::Riminder.exp.RiminderResponseException>(
                () => client.profile.documents.list(thelper.Source_id, profile_reference: "lol")
            );
        }

        [Fact]
        public void TestOK_ref()
        {
            client.profile.documents.list(thelper.Source_id, profile_reference: thelper.Profile_reference);
        }
    }

    public class Profile_ParsingGet
    {
        public TestHelper thelper;
        public Riminder client;

        public Profile_ParsingGet()
        {
            thelper = TestHelper.Instance;
            client = thelper.Client;
        }

        [Fact]
        public void TestOK()
        {
            client.profile.parsing.get(thelper.Source_id, thelper.Profile_id);
        }

        [Fact]
        public void TestKO_noIDref()
        {
            Assert.Throws<global::Riminder.exp.RiminderArgumentException>(
                () => client.profile.parsing.get(thelper.Source_id)
            );
        }

        [Fact]
        public void TestKO_badsource()
        {
            Assert.Throws<global::Riminder.exp.RiminderResponseException>(
                () => client.profile.parsing.get("zap", thelper.Profile_id)
            );
        }

        [Fact]
        public void TestKO_badid()
        {
            Assert.Throws<global::Riminder.exp.RiminderResponseException>(
                () => client.profile.parsing.get(thelper.Source_id, "lol")
            );
        }

        [Fact]
        public void TestKO_badref()
        {
            Assert.Throws<global::Riminder.exp.RiminderResponseException>(
                () => client.profile.parsing.get(thelper.Source_id, profile_reference: "lol")
            );
        }

        [Fact]
        public void TestOK_ref()
        {
            client.profile.parsing.get(thelper.Source_id, profile_reference: thelper.Profile_reference);
        }
    }

    public class Profile_ScoringList
    {
        public TestHelper thelper;
        public Riminder client;

        public Profile_ScoringList()
        {
            thelper = TestHelper.Instance;
            client = thelper.Client;
        }

        [Fact]
        public void TestOK()
        {
            client.profile.scoring.list(thelper.Source_id, thelper.Profile_id);
        }

        [Fact]
        public void TestKO_noIDref()
        {
            Assert.Throws<global::Riminder.exp.RiminderArgumentException>(
                () => client.profile.scoring.list(thelper.Source_id)
            );
        }

        [Fact]
        public void TestKO_badsource()
        {
            Assert.Throws<global::Riminder.exp.RiminderResponseException>(
                () => client.profile.scoring.list("zdsdsqds i'm a bad source sqfeap", thelper.Profile_id)
            );
        }

        [Fact]
        public void TestKO_badid()
        {
            Assert.Throws<global::Riminder.exp.RiminderResponseException>(
                () => client.profile.scoring.list(thelper.Source_id, "Nope")
            );
        }

        [Fact]
        public void TestKO_badref()
        {
            Assert.Throws<global::Riminder.exp.RiminderResponseException>(
                () => client.profile.scoring.list(thelper.Source_id, profile_reference: "I don't want that.")
            );
        }

        [Fact]
        public void TestOK_ref()
        {
            client.profile.scoring.list(thelper.Source_id, profile_reference: thelper.Profile_reference);
        }
    }

    public class Profile_StageSet
    {
        public TestHelper thelper;
        public Riminder client;

        public Profile_StageSet()
        {
            thelper = TestHelper.Instance;
            client = thelper.Client;
        }

        [Fact]
        public void TestOK()
        {
            client.profile.stage.set(thelper.Source_id,
                stage:RequestConstant.Stage.LATER,
                profile_id: thelper.Profile_id,
                filter_id: thelper.Filter_id);
        }

        [Fact]
        public void TestKO_nofIDref()
        {
            Assert.Throws<global::Riminder.exp.RiminderArgumentException>(
(Func<object>)(() => client.profile.stage.set(thelper.Source_id,
                 stage: (string)global::Riminder.RequestConstant.Stage.LATER,
                 profile_id: thelper.Profile_id))
            );
        }

        [Fact]
        public void TestKO_nopIDref()
        {
            Assert.Throws<global::Riminder.exp.RiminderArgumentException>(
(Func<object>)(() => client.profile.stage.set(thelper.Source_id,
                 stage: (string)global::Riminder.RequestConstant.Stage.LATER,
                 filter_id: thelper.Filter_id))
            );
        }

        [Fact]
        public void TestKO_badsource()
        {
            Assert.Throws<global::Riminder.exp.RiminderResponseException>(
(Func<object>)(() => client.profile.stage.set("not a good sdzdzddzdzddzdd source.",
                stage: (string)global::Riminder.RequestConstant.Stage.LATER,
                profile_id: thelper.Profile_id,
                filter_id: thelper.Filter_id))
            );
        }

        [Fact]
        public void TestKO_badpid()
        {
            Assert.Throws<global::Riminder.exp.RiminderResponseException>(
(Func<object>)(() => client.profile.stage.set(thelper.Source_id,
               stage: (string)global::Riminder.RequestConstant.Stage.LATER,
               profile_id: "Not a good profile id.dddsdzdzddzd",
               filter_id: thelper.Filter_id))
           );
        }

        [Fact]
        public void TestKO_badfid()
        {
            Assert.Throws<global::Riminder.exp.RiminderResponseException>(
(Func<object>)(() => client.profile.stage.set(thelper.Source_id,
               stage: (string)global::Riminder.RequestConstant.Stage.LATER,
               profile_id: thelper.Profile_id,
               filter_id: "Not a good filter id.dzdzdzdzdzdd"))
           );
        }

        [Fact]
        public void TestKO_badref()
        {
            Assert.Throws<global::Riminder.exp.RiminderResponseException>(
(Func<object>)(() => client.profile.stage.set(thelper.Source_id,
                stage: (string)global::Riminder.RequestConstant.Stage.LATER,
                profile_reference: "I'm not a good profile reddzdzddzdf",
                filter_reference: thelper.Filter_reference))
            );
        }

        [Fact]
        public void TestKO_badfref()
        {
            Assert.Throws<global::Riminder.exp.RiminderResponseException>(
(Func<object>)(() => client.profile.stage.set(thelper.Source_id,
                stage: (string)global::Riminder.RequestConstant.Stage.LATER,
                profile_reference: thelper.Profile_reference,
                filter_reference: "I'm not a good fildzdzdzddzdter ref"))
            );
        }


        [Fact]
        public void TestOK_ref()
        {
            client.profile.stage.set(thelper.Source_id,
                stage: RequestConstant.Stage.LATER,
                profile_reference: thelper.Profile_reference,
                filter_reference: thelper.Filter_reference);
        }
    }

    public class Profile_RatingSet
    {
        public TestHelper thelper;
        public Riminder client;

        public Profile_RatingSet()
        {
            thelper = TestHelper.Instance;
            client = thelper.Client;
        }

        [Fact]
        public void TestOK()
        {
            client.profile.rating.set(thelper.Source_id,
                rating: 1,
                profile_id: thelper.Profile_id,
                filter_id: thelper.Filter_id);
        }

        [Fact]
        public void TestKO_nofIDref()
        {
            Assert.Throws<global::Riminder.exp.RiminderArgumentException>(
                () => client.profile.rating.set(thelper.Source_id,
                 rating: 1,
                 profile_id: thelper.Profile_id)
            );
        }

        [Fact]
        public void TestKO_nopIDref()
        {
            Assert.Throws<global::Riminder.exp.RiminderArgumentException>(
                () => client.profile.rating.set(thelper.Source_id,
                 rating: 1,
                 filter_id: thelper.Filter_id)
            );
        }

        [Fact]
        public void TestKO_badsource()
        {
            Assert.Throws<global::Riminder.exp.RiminderResponseException>(
                () => client.profile.rating.set("not a good sdzdzddzdzddzdd source.",
                rating: 1,
                profile_id: thelper.Profile_id,
                filter_id: thelper.Filter_id)
            );
        }

        [Fact]
        public void TestKO_badpid()
        {
            Assert.Throws<global::Riminder.exp.RiminderResponseException>(
               () => client.profile.rating.set(thelper.Source_id,
               rating: 1,
               profile_id: "Not a good profile id.dddsdzdzddzd",
               filter_id: thelper.Filter_id)
           );
        }

        [Fact]
        public void TestKO_badfid()
        {
            Assert.Throws<global::Riminder.exp.RiminderResponseException>(
               () => client.profile.rating.set(thelper.Source_id,
               rating: 1,
               profile_id: thelper.Profile_id,
               filter_id: "Not a good filter id.dzdzdzdzdzdd")
           );
        }

        [Fact]
        public void TestKO_badref()
        {
            Assert.Throws<global::Riminder.exp.RiminderResponseException>(
                () => client.profile.rating.set(thelper.Source_id,
                rating: 1,
                profile_reference: "I'm not a good profile reddzdzddzdf",
                filter_reference: thelper.Filter_reference)
            );
        }

        [Fact]
        public void TestKO_badfref()
        {
            Assert.Throws<global::Riminder.exp.RiminderResponseException>(
                () => client.profile.rating.set(thelper.Source_id,
                rating: 1,
                profile_reference: thelper.Profile_reference,
                filter_reference: "I'm not a good fildzdzdzddzdter ref")
            );
        }


        [Fact]
        public void TestOK_ref()
        {
            client.profile.rating.set(thelper.Source_id,
                rating: 1,
                profile_reference: thelper.Profile_reference,
                filter_reference: thelper.Filter_reference);
        }
    }

    public class TestProfileJsonCheck
    {
        public TestHelper thelper;
        public Riminder client;

        public TestProfileJsonCheck()
        {
            thelper = TestHelper.Instance;
            client = thelper.Client;
        }

        [Fact]
        public void TestOk_minargs()
        {
            client.profile.json.check(TestHelper.gen_profileJson());
        }

        [Fact]
        public void TestOk_maxargs()
        {
            client.profile.json.check(TestHelper.gen_profileJson(), thelper.gen_metadatas());
        }
    }

    public class TestProfileJsonAdd
    {
        public TestHelper thelper;
        public Riminder client;

        public TestProfileJsonAdd()
        {
            thelper = TestHelper.Instance;
            client = thelper.Client;
        }

        [Fact]
        public void TestOk_minargs()
        {
            client.profile.json.add(thelper.Source_id, TestHelper.gen_profileJson());
        }

        [Fact]
        public void TestOk_maxargs()
        {
            var rnd = new Random();
            client.profile.json.add(thelper.Source_id, 
                TestHelper.gen_profileJson(),
                training_metadata: thelper.gen_metadatas(),
                profile_reference: rnd.Next(0, 99999).ToString(),
                timestamp_reception: 1533895264);
        }
    }
}