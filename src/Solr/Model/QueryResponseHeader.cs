using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Solr.Model
{
    public class QueryResponseHeader
    {

        [JsonProperty("status")]
        public int Status { get; set; }

        [JsonProperty("QTime")]
        public int QTime { get; set; }

        [JsonProperty("parameters")]
        public Dictionary<string, string> parameters { get; set; }

    }
}