using Moq.Language.Flow;
using System.Threading.Tasks;

namespace Planner.Tests.Helpers
{
    internal static class TaskResultHelper
    {
        public static IReturnsResult<TMock> ReturnsEmptyTask<TMock>(this ISetup<TMock, Task> setup)
            where TMock : class
        {
            return setup.Returns(Task.FromResult<object>(null));
        }
    }
}