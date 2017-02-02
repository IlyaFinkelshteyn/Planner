using Planner.Models.EventsModel.Interfaces;
using Planner.Models.EventsViewModels;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

#pragma warning disable 1591

namespace Planner.Models.EventsModel
{
	[GeneratedCode("Model Generator", "v1"), ExcludeFromCodeCoverage]
	public partial class Email : IIdentifiable, ICloneable, IEquatable<Email>
	{
		[Required]
		public string Address { get; set; }
		public int Id { get; set; }
		[Required]
		public string Name { get; set; }
		public bool WideList { get; set; }

		public object Clone()
		{
			var item = new Email
			{
				Address = Address,
				Id = Id,
				Name = Name,
				WideList = WideList,
			};

			return item;
		}

		public override bool Equals(object other)
		{
			return Equals(other as Email);
		}

		public bool Equals(Email other)
		{
			if (other == null)
				return false;

			var res = true;
			res &= Address == other.Address;
			res &= Id == other.Id;
			res &= Name == other.Name;
			res &= WideList == other.WideList;
			return res;
		}

		public override int GetHashCode()
		{
			int hash = 17;
			hash = hash * 31 + Address.GetHashCode();
			hash = hash * 31 + Id.GetHashCode();
			hash = hash * 31 + Name.GetHashCode();
			hash = hash * 31 + WideList.GetHashCode();
			return hash;
		}
	}
	[GeneratedCode("Model Generator", "v1"), ExcludeFromCodeCoverage]
	public partial class Deployment : IIdentifiable, ICloneable, IEquatable<Deployment>, IDetailable<DeploymentDetails>
	{
		public string Callsign { get; set; }
		public CyclingLevel? CyclingLevel { get; set; }
		public int Id { get; set; }
		public string Name { get; set; }
		public Qualification? Qualification { get; set; }
		public int Team { get; set; }

		public object Clone()
		{
			var item = new Deployment
			{
				Callsign = Callsign,
				CyclingLevel = CyclingLevel,
				Id = Id,
				Name = Name,
				Qualification = Qualification,
				Team = Team,
			};

			return item;
		}

		public override bool Equals(object other)
		{
			return Equals(other as Deployment);
		}

		public bool Equals(Deployment other)
		{
			if (other == null)
				return false;

			var res = true;
			res &= Callsign == other.Callsign;
			res &= CyclingLevel == other.CyclingLevel;
			res &= Id == other.Id;
			res &= Name == other.Name;
			res &= Qualification == other.Qualification;
			res &= Team == other.Team;
			return res;
		}

		public override int GetHashCode()
		{
			int hash = 17;
			hash = hash * 31 + (Callsign??string.Empty).GetHashCode();
			hash = hash * 31 + CyclingLevel.GetHashCode();
			hash = hash * 31 + Id.GetHashCode();
			hash = hash * 31 + (Name??string.Empty).GetHashCode();
			hash = hash * 31 + Qualification.GetHashCode();
			hash = hash * 31 + Team.GetHashCode();
			return hash;
		}

		public DeploymentDetails ToDetail()
		{
			return new DeploymentDetails(this);
		}
	}
	[GeneratedCode("Model Generator", "v1"), ExcludeFromCodeCoverage]
	public partial class Event : IIdentifiable, ICloneable, IEquatable<Event>, IDetailable<EventDetails>
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

		public object Clone()
		{
			var item = new Event
			{
				AmbulancesAvailable = AmbulancesAvailable,
				BriefingNotesSent = BriefingNotesSent,
				ControlPhoneNumber = ControlPhoneNumber,
				Created = Created,
				CreatedBy = CreatedBy,
				CruTrackingInUse = CruTrackingInUse,
				CyclistsRequested = CyclistsRequested,
				Date = Date,
				DateConfirmed = DateConfirmed,
				Description = Description,
				DipsNumber = DipsNumber,
				DoctorsPresent = DoctorsPresent,
				EndTime = EndTime,
				ExpectingBadWeather = ExpectingBadWeather,
				FallbackRadioChannel = FallbackRadioChannel,
				FirstAidersAvailable = FirstAidersAvailable,
				FirstAidUnitsAvailable = FirstAidUnitsAvailable,
				HasSeriousHistory = HasSeriousHistory,
				HighSpeedRoadsAtEvent = HighSpeedRoadsAtEvent,
				Id = Id,
				LastEmailedOut = LastEmailedOut,
				LastUpdated = LastUpdated,
				Location = Location,
				Name = Name,
				ParamedicsAvailable = ParamedicsAvailable,
				PostCode = PostCode,
				RadioChannel = RadioChannel,
				SoloRespondingExpected = SoloRespondingExpected,
				StartTime = StartTime,
				Status = Status,
				UpdatedBy = UpdatedBy,
				UsingAirwave = UsingAirwave,
				UsingSJARadio = UsingSJARadio,
				WiderDistribution = WiderDistribution,
			};

			return item;
		}

		public override bool Equals(object other)
		{
			return Equals(other as Event);
		}

		public bool Equals(Event other)
		{
			if (other == null)
				return false;

			var res = true;
			res &= AmbulancesAvailable == other.AmbulancesAvailable;
			res &= BriefingNotesSent == other.BriefingNotesSent;
			res &= ControlPhoneNumber == other.ControlPhoneNumber;
			res &= Created == other.Created;
			res &= CreatedBy == other.CreatedBy;
			res &= CruTrackingInUse == other.CruTrackingInUse;
			res &= CyclistsRequested == other.CyclistsRequested;
			res &= Date == other.Date;
			res &= DateConfirmed == other.DateConfirmed;
			res &= Description == other.Description;
			res &= DipsNumber == other.DipsNumber;
			res &= DoctorsPresent == other.DoctorsPresent;
			res &= EndTime == other.EndTime;
			res &= ExpectingBadWeather == other.ExpectingBadWeather;
			res &= FallbackRadioChannel == other.FallbackRadioChannel;
			res &= FirstAidersAvailable == other.FirstAidersAvailable;
			res &= FirstAidUnitsAvailable == other.FirstAidUnitsAvailable;
			res &= HasSeriousHistory == other.HasSeriousHistory;
			res &= HighSpeedRoadsAtEvent == other.HighSpeedRoadsAtEvent;
			res &= Id == other.Id;
			res &= LastEmailedOut == other.LastEmailedOut;
			res &= LastUpdated == other.LastUpdated;
			res &= Location == other.Location;
			res &= Name == other.Name;
			res &= ParamedicsAvailable == other.ParamedicsAvailable;
			res &= PostCode == other.PostCode;
			res &= RadioChannel == other.RadioChannel;
			res &= SoloRespondingExpected == other.SoloRespondingExpected;
			res &= StartTime == other.StartTime;
			res &= Status == other.Status;
			res &= UpdatedBy == other.UpdatedBy;
			res &= UsingAirwave == other.UsingAirwave;
			res &= UsingSJARadio == other.UsingSJARadio;
			res &= WiderDistribution == other.WiderDistribution;
			return res;
		}

		public override int GetHashCode()
		{
			int hash = 17;
			hash = hash * 31 + AmbulancesAvailable.GetHashCode();
			hash = hash * 31 + BriefingNotesSent.GetHashCode();
			hash = hash * 31 + (ControlPhoneNumber??string.Empty).GetHashCode();
			hash = hash * 31 + Created.GetHashCode();
			hash = hash * 31 + (CreatedBy??string.Empty).GetHashCode();
			hash = hash * 31 + CruTrackingInUse.GetHashCode();
			hash = hash * 31 + CyclistsRequested.GetHashCode();
			hash = hash * 31 + Date.GetHashCode();
			hash = hash * 31 + DateConfirmed.GetHashCode();
			hash = hash * 31 + (Description??string.Empty).GetHashCode();
			hash = hash * 31 + DipsNumber.GetHashCode();
			hash = hash * 31 + DoctorsPresent.GetHashCode();
			hash = hash * 31 + EndTime.GetHashCode();
			hash = hash * 31 + ExpectingBadWeather.GetHashCode();
			hash = hash * 31 + (FallbackRadioChannel??string.Empty).GetHashCode();
			hash = hash * 31 + FirstAidersAvailable.GetHashCode();
			hash = hash * 31 + FirstAidUnitsAvailable.GetHashCode();
			hash = hash * 31 + HasSeriousHistory.GetHashCode();
			hash = hash * 31 + HighSpeedRoadsAtEvent.GetHashCode();
			hash = hash * 31 + Id.GetHashCode();
			hash = hash * 31 + LastEmailedOut.GetHashCode();
			hash = hash * 31 + LastUpdated.GetHashCode();
			hash = hash * 31 + (Location??string.Empty).GetHashCode();
			hash = hash * 31 + Name.GetHashCode();
			hash = hash * 31 + ParamedicsAvailable.GetHashCode();
			hash = hash * 31 + (PostCode??string.Empty).GetHashCode();
			hash = hash * 31 + (RadioChannel??string.Empty).GetHashCode();
			hash = hash * 31 + SoloRespondingExpected.GetHashCode();
			hash = hash * 31 + StartTime.GetHashCode();
			hash = hash * 31 + Status.GetHashCode();
			hash = hash * 31 + (UpdatedBy??string.Empty).GetHashCode();
			hash = hash * 31 + UsingAirwave.GetHashCode();
			hash = hash * 31 + UsingSJARadio.GetHashCode();
			hash = hash * 31 + WiderDistribution.GetHashCode();
			return hash;
		}

		public EventDetails ToDetail()
		{
			return new EventDetails(this);
		}
	}
	[GeneratedCode("Model Generator", "v1"), ExcludeFromCodeCoverage]
	public partial class ExpectedIncident : IIdentifiable, ICloneable, IEquatable<ExpectedIncident>, IDetailable<ExpectedIncidentDetails>
	{
		public int Id { get; set; }
		[Required]
		public string Name { get; set; }

		public object Clone()
		{
			var item = new ExpectedIncident
			{
				Id = Id,
				Name = Name,
			};

			return item;
		}

		public override bool Equals(object other)
		{
			return Equals(other as ExpectedIncident);
		}

		public bool Equals(ExpectedIncident other)
		{
			if (other == null)
				return false;

			var res = true;
			res &= Id == other.Id;
			res &= Name == other.Name;
			return res;
		}

		public override int GetHashCode()
		{
			int hash = 17;
			hash = hash * 31 + Id.GetHashCode();
			hash = hash * 31 + Name.GetHashCode();
			return hash;
		}

		public ExpectedIncidentDetails ToDetail()
		{
			return new ExpectedIncidentDetails(this);
		}
	}
	[GeneratedCode("Model Generator", "v1"), ExcludeFromCodeCoverage]
	public partial class NoGoArea : IIdentifiable, ICloneable, IEquatable<NoGoArea>, IDetailable<NoGoAreaDetails>
	{
		public int Id { get; set; }
		[Required]
		public string Name { get; set; }

		public object Clone()
		{
			var item = new NoGoArea
			{
				Id = Id,
				Name = Name,
			};

			return item;
		}

		public override bool Equals(object other)
		{
			return Equals(other as NoGoArea);
		}

		public bool Equals(NoGoArea other)
		{
			if (other == null)
				return false;

			var res = true;
			res &= Id == other.Id;
			res &= Name == other.Name;
			return res;
		}

		public override int GetHashCode()
		{
			int hash = 17;
			hash = hash * 31 + Id.GetHashCode();
			hash = hash * 31 + Name.GetHashCode();
			return hash;
		}

		public NoGoAreaDetails ToDetail()
		{
			return new NoGoAreaDetails(this);
		}
	}
	[GeneratedCode("Model Generator", "v1"), ExcludeFromCodeCoverage]
	public partial class Note : IIdentifiable, ICloneable, IEquatable<Note>, IDetailable<NoteDetails>
	{
		public int Id { get; set; }
		public int SortNumber { get; set; }
		[Required]
		public string Text { get; set; }

		public object Clone()
		{
			var item = new Note
			{
				Id = Id,
				SortNumber = SortNumber,
				Text = Text,
			};

			return item;
		}

		public override bool Equals(object other)
		{
			return Equals(other as Note);
		}

		public bool Equals(Note other)
		{
			if (other == null)
				return false;

			var res = true;
			res &= Id == other.Id;
			res &= SortNumber == other.SortNumber;
			res &= Text == other.Text;
			return res;
		}

		public override int GetHashCode()
		{
			int hash = 17;
			hash = hash * 31 + Id.GetHashCode();
			hash = hash * 31 + SortNumber.GetHashCode();
			hash = hash * 31 + Text.GetHashCode();
			return hash;
		}

		public NoteDetails ToDetail()
		{
			return new NoteDetails(this);
		}
	}
	[GeneratedCode("Model Generator", "v1"), ExcludeFromCodeCoverage]
	public partial class ScheduleItem : IIdentifiable, ICloneable, IEquatable<ScheduleItem>, IDetailable<ScheduleItemDetails>
	{
		[Required]
		public string Action { get; set; }
		public int Id { get; set; }
		public TimeSpan Time { get; set; }

		public object Clone()
		{
			var item = new ScheduleItem
			{
				Action = Action,
				Id = Id,
				Time = Time,
			};

			return item;
		}

		public override bool Equals(object other)
		{
			return Equals(other as ScheduleItem);
		}

		public bool Equals(ScheduleItem other)
		{
			if (other == null)
				return false;

			var res = true;
			res &= Action == other.Action;
			res &= Id == other.Id;
			res &= Time == other.Time;
			return res;
		}

		public override int GetHashCode()
		{
			int hash = 17;
			hash = hash * 31 + Action.GetHashCode();
			hash = hash * 31 + Id.GetHashCode();
			hash = hash * 31 + Time.GetHashCode();
			return hash;
		}

		public ScheduleItemDetails ToDetail()
		{
			return new ScheduleItemDetails(this);
		}
	}
}

#pragma warning restore 1591