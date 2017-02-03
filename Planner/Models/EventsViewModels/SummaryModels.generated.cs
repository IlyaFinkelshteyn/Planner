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
		public override bool Equals(object other)
		{
			return Equals(other as EmailSummary);
		}

		public bool Equals(EmailSummary other)
		{
			if (other == null)
				return false;

			var res = true;
			res &= Id == other.Id;
			res &= Name == other.Name;
			res &= Address == other.Address;
			res &= WideList == other.WideList;
			return res;
		}

		public override int GetHashCode()
		{
			int hash = 17;
			hash = hash * 31 + Id.GetHashCode();
			hash = hash * 31 + Name.GetHashCode();
			hash = hash * 31 + Address.GetHashCode();
			hash = hash * 31 + WideList.GetHashCode();
			return hash;
		}
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
		public override bool Equals(object other)
		{
			return Equals(other as EventSummary);
		}

		public bool Equals(EventSummary other)
		{
			if (other == null)
				return false;

			var res = true;
			res &= CyclistsRequested == other.CyclistsRequested;
			res &= Date == other.Date;
			res &= DipsNumber == other.DipsNumber;
			res &= EndTime == other.EndTime;
			res &= Id == other.Id;
			res &= Name == other.Name;
			res &= StartTime == other.StartTime;
			res &= Status == other.Status;
			res &= WiderDistribution == other.WiderDistribution;
			res &= BriefingNotesSent == other.BriefingNotesSent;
			res &= DateConfirmed == other.DateConfirmed;
			res &= Created == other.Created;
			res &= LastUpdated == other.LastUpdated;
			res &= CreatedBy == other.CreatedBy;
			res &= UpdatedBy == other.UpdatedBy;
			return res;
		}

		public override int GetHashCode()
		{
			int hash = 17;
			hash = hash * 31 + CyclistsRequested.GetHashCode();
			hash = hash * 31 + Date.GetHashCode();
			hash = hash * 31 + DipsNumber.GetHashCode();
			hash = hash * 31 + EndTime.GetHashCode();
			hash = hash * 31 + Id.GetHashCode();
			hash = hash * 31 + Name.GetHashCode();
			hash = hash * 31 + StartTime.GetHashCode();
			hash = hash * 31 + Status.GetHashCode();
			hash = hash * 31 + WiderDistribution.GetHashCode();
			hash = hash * 31 + BriefingNotesSent.GetHashCode();
			hash = hash * 31 + DateConfirmed.GetHashCode();
			hash = hash * 31 + Created.GetHashCode();
			hash = hash * 31 + LastUpdated.GetHashCode();
			hash = hash * 31 + (CreatedBy??string.Empty).GetHashCode();
			hash = hash * 31 + (UpdatedBy??string.Empty).GetHashCode();
			return hash;
		}
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