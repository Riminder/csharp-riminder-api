using Xunit;
using System;
using System.Collections.Generic;


namespace Riminder.UnitTests.route
{
    public class Filter_Test
    {
        public class FilterListTest
        {
            public TestHelper thelper;
            public Riminder client;

            public FilterListTest()
            {
                thelper = TestHelper.Instance;
                client = thelper.Client;
            }

            private void check_filter_elem(global::Riminder.response.FilterListElem elem)
            {
                Assert.True(elem.filter_id != null);
                Assert.True(elem.filter_reference != null);
                Assert.True(TestHelper.check_date(elem.date_creation));
            }

            [Fact]
            public void TestOK()
            {
                var resp = client.filter.list();
            }
        }

        public class FilterGetTest
        {
            private TestHelper thelper;
            private Riminder client;

            public FilterGetTest()
            {
                thelper = TestHelper.Instance;
                client = thelper.Client;
            }

            [Fact]
            public void TestOK_id()
            {
                client.filter.get(filter_id:thelper.Filter_id);
            }

            [Fact]
            public void TestKO_id()
            {

                Assert.Throws<global::Riminder.exp.RiminderResponseException>(
                    () => client.filter.get(filter_id: "hahahahahahah"));
            }

            [Fact]
            public void TestOK_reference()
            {
                client.filter.get(filter_reference:thelper.Filter_reference);
            }

            [Fact]
            public void TestKO_reference()
            {

                Assert.Throws<global::Riminder.exp.RiminderResponseException>(
                    () => client.filter.get(filter_reference: "hope it will never be a valid refence :/"));
            }
        }
    }
}