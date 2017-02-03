using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Planner.Models.ManageViewModels
{
    [ExcludeFromCodeCoverage]
    public class ConfigureTwoFactorViewModel
    {
        public ICollection<SelectListItem> Providers { get; set; }
        public string SelectedProvider { get; set; }
    }
}