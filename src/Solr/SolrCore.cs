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

        public async Task<QueryResponse<T>> Query(string query = @"*:*", int start = 0, int rows = 10, string[] sort = null)
        {
            if (string.IsNullOrEmpty(query)) throw new ArgumentNullException(nameof(query));

            string sortOrder = string.Empty;
            if (sort != null && sort.Length > 0) sortOrder = "&sort=" + string.Join(',', sort);

            string url = $"{baseUri.AbsoluteUri}/{this.coreName}/select?indent=off&q={query}&rows={rows.ToString()}&start={start.ToString()}{sortOrder}&wt=json";

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);
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
