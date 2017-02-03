using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Planner.Models.AccountViewModels
{
    [ExcludeFromCodeCoverage]
    public class SendCodeViewModel
    {
        public ICollection<SelectListItem> Providers { get; set; }
        public bool RememberMe { get; set; }
        public string ReturnUrl { get; set; }
        public string SelectedProvider { get; set; }
    }
}