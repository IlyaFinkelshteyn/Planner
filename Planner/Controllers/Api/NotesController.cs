using Planner.Models.EventsModel;
using Planner.Models.EventsViewModels;
using Planner.Services.Interfaces;

namespace Planner.Controllers.Api
{
    /// <summary>
    /// API Controller used to manipulate notes.
    /// </summary>
    /// <seealso cref="Api.SubItemControllerBase{TModel, TCreate, TDetail}" />
    public class NotesController : SubItemControllerBase<Note, NoteCreate, NoteDetails>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NotesController"/> class.
        /// </summary>
        /// <param name="service">The service used to manipulate notes.</param>
        public NotesController(ISubItemService<Note> service) : base(service)
        {
        }
    }
}