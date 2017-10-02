using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SearchConsoleAPI.Models
{
    public class SearchResult
    {
        public string DomainName { get; set; }
        public List<string> DaySearchList { get; set; }
        public List<Filter> FilterList { get; set; }
        //public List<QueryDataCollection> QueryData { get; set; }
        //public List<PageDataCollection> PageData { get; set; }
        ////public List<DateDataCollection> DateData { get; set; }
        //public List<DeviceDataCollection> DeviceData { get; set; }
        public  Dictionary<string, List<double?>> QueryData = new Dictionary<string, List<double?>>();
        public Dictionary<string, List<double?>> PageData = new Dictionary<string, List<double?>>();
        public Dictionary<string, List<double?>> DeviceData = new Dictionary<string, List<double?>>();
    }

    public class Filter
    {
        public string Name { get; set; }
        public List<double?> Data { get; set; }
    }
    //public class QueryDataCollection
    //{
    //    public double? Clicks { get; set; }
    //    public double? Impressions { get; set; }
    //    public double? CTR { get; set; }
    //    public double? Position { get; set; }
    //    public int DomainId { get; set; }
    //    public string Query { get; set; }
    //    public string DateofSearch { get; set; }
    //}
    //public class PageDataCollection
    //{
    //    public double? Clicks { get; set; }
    //    public double? Impressions { get; set; }
    //    public double? CTR { get; set; }
    //    public double? Position { get; set; }
    //    public int DomainId { get; set; }
    //    public string Page { get; set; }
    //}
    ////public class DateDataCollection
    ////{
    ////    public double? Clicks { get; set; }
    ////    public double? Impressions { get; set; }
    ////    public double? CTR { get; set; }
    ////    public double? Position { get; set; }
    ////    public int DomainId { get; set; }
    ////    public string Date { get; set; }
    ////}
    //public class DeviceDataCollection
    //{
    //    public double? Clicks { get; set; }
    //    public double? Impressions { get; set; }
    //    public double? CTR { get; set; }
    //    public double? Position { get; set; }
    //    public int DomainId { get; set; }
    //    public string Device { get; set; }
    //}
}