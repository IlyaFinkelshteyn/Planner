using System.Diagnostics.CodeAnalysis;

namespace Planner.Controllers.Api.Results
{
    /// <summary>
    /// The standard result when an item is created, containing the item's ID.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class IdResult
    {
        /// <summary>
        /// The ID of the item.
        /// </summary>
        public int Id { get; set; }
    }
}