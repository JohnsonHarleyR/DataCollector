using DataCollector.Helpers;
using DataCollector.Logic.Orchestrators;
using DataCollector.Models;
using System.Web.Mvc;

namespace DataCollector.Controllers
{
    public class AskController : Controller
    {
        private ItemOrchestrator itemOrchestrator = new ItemOrchestrator();
        private AnswerOrchestrator answerOrchestrator = new AnswerOrchestrator();

        public ActionResult Questions(int? itemId)
        {
            if (itemId == null)
            {
                return RedirectToAction("Index", "Home");
            }

            // create a model
            AskQuestionsViewModel model = new AskQuestionsViewModel()
            {
                Item = itemOrchestrator.GetItemById((int)itemId),
                Questions = AnswerHelper.GetUnansweredQuestions((int)itemId)
            };

            if (model.Questions != null)
            {
                return View(model);
            }

            return RedirectToAction("Index", "Home");

        }
    }
}