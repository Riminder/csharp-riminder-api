using Xunit;
using System;
using System.Collections.Generic;


namespace Riminder.UnitTests.route
{
    public class Source_Test
    {
        public class SourceListTest
        {
            public TestHelper thelper;
            public Riminder client;

            public SourceListTest()
            {
                thelper = TestHelper.Instance;
                client = thelper.Client;
            }

            private void check_source_elem(global::Riminder.response.SourceListElem elem)
            {
                Assert.True(elem.source_id != null);
                Assert.True(TestHelper.check_date(elem.date_creation));
            }

            [Fact]
            public void TestOK()
            {
                var resp = client.source.list();
            }
        }

        public class SourceGetTest
        {
            private TestHelper thelper;
            private Riminder client;

            public SourceGetTest()
            {
                thelper = TestHelper.Instance;
                client = thelper.Client;
            }

            [Fact]
            public void TestOK_id()
            {
                client.source.get(thelper.Source_id);
            }
        }
    }
}