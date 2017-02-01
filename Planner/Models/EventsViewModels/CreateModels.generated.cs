using Planner.Models.EventsModel;
using Planner.Models.EventsViewModels.Interfaces;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#pragma warning disable 1591

namespace Planner.Models.EventsViewModels
{
	[GeneratedCode("Model Generator", "v1"), ExcludeFromCodeCoverage]
	public partial class EmailCreate : ICreateViewModel<Email>
	{
		[Required]
		public string Name { get; set; }
		[Required]
		[EmailAddress]
		public string Address { get; set; }
		[Display(Name="Wider List")]
		public bool WideList { get; set; }
		public Email ToItem()
		{
			var item = new Email
			{
				Name = Name,
				Address = Address,
				WideList = WideList,
			};

			return item;
		}
	}
	[GeneratedCode("Model Generator", "v1"), ExcludeFromCodeCoverage]
	public partial class DeploymentCreate : ICreateViewModel<Deployment>
	{
		public string Callsign { get; set; }
		public CyclingLevel? CyclingLevel { get; set; }
		public string Name { get; set; }
		public Qualification? Qualification { get; set; }
		public int Team { get; set; }
		public Deployment ToItem()
		{
			var item = new Deployment
			{
				Callsign = Callsign,
				CyclingLevel = CyclingLevel,
				Name = Name,
				Qualification = Qualification,
				Team = Team,
			};

			return item;
		}
	}
	[GeneratedCode("Model Generator", "v1"), ExcludeFromCodeCoverage]
	public partial class EventCreate : ICreateViewModel<Event>
	{
		[Display(Name="Cyclists")]
		public int CyclistsRequested { get; set; }
		public DateTime Date { get; set; }
		[Display(Name="DIPS Number")]
		public int DipsNumber { get; set; }
		[Display(Name="End Time")]
		public TimeSpan EndTime { get; set; }
		public string Location { get; set; }
		[Required]
		public string Name { get; set; }
		[Display(Name="Start Time")]
		public TimeSpan StartTime { get; set; }
		public EventStatus Status { get; set; }
		[Display(Name="Date Confirmed")]
		public bool DateConfirmed { get; set; }
		public Event ToItem()
		{
			var item = new Event
			{
				CyclistsRequested = CyclistsRequested,
				Date = Date,
				DipsNumber = DipsNumber,
				EndTime = EndTime,
				Location = Location,
				Name = Name,
				StartTime = StartTime,
				Status = Status,
				DateConfirmed = DateConfirmed,
			};

			return item;
		}
	}
	[GeneratedCode("Model Generator", "v1"), ExcludeFromCodeCoverage]
	public partial class ExpectedIncidentCreate : ICreateViewModel<ExpectedIncident>
	{
		[Required]
		public string Name { get; set; }
		public ExpectedIncident ToItem()
		{
			var item = new ExpectedIncident
			{
				Name = Name,
			};

			return item;
		}
	}
	[GeneratedCode("Model Generator", "v1"), ExcludeFromCodeCoverage]
	public partial class NoGoAreaCreate : ICreateViewModel<NoGoArea>
	{
		[Required]
		public string Name { get; set; }
		public NoGoArea ToItem()
		{
			var item = new NoGoArea
			{
				Name = Name,
			};

			return item;
		}
	}
	[GeneratedCode("Model Generator", "v1"), ExcludeFromCodeCoverage]
	public partial class ScheduleItemCreate : ICreateViewModel<ScheduleItem>
	{
		[Required]
		public string Action { get; set; }
		public TimeSpan Time { get; set; }
		public ScheduleItem ToItem()
		{
			var item = new ScheduleItem
			{
				Action = Action,
				Time = Time,
			};

			return item;
		}
	}
}

#pragma warning restore 1591