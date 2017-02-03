using FluentAssertions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using Planner.Controllers.Api;
using Planner.Models;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.Xunit2;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Planner.Tests.Helpers;

namespace Planner.Tests.Controllers.Api
{
    public class AccountControllerTests
    {
        private Fixture _fixture = new Fixture();

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public async Task ConfirmEmailReturnsBadRequestIfCodeIsEmptyOrWhitespace(string code)
        {
            var userId = _fixture.Create<string>();

            var controller = new AccountController(null);
            var result = await controller.ConfirmEmail(userId, code);

            result.Should().NotBeNull().And.BeOfType<BadRequestResult>();
        }

        [Theory, AutoData]
        public async Task ConfirmEmailReturnsBadRequestIfCodeIsInvalid(string userId, string code, ApplicationUser user)
        {
            var userStore = new Mock<IUserStore<ApplicationUser>>(MockBehavior.Strict);
            var logger = new Mock<ILogger<UserManager<ApplicationUser>>>();

            userStore.Setup(s => s.FindByIdAsync(userId, It.IsAny<CancellationToken>())).ReturnsAsync(user);
            userStore.Setup(s => s.GetUserIdAsync(user, It.IsAny<CancellationToken>())).ReturnsAsync(userId);
            userStore.As<IUserEmailStore<ApplicationUser>>();

            var tokenProvider = new Mock<IUserTwoFactorTokenProvider<ApplicationUser>>();
            tokenProvider.Setup(t => t.ValidateAsync("EmailConfirmation", code, It.IsAny<UserManager<ApplicationUser>>(), user))
                .ReturnsAsync(false);

            var options = new IdentityOptions { Tokens = new TokenOptions { EmailConfirmationTokenProvider = "ConfirmProvider" } };

            var manager = new UserManager<ApplicationUser>(userStore.Object, Options.Create(options), null, null, null, null, new IdentityErrorDescriber(), null, logger.Object);
            manager.RegisterTokenProvider(options.Tokens.EmailConfirmationTokenProvider, tokenProvider.Object);

            var controller = new AccountController(manager);
            var result = await controller.ConfirmEmail(userId, code);

            result.Should().NotBeNull().And.BeOfType<BadRequestResult>();
            userStore.VerifyAll();
        }

        [Theory, AutoData]
        public async Task ConfirmEmailReturnsBadRequestIfUserDoesNotExist(string userId, string code)
        {
            var userStore = new Mock<IUserStore<ApplicationUser>>(MockBehavior.Strict);

            userStore.Setup(s => s.FindByIdAsync(userId, It.IsAny<CancellationToken>())).ReturnsAsync(null);

            var manager = new UserManager<ApplicationUser>(userStore.Object, null, null, null, null, null, null, null, null);

            var controller = new AccountController(manager);
            var result = await controller.ConfirmEmail(userId, code);

            result.Should().NotBeNull().And.BeOfType<BadRequestResult>();
            userStore.VerifyAll();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public async Task ConfirmEmailReturnsBadRequestIfUserIdIsEmptyOrWhitespace(string userId)
        {
            var code = _fixture.Create<string>();

            var controller = new AccountController(null);
            var result = await controller.ConfirmEmail(userId, code);

            result.Should().NotBeNull().And.BeOfType<BadRequestResult>();
        }

        [Theory, AutoData]
        public async Task ConfirmEmailReturnsOkayIfCodeIsValid(string userId, string code, ApplicationUser user)
        {
            var userStore = new Mock<IUserStore<ApplicationUser>>(MockBehavior.Strict);
            var logger = new Mock<ILogger<UserManager<ApplicationUser>>>();

            userStore.Setup(s => s.FindByIdAsync(userId, It.IsAny<CancellationToken>())).ReturnsAsync(user);
            userStore.Setup(s => s.GetUserNameAsync(user, It.IsAny<CancellationToken>())).ReturnsAsync(user.UserName);
            userStore.Setup(s => s.SetNormalizedUserNameAsync(user, user.UserName, It.IsAny<CancellationToken>())).ReturnsEmptyTask();
            userStore.Setup(s => s.UpdateAsync(user, It.IsAny<CancellationToken>())).ReturnsAsync(IdentityResult.Success);
            userStore.As<IUserEmailStore<ApplicationUser>>().Setup(s => s.SetEmailConfirmedAsync(user, true, It.IsAny<CancellationToken>())).ReturnsEmptyTask();
            userStore.As<IUserEmailStore<ApplicationUser>>().Setup(s => s.GetEmailAsync(user, It.IsAny<CancellationToken>())).ReturnsAsync(user.Email);
            userStore.As<IUserEmailStore<ApplicationUser>>().Setup(s => s.SetNormalizedEmailAsync(user, user.Email, It.IsAny<CancellationToken>())).ReturnsEmptyTask();

            var tokenProvider = new Mock<IUserTwoFactorTokenProvider<ApplicationUser>>();
            tokenProvider.Setup(t => t.ValidateAsync("EmailConfirmation", code, It.IsAny<UserManager<ApplicationUser>>(), user))
                .ReturnsAsync(true);

            var options = new IdentityOptions { Tokens = new TokenOptions { EmailConfirmationTokenProvider = "ConfirmProvider" } };

            var manager = new UserManager<ApplicationUser>(userStore.Object, Options.Create(options), null, null, null, null, new IdentityErrorDescriber(), null, logger.Object);
            manager.RegisterTokenProvider(options.Tokens.EmailConfirmationTokenProvider, tokenProvider.Object);

            var controller = new AccountController(manager);
            var result = await controller.ConfirmEmail(userId, code);

            result.Should().NotBeNull().And.BeOfType<OkResult>();

            userStore.VerifyAll();
        }
    }
}