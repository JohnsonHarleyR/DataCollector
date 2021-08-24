using DataCollector.Logic.Enums;
using DataCollector.Logic.Models;
using DataCollector.Logic.Orchestrators;
using DataCollector.Models.Containers;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Web.Mvc;

namespace DataCollector.Controllers
{
    public class AjaxController : Controller
    {
        private ItemOrchestrator itemOrch = new ItemOrchestrator();
        private QuestionOrchestrator questionOrch = new QuestionOrchestrator();

        public string ItemExists(string input)
        {

            Item existingItem = itemOrch.GetItemByName(input.ToLower());

            if (existingItem == null)
            {
                return JsonConvert.SerializeObject(false);
            }
            return JsonConvert.SerializeObject(true);

        }

        public string GetQuestions(int? attachedQuestionId, int? attachedAnswerId,
            bool showAll)
        {
            QuestionsContainer container = new QuestionsContainer();
            List<Question> questions;
            List<PossibleAnswerContainer> answers = new List<PossibleAnswerContainer>();
            answers.Add(new PossibleAnswerContainer()
            {
                Answer = "Yes",
                AnswerId = (int)PossibleAnswer.Yes
            });
            answers.Add(new PossibleAnswerContainer()
            {
                Answer = "No",
                AnswerId = (int)PossibleAnswer.No
            });
            answers.Add(new PossibleAnswerContainer()
            {
                Answer = "Sometimes",
                AnswerId = (int)PossibleAnswer.Sometimes
            });
            answers.Add(new PossibleAnswerContainer()
            {
                Answer = "Does not apply",
                AnswerId = (int)PossibleAnswer.DoesNotApply
            });

            if (showAll)
            {
                questions = questionOrch.GetAllQuestions();
            }
            else
            {
                questions = questionOrch
                    .GetQuestionsByDependencies(attachedQuestionId, attachedAnswerId);
            }

            if (questions == null)
            {
                questions = new List<Question>();
            }

            //// sort questions
            //questions.Sort();

            container.Questions = questions;
            container.Answers = answers;

            return JsonConvert.SerializeObject(container);

        }

    }
}