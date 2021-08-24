using System.ComponentModel.DataAnnotations;

namespace DataCollector.Logic.Enums
{
    public enum PossibleAnswer
    {
        Yes = 1,
        No,
        Sometimes,
        [Display(Name = "Does not apply")]
        DoesNotApply
    }
}