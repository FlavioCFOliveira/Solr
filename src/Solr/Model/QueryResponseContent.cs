using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Solr.Model
{
    public class QueryResponseContent<T>
    {

        [JsonProperty("numFound")]
        public int NumFound { get; set; }

        [JsonProperty("start")]
        public int Start { get; set; }

        [JsonProperty("docs")]
        public IEnumerable<T> Docs { get; set; }

    }
}