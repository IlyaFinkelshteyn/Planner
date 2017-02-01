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
	public partial class EmailSummary
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Address { get; set; }
		[Display(Name="Wider List")]
		public bool WideList { get; set; }
		public EmailSummary(Email item)
		{
			Id = item.Id;
			Name = item.Name;
			Address = item.Address;
			WideList = item.WideList;
		}
	}
	[GeneratedCode("Model Generator", "v1"), ExcludeFromCodeCoverage]
	public partial class EventSummary
	{
		[Display(Name="Cyclists")]
		public int CyclistsRequested { get; set; }
		public DateTime Date { get; set; }
		[Display(Name="DIPS Number")]
		public int DipsNumber { get; set; }
		[Display(Name="End Time")]
		public TimeSpan EndTime { get; set; }
		public int Id { get; set; }
		public string Name { get; set; }
		[Display(Name="Start Time")]
		public TimeSpan StartTime { get; set; }
		public EventStatus Status { get; set; }
		[Display(Name="Event Needs Wide Distribution")]
		public bool WiderDistribution { get; set; }
		public bool BriefingNotesSent { get; set; }
		[Display(Name="Date Confirmed")]
		public bool DateConfirmed { get; set; }
		public DateTime Created { get; set; }
		public DateTime LastUpdated { get; set; }
		public string CreatedBy { get; set; }
		public string UpdatedBy { get; set; }
		public EventSummary(Event item)
		{
			CyclistsRequested = item.CyclistsRequested;
			Date = item.Date;
			DipsNumber = item.DipsNumber;
			EndTime = item.EndTime;
			Id = item.Id;
			Name = item.Name;
			StartTime = item.StartTime;
			Status = item.Status;
			WiderDistribution = item.WiderDistribution;
			BriefingNotesSent = item.BriefingNotesSent;
			DateConfirmed = item.DateConfirmed;
			Created = item.Created;
			LastUpdated = item.LastUpdated;
			CreatedBy = item.CreatedBy;
			UpdatedBy = item.UpdatedBy;
		}
	}
}

#pragma warning restore 1591