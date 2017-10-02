using SearchConsoleDAL.Context;
using SearchConsoleDAL.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using SearchConsoleAPI.Models;
using SearchConsoleAPI.Service;
using System;
using System.Data;
using System.Globalization;

namespace SearchConsoleAPI.Controllers
{
    public class SearchConsoleController : ApiController
    {
        private SearchConsoleContext db = new SearchConsoleContext();
        [ActionName("Domains")]
        public List<Domain> GetAllDomains()
        {
            if(db != null)
            {
                return db.Domains.ToList();
            }
            return new List<Domain>();
        }

        [ActionName("FilterTypes")]
        public List<FilterType> GetAllFilterTypes()
        {
            if(db != null)
            {
                return db.FilterTypes.ToList();
            }
            return new List<FilterType>();
        }

        //[ActionName("SearchByDate")]
        //public SearchResult GetSearchDataByDate()
        //{
        //    return SearchService.SearchDataByDate();
        //}

        [ActionName("GetDates")]
        public List<SearchConsoleDataSet> GetSearchDateWiseDataSet( int domainID)
        {
            return SearchService.GetFirstAndLastDate(domainID);
        }

        [ActionName("LoginCheck")]
        [HttpGet]
        public List<int> LoginCheck( string userName, string password)
        {
            return SearchService.LoginCheck(userName, password);
        }

        [ActionName("SearchByDate")]
        public List<SearchConsoleDataSet> GetSearchDateWiseDataSet(string startDate, string endDate, int domainID)
        {
            DateTime sdate;
            DateTime edate;
            if (startDate == "null")
            {
                sdate = DateTime.Now.AddDays(-95).Date;
            }
            else
            {
                //sdate = DateTime.Parse(startDate);
                sdate = DateTime.Parse(startDate, CultureInfo.GetCultureInfo("en-US"));
            }
           if(endDate == "null")
            {
                edate = DateTime.Now.Date.AddDays(1).Date;
            }
            else
            {
                edate = DateTime.Parse(endDate, CultureInfo.GetCultureInfo("en-US")).AddDays(1).Date;
            }
            return SearchService.SearchDateWiseDataSet(sdate,edate,domainID);
        }

        [ActionName("SearchByPage")]
        public List<SearchConsoleDataSet> GetSearchPageWiseDataSet(string startDate, string endDate, string Page, int domainID)
        {
            DateTime sdate;
            DateTime edate;
            if (startDate == "null")
            {
                sdate = DateTime.Now.AddDays(-95).Date;
            }
            else
            {
                sdate = DateTime.Parse(startDate, CultureInfo.GetCultureInfo("en-US"));
            }
            if (endDate == "null")
            {
                edate = DateTime.Now.Date.AddDays(1).Date;
            }
            else
            {
                edate = DateTime.Parse(endDate, CultureInfo.GetCultureInfo("en-US")).AddDays(1).Date;
            }
            return SearchService.SearchPageWiseDataSet(sdate, edate, Page, domainID);
        }

        [ActionName("SearchByDevice")]
        public List<SearchConsoleDataSet> GetSearchDeviceWiseDataSet(string startDate, string endDate, int domainID)
        {
            DateTime sdate;
            DateTime edate;
            if (startDate == "null")
            {
                sdate = DateTime.Now.AddDays(-95).Date;
            }
            else
            {
                sdate = DateTime.Parse(startDate, CultureInfo.GetCultureInfo("en-US"));
            }
            if (endDate == "null")
            {
                edate = DateTime.Now.Date.AddDays(1).Date;
            }
            else
            {
                edate = DateTime.Parse(endDate, CultureInfo.GetCultureInfo("en-US")).AddDays(1).Date;
            }
            return SearchService.SearchDeviceWiseDataSet(sdate, edate, domainID);
        }
        [ActionName("SearchByQuery")]
        public List<SearchConsoleDataSet> GetSearchQueryWiseDataSet(string startDate, string endDate, string Query, int domainID)
        {
            DateTime sdate;
            DateTime edate;
            if (startDate == "null")
            {
                sdate = DateTime.Now.AddDays(-95).Date;
            }
            else
            {
                sdate = DateTime.Parse(startDate, CultureInfo.GetCultureInfo("en-US"));
            }
            if (endDate == "null")
            {
                edate = DateTime.Now.Date.AddDays(1).Date;
            }
            else
            {
                edate = DateTime.Parse(endDate, CultureInfo.GetCultureInfo("en-US")).AddDays(1).Date;
            }
            return SearchService.SearchQueryWiseDataSet(sdate, edate, Query, domainID);
        }
        [ActionName("Comp_SearchByQuery")]
        public  List<List<SearchConsoleDataSet>> GetComp_SearchQueryWiseDataSet(string startDate1, string endDate1, string startDate2, string endDate2, string Query, int domainID)
        {
            DateTime sdate1;
            DateTime edate1;
            DateTime sdate2;
            DateTime edate2;
          
            sdate1 = DateTime.Parse(startDate1, CultureInfo.GetCultureInfo("en-US"));
            edate1 = DateTime.Parse(endDate1, CultureInfo.GetCultureInfo("en-US")).AddDays(1).Date;
            sdate2 = DateTime.Parse(startDate2, CultureInfo.GetCultureInfo("en-US"));
            edate2 = DateTime.Parse(endDate2, CultureInfo.GetCultureInfo("en-US")).AddDays(1).Date;

            return SearchService.Comp_SearchQueryWiseDataSet(sdate1, edate1, sdate2, edate2, Query, domainID);
        }
        [ActionName("Comp_SearchByPage")]
        public List<List<SearchConsoleDataSet>> GetComp_SearchPageWiseDataSet(string startDate1, string endDate1, string startDate2, string endDate2, string Page, int domainID)
        {
            DateTime sdate1;
            DateTime edate1;
            DateTime sdate2;
            DateTime edate2;

            sdate1 = DateTime.Parse(startDate1, CultureInfo.GetCultureInfo("en-US"));
            edate1 = DateTime.Parse(endDate1, CultureInfo.GetCultureInfo("en-US")).AddDays(1).Date;
            sdate2 = DateTime.Parse(startDate2, CultureInfo.GetCultureInfo("en-US"));
            edate2 = DateTime.Parse(endDate2, CultureInfo.GetCultureInfo("en-US")).AddDays(1).Date;

            return SearchService.Comp_SearchPageWiseDataSet(sdate1, edate1, sdate2, edate2, Page, domainID);
        }
        [ActionName("Comp_SearchByDate")]
        public List<List<SearchConsoleDataSet>> GetComp_SearchDateWiseDataSet(string startDate1, string endDate1, string startDate2, string endDate2, int domainID)
        {
            DateTime sdate1;
            DateTime edate1;
            DateTime sdate2;
            DateTime edate2;

            sdate1 = DateTime.Parse(startDate1, CultureInfo.GetCultureInfo("en-US"));
            edate1 = DateTime.Parse(endDate1, CultureInfo.GetCultureInfo("en-US")).AddDays(1).Date;
            sdate2 = DateTime.Parse(startDate2, CultureInfo.GetCultureInfo("en-US"));
            edate2 = DateTime.Parse(endDate2, CultureInfo.GetCultureInfo("en-US")).AddDays(1).Date;
            return SearchService.Comp_SearchDateWiseDataSet(sdate1, edate1, sdate2, edate2, domainID);
        }
        [ActionName("Comp_SearchByDevice")]
        public List<List<SearchConsoleDataSet>> GetComp_SearchDeviceWiseDataSet(string startDate1, string endDate1, string startDate2, string endDate2, int domainID)
        {
            DateTime sdate1;
            DateTime edate1;
            DateTime sdate2;
            DateTime edate2;

            sdate1 = DateTime.Parse(startDate1, CultureInfo.GetCultureInfo("en-US"));
            edate1 = DateTime.Parse(endDate1, CultureInfo.GetCultureInfo("en-US")).AddDays(1).Date;
            sdate2 = DateTime.Parse(startDate2, CultureInfo.GetCultureInfo("en-US"));
            edate2 = DateTime.Parse(endDate2, CultureInfo.GetCultureInfo("en-US")).AddDays(1).Date;

            return SearchService.Comp_SearchDeviceWiseDataSet(sdate1, edate1, sdate2, edate2, domainID);
        }
    }
}
