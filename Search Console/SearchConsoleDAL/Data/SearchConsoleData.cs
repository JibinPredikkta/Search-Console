using System.Collections.Generic;

namespace SearchConsoleDAL.Data
{
    public class SearchConsoleData : EntityBase
    {
        public double? Clicks { get; set; }
        public double? Impressions { get; set; }
        public double? CTR { get; set; }
        public double? Position { get; set; }
        public int DomainId { get; set; }
        public virtual Domain Domain { get; set; }
        public virtual ICollection<SearchConsoleDataKey> SearchConsoleDataKeys { get; set; }
    }
}
