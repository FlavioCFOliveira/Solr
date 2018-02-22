namespace Solr.Abstractions
{
    using Solr.Model;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public interface ISolrCore
    {

        string CoreName { get; }

        string BaseAddress { get; }

        //Task<SolrResponse> Add(T obj);
        //Task<SolrResponse> AddRange(IEnumerable<T> lst);

        ///// <summary>
        ///// Removes All the documents from the index
        ///// </summary>
        ///// <returns></returns>
        //Task<SolrResponse> Clean();

        //Task<SolrResponse> Delete(T obj);
        //Task<SolrResponse> DeleteByQuery(string query);

        //Task<QueryResponse<T>> Query(string query, int start = 0, int rows = 10, string[] sort = null);

        //Task<SolrResponse> Commit();

        //Task<SolrResponse> Optimize();

    }
}