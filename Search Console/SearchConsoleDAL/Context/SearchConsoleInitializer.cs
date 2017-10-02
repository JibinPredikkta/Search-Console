using SearchConsoleDAL.Data;
using System.Collections.Generic;
using System.Data.Entity;

namespace SearchConsoleDAL.Context
{
    public class SearchConsoleInitializer : DropCreateDatabaseIfModelChanges<SearchConsoleContext>
    {
        protected override void Seed(SearchConsoleContext context)
        {
            var domains = new List<Domain>
            {
                new Domain { Name = "http://www.iselect.com.au/" },
                new Domain { Name = "https://www.predikkta.com" }
            };
            domains.ForEach(domain => context.Domains.Add(domain));
            context.SaveChanges();

            var filterTypes = new List<FilterType>
            {
                new FilterType { Type = "query" },
                new FilterType { Type = "page" },
                new FilterType { Type = "country" },
                new FilterType { Type = "device" },
                new FilterType { Type = "date" }
            };
            filterTypes.ForEach(filterType => context.FilterTypes.Add(filterType));

            var deviceTypes = new List<DeviceType>
            {
                new DeviceType { Type = "DESKTOP" },
                  new DeviceType { Type = "MOBILE" },
                  new DeviceType { Type = "TABLET" }
            };
            deviceTypes.ForEach(devicetype => context.DeviceTypes.Add(devicetype));
            context.SaveChanges();
        }
    }
}

