using Xunit;
using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Riminder.UnitTests.route
{
    public class Webhook_Check
    {
        public TestHelper thelper;
        public Riminder client;

        public Webhook_Check()
        {
            thelper = TestHelper.Instance;
            client = thelper.Client;
        }

        [Fact]
        public void TestCheck()
        {
            client.webhooks.check();
        }

        [Fact]
        public void TestWebhookCallback_headerfull()
        {
            //Given
            var encoded_header = thelper.gen_encodedHeaders();
            string testname = "";
            client.webhooks.setHandler(global::Riminder.route.Webhook.EventNames.PROFILE_PARSE_SUCCESS,
               delegate(string evtname, global::Riminder.response.IWebhookMessage mess) {testname = evtname;});
            
            //When
            client.webhooks.handle(encoded_header);

            //Then
            Assert.Equal(testname, global::Riminder.route.Webhook.EventNames.PROFILE_PARSE_SUCCESS);
        }

        [Fact]
        public void TestWebhookCallback_onlymes()
        {
            //Given
            var encoded_header = thelper.gen_encodedHeaders();
            string testname = "";
            client.webhooks.setHandler(global::Riminder.route.Webhook.EventNames.PROFILE_PARSE_SUCCESS,
               delegate (string evtname, global::Riminder.response.IWebhookMessage mess) { testname = evtname; });

            //When
            client.webhooks.handle(signatureHeader:encoded_header["HTTP-RIMINDER-SIGNATURE"]);

            //Then
            Assert.Equal(testname, global::Riminder.route.Webhook.EventNames.PROFILE_PARSE_SUCCESS);
        }

        [Fact]
        public void TestWebhookCallback_noHandler()
        {
            //Given
            var encoded_header = thelper.gen_encodedHeaders();
            string testname = "";
            client.webhooks.setHandler(global::Riminder.route.Webhook.EventNames.PROFILE_PARSE_SUCCESS,
               delegate (string evtname, global::Riminder.response.IWebhookMessage mess) { testname = evtname; });
            client.webhooks.removeHandler(global::Riminder.route.Webhook.EventNames.PROFILE_PARSE_SUCCESS);

            //When
            client.webhooks.handle(signatureHeader: encoded_header["HTTP-RIMINDER-SIGNATURE"]);

            //Then
            Assert.NotEqual(testname, global::Riminder.route.Webhook.EventNames.PROFILE_PARSE_SUCCESS);
        }

        [Fact]
        public void TestWebhookCallback_noheader()
        {
            //Given
            var encoded_header = thelper.gen_encodedHeaders();
            string testname = "";
            client.webhooks.setHandler(global::Riminder.route.Webhook.EventNames.PROFILE_PARSE_SUCCESS,
               delegate (string evtname, global::Riminder.response.IWebhookMessage mess) { testname = evtname; });

            //When
            Assert.Throws<global::Riminder.exp.RiminderArgumentException>(() => client.webhooks.handle());
        }
    }
}