using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Planner.Models;
using Microsoft.AspNetCore.Identity;

namespace Planner.Controllers.Api
{
    /// <summary>
    /// API controller to deal with account management
    /// </summary>
    [Route("api/Account")]
    public class AccountController : Controller
    {
        private UserManager<ApplicationUser> _userManager;

        public AccountController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        /// <summary>
        /// Uses a user ID and verification code to confirm an email address.
        /// </summary>
        /// <param name="userId">The user's ID.</param>
        /// <param name="code">The verification code.</param>
        /// <returns>BadRequest if the input is valid.</returns>
        /// <response code="400">User ID or verification code is invalid</response>
        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            if (string.IsNullOrWhiteSpace(userId) || string.IsNullOrWhiteSpace(code))
                return BadRequest();

            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
                return BadRequest();

            var result = await _userManager.ConfirmEmailAsync(user, code);

            if (!result.Succeeded)
                return BadRequest();

            return Ok();
        }
    }
}