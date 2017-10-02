namespace SearchConsoleDAL.Data
{
    public class SearchConsoleDataKey : EntityBase
    {
        public string Key { get; set; }
        public int FilterTypeId { get; set; }
        public int SearchConsoleDataId { get; set; }
        public virtual FilterType FilterType { get; set; }
        public virtual SearchConsoleData SearchConsoleData { get; set; }
    }
}
