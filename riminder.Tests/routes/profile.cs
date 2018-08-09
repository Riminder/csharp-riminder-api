using Xunit;
using System;
using System.IO;
using System.Collections.Generic; 
using Newtonsoft.Json;

namespace riminder.UnitTests.route
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
            seniority: riminder.RequestConstant.Seniority.JUNIOR,
            filter_id: thelper.Filter_id,
            stage: RequestConstant.Stage.NEW,
            sort_by: RequestConstant.Sortby.RANKING,
            order_by: RequestConstant.Orderby.ASC);
        }

        [Fact]
        public void TestOK_maxArg_ref()
        {
            var sids = new List<string>() { thelper.Source_id };
            client.profile.list(source_ids: sids,
            date_start: 1060445571,
            date_end: 1533831171,
            page: 1,
            seniority: riminder.RequestConstant.Seniority.JUNIOR,
            filter_id: thelper.Filter_reference,
            stage: RequestConstant.Stage.NEW,
            sort_by: RequestConstant.Sortby.RANKING,
            order_by: RequestConstant.Orderby.ASC);
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
            Assert.Throws<riminder.exp.RiminderResponseException>(
                () => client.profile.get("zap", thelper.Profile_id)
            );
        }

        [Fact]
        public void TestKO_badid()
        {
            Assert.Throws<riminder.exp.RiminderResponseException>(
                () => client.profile.get(thelper.Source_id, "lol")
            );
        }

        [Fact]
        public void TestKO_badref()
        {
            Assert.Throws<riminder.exp.RiminderResponseException>(
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
        public void TestOK()
        {
            client.profile.documents.list(thelper.Source_id, thelper.Profile_id);
        }

        [Fact]
        public void TestKO_badsource()
        {
            Assert.Throws<riminder.exp.RiminderResponseException>(
                () => client.profile.documents.list("zap", thelper.Profile_id)
            );
        }

        [Fact]
        public void TestKO_badid()
        {
            Assert.Throws<riminder.exp.RiminderResponseException>(
                () => client.profile.documents.list(thelper.Source_id, "lol")
            );
        }

        [Fact]
        public void TestKO_badref()
        {
            Assert.Throws<riminder.exp.RiminderResponseException>(
                () => client.profile.documents.list(thelper.Source_id, profile_reference: "lol")
            );
        }

        [Fact]
        public void TestOK_ref()
        {
            client.profile.documents.list(thelper.Source_id, profile_reference: thelper.Profile_reference);
        }
    }

    public class Profile_ParsingList
    {
        public TestHelper thelper;
        public Riminder client;

        public Profile_ParsingList()
        {
            thelper = TestHelper.Instance;
            client = thelper.Client;
        }

        [Fact]
        public void TestOK()
        {
            client.profile.parsing.list(thelper.Source_id, thelper.Profile_id);
        }

        [Fact]
        public void TestKO_badsource()
        {
            Assert.Throws<riminder.exp.RiminderResponseException>(
                () => client.profile.parsing.list("zap", thelper.Profile_id)
            );
        }

        [Fact]
        public void TestKO_badid()
        {
            Assert.Throws<riminder.exp.RiminderResponseException>(
                () => client.profile.parsing.list(thelper.Source_id, "lol")
            );
        }

        [Fact]
        public void TestKO_badref()
        {
            Assert.Throws<riminder.exp.RiminderResponseException>(
                () => client.profile.parsing.list(thelper.Source_id, profile_reference: "lol")
            );
        }

        [Fact]
        public void TestOK_ref()
        {
            client.profile.parsing.list(thelper.Source_id, profile_reference: thelper.Profile_reference);
        }
    }
}