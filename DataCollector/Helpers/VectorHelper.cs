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

        public static List<Vector> GenerateVectors()
        {
            ItemOrchestrator itemOrchestrator = new ItemOrchestrator();

            // start list to store the vectors
            List<Vector> vectors = new List<Vector>();

            // Get all the items to create vectors with - sort them by id
            List<Item> items = itemOrchestrator.GetAllItems().OrderBy(i => i.Id).ToList();

            // Create a dictionary for setting position ids
            Dictionary<int, int> featureDBIdToPositionId = new Dictionary<int, int>();

            // loop through the items
            int itemCount = 0;
            foreach (var item in items)
            {
                // create vector
                Vector newVector = new Vector()
                {
                    VectorId = itemCount,
                    DatabaseId = item.Id,
                    Name = item.Name
                };

                // if it's the first one, set up the item dictionary
                if (itemCount == 0)
                {
                    featureDBIdToPositionId = CreateFeatureDictionary(item.Id);
                }

                // Grab question answers to turn into vector positions - sort them by question Ids
                newVector.Features = GeneratePositionList(item.Id, featureDBIdToPositionId);

                // add new feature vector to the list
                vectors.Add(newVector);

                itemCount++;
            }

            // return list of vectors
            return vectors;
        }

        private static Dictionary<int, int> CreateFeatureDictionary(int itemId)
        {
            AnswerOrchestrator answerOrchestrator = new AnswerOrchestrator();
            QuestionOrchestrator questionOrchestrator = new QuestionOrchestrator();

            // create dictionary
            Dictionary<int, int> featureDictionary = new Dictionary<int, int>();

            // Grab question answers to turn into vector positions - sort them by question Ids
            List<Answer> itemAnswers = answerOrchestrator
                .GetAnswersByItem((int)itemId).OrderBy(a => a.QuestionId).ToList();

            int answerCount = 0;
            foreach (var answer in itemAnswers)
            {
                featureDictionary.Add(answer.QuestionId, answerCount);
                answerCount++;
            }

            return featureDictionary;

        }

        private static List<Feature> GeneratePositionList(int itemId, Dictionary<int, int> featureDictionary)
        {
            AnswerOrchestrator answerOrchestrator = new AnswerOrchestrator();
            QuestionOrchestrator questionOrchestrator = new QuestionOrchestrator();

            // Create list to add to
            List<Feature> positions = new List<Feature>();

            // Grab question answers to turn into vector positions - sort them by question Ids
            List<Answer> itemAnswers = answerOrchestrator
                .GetAnswersByItem((int)itemId).OrderBy(a => a.QuestionId).ToList();

            int answerCount = 0;
            foreach (var answer in itemAnswers)
            {
                // grab the relevent question
                Question question = questionOrchestrator.GetQuestionById(answer.QuestionId);

                // create vector position and add it to the list
                Feature newPosition = new Feature();

                // add values
                //newPosition.PositionId = answerCount;
                newPosition.DatabaseId = answer.QuestionId;
                newPosition.Name = question.QuestionString;

                // check dictionary to give it a PositionId - if it doesn't exist, add a value
                if (featureDictionary.ContainsKey(answer.QuestionId))
                {
                    newPosition.PositionId = featureDictionary[answer.QuestionId];
                }
                else
                {
                    featureDictionary.Add(answer.QuestionId, featureDictionary.Count);
                    newPosition.PositionId = featureDictionary[answer.QuestionId];
                }

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

                answerCount++;
            }

            // sort the positions by position id before returning
            positions = positions.OrderBy(p => p.PositionId).ToList();

            // return result
            return positions;
        }

    }
}