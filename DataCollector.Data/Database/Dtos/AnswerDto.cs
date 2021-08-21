using DataCollector.Data.Database.Interfaces;

namespace DataCollector.Data.Database.Dtos
{
    public class AnswerDto : IAnswer
    {
        // NOTE this is for ItemAnswers in the database - PossibleAnswers will refer to an enum
        public int Id { get; set; }

        public int ItemId { get; set; }
        public int QuestionId { get; set; }
        public int AnswerId { get; set; }
    }
}