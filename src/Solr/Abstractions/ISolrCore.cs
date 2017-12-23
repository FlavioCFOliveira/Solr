namespace Solr.Abstractions
{
    using Solr.Model;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public interface ISolrCore<T>
    {

        string CoreName { get; }

        Uri SolrUri { get; }

        Task<SolrResponse> Add(T obj);

        Task<SolrResponse> Delete(T obj);

        Task<QueryResponse<T>> Query(string query, int start = 0, int rows = 10);

        Task Commit();

        Task Rollback();

    }
}