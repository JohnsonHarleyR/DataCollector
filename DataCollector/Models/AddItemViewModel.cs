using System.Web.Mvc;

namespace DataCollector.Models
{
    public class AddItemViewModel
    {
        [Remote("ItemExists", "Home", HttpMethod = "POST", ErrorMessage = "Item already exists")]
        public string Name { get; set; }
    }
}