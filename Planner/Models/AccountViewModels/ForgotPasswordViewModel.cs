using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Planner.Models.AccountViewModels
{
    [ExcludeFromCodeCoverage]
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}