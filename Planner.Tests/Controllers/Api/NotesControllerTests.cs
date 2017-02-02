using Microsoft.AspNetCore.JsonPatch;
using Planner.Controllers.Api;
using Planner.Models.EventsModel;
using Planner.Models.EventsViewModels;
using Planner.Services.Interfaces;
using Ploeh.AutoFixture;

namespace Planner.Tests.Controllers.Api
{
    public class NotesControllerTests : SubItemControllerTestsBase<NotesController, Note, NoteCreate, NoteDetails>
    {
        protected override NotesController GetController(ISubItemService<Note> service)
        {
            return new NotesController(service);
        }

        protected override JsonPatchDocument<Note> GetPatch()
        {
            var patch = new JsonPatchDocument<Note>();

            var newText = Fixture.Create<string>();

            patch.Replace(d => d.Text, newText);

            return patch;
        }
    }
}