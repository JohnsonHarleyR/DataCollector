using DataCollector.Interfaces;

namespace DataCollector.Database.Dtos
{
    public class ItemDto : IItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}