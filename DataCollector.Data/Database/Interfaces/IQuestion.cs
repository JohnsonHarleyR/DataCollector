namespace DataCollector.Data.Database.Interfaces
{
    public interface IQuestion
    {
        int? DependentAnswerId { get; set; }
        int? DependentQuestionId { get; set; }
        int Id { get; set; }
        string Question { get; set; }
    }
}