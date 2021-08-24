using DataCollector.Logic.Models;
using DataCollector.Logic.Orchestrators;
using System.Collections.Generic;
using System.Linq;

namespace DataCollector.Helpers
{
    public static class AnswerHelper
    {
        //// answer any dependent questions that go against an answer
        //public static void AutoAnswerIrrelevant(Answer answer)
        //{
        //    ItemOrchestrator itemOrchestrator = new ItemOrchestrator();
        //    QuestionOrchestrator questionOrchestrator = new QuestionOrchestrator();
        //    AnswerOrchestrator answerOrchestrator = new AnswerOrchestrator();

        //    // create a list to store any answers that get auto answered - for recursion
        //    List<Answer> autoAnswers = new List<Answer>();

        //    // store the relevent question id
        //    int questionId = answer.QuestionId;
        //    int newAnswer = -1;

        //    // store the other two answers to the question that were not chose
        //    List<int> unchosenAnswerIds = new List<int>();

        //    if ((PossibleAnswer)answer.AnswerId == PossibleAnswer.Yes)
        //    {
        //        newAnswer = (int)PossibleAnswer.No;
        //    }
        //    if ((PossibleAnswer)answer.AnswerId == PossibleAnswer.No)
        //    {
        //        newAnswer = (int)PossibleAnswer.Yes;
        //    }
        //    //if ((PossibleAnswer)answer.AnswerId != PossibleAnswer.DoesNotApply)
        //    //{
        //    //    newAnswer = (int)PossibleAnswer.DoesNotApply;
        //    //}

        //    if ((PossibleAnswer)answer.AnswerId != PossibleAnswer.Yes)
        //    {
        //        unchosenAnswerIds.Add((int)PossibleAnswer.Yes);
        //    }
        //    if ((PossibleAnswer)answer.AnswerId != PossibleAnswer.No)
        //    {
        //        unchosenAnswerIds.Add((int)PossibleAnswer.No);
        //    }
        //    //if ((PossibleAnswer)answer.AnswerId != PossibleAnswer.DoesNotApply)
        //    //{
        //    //    unchosenAnswerIds.Add((int)PossibleAnswer.DoesNotApply);
        //    //}

        //    // Grab all the unanswered item question Ids
        //    List<int> allUnansweredIds = GetUnansweredQuestions(answer.ItemId).Select(q => q.Id).ToList();

        //    if (allUnansweredIds != null && newAnswer != -1)
        //    {
        //        // loop through the other answers to the question - grab any questions dependent on that answer
        //        foreach (var possibleAnswerId in unchosenAnswerIds)
        //        {
        //            // grab all questions with these variables
        //            List<Question> questions = questionOrchestrator.GetQuestionsByDependencies(questionId, possibleAnswerId);

        //            if (questions != null)
        //            {
        //                // loop through those questions and auto answer them while storing the ids
        //                foreach (var question in questions)
        //                {
        //                    allUnansweredIds.Add(question.Id);
        //                    Answer autoAnswer = new Answer()
        //                    {
        //                        ItemId = answer.ItemId,
        //                        QuestionId = question.Id,
        //                        AnswerId = newAnswer
        //                    };

        //                    // save answer
        //                    answerOrchestrator.AddAnswer(autoAnswer);

        //                    // add answer to new answers
        //                    autoAnswers.Add(autoAnswer);

        //                }
        //            }

        //            // now use recursion on newly answered questions
        //            foreach (var a in autoAnswers)
        //            {
        //                AutoAnswerIrrelevant(a);
        //            }

        //        }
        //    }



        //}


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