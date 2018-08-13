using System;
using System.Collections.Generic;

namespace Riminder.route
{
    public class Filter
    {
        private RestClientW _client;

        // To avoid incoherente type availabilitie
        public Filter(object client)
        {
            _client = (RestClientW)client;
        }

        public response.FilterList list()
        {
            var resp = _client.get<global::Riminder.response.FilterList>("filters");
            return resp.data;
        }

        public response.Filter_get get(string filter_id=null, string filter_reference=null)
        { 
            // To avoid a line of about 30000 column.
            var mess = String.Format("One beetween filter_id and filter_reference has to be not null or empty. (filter_id: {0} filter_reference: {1})", filter_id, filter_reference);
            global::Riminder.RequestUtils.assert_id_ref_notNull(filter_id, filter_reference, mess);
            
            var query = new Dictionary<string, string>();
            global::Riminder.RequestUtils.addIfNotNull(ref query, "filter_id", filter_id);
            global::Riminder.RequestUtils.addIfNotNull(ref query, "filter_reference", filter_reference);
            
            var resp = _client.get<global::Riminder.response.Filter_get>("filter", query);
            return resp.data;
        }
    }
}