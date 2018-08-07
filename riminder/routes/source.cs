using System;
using System.Collections.Generic;

namespace riminder.route
{
    class Source
    {
        private RestClientW _client;
        public Source(ref RestClientW client)
        {
            _client = client;
        }

        public response.SourceList list()
        {
            var resp = _client.get<riminder.response.SourceList>("sources");
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