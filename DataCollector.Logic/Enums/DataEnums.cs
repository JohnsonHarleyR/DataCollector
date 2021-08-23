using System.ComponentModel.DataAnnotations;

namespace DataCollector.Logic.Enums
{
    public enum PossibleAnswer
    {
        Yes,
        No,
        [Display(Name = "Does not apply")]
        DoesNotApply
    }
}