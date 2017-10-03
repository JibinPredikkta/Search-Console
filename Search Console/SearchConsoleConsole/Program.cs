using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Google.Apis.Webmasters.v3;
using Google.Apis.Webmasters.v3.Data;
using SearchConsoleDAL.Context;
using SearchConsoleDAL.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;

namespace SearchConsoleConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            string clientId = ConfigurationManager.AppSettings.Get("clientId");
            string clientSecret = ConfigurationManager.AppSettings.Get("clientSecret");
            string userName = ConfigurationManager.AppSettings.Get("userName");
            SearchConsoleContext db = new SearchConsoleContext();

            WebmastersService service = AuthenticateOauth(clientId, clientSecret, userName);

            if (db != null && service != null)
            {
                foreach (Domain domain in db.Domains.ToList())
                {
                    if (domain.Id == 2)
                    {
                        continue;
                    }
                    IList<string> dimensions = new List<string>();
                    db.FilterTypes.ToList().ForEach(ft => dimensions.Add(ft.Type));

                    //SearchConsoleDataKey dataKey = null;
                    SearchConsoleDataSet dataKey = null;
                    FilterType dateFilterType = db.FilterTypes.FirstOrDefault(ft => ft.Type == "date");
                    if (dateFilterType != null && dateFilterType.Id != 0)
                    {
                        //dataKey = db.SearchConsoleDataKeys.Where(d => d.FilterTypeId == dateFilterType.Id).OrderByDescending(k => k.Key).FirstOrDefault();
                        dataKey = db.SearchConsoleDataSets.Where(d => d.DomainId == domain.Id).OrderByDescending(k => k.Date).FirstOrDefault();
                    }

                    SearchAnalyticsQueryRequest request = new SearchAnalyticsQueryRequest();
                    request.RowLimit = 5000;
                    request.Dimensions = dimensions;
                    request.AggregationType = "bypage";
                    DateTime startDate = DateTime.Now.AddDays(-78).Date;
                    DateTime endDate = startDate;

                    if (dataKey != null)
                    {
                        //startDate = DateTime.Parse(dataKey.Key).AddDays(1);
                        startDate = dataKey.Date.AddDays(1);
                        endDate = startDate;
                    }

                    //while (startDate < endDate)
                    //{
                    request.StartDate = startDate.ToString("yyyy-MM-dd");
                    request.EndDate = endDate.ToString("yyyy-MM-dd");

                    var result = service.Searchanalytics.Query(request, domain.Name).Execute();

                    if (result != null &&
                        result.Rows != null &&
                        result.Rows.Count > 0)
                    {
                        for (int i = 0; i < result.Rows.Count; i++)
                        {
                            SearchConsoleData data = new SearchConsoleData();
                            data.Clicks = result.Rows[i].Clicks;
                            data.CTR = result.Rows[i].Ctr;
                            data.Impressions = result.Rows[i].Impressions;
                            data.Position = result.Rows[i].Position;
                            data.DomainId = domain.Id;
                            data.SearchConsoleDataKeys = new List<SearchConsoleDataKey>();
                            SearchConsoleDataSet dataInOneRow = new SearchConsoleDataSet();
                            dataInOneRow.Clicks = result.Rows[i].Clicks;
                            dataInOneRow.CTR = result.Rows[i].Ctr;
                            dataInOneRow.Impressions = result.Rows[i].Impressions;
                            dataInOneRow.Position = result.Rows[i].Position;
                            dataInOneRow.DomainId = domain.Id;
                            dataInOneRow.Query = result.Rows[i].Keys[0];
                            dataInOneRow.Page = result.Rows[i].Keys[1];
                            dataInOneRow.country = result.Rows[i].Keys[2];
                            string device = result.Rows[i].Keys[3];
                            DeviceType deviceType = db.DeviceTypes.FirstOrDefault(dt => dt.Type == device);
                            dataInOneRow.DeviceType = deviceType.Id;
                            dataInOneRow.Date = DateTime.Parse(result.Rows[i].Keys[4]);

                            //NOTE: Keys are arranged according to how the dimensions was arranged in the request.
                            for (int key = 0; key < dimensions.Count; key++)
                            {
                                string filter = dimensions[key];
                                FilterType filterType = db.FilterTypes.FirstOrDefault(ft => ft.Type == filter);
                                data.SearchConsoleDataKeys.Add(
                                    new SearchConsoleDataKey
                                    {
                                        FilterTypeId = filterType.Id,
                                        Key = result.Rows[i].Keys[key]
                                    });
                            }

                            db.SearchConsoleDataCollection.Add(data);
                            db.SearchConsoleDataSets.Add(dataInOneRow);
                            db.SaveChanges();
                        }
                    }


                    //    startDate = startDate.AddDays(1);
                    //}
                }
            }
        }

        /// <summary>
        /// Authenticate to Google Using Oauth2
        /// Documentation https://developers.google.com/accounts/docs/OAuth2
        /// </summary>
        /// <param name="clientId">From Google Developer console https://console.developers.google.com</param>
        /// <param name="clientSecret">From Google Developer console https://console.developers.google.com</param>
        /// <param name="userName">A string used to identify a user.</param>
        /// <returns></returns>
        public static WebmastersService AuthenticateOauth(string clientId, string clientSecret, string userName)
        {
            string[] scopes = new string[] { WebmastersService.Scope.Webmasters };     // View analytics data

            try
            {
                // here is where we Request the user to give us access, or use the Refresh Token that was previously stored in %AppData%
                UserCredential credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    new ClientSecrets { ClientId = clientId, ClientSecret = clientSecret }
                    , scopes
                    , userName
                    , CancellationToken.None
                    , new FileDataStore(".")).Result;

                WebmastersService service = new WebmastersService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = "Predikkta Search Console",
                });
                return service;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.InnerException);
                return null;

            }

        }
    }
}
