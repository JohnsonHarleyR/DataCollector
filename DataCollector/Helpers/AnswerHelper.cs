using DataCollector.Logic.Models;
using DataCollector.Logic.Orchestrators;
using System.Collections.Generic;
using System.Linq;

namespace DataCollector.Helpers
{
    public static class AnswerHelper
    {
        public static List<Question> GetUnansweredQuestions(int itemId)
        {
            AnswerOrchestrator answerOrchestrator = new AnswerOrchestrator();
            QuestionOrchestrator questionOrchestrator = new QuestionOrchestrator();

            // Get all item answers and all questions
            IEnumerable<Answer> itemAnswers = answerOrchestrator.GetAnswersByItem(itemId);
            IEnumerable<Question> allQuestions = questionOrchestrator.GetAllQuestions();

            // create a list of question ids that have been answered already
            List<int> answeredQuestionIds = itemAnswers.Select(a => a.QuestionId).ToList();

            //// now add any questions to a list of unanswered questions which don't have any of those ids
            //IEnumerable<Question> unansweredQuestions = allQuestions.Where(q => !answeredQuestionIds.Contains(q.Id));

            // now add any questions to a list of unanswered questions which don't have any of those ids
            List<Question> unansweredQuestions = new List<Question>();

            foreach (var question in allQuestions)
            {
                if (!answeredQuestionIds.Contains(question.Id))
                {
                    unansweredQuestions.Add(question);
                }
            }

            // return result
            if (unansweredQuestions.Count() == 0)
            {
                return null;
            }
            return unansweredQuestions;
        }
    }
}