using SearchConsoleDAL.Data;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace SearchConsoleDAL.Context
{
    public class SearchConsoleContext : DbContext
    {
        public SearchConsoleContext() : base("SearchConsoleContext")
        { }

        public DbSet<Domain> Domains { get; set; }
        public DbSet<SearchConsoleData> SearchConsoleDataCollection { get; set; }
        public DbSet<SearchConsoleDataKey> SearchConsoleDataKeys { get; set; }
        public DbSet<FilterType> FilterTypes { get; set; }
        public DbSet<DeviceType> DeviceTypes { get; set; }
        public DbSet<SearchConsoleDataSet> SearchConsoleDataSets { get; set; }
        //public DbSet<Users> Userss { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
