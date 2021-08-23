using DataCollector.Logic.Models;
using System.Collections.Generic;

namespace DataCollector.Models.Containers
{
    public class QuestionsContainer
    {
        public List<Question> Questions { get; set; }
        public List<PossibleAnswerContainer> Answers { get; set; }
    }
}