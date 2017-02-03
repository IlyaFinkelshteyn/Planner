using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Planner.Models.AccountViewModels
{
    [ExcludeFromCodeCoverage]
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}