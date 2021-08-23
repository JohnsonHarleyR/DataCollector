using DataCollector.Logic.Models;
using DataCollector.Logic.Orchestrators;
using DataCollector.Models;
using System.Web.Mvc;

namespace DataCollector.Controllers
{
    public class AddController : Controller
    {

        ItemOrchestrator itemOrchestrator = new ItemOrchestrator();

        public ActionResult Item()
        {
            AddItemViewModel model = new AddItemViewModel();

            return View(model);
        }

        public ActionResult SubmitItem(string input)
        {
            // Add item to the database
            Item item = new Item()
            {
                Name = input.ToLower()
            };

            itemOrchestrator.AddItem(item);

            return RedirectToAction("Questions", "Ask");
        }

        public ActionResult Question()
        {
            AddItemViewModel model = new AddItemViewModel();

            return View(model);
        }

        public ActionResult SubmitQuestion(string input)
        {
            // Add item to the database
            Item item = new Item()
            {
                Name = input.ToLower()
            };

            itemOrchestrator.AddItem(item);

            return RedirectToAction("Questions", "Ask");
        }


    }
}