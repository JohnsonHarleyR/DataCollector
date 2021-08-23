namespace DataCollector.Logic.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string QuestionString { get; set; }
        public int? DependentQuestionId { get; set; }
        public Question DependentQuestion { get; set; }
        public int? DependentAnswerId { get; set; }
    }
}
