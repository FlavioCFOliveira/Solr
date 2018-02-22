namespace Solr.Model
{
    using Newtonsoft.Json;

    public class SolrResponse
    {
        [JsonProperty("responseHeader")]
        public QueryResponseHeader Header { get; set; }

    }
}