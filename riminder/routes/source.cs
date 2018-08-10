using System;
using System.Collections.Generic;

namespace Riminder.route
{
    public class Source
    {
        private RestClientW _client;
        public Source(object client)
        {
            _client = (RestClientW)client;
        }

        public response.SourceList list()
        {
            var resp = _client.get<global::Riminder.response.SourceList>("sources");
            return resp.data;
        }

        public response.Source_get get(string source_id)
        {
            var query = new Dictionary<string, string> {
                {"source_id", source_id}
            };

            var resp = _client.get<response.Source_get>("source", args: query);
            return resp.data;
        } 
    }
}