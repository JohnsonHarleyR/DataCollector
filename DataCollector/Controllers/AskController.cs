using DataCollector.Helpers;
using DataCollector.Logic.Models;
using DataCollector.Logic.Orchestrators;
using DataCollector.Models;
using System.Collections.Generic;
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

        public ActionResult ItemsWithQuestions()
        {
            // get all the items
            List<Item> items = itemOrchestrator.GetAllItems();

            // loop through items - when it finds one that has unanswered questions, redirect
            foreach (var item in items)
            {
                List<Question> unanswered = AnswerHelper.GetUnansweredQuestions(item.Id);
                if (unanswered != null)
                {
                    return RedirectToAction("Questions", "Ask", new { itemId = item.Id });
                }
            }

            // if there are no items with questions left, redirect to a place where questions can be created
            return RedirectToAction("Index", "Home");
        }

        public void AddAnswer(int itemId, int questionId, int answerId)
        {
            Answer newAnswer = new Answer()
            {
                ItemId = itemId,
                QuestionId = questionId,
                AnswerId = answerId
            };

            answerOrchestrator.AddAnswer(newAnswer);

        }
    }
}