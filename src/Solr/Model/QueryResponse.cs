namespace Solr.Model
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class QueryResponse<T>
    {

        [JsonProperty("responseHeader")]
        public QueryResponseHeader Header { get; set; }


    }

}