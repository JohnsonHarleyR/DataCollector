namespace DataCollector.Data.Database.Interfaces
{
    public interface IAnswer
    {
        int AnswerId { get; set; }
        int Id { get; set; }
        int ItemId { get; set; }
        int QuestionId { get; set; }
    }
}