namespace Solr
{
    using Solr.Abstractions;
    using Solr.Model;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;

    public class SolrCore<T> : ISolrCore<T>
    {
        readonly Uri baseUri;
        readonly string coreName;
        readonly HttpClient client;

        public SolrCore(string baseAddress, string coreName)
        {
            this.baseUri = new Uri(baseAddress);
            this.coreName = coreName;

            this.client = new HttpClient()
            {
                BaseAddress = this.baseUri
            };

        }

        public string CoreName { get { return this.coreName; } }

        public Uri SolrUri { get { return this.baseUri; } }

        public Task<SolrResponse> Add(T obj)
        {
            throw new NotImplementedException();
        }

        public Task<SolrResponse> Delete(T obj)
        {
            throw new NotImplementedException();
        }

        public Task<QueryResponse> Query(T obj)
        {
            throw new NotImplementedException();
        }

    }

}
