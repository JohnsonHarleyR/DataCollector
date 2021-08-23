using DataCollector.Logic.Models;
using System.Collections.Generic;

namespace DataCollector.Models
{
    public class AskQuestionsViewModel
    {
        public Item Item { get; set; }
        public List<Question> Questions { get; set; }
    }
}