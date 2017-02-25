using FluentAssertions;
using Microsoft.Extensions.Options;
using Planner.Models.EventsModel;
using Planner.Models.EventsViewModels;
using Planner.Services;
using Ploeh.AutoFixture;
using System;
using Xunit;

namespace Planner.Tests.Services
{
    public class FlagServiceTests
    {
        private Fixture _fixture = new Fixture();

        [Fact]
        public void GetFlagsAddsBriefingNotesReadyIfBriefingValidAndEventSoonAndNotesNotSent()
        {
            var testEvent = GetTestEvent();

            var notesThreshold = 14;

            var options = new FlagServiceOptions
            {
                SendBriefingNotesThreshold = notesThreshold
            };

            testEvent.Date = DateTime.Today.AddDays(notesThreshold - 1);
            testEvent.Schedule.Add(_fixture.Create<ScheduleItem>());
            testEvent.Deployments.Add(_fixture.Create<Deployment>());
            testEvent.ExpectedIncidents.Add(_fixture.Create<ExpectedIncident>());
            testEvent.BriefingNotesSent = false;

            var expectedFlag = Flags.BriefingNotesReady;

            var flagService = new FlagService(Options.Create(options));

            var actualFlag = flagService.GetFlags(testEvent, expectedFlag);

            actualFlag.Should().Contain(expectedFlag);
        }

        [Fact]
        public void GetFlagsAddsBriefingNotesSentIfBriefingHasBeenSent()
        {
            var testEvent = GetTestEvent();

            var options = new FlagServiceOptions();

            testEvent.BriefingNotesSent = true;

            var expectedFlag = Flags.BriefingNotesSent;

            var flagService = new FlagService(Options.Create(options));

            var actualFlag = flagService.GetFlags(testEvent, expectedFlag);

            actualFlag.Should().Contain(expectedFlag);
        }

        [Fact]
        public void GetFlagsAddsNeedsEmailingToSoonEventNotRecentlyEmailed()
        {
            var testEvent = GetTestEvent();

            var sendEmailThreshold = 90;
            var emailCautionThreshold = 45;

            var options = new FlagServiceOptions
            {
                SendEmailThreshold = sendEmailThreshold,
                EmailCautionThreshold = emailCautionThreshold
            };

            testEvent.Date = DateTime.Today.AddDays(sendEmailThreshold - 1);
            testEvent.LastEmailedOut = DateTime.Today.AddDays(-(emailCautionThreshold + 1));

            var expectedFlag = Flags.NeedsEmailing;

            var flagService = new FlagService(Options.Create(options));

            var actualFlag = flagService.GetFlags(testEvent, expectedFlag);

            actualFlag.Should().Contain(expectedFlag);
        }

        [Fact]
        public void GetFlagsAddsUrgentCoverFlagToUrgentUncoveredConfirmedEvent()
        {
            var testEvent = GetTestEvent();

            var urgentThreshold = 15;

            var options = new FlagServiceOptions
            {
                UrgentCoverThreshold = urgentThreshold
            };

            testEvent.Date = DateTime.Today.AddDays(urgentThreshold - 1);
            testEvent.Deployments.Clear();
            testEvent.CyclistsRequested = 3;
            testEvent.DateConfirmed = true;

            var expectedFlag = Flags.UrgentCoverNeeded;

            var flagService = new FlagService(Options.Create(options));

            var actualFlag = flagService.GetFlags(testEvent, expectedFlag);

            actualFlag.Should().Contain(expectedFlag);
        }

        [Fact]
        public void GetFlagsDoesNotAddBriefingNotesReadyIfBriefingNotesAreSent()
        {
            var testEvent = GetTestEvent();

            var notesThreshold = 14;

            var options = new FlagServiceOptions
            {
                SendBriefingNotesThreshold = notesThreshold
            };

            testEvent.Date = DateTime.Today.AddDays(notesThreshold - 1);
            testEvent.Schedule.Add(_fixture.Create<ScheduleItem>());
            testEvent.Deployments.Add(_fixture.Create<Deployment>());
            testEvent.ExpectedIncidents.Add(_fixture.Create<ExpectedIncident>());
            testEvent.BriefingNotesSent = true;

            var expectedFlag = Flags.BriefingNotesReady;

            var flagService = new FlagService(Options.Create(options));

            var actualFlag = flagService.GetFlags(testEvent, expectedFlag);

            actualFlag.Should().NotContain(expectedFlag);
        }

        [Fact]
        public void GetFlagsDoesNotAddBriefingNotesReadyIfDeploymentsAreEmpty()
        {
            var testEvent = GetTestEvent();

            var notesThreshold = 14;

            var options = new FlagServiceOptions
            {
                SendBriefingNotesThreshold = notesThreshold
            };

            testEvent.Date = DateTime.Today.AddDays(notesThreshold - 1);
            testEvent.Schedule.Add(_fixture.Create<ScheduleItem>());
            testEvent.ExpectedIncidents.Add(_fixture.Create<ExpectedIncident>());
            testEvent.BriefingNotesSent = false;

            var expectedFlag = Flags.BriefingNotesReady;

            var flagService = new FlagService(Options.Create(options));

            var actualFlag = flagService.GetFlags(testEvent, expectedFlag);

            actualFlag.Should().NotContain(expectedFlag);
        }

        [Fact]
        public void GetFlagsDoesNotAddBriefingNotesReadyIfDescriptionIsBlank()
        {
            var testEvent = GetTestEvent();

            var notesThreshold = 14;

            var options = new FlagServiceOptions
            {
                SendBriefingNotesThreshold = notesThreshold
            };

            testEvent.Date = DateTime.Today.AddDays(notesThreshold - 1);
            testEvent.Schedule.Add(_fixture.Create<ScheduleItem>());
            testEvent.Deployments.Add(_fixture.Create<Deployment>());
            testEvent.ExpectedIncidents.Add(_fixture.Create<ExpectedIncident>());
            testEvent.BriefingNotesSent = false;
            testEvent.Description = string.Empty;

            var expectedFlag = Flags.BriefingNotesReady;

            var flagService = new FlagService(Options.Create(options));

            var actualFlag = flagService.GetFlags(testEvent, expectedFlag);

            actualFlag.Should().NotContain(expectedFlag);
        }

        [Fact]
        public void GetFlagsDoesNotAddBriefingNotesReadyIfEventIsDistant()
        {
            var testEvent = GetTestEvent();

            var notesThreshold = 14;

            var options = new FlagServiceOptions
            {
                SendBriefingNotesThreshold = notesThreshold
            };

            testEvent.Date = DateTime.Today.AddDays(notesThreshold + 1);
            testEvent.Schedule.Add(_fixture.Create<ScheduleItem>());
            testEvent.Deployments.Add(_fixture.Create<Deployment>());
            testEvent.ExpectedIncidents.Add(_fixture.Create<ExpectedIncident>());
            testEvent.BriefingNotesSent = false;

            var expectedFlag = Flags.BriefingNotesReady;

            var flagService = new FlagService(Options.Create(options));

            var actualFlag = flagService.GetFlags(testEvent, expectedFlag);

            actualFlag.Should().NotContain(expectedFlag);
        }

        [Fact]
        public void GetFlagsDoesNotAddBriefingNotesReadyIfExpectedIncidentsAreEmpty()
        {
            var testEvent = GetTestEvent();

            var notesThreshold = 14;

            var options = new FlagServiceOptions
            {
                SendBriefingNotesThreshold = notesThreshold
            };

            testEvent.Date = DateTime.Today.AddDays(notesThreshold - 1);
            testEvent.Schedule.Add(_fixture.Create<ScheduleItem>());
            testEvent.Deployments.Add(_fixture.Create<Deployment>());
            testEvent.BriefingNotesSent = false;

            var expectedFlag = Flags.BriefingNotesReady;

            var flagService = new FlagService(Options.Create(options));

            var actualFlag = flagService.GetFlags(testEvent, expectedFlag);

            actualFlag.Should().NotContain(expectedFlag);
        }

        [Fact]
        public void GetFlagsDoesNotAddBriefingNotesReadyIfScheduleIsBlank()
        {
            var testEvent = GetTestEvent();

            var notesThreshold = 14;

            var options = new FlagServiceOptions
            {
                SendBriefingNotesThreshold = notesThreshold
            };

            testEvent.Date = DateTime.Today.AddDays(notesThreshold - 1);
            testEvent.Deployments.Add(_fixture.Create<Deployment>());
            testEvent.ExpectedIncidents.Add(_fixture.Create<ExpectedIncident>());
            testEvent.BriefingNotesSent = false;

            var expectedFlag = Flags.BriefingNotesReady;

            var flagService = new FlagService(Options.Create(options));

            var actualFlag = flagService.GetFlags(testEvent, expectedFlag);

            actualFlag.Should().NotContain(expectedFlag);
        }

        [Fact]
        public void GetFlagsDoesNotAddBriefingNotesSentIfBriefingHasNotBeenSent()
        {
            var testEvent = GetTestEvent();

            var options = new FlagServiceOptions();

            testEvent.BriefingNotesSent = false;

            var expectedFlag = Flags.BriefingNotesSent;

            var flagService = new FlagService(Options.Create(options));

            var actualFlag = flagService.GetFlags(testEvent, expectedFlag);

            actualFlag.Should().NotContain(expectedFlag);
        }

        [Fact]
        public void GetFlagsDoesNotAddNeedsEmailingToDistantEvent()
        {
            var testEvent = GetTestEvent();

            var sendEmailThreshold = 90;
            var emailCautionThreshold = 45;

            var options = new FlagServiceOptions
            {
                SendEmailThreshold = sendEmailThreshold,
                EmailCautionThreshold = emailCautionThreshold
            };

            testEvent.Date = DateTime.Today.AddDays(sendEmailThreshold + 1);
            testEvent.LastEmailedOut = DateTime.Today.AddDays(-(emailCautionThreshold + 1));

            var expectedFlag = Flags.NeedsEmailing;

            var flagService = new FlagService(Options.Create(options));

            var actualFlag = flagService.GetFlags(testEvent, expectedFlag);

            actualFlag.Should().NotContain(expectedFlag);
        }

        [Fact]
        public void GetFlagsDoesNotAddNeedsEmailingToRecentlyEmailedEvent()
        {
            var testEvent = GetTestEvent();

            var sendEmailThreshold = 90;
            var emailCautionThreshold = 45;

            var options = new FlagServiceOptions
            {
                SendEmailThreshold = sendEmailThreshold,
                EmailCautionThreshold = emailCautionThreshold
            };

            testEvent.Date = DateTime.Today.AddDays(sendEmailThreshold - 1);
            testEvent.LastEmailedOut = DateTime.Today.AddDays(-(emailCautionThreshold - 1));

            var expectedFlag = Flags.NeedsEmailing;

            var flagService = new FlagService(Options.Create(options));

            var actualFlag = flagService.GetFlags(testEvent, expectedFlag);

            actualFlag.Should().NotContain(expectedFlag);
        }

        [Fact]
        public void GetFlagsDoesNotAddUrgentCoverFlagToCoveredEvent()
        {
            var testEvent = GetTestEvent();

            var urgentThreshold = 15;

            var options = new FlagServiceOptions
            {
                UrgentCoverThreshold = urgentThreshold
            };

            testEvent.Date = DateTime.Today.AddDays(urgentThreshold - 1);
            testEvent.Deployments.Clear();
            testEvent.Deployments.Add(_fixture.Create<Deployment>());
            testEvent.Deployments.Add(_fixture.Create<Deployment>());
            testEvent.Deployments.Add(_fixture.Create<Deployment>());
            testEvent.CyclistsRequested = 3;
            testEvent.DateConfirmed = true;

            var expectedFlag = Flags.UrgentCoverNeeded;

            var flagService = new FlagService(Options.Create(options));

            var actualFlag = flagService.GetFlags(testEvent, expectedFlag);

            actualFlag.Should().NotContain(expectedFlag);
        }

        [Fact]
        public void GetFlagsDoesNotAddUrgentCoverFlagToNonUrgentEvent()
        {
            var testEvent = GetTestEvent();

            var urgentThreshold = 15;

            var options = new FlagServiceOptions
            {
                UrgentCoverThreshold = urgentThreshold
            };

            testEvent.Date = DateTime.Today.AddDays(urgentThreshold + 1);
            testEvent.Deployments.Clear();
            testEvent.CyclistsRequested = 3;
            testEvent.DateConfirmed = true;

            var expectedFlag = Flags.UrgentCoverNeeded;

            var flagService = new FlagService(Options.Create(options));

            var actualFlag = flagService.GetFlags(testEvent, expectedFlag);

            actualFlag.Should().NotContain(expectedFlag);
        }

        [Fact]
        public void GetFlagsDoesNotAddUrgentCoverFlagToUnconfirmedEvent()
        {
            var testEvent = GetTestEvent();

            var urgentThreshold = 15;

            var options = new FlagServiceOptions
            {
                UrgentCoverThreshold = urgentThreshold
            };

            testEvent.Date = DateTime.Today.AddDays(urgentThreshold - 1);
            testEvent.Deployments.Clear();
            testEvent.CyclistsRequested = 3;
            testEvent.DateConfirmed = false;

            var expectedFlag = Flags.UrgentCoverNeeded;

            var flagService = new FlagService(Options.Create(options));

            var actualFlag = flagService.GetFlags(testEvent, expectedFlag);

            actualFlag.Should().NotContain(expectedFlag);
        }

        private Event GetTestEvent()
        {
            return _fixture.Build<Event>().Without(e => e.Deployments).Without(e => e.ExpectedIncidents).Without(e => e.NoGoAreas)
                .Without(e => e.Notes).Without(e => e.Schedule).Create();
        }
    }
}