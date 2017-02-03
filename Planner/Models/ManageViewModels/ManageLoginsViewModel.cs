using Microsoft.AspNetCore.Http.Authentication;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Planner.Models.ManageViewModels
{
    [ExcludeFromCodeCoverage]
    public class ManageLoginsViewModel
    {
        public IList<UserLoginInfo> CurrentLogins { get; set; }

        public IList<AuthenticationDescription> OtherLogins { get; set; }
    }
}