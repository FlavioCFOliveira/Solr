using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solr.Abstractions;
using SolrTests.Model;

namespace SolrTests
{
    [TestClass]
    public class SolrQueryTests
    {
        ISolrCore<SolrCoreEntity> core;

        public SolrQueryTests()
        {
            this.core = new Solr.SolrCore<SolrCoreEntity>(@"http://localhost:8983/solr", "Test");
        }

        [TestMethod]
        public void SolrQueryTests_all_Success()
        {

            var result = this.core.Query("*:*").Result;

        }
    }
}
