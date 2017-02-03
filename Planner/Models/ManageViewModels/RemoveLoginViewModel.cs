using System.Diagnostics.CodeAnalysis;

namespace Planner.Models.ManageViewModels
{
    [ExcludeFromCodeCoverage]
    public class RemoveLoginViewModel
    {
        public string LoginProvider { get; set; }
        public string ProviderKey { get; set; }
    }
}