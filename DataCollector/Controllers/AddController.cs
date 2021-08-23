using DataCollector.Logic.Models;
using DataCollector.Logic.Orchestrators;
using System.Web.Mvc;

namespace DataCollector.Controllers
{
    public class AddController : Controller
    {

        ItemOrchestrator itemOrchestrator = new ItemOrchestrator();
        QuestionOrchestrator questionOrchestrator = new QuestionOrchestrator();

        public ActionResult Item()
        {

            return View();
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

            return View();
        }

        public ActionResult SubmitQuestion(string input, int? dependentQuestionId, int? dependentAnswerId)
        {
            // Add item to the database
            Question question = new Question()
            {
                QuestionString = input,
                DependentQuestionId = dependentQuestionId,
                DependentAnswerId = dependentAnswerId
            };

            questionOrchestrator.AddQueston(question);

            return RedirectToAction("Items", "Ask");
        }


    }
}