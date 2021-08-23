using DataCollector.Logic.Models;
using DataCollector.Logic.Orchestrators;
using Newtonsoft.Json;
using System.Web.Mvc;

namespace DataCollector.Controllers
{
    public class AjaxController : Controller
    {
        private ItemOrchestrator orch = new ItemOrchestrator();

        public string ItemExists(string input)
        {

            Item existingItem = orch.GetItemByName(input.ToLower());

            if (existingItem == null)
            {
                return JsonConvert.SerializeObject(false);
            }
            return JsonConvert.SerializeObject(true);

        }
    }
}