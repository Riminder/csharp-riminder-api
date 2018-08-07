using System;
using System.Collections.Generic;

namespace riminder.route
{
    class Filter
    {
        private RestClientW _client;

        public Filter(ref RestClientW client)
        {
            _client = client;
        }

        public response.FilterList list()
        {
            var resp = _client.get<riminder.response.FilterList>("filters");
            return resp.data;
        }

        public response.Filter_get get(string filter_id=null, string filter_reference=null)
        { 
            // To avoid a line of about 30000 column.
            var mess = String.Format("One beetween filter_id and filter_reference has to be not null or empty. (filter_id: {0} filter_reference: {1})", filter_id, filter_reference);
            riminder.RequestUtils.assert_id_ref_notNull(filter_id, filter_reference, mess);
            
            var query = new Dictionary<string, string>();
            riminder.RequestUtils.addIfNotNull(ref query, "filter_id", filter_id);
            riminder.RequestUtils.addIfNotNull(ref query, "filter_reference", filter_reference);
            
            var resp = _client.get<riminder.response.Filter_get>("filter");
            return resp.data;
        }
    }
}