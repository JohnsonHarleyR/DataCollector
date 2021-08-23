using DataCollector.Data.Database.Interfaces;
using DataCollector.Logic.Enums;

namespace DataCollector.Logic.Models
{
    public class Answer : IAnswer
    {

        // NOTE this is for ItemAnswers in the database - PossibleAnswers will refer to an enum
        public int Id { get; set; }

        public Item Item { get; set; }
        public int ItemId { get; set; }
        public Question Question { get; set; }
        public int QuestionId { get; set; }
        public PossibleAnswer AnswerEnum { get; set; }
        public int AnswerId { get; set; }

    }
}
