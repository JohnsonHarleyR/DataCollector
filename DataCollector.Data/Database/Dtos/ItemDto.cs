using DataCollector.Data.Database.Interfaces;

namespace DataCollector.Data.Database.Dtos
{
    public class ItemDto : IItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}