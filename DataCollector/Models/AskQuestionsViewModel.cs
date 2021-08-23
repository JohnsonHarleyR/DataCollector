using DataCollector.Logic.Models;
using System.Collections.Generic;

namespace DataCollector.Models
{
    public class AskQuestionsViewModel
    {
        public string ItemName { get; set; }
        public int ItemId { get; set; }
        public List<Question> Questions { get; set; }
    }
}