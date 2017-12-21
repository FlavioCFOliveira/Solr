using System;
using System.Collections.Generic;
using System.Text;

namespace SolrTests.Model
{
    public class SolrCoreEntity
    {

        public string id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public DateTime BirthDate { get; set; }

        public IEnumerable<string> Emails { get; set; }

    }
}