namespace SolrTests.code
{
    using Solr.Abstractions;
    using SolrTests.Model;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface ISolrCoreEntity : ISolrCore<SolrCoreEntity>
    {
    }
}