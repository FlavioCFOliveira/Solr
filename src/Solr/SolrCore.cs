namespace Solr
{
    using Newtonsoft.Json;
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

        string transactionID;

        public SolrCore(string baseAddress, string coreName)
        {
            this.baseUri = new Uri(baseAddress);
            this.coreName = coreName;
            this.transactionID = string.Empty;

            this.client = new HttpClient()
            {
                BaseAddress = this.baseUri
            };

        }

        public string CoreName { get { return this.coreName; } }

        public Uri SolrUri { get { return this.baseUri; } }

        public async Task<SolrResponse> Add(T obj)
        {
            throw new NotImplementedException();
        }


        public async Task<SolrResponse> Delete(T obj)
        {
            throw new NotImplementedException();
        }

        public async Task<QueryResponse<T>> Query(string query = @"*:*")
        {
            if (string.IsNullOrEmpty(query)) throw new ArgumentNullException(nameof(query));

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, $"{baseUri.AbsoluteUri}/{this.coreName}/select?{query}");
            request.Headers.Add("Accept", @"application/json");

            var result = await this.client.SendAsync(request);
            if (result.IsSuccessStatusCode)
            {
                var cnt = await result.Content.ReadAsStringAsync();

                var output = JsonConvert.DeserializeObject<QueryResponse<T>>(cnt);

                return output;
            }

            return null;
        }

        public async Task Commit()
        {
            throw new NotImplementedException();


            this.transactionID = string.Empty;
        }
        public async Task Rollback()
        {
            throw new NotImplementedException();

            this.transactionID = string.Empty;
        }

    }

}
