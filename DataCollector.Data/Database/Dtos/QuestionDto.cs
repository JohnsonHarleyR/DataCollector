using DataCollector.Data.Database.Interfaces;

namespace DataCollector.Data.Database.Dtos
{
    public class QuestionDto : IQuestion
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public int DependentQuestionId { get; set; }
        public int DependentAnswerId { get; set; }
    }
}