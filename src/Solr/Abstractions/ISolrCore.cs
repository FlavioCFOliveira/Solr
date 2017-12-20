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

        Task<QueryResponse> Query(T obj);
        
    }
}