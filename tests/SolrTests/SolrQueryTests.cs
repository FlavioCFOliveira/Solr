using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solr.Abstractions;
using SolrTests.code;
using SolrTests.Model;

namespace SolrTests
{
    [TestClass]
    public class SolrQueryTests
    {
        ISolrCoreEntity core;

        public SolrQueryTests()
        {

            // sudo su - solr -c "/opt/solr/bin/solr create -c TestIX -n data_driven_schema_configs"
            this.core = new SolrCoreEntityClient(@"http://192.168.1.96:8983/solr", "TestIX");
            

        }

        [TestMethod]
        public void SolrQueryTests_all_Success()
        {
            //var result = this.core.Query("*:*").Result;
        }
        
    }
}
