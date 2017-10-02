using System;
namespace SearchConsoleDAL.Data
{
    public class SearchConsoleDataSet : EntityBase
    {
        public string Query { get; set; }
        public int DeviceType { get; set; }
        public string Page  { get; set; }
        public DateTime Date { get; set; }
        public string country { get; set; }
        public double? Clicks { get; set; }
        public double? Impressions { get; set; }
        public double? CTR { get; set; }
        public double? Position { get; set; }
        public int DomainId { get; set; }
        public virtual Domain Domain { get; set; }
        public virtual DeviceType Type { get; set; }
    }
}
