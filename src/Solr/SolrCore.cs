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

    public abstract class SolrCore<T> : ISolrCore
    {
        protected readonly string baseAddress;
        protected readonly string coreName;
        protected readonly HttpClient client;

        public SolrCore(string baseAddress, string coreName)
        {
            if (string.IsNullOrEmpty(baseAddress)) throw new ArgumentNullException(nameof(baseAddress));
            if (string.IsNullOrEmpty(coreName)) throw new ArgumentNullException(nameof(coreName));

            this.baseAddress = baseAddress;
            this.coreName = coreName;

            this.client = new HttpClient()
            {
                BaseAddress = new Uri(this.baseAddress)
            };

        }

        public string CoreName { get { return this.coreName; } }

        public string BaseAddress { get { return this.baseAddress; } }

        protected async Task<SolrResponse> Clean()
        {
            return await this.DeleteByQuery("*:*");
        }

        private const string STR_COMMIT_PAYLOAD = "{\"commit\": {}}";
        protected async Task<SolrResponse> Commit()
        {
            SolrResponse result = new SolrResponse();

            string url = $"{this.baseAddress}/solr/{this.coreName}/update";

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Headers.Add("Accept", @"application/json");
            request.Content = new StringContent(STR_COMMIT_PAYLOAD, Encoding.UTF8, "application/json");

            var response = await this.client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var cnt = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<SolrResponse>(cnt);
            }

            return null;
        }

        protected async Task<SolrResponse> Update(string payload)
        {
            SolrResponse result = new SolrResponse();

            string url = $"{this.baseAddress}/solr/{this.coreName}/update/json";

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Headers.Add("Accept", @"application/json");
            request.Content = new StringContent(payload, Encoding.UTF8, "application/json");

            var response = await this.client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var cnt = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<SolrResponse>(cnt);
            }

            return null;
        }

        private const string STR_DELETE_STATEMENT = "{\"delete\": {\"query\":\"[query]\"}}";
        protected async Task<SolrResponse> DeleteByQuery(string query)
        {
            if (string.IsNullOrEmpty(query)) throw new ArgumentNullException(nameof(query));

            string requestUrl = $"{this.baseAddress}/solr/{this.coreName}/update/json";
            string requestContent = STR_DELETE_STATEMENT.Replace("[query]", query);

            HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Post, requestUrl);
            req.Headers.Add("Accept", "application/json");
            req.Content = new StringContent(requestContent, Encoding.UTF8, "application/json");

            var result = await this.client.SendAsync(req);
            if (result.IsSuccessStatusCode)
            {
                var cnt = await result.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<SolrResponse>(cnt);
            }

            return null;
        }

        protected async Task<SolrResponse> Optimize(bool waitSearcher = true, bool expungeDeletes = false, int maxSegments = 1)
        {
            SolrResponse result = new SolrResponse();

            string url = $"{this.baseAddress}/solr/{this.coreName}/update/json";

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Headers.Add("Accept", @"application/json");
            request.Content = new StringContent("{\"optimize\": {}}", Encoding.UTF8, "application/json");

            var response = await this.client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var cnt = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<SolrResponse>(cnt);
            }

            return null;
        }

        protected async Task<QueryResponse<T>> Query(string query = @"*:*", int start = 0, int rows = 10, string[] sort = null)
        {
            if (string.IsNullOrEmpty(query)) throw new ArgumentNullException(nameof(query));

            string sortOrder = string.Empty;
            if (sort != null && sort.Length > 0) sortOrder = "&sort=" + string.Join(',', sort);

            string url = $"{this.baseAddress}/solr/{this.coreName}/select?indent=off&q={query}&rows={rows.ToString()}&start={start.ToString()}{sortOrder}&wt=json";

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

    }

}
