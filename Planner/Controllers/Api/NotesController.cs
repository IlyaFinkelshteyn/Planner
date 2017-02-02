using Planner.Models.EventsModel;
using Planner.Models.EventsViewModels;
using Planner.Services.Interfaces;

namespace Planner.Controllers.Api
{
    public class NotesController : SubItemControllerBase<Note, NoteCreate, NoteDetails>
    {
        public NotesController(ISubItemService<Note> service) : base(service)
        {
        }
    }
}