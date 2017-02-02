using System;
using Microsoft.AspNetCore.JsonPatch;
using Moq;
using Planner.Controllers.Api;
using Planner.Models.EventsModel;
using Planner.Models.EventsViewModels;
using Planner.Services.Interfaces;
using Ploeh.AutoFixture;

namespace Planner.Tests.Controllers.Api
{
    public class NotesControllerTests : SubItemControllerTestsBase<NotesController, Note, NoteCreate, NoteDetails>
    {
        protected override NotesController GetController(IItemService<Note> service)
        {
            return new NotesController(service as ISubItemService<Note>);
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