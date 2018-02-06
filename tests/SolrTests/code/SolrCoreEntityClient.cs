namespace SolrTests.code
{
    using Solr;
    using SolrTests.Model;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public class SolrCoreEntityClient : SolrCore<SolrCoreEntity>, ISolrCoreEntity
    {
        public SolrCoreEntityClient(string baseAddress, string coreName) : base(baseAddress, coreName)
        {
        }

        public override void InitializeIndexFields()
        {

        }
    }
}