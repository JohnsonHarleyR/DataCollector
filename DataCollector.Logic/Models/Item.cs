using DataCollector.Data.Database.Interfaces;

namespace DataCollector.Logic.Models
{
    public class Item : IItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}