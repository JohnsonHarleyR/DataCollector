using DataCollector.Logic.Enums;
using DataCollector.Logic.Models;
using DataCollector.Logic.Orchestrators;
using FeatureVectors.Classes;
using System.Collections.Generic;
using System.Linq;

namespace DataCollector.Helpers
{
    public static class VectorHelper
    {

        public static List<FeatureVector> GenerateVectors()
        {
            ItemOrchestrator itemOrchestrator = new ItemOrchestrator();

            // start list to store the vectors
            List<FeatureVector> vectors = new List<FeatureVector>();

            // Get all the items to create vectors with - sort them by id
            List<Item> items = itemOrchestrator.GetAllItems().OrderBy(i => i.Id).ToList();

            // loop through the items
            foreach (var item in items)
            {
                // create vector
                FeatureVector newVector = new FeatureVector()
                {
                    Id = item.Id,
                    Name = item.Name
                };

                // Grab question answers to turn into vector positions - sort them by question Ids
                newVector.Positions = GeneratePositionList(item.Id);

                // add new feature vector to the list
                vectors.Add(newVector);

            }

            // return list of vectors
            return vectors;
        }


        private static List<VectorPosition> GeneratePositionList(int itemId)
        {
            AnswerOrchestrator answerOrchestrator = new AnswerOrchestrator();
            QuestionOrchestrator questionOrchestrator = new QuestionOrchestrator();

            // Create list to add to
            List<VectorPosition> positions = new List<VectorPosition>();

            // Grab question answers to turn into vector positions - sort them by question Ids
            List<Answer> itemAnswers = answerOrchestrator
                .GetAnswersByItem((int)itemId).OrderBy(a => a.QuestionId).ToList();

            foreach (var answer in itemAnswers)
            {
                // grab the relevent question
                Question question = questionOrchestrator.GetQuestionById(answer.QuestionId);

                // create vector position and add it to the list
                VectorPosition newPosition = new VectorPosition();

                // add values
                newPosition.Id = answer.QuestionId;
                newPosition.Name = question.QuestionString;

                // if the answer is yes or sometimes, set bool to true. Otherwise, set it to false.
                if ((PossibleAnswer)answer.AnswerId == PossibleAnswer.Yes ||
                    (PossibleAnswer)answer.AnswerId == PossibleAnswer.Sometimes)
                {
                    newPosition.Value = true;
                }
                else
                {
                    newPosition.Value = false;
                }
                // add to position list
                positions.Add(newPosition);
            }

            // return result
            return positions;
        }

    }
}