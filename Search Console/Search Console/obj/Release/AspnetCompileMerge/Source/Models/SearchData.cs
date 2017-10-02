using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SearchConsoleAPI.Models
{
    public class SearchData
    {
        public List<Filterset> datasets { get; set; }
    }

    public class Filterset
    {
        public string DomainName { get; set; }
        public string Page { get; set; }
        public double? Clicks { get; set; }
        public double? Impressions { get; set; }
        public double? CTR { get; set; }
        public double? Position { get; set; }
    }
}