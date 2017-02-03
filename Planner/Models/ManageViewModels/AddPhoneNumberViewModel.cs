using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Planner.Models.ManageViewModels
{
    [ExcludeFromCodeCoverage]
    public class AddPhoneNumberViewModel
    {
        [Required]
        [Phone]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }
    }
}