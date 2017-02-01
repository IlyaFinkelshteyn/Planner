using Planner.Models.EventsModel.Interfaces;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

#pragma warning disable 1591

namespace Planner.Models.EventsModel
{
	[GeneratedCode("Model Generator", "v1"), ExcludeFromCodeCoverage]
	public partial class Email : IIdentifiable
	{
		[Required]
		public string Address { get; set; }
		public int Id { get; set; }
		[Required]
		public string Name { get; set; }
		public bool WideList { get; set; }
	}
	[GeneratedCode("Model Generator", "v1"), ExcludeFromCodeCoverage]
	public partial class Deployment : IIdentifiable
	{
		public string Callsign { get; set; }
		public CyclingLevel? CyclingLevel { get; set; }
		public int Id { get; set; }
		public string Name { get; set; }
		public Qualification? Qualification { get; set; }
		public int Team { get; set; }
	}
	[GeneratedCode("Model Generator", "v1"), ExcludeFromCodeCoverage]
	public partial class Event : IIdentifiable
	{
		public int AmbulancesAvailable { get; set; }
		public bool BriefingNotesSent { get; set; }
		public string ControlPhoneNumber { get; set; }
		public DateTime Created { get; set; }
		public string CreatedBy { get; set; }
		public bool CruTrackingInUse { get; set; }
		public int CyclistsRequested { get; set; }
		public DateTime Date { get; set; }
		public bool DateConfirmed { get; set; }
		public virtual ICollection<Deployment> Deployments { get; set; } = new HashSet<Deployment>();
		public string Description { get; set; }
		public int DipsNumber { get; set; }
		public bool DoctorsPresent { get; set; }
		public TimeSpan EndTime { get; set; }
		public virtual ICollection<ExpectedIncident> ExpectedIncidents { get; set; } = new HashSet<ExpectedIncident>();
		public bool ExpectingBadWeather { get; set; }
		public string FallbackRadioChannel { get; set; }
		public int FirstAidersAvailable { get; set; }
		public int FirstAidUnitsAvailable { get; set; }
		public bool HasSeriousHistory { get; set; }
		public bool HighSpeedRoadsAtEvent { get; set; }
		public int Id { get; set; }
		public DateTime LastEmailedOut { get; set; }
		public DateTime LastUpdated { get; set; }
		public string Location { get; set; }
		[Required]
		public string Name { get; set; }
		public virtual ICollection<NoGoArea> NoGoAreas { get; set; } = new HashSet<NoGoArea>();
		public virtual ICollection<Note> Notes { get; set; } = new HashSet<Note>();
		public bool ParamedicsAvailable { get; set; }
		public string PostCode { get; set; }
		public string RadioChannel { get; set; }
		public virtual ICollection<ScheduleItem> Schedule { get; set; } = new HashSet<ScheduleItem>();
		public bool SoloRespondingExpected { get; set; }
		public TimeSpan StartTime { get; set; }
		public EventStatus Status { get; set; }
		public string UpdatedBy { get; set; }
		public bool UsingAirwave { get; set; }
		public bool UsingSJARadio { get; set; }
		public bool WiderDistribution { get; set; }
	}
	[GeneratedCode("Model Generator", "v1"), ExcludeFromCodeCoverage]
	public partial class ExpectedIncident : IIdentifiable
	{
		public int Id { get; set; }
		[Required]
		public string Name { get; set; }
	}
	[GeneratedCode("Model Generator", "v1"), ExcludeFromCodeCoverage]
	public partial class NoGoArea : IIdentifiable
	{
		public int Id { get; set; }
		[Required]
		public string Name { get; set; }
	}
	[GeneratedCode("Model Generator", "v1"), ExcludeFromCodeCoverage]
	public partial class Note : IIdentifiable
	{
		public int Id { get; set; }
		public int SortNumber { get; set; }
		[Required]
		public string Text { get; set; }
	}
	[GeneratedCode("Model Generator", "v1"), ExcludeFromCodeCoverage]
	public partial class ScheduleItem : IIdentifiable
	{
		[Required]
		public string Action { get; set; }
		public int Id { get; set; }
		public TimeSpan Time { get; set; }
	}
}

#pragma warning restore 1591