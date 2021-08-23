using System.ComponentModel.DataAnnotations;

namespace DataCollector.Logic.Enums
{
    public enum PossibleAnswers
    {
        Yes,
        No,
        [Display(Name = "Does not apply")]
        DoesNotApply
    }
}