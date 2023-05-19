namespace OscarWinChecker.Models
{
    public class IMBDActor
    {
        public string ImDbId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Item> Items { get; set; }
    }

    public class NameAwardEventDetail
    {
        public string Image { get; set; }
        public string Title { get; set; }
        public string For { get; set; }
        public string Description { get; set; }
    }

    public class Item
    {
        public string EventTitle { get; set; }
        public List<NameAwardEventDetail> NameAwardEventDetails { get; set; }
    }
}
