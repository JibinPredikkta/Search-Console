using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SearchConsoleAPI.Models;
using System.Data.Entity;
using SearchConsoleDAL.Context;
using SearchConsoleDAL.Data;
using System.Data.SqlClient;
using System.Data;

namespace SearchConsoleAPI.Service
{
    public static class SearchService
    {
        //public static SearchResult SearchDataByDate(DateTime startDate, DateTime endDate)
        //{
        //    SearchConsoleContext context = new SearchConsoleContext();
        //    DateTime sDate = startDate;
        //    SearchResult searchResult = new SearchResult();
        //    searchResult.DaySearchList = new List<string>();
        //    searchResult.FilterList = new List<Filter>();
        //    searchResult.DomainName = "https://www.spotjobs.com";
        //    //searchResult.QueryData = new List<QueryDataCollection>();
        //    //searchResult.PageData = new List<PageDataCollection>();
        //    ////searchResult.DateData = new List<DateDataCollection>();
        //    //searchResult.DeviceData = new List<DeviceDataCollection>();
        //    searchResult.QueryData = new Dictionary<string, List<double?>>();
        //    searchResult.PageData = new Dictionary<string, List<double?>>();
        //    searchResult.DeviceData = new Dictionary<string, List<double?>>();


        //    if (context != null)
        //    {
        //        //Clicks
        //        Filter clicks = new Filter();
        //        clicks.Name = "Clicks";
        //        clicks.Data = new List<double?>();

        //        //CTR
        //        Filter ctr = new Filter();
        //        ctr.Name = "CTR";
        //        ctr.Data = new List<double?>();

        //        //Impressions
        //        Filter impressions = new Filter();
        //        impressions.Name = "Impressions";
        //        impressions.Data = new List<double?>();

        //        //Position
        //        Filter position = new Filter();
        //        position.Name = "Position";
        //        position.Data = new List<double?>();
        //        while (sDate <= endDate)
        //        {
        //            int queryCounter = 0;
        //            int pageCounter = 0;
        //            int deviceCounter = 0;
        //            string currentDate = sDate.Date.ToString("yyyy-MM-dd");
        //            List<SearchConsoleDataKey> dataList = context.SearchConsoleDataKeys.Include("SearchConsoleData").Where(s => s.Key == currentDate).ToList();
        //            List<SearchConsoleData> searchConsoleDataList = new List<SearchConsoleData>();
        //            foreach (SearchConsoleDataKey dataKey in dataList)
        //            {
        //                if (!searchConsoleDataList.Contains(dataKey.SearchConsoleData))
        //                {
        //                    searchConsoleDataList.Add(dataKey.SearchConsoleData);
        //                }
        //            }

        //            if (dataList != null &&
        //                dataList.Count > 0)
        //            {
        //                searchResult.DaySearchList.Add(sDate.Date.ToString("dd-MM-yyyy"));
        //                double? clicksTotal = 0.0;
        //                double? ctrTotal = 0.0;
        //                double? impressionsTotal = 0.0;
        //                double? positionTotal = 0.0;
        //                int positionCount = 0;
        //                int ctrCount = 0;
        //                int QueryCtrCount = 0;
        //                foreach (SearchConsoleData data in searchConsoleDataList)
        //                {
        //                    clicksTotal += data.Clicks;
        //                    ctrTotal += data.CTR;
        //                    impressionsTotal += data.Impressions;
        //                    positionTotal += data.Position;
        //                    positionCount++;
        //                    ctrCount++;
        //                    //int flag = 0;
        //                    //int flag_page = 0;
        //                    //int flag_Date = 0;
        //                    //int flag_Device = 0;
        //                    List<double?> fg = new List<double?>();
        //                    //QueryDataCollection qd = new QueryDataCollection();
        //                    foreach (SearchConsoleDataKey dataKey in data.SearchConsoleDataKeys)
        //                    {

        //                        if (dataKey.FilterTypeId == 1 /*&& queryCounter < 1000*/)
        //                        {
        //                            //queryCounter++;
        //                            if (!searchResult.QueryData.ContainsKey(dataKey.Key))
        //                            {
        //                                fg = new List<double?>();
        //                                fg.Add(data.Clicks);
        //                                fg.Add(data.CTR);
        //                                fg.Add(data.Impressions);
        //                                fg.Add(data.Position);
        //                                fg.Add(1);
        //                                searchResult.QueryData.Add(dataKey.Key, fg);
        //                            }
        //                            else
        //                            {
        //                                searchResult.QueryData[dataKey.Key][0] += data.Clicks;
        //                                searchResult.QueryData[dataKey.Key][1] += data.CTR;
        //                                searchResult.QueryData[dataKey.Key][2] += data.Impressions;
        //                                if (searchResult.QueryData[dataKey.Key][3] < data.Position)
        //                                {
        //                                    searchResult.QueryData[dataKey.Key][3] = data.Position;
        //                                }

        //                                searchResult.QueryData[dataKey.Key][4]++;
        //                            }
        //                        }
        //                        if (dataKey.FilterTypeId == 2 /*&& pageCounter < 1000*/)
        //                        {
        //                            //pageCounter++;
        //                            if (!searchResult.PageData.ContainsKey(dataKey.Key))
        //                            {
        //                                fg = new List<double?>();
        //                                fg.Add(data.Clicks);
        //                                fg.Add(data.CTR);
        //                                fg.Add(data.Impressions);
        //                                fg.Add(data.Position);
        //                                fg.Add(1);
        //                                searchResult.PageData.Add(dataKey.Key, fg);
        //                            }
        //                            else
        //                            {
        //                                searchResult.PageData[dataKey.Key][0] += data.Clicks;
        //                                searchResult.PageData[dataKey.Key][1] += data.CTR;
        //                                searchResult.PageData[dataKey.Key][2] += data.Impressions;
        //                                if (searchResult.PageData[dataKey.Key][3] < data.Position)
        //                                {
        //                                    searchResult.PageData[dataKey.Key][3] = data.Position;
        //                                }
        //                                searchResult.PageData[dataKey.Key][4]++;
        //                            }
        //                        }

        //                        if (dataKey.FilterTypeId == 4 /*&& deviceCounter < 1000*/)
        //                        {
        //                            //deviceCounter++;
        //                            if (!searchResult.DeviceData.ContainsKey(dataKey.Key))
        //                            {
        //                                fg = new List<double?>();
        //                                fg.Add(data.Clicks);
        //                                fg.Add(data.CTR);
        //                                fg.Add(data.Impressions);
        //                                fg.Add(data.Position);
        //                                fg.Add(1);
        //                                searchResult.DeviceData.Add(dataKey.Key, fg);
        //                            }
        //                            else
        //                            {
        //                                searchResult.DeviceData[dataKey.Key][0] += data.Clicks;
        //                                searchResult.DeviceData[dataKey.Key][1] += data.CTR;
        //                                searchResult.DeviceData[dataKey.Key][2] += data.Impressions;
        //                                if (searchResult.DeviceData[dataKey.Key][3] < data.Position)
        //                                {
        //                                    searchResult.DeviceData[dataKey.Key][3] = data.Position;
        //                                }
        //                                searchResult.DeviceData[dataKey.Key][4]++;
        //                            }
        //                        }
        //                    }
        //                }

        //                clicks.Data.Add(clicksTotal);
        //                ctr.Data.Add((ctrTotal / ctrCount) * 100);
        //                impressions.Data.Add(impressionsTotal);
        //                position.Data.Add((positionTotal / positionCount));
        //            }
        //            sDate = sDate.AddDays(1);
        //        }

        //        searchResult.FilterList.Add(clicks);
        //        searchResult.FilterList.Add(ctr);
        //        searchResult.FilterList.Add(impressions);
        //        searchResult.FilterList.Add((position));

        //        //var serialize = new System.Web.Script.Serialization.JavaScriptSerializer();
        //        //serialize.Serialize(searchResult.Query_Click);
        //    }

        //    return searchResult;
        //}
        public static List<SearchConsoleDataSet> SearchPageWiseDataSet(DateTime startDate, DateTime endDate, string page, int domainID)
        {
            SearchConsoleContext context = new SearchConsoleContext();
            DateTime sDate = startDate;
            List<SearchConsoleDataSet> PageWiseData = new List<SearchConsoleDataSet>();
            if (context != null)
            {
                if (page != "" && page != null)
                {
                    List<SearchConsoleDataSet> dataset = context.SearchConsoleDataSets.Where(s => s.Date >= sDate && s.Date < endDate && s.Page == page && s.DomainId == domainID).ToList();
                    PageWiseData = dataset.GroupBy(l => l.Date).Select(cl => new SearchConsoleDataSet { Clicks = cl.Sum(c => c.Clicks), Impressions = cl.Sum(d => d.Impressions), CTR = cl.Sum(c => c.Clicks) / cl.Sum(d => d.Impressions), Position = cl.Average(f => f.Position), Page = cl.First().Page, Date = cl.First().Date }).OrderBy(l =>l.Date).ToList();

                }
                else
                {
                    List<SearchConsoleDataSet> dataset = context.SearchConsoleDataSets.Where(s => s.Date >= sDate && s.Date < endDate && s.DomainId == domainID).OrderBy(l => l.Date).ToList();
                    PageWiseData = dataset.GroupBy(l => l.Page).Select(cl => new SearchConsoleDataSet { Clicks = cl.Sum(c => c.Clicks), Impressions = cl.Sum(d => d.Impressions), CTR = cl.Sum(c => c.Clicks) / cl.Sum(d => d.Impressions), Position = cl.Average(f => f.Position), Page = cl.First().Page }).OrderByDescending(c => c.Clicks).ToList();
                }
            }

            return PageWiseData;
        }

        public static List<List<SearchConsoleDataSet>> Comp_SearchPageWiseDataSet(DateTime startDate1, DateTime endDate1, DateTime startDate2, DateTime endDate2, string page, int domainID)
        {
            SearchConsoleContext context = new SearchConsoleContext();
            DateTime sDate = startDate1;
            List<SearchConsoleDataSet> PageWiseData1 = new List<SearchConsoleDataSet>();
            List<SearchConsoleDataSet> PageWiseData2 = new List<SearchConsoleDataSet>();
            List<SearchConsoleDataSet> PageWiseData3 = new List<SearchConsoleDataSet>();
            List<SearchConsoleDataSet> PageWiseData4 = new List<SearchConsoleDataSet>();
            List<List<SearchConsoleDataSet>> res = new List<List<SearchConsoleDataSet>>();
            if (context != null)
            {
                if (page != "" && page != null)
                {
                    List<SearchConsoleDataSet> dataset = context.SearchConsoleDataSets.Where(s => s.Date >= sDate && s.Date < endDate1 && s.Page == page && s.DomainId == domainID).OrderBy(l => l.Date).ToList();
                    PageWiseData1 = dataset.GroupBy(l => l.Date).Select(cl => new SearchConsoleDataSet { Clicks = cl.Sum(c => c.Clicks), Impressions = cl.Sum(d => d.Impressions), CTR = cl.Sum(c => c.Clicks) / cl.Sum(d => d.Impressions), Position = cl.Average(f => f.Position), Page = cl.First().Page, Date = cl.First().Date }).OrderBy(l => l.Date).ToList();
                    List<SearchConsoleDataSet> dataset1 = context.SearchConsoleDataSets.Where(s => s.Date >= startDate2 && s.Date < endDate2 && s.Page == page && s.DomainId == domainID).OrderBy(l => l.Date).ToList();
                    PageWiseData2 = dataset1.GroupBy(l => l.Date).Select(cl => new SearchConsoleDataSet { Clicks = cl.Sum(c => c.Clicks), Impressions = cl.Sum(d => d.Impressions), CTR = cl.Sum(c => c.Clicks) / cl.Sum(d => d.Impressions), Position = cl.Average(f => f.Position), Page = cl.First().Page, Date = cl.First().Date }).OrderBy(l => l.Date).ToList();
                    foreach (SearchConsoleDataSet item in PageWiseData1)
                    {
                        foreach (SearchConsoleDataSet item1 in PageWiseData2)
                        {
                            if (item.Page == item1.Page)
                            {
                                PageWiseData3.Add(item);
                                PageWiseData4.Add(item1);
                            }

                        }
                    }
                }
                else
                {
                    List<SearchConsoleDataSet> dataset = context.SearchConsoleDataSets.Where(s => s.Date >= sDate && s.Date < endDate1 && s.DomainId == domainID).OrderBy(l => l.Date).ToList();
                    PageWiseData1 = dataset.GroupBy(l => l.Page).Select(cl => new SearchConsoleDataSet { Clicks = cl.Sum(c => c.Clicks), Impressions = cl.Sum(d => d.Impressions), CTR = cl.Sum(c => c.Clicks) / cl.Sum(d => d.Impressions), Position = cl.Average(f => f.Position), Page = cl.First().Page }).OrderByDescending(c => c.Clicks).ToList();
                    List<SearchConsoleDataSet> dataset1 = context.SearchConsoleDataSets.Where(s => s.Date >= startDate2 && s.Date < endDate2 && s.DomainId == domainID).OrderBy(l => l.Date).ToList();
                    PageWiseData2 = dataset1.GroupBy(l => l.Page).Select(cl => new SearchConsoleDataSet { Clicks = cl.Sum(c => c.Clicks), Impressions = cl.Sum(d => d.Impressions), CTR = cl.Sum(c => c.Clicks) / cl.Sum(d => d.Impressions), Position = cl.Average(f => f.Position), Page = cl.First().Page }).OrderByDescending(c => c.Clicks).ToList();
                    foreach (SearchConsoleDataSet item in PageWiseData1)
                    {
                        foreach (SearchConsoleDataSet item1 in PageWiseData2)
                        {
                            if (item.Page == item1.Page)
                            {
                                PageWiseData3.Add(item);
                                PageWiseData4.Add(item1);
                            }

                        }
                    }
                }
            
                res.Add(PageWiseData3);
                res.Add(PageWiseData4);
                res.Add(PageWiseData1);
                res.Add(PageWiseData2);
            }

            return res;
        }
        public static List<SearchConsoleDataSet> SearchQueryWiseDataSet(DateTime startDate, DateTime endDate, string query, int domainID)
        {
            SearchConsoleContext context = new SearchConsoleContext();
            DateTime sDate = startDate;
            List<SearchConsoleDataSet> QueryWiseData = new List<SearchConsoleDataSet>();
            if (context != null)
            {
                if (query != "" && query != null)
                {
                    List<SearchConsoleDataSet> dataset = context.SearchConsoleDataSets.Where(s => s.Date >= sDate && s.Date < endDate && s.Query == query && s.DomainId == domainID).OrderBy(l => l.Date).ToList();
                    QueryWiseData = dataset.GroupBy(l => l.Date).Select(cl => new SearchConsoleDataSet { Clicks = cl.Sum(c => c.Clicks), Impressions = cl.Sum(d => d.Impressions), CTR = cl.Sum(c => c.Clicks) / cl.Sum(d => d.Impressions), Position = cl.Average(f => f.Position), Query = cl.First().Query, Date = cl.First().Date }).OrderBy(l =>l.Date).ToList();

                }
                else
                {
                    List<SearchConsoleDataSet> dataset = context.SearchConsoleDataSets.Where(s => s.Date >= sDate && s.Date < endDate && s.DomainId == domainID).OrderBy(l => l.Date).ToList();
                    QueryWiseData = dataset.GroupBy(l => l.Query).Select(cl => new SearchConsoleDataSet { Clicks = cl.Sum(c => c.Clicks), Impressions = cl.Sum(d => d.Impressions), CTR = cl.Sum(c => c.Clicks) / cl.Sum(d => d.Impressions), Position = cl.Average(f => f.Position), Query = cl.First().Query }).OrderByDescending(c => c.Clicks).ToList();

                }

            }

            return QueryWiseData;
        }

        public static List<List<SearchConsoleDataSet>> Comp_SearchQueryWiseDataSet(DateTime startDate1, DateTime endDate1, DateTime startDate2, DateTime endDate2, string query, int domainID)
        {
            SearchConsoleContext context = new SearchConsoleContext();
            DateTime sDate = startDate1;
            List<SearchConsoleDataSet> QueryWiseData1 = new List<SearchConsoleDataSet>();
            List<SearchConsoleDataSet> QueryWiseData2 = new List<SearchConsoleDataSet>();
            List<SearchConsoleDataSet> QueryWiseData3 = new List<SearchConsoleDataSet>();
            List<SearchConsoleDataSet> QueryWiseData4 = new List<SearchConsoleDataSet>();
            List<List<SearchConsoleDataSet>> res = new List<List<SearchConsoleDataSet>>();
            List<SearchConsoleDataSet> Total = new List<SearchConsoleDataSet>(1);
            List<SearchConsoleDataSet> Total1 = new List<SearchConsoleDataSet>();
            if (context != null)
            {
                if(query != "" && query != null)
                {
                    List<SearchConsoleDataSet> dataset = context.SearchConsoleDataSets.Where(s => s.Date >= sDate && s.Date < endDate1 && s.Query == query && s.DomainId == domainID).OrderBy(l => l.Date).ToList();
                    QueryWiseData1 = dataset.GroupBy(l => l.Date).Select(cl => new SearchConsoleDataSet { Clicks = cl.Sum(c => c.Clicks), Impressions = cl.Sum(d => d.Impressions), CTR = cl.Sum(c => c.Clicks) / cl.Sum(d => d.Impressions), Position = cl.Average(f => f.Position), Query = cl.First().Query, Date = cl.First().Date}).OrderBy(l => l.Date).ToList();
                    List<SearchConsoleDataSet> dataset1 = context.SearchConsoleDataSets.Where(s => s.Date >= startDate2 && s.Date < endDate2 && s.Query == query && s.DomainId == domainID).OrderBy(l => l.Date).ToList();
                    QueryWiseData2 = dataset1.GroupBy(l => l.Date).Select(cl => new SearchConsoleDataSet { Clicks = cl.Sum(c => c.Clicks), Impressions = cl.Sum(d => d.Impressions), CTR = cl.Sum(c => c.Clicks) / cl.Sum(d => d.Impressions), Position = cl.Average(f => f.Position), Query = cl.First().Query, Date = cl.First().Date}).OrderBy(l => l.Date).ToList();
                    foreach (SearchConsoleDataSet item in QueryWiseData1)
                    {
                        foreach (SearchConsoleDataSet item1 in QueryWiseData2)
                        {
                            if (item.Query == item1.Query)
                            {
                                QueryWiseData3.Add(item);
                                QueryWiseData4.Add(item1);
                            }

                        }
                    }
                }
                else
                {
                    List<SearchConsoleDataSet> dataset = context.SearchConsoleDataSets.Where(s => s.Date >= sDate && s.Date < endDate1 && s.DomainId == domainID).OrderBy(l => l.Date).ToList();
                    QueryWiseData1 = dataset.GroupBy(l => l.Query).Select(cl => new SearchConsoleDataSet { Clicks = cl.Sum(c => c.Clicks), Impressions = cl.Sum(d => d.Impressions), CTR = cl.Sum(c => c.Clicks) / cl.Sum(d => d.Impressions), Position = cl.Average(f => f.Position), Query = cl.First().Query }).OrderByDescending(c => c.Clicks).ToList(); 
                    List<SearchConsoleDataSet> dataset1 = context.SearchConsoleDataSets.Where(s => s.Date >= startDate2 && s.Date < endDate2 && s.DomainId == domainID).OrderBy(l => l.Date).ToList();
                    QueryWiseData2 = dataset1.GroupBy(l => l.Query).Select(cl => new SearchConsoleDataSet { Clicks = cl.Sum(c => c.Clicks), Impressions = cl.Sum(d => d.Impressions), CTR = cl.Sum(c => c.Clicks) / cl.Sum(d => d.Impressions), Position = cl.Average(f => f.Position), Query = cl.First().Query }).OrderByDescending(c => c.Clicks).ToList();
                    foreach (SearchConsoleDataSet item in QueryWiseData1)
                    {
                        foreach (SearchConsoleDataSet item1 in QueryWiseData2)
                        {
                            if (item.Query == item1.Query)
                            {
                                QueryWiseData3.Add(item);
                                QueryWiseData4.Add(item1);
                            }

                        }
                    }
                }
                
                res.Add(QueryWiseData3);
                res.Add(QueryWiseData4);
                res.Add(QueryWiseData1);
                res.Add(QueryWiseData2);
            }

            return res;
        }

        public static List<SearchConsoleDataSet> GetFirstAndLastDate( int domainID)
        {
            SearchConsoleContext context = new SearchConsoleContext();
            List<SearchConsoleDataSet> res = new List<SearchConsoleDataSet>();
            SearchConsoleDataSet firstDate = new SearchConsoleDataSet();
            SearchConsoleDataSet lastDate = new SearchConsoleDataSet();
            if (context != null)
            {
                firstDate = context.SearchConsoleDataSets.Where(s => s.DomainId == domainID).OrderBy(l => l.Date).FirstOrDefault();
                lastDate = context.SearchConsoleDataSets.Where(s => s.DomainId == domainID).OrderByDescending(l => l.Date).FirstOrDefault();

            }
            res.Add(firstDate);
            res.Add(lastDate);
            return res;
        }

        public static List<SearchConsoleDataSet> SearchDateWiseDataSet(DateTime startDate, DateTime endDate, int domainID)
        {
            SearchConsoleContext context = new SearchConsoleContext();
            DateTime sDate = startDate;
            List<SearchConsoleDataSet> DateWiseData = new List<SearchConsoleDataSet>();
            if (context != null)
            {
                List<SearchConsoleDataSet> dataset = context.SearchConsoleDataSets.Where(s => s.Date >= sDate && s.Date < endDate && s.DomainId == domainID).OrderBy(l => l.Date).ToList();
                DateWiseData = dataset.GroupBy(l => l.Date).Select(cl => new SearchConsoleDataSet { Clicks = cl.Sum(c => c.Clicks), Impressions = cl.Sum(d => d.Impressions), CTR = cl.Sum(c => c.Clicks) / cl.Sum(d => d.Impressions), Position = cl.Average(f => f.Position), Date = cl.First().Date }).ToList();

            }

            return DateWiseData;
        }
        public static List<List<SearchConsoleDataSet>> Comp_SearchDateWiseDataSet(DateTime startDate1, DateTime endDate1, DateTime startDate2, DateTime endDate2, int domainID)
        {
            SearchConsoleContext context = new SearchConsoleContext();
            DateTime sDate = startDate1;
            List<SearchConsoleDataSet> QueryWiseData1 = new List<SearchConsoleDataSet>();
            List<SearchConsoleDataSet> QueryWiseData2 = new List<SearchConsoleDataSet>();
            List<SearchConsoleDataSet> QueryWiseData3 = new List<SearchConsoleDataSet>();
            List<SearchConsoleDataSet> QueryWiseData4 = new List<SearchConsoleDataSet>();
            List<List<SearchConsoleDataSet>> res = new List<List<SearchConsoleDataSet>>();
            if (context != null)
            {
                List<SearchConsoleDataSet> dataset = context.SearchConsoleDataSets.Where(s => s.Date >= sDate && s.Date < endDate1 && s.DomainId == domainID).OrderBy(l => l.Date).ToList();
                QueryWiseData1 = dataset.GroupBy(l => l.Date).Select(cl => new SearchConsoleDataSet { Clicks = cl.Sum(c => c.Clicks), Impressions = cl.Sum(d => d.Impressions), CTR = cl.Sum(c => c.Clicks) / cl.Sum(d => d.Impressions), Position = cl.Average(f => f.Position), Date = cl.First().Date }).ToList();
                List<SearchConsoleDataSet> dataset1 = context.SearchConsoleDataSets.Where(s => s.Date >= startDate2 && s.Date < endDate2 && s.DomainId == domainID).OrderBy(l => l.Date).ToList();
                QueryWiseData2 = dataset1.GroupBy(l => l.Date).Select(cl => new SearchConsoleDataSet { Clicks = cl.Sum(c => c.Clicks), Impressions = cl.Sum(d => d.Impressions), CTR = cl.Sum(c => c.Clicks) / cl.Sum(d => d.Impressions), Position = cl.Average(f => f.Position), Date = cl.First().Date }).ToList();
                //foreach (SearchConsoleDataSet item in QueryWiseData1)
                //{
                //    foreach (SearchConsoleDataSet item1 in QueryWiseData2)
                //    {
                //        if (item.Query == item1.Query)
                //        {
                //            QueryWiseData3.Add(item);
                //            QueryWiseData4.Add(item1);
                //        }

                //    }
                //}
                //res.Add(QueryWiseData3);
                //res.Add(QueryWiseData4);
                res.Add(QueryWiseData1);
                res.Add(QueryWiseData2);
            }

            return res;
        }
        public static List<SearchConsoleDataSet> SearchDeviceWiseDataSet(DateTime startDate, DateTime endDate, int domainID)
        {
            SearchConsoleContext context = new SearchConsoleContext();
            DateTime sDate = startDate;
            List<SearchConsoleDataSet> DeviceWiseData = new List<SearchConsoleDataSet>();
            if (context != null)
            {
                List<SearchConsoleDataSet> dataset = context.SearchConsoleDataSets.Where(s => s.Date >= sDate && s.Date < endDate && s.DomainId == domainID).OrderBy(l => l.Date).ToList();
                DeviceWiseData = dataset.GroupBy(l => l.DeviceType).Select(cl => new SearchConsoleDataSet { Clicks = cl.Sum(c => c.Clicks), Impressions = cl.Sum(d => d.Impressions), CTR = cl.Sum(c => c.Clicks) / cl.Sum(d => d.Impressions), Position = cl.Average(f => f.Position), DeviceType = cl.First().DeviceType }).OrderByDescending(c => c.Clicks).ToList();

            }

            return DeviceWiseData;
        }

        public static List<List<SearchConsoleDataSet>> Comp_SearchDeviceWiseDataSet(DateTime startDate1, DateTime endDate1, DateTime startDate2, DateTime endDate2, int domainID)
        {
            SearchConsoleContext context = new SearchConsoleContext();
            DateTime sDate = startDate1;
            List<SearchConsoleDataSet> QueryWiseData1 = new List<SearchConsoleDataSet>();
            List<SearchConsoleDataSet> QueryWiseData2 = new List<SearchConsoleDataSet>();
            List<SearchConsoleDataSet> QueryWiseData3 = new List<SearchConsoleDataSet>();
            List<SearchConsoleDataSet> QueryWiseData4 = new List<SearchConsoleDataSet>();
            List<List<SearchConsoleDataSet>> res = new List<List<SearchConsoleDataSet>>();
            if (context != null)
            {
                List<SearchConsoleDataSet> dataset = context.SearchConsoleDataSets.Where(s => s.Date >= sDate && s.Date < endDate1 && s.DomainId == domainID).OrderBy(l => l.Date).ToList();
                QueryWiseData1 = dataset.GroupBy(l => l.DeviceType).Select(cl => new SearchConsoleDataSet { Clicks = cl.Sum(c => c.Clicks), Impressions = cl.Sum(d => d.Impressions), CTR = cl.Sum(c => c.Clicks) / cl.Sum(d => d.Impressions), Position = cl.Average(f => f.Position), DeviceType = cl.First().DeviceType }).OrderByDescending(c => c.Clicks).ToList();
                List<SearchConsoleDataSet> dataset1 = context.SearchConsoleDataSets.Where(s => s.Date >= startDate2 && s.Date < endDate2 && s.DomainId == domainID).OrderBy(l => l.Date).ToList();
                QueryWiseData2 = dataset1.GroupBy(l => l.DeviceType).Select(cl => new SearchConsoleDataSet { Clicks = cl.Sum(c => c.Clicks), Impressions = cl.Sum(d => d.Impressions), CTR = cl.Sum(c => c.Clicks) / cl.Sum(d => d.Impressions), Position = cl.Average(f => f.Position), DeviceType = cl.First().DeviceType }).OrderByDescending(c => c.Clicks).ToList();
                foreach (SearchConsoleDataSet item in QueryWiseData1)
                {
                    foreach (SearchConsoleDataSet item1 in QueryWiseData2)
                    {
                        if (item.DeviceType == item1.DeviceType)
                        {
                            QueryWiseData3.Add(item);
                            QueryWiseData4.Add(item1);
                        }

                    }
                }
                res.Add(QueryWiseData3);
                res.Add(QueryWiseData4);
                res.Add(QueryWiseData1);
                res.Add(QueryWiseData2);
            }

            return res;
        }

        public static List<int> LoginCheck(string userName, string password)
        {
            List<int> f = new List<int>();
            try
            {
                SqlConnection thisConnection = new SqlConnection(@"Data Source=.\;Initial Catalog=SearchConsole;Integrated Security=True");
                //thisConnection.Open();
                password = Users.Encrypt(password);
                string sqlcommand = "SELECT [DomainId] FROM [dbo].[Users] WHERE [UserName] = '"+userName+"' and [Password] = '"+password+"'";
                //SqlCommand cmd = new SqlCommand(sqlcommand, thisConnection);
                //SqlDataReader thisReader = cmd.ExecuteReader();
                //while (thisReader.Read())
                //{
                //     f = "";
                //}
                //thisReader.Close();
                //thisConnection.Close();


                SqlDataAdapter adptre = new SqlDataAdapter();
                DataSet resultSet = new DataSet();

                SqlCommand sqlcmd = new SqlCommand(sqlcommand, thisConnection);
                adptre.SelectCommand = sqlcmd;
                thisConnection.Open();
                try
                {
                    adptre.Fill(resultSet);
                    for(int i = 0; i< resultSet.Tables[0].Rows.Count;i++)
                    {
                        f.Add(Convert.ToInt32(resultSet.Tables[0].Rows[i].ItemArray[0]));
                    }
                }

                catch (Exception ex)
                {

                }
                thisConnection.Close();

            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }

            return f;
        }

    }
}