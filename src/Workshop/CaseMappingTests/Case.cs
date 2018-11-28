using System.Collections.Generic;

namespace CaseMappingTests
{
    public class Case
    {
        public string Reference { get; set; }
        public List<double> Financials { get; set; }
        public Person Person { get; set; }
    }
}