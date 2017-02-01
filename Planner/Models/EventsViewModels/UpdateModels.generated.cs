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
	public partial class EmailUpdate : IUpdateViewModel<Email>
	{
		public EmailUpdate() { }

		public EmailUpdate(Email item)
		{
			Id = item.Id;
			Name = item.Name;
			Address = item.Address;
			WideList = item.WideList;
		}
		public int Id { get; set; }
		[Required]
		public string Name { get; set; }
		[Required]
		[EmailAddress]
		public string Address { get; set; }
		[Display(Name="Wider List")]
		public bool WideList { get; set; }
		public void UpdateItem(Email item)
		{
			item.Id = Id;
			item.Name = Name;
			item.Address = Address;
			item.WideList = WideList;
		}
	}
	[GeneratedCode("Model Generator", "v1"), ExcludeFromCodeCoverage]
	public partial class DeploymentUpdate : IUpdateViewModel<Deployment>
	{
		public DeploymentUpdate() { }

		public DeploymentUpdate(Deployment item)
		{
			Callsign = item.Callsign;
			CyclingLevel = item.CyclingLevel;
			Id = item.Id;
			Name = item.Name;
			Qualification = item.Qualification;
			Team = item.Team;
		}
		public string Callsign { get; set; }
		public CyclingLevel? CyclingLevel { get; set; }
		public int Id { get; set; }
		public string Name { get; set; }
		public Qualification? Qualification { get; set; }
		public int Team { get; set; }
		public void UpdateItem(Deployment item)
		{
			item.Callsign = Callsign;
			item.CyclingLevel = CyclingLevel;
			item.Id = Id;
			item.Name = Name;
			item.Qualification = Qualification;
			item.Team = Team;
		}
	}
	[GeneratedCode("Model Generator", "v1"), ExcludeFromCodeCoverage]
	public partial class EventUpdate : IUpdateViewModel<Event>
	{
		public EventUpdate() { }

		public EventUpdate(Event item)
		{
			AmbulancesAvailable = item.AmbulancesAvailable;
			ControlPhoneNumber = item.ControlPhoneNumber;
			CruTrackingInUse = item.CruTrackingInUse;
			CyclistsRequested = item.CyclistsRequested;
			Date = item.Date;
			Description = item.Description;
			DipsNumber = item.DipsNumber;
			DoctorsPresent = item.DoctorsPresent;
			EndTime = item.EndTime;
			ExpectingBadWeather = item.ExpectingBadWeather;
			FallbackRadioChannel = item.FallbackRadioChannel;
			FirstAidersAvailable = item.FirstAidersAvailable;
			FirstAidUnitsAvailable = item.FirstAidUnitsAvailable;
			HasSeriousHistory = item.HasSeriousHistory;
			HighSpeedRoadsAtEvent = item.HighSpeedRoadsAtEvent;
			Id = item.Id;
			Location = item.Location;
			Name = item.Name;
			ParamedicsAvailable = item.ParamedicsAvailable;
			PostCode = item.PostCode;
			RadioChannel = item.RadioChannel;
			SoloRespondingExpected = item.SoloRespondingExpected;
			StartTime = item.StartTime;
			Status = item.Status;
			UsingAirwave = item.UsingAirwave;
			UsingSJARadio = item.UsingSJARadio;
			WiderDistribution = item.WiderDistribution;
			DateConfirmed = item.DateConfirmed;
		}
		[Display(Name="Ambulances")]
		public int AmbulancesAvailable { get; set; }
		[Display(Name="Control Phone")]
		public string ControlPhoneNumber { get; set; }
		[Display(Name="Tracking Available")]
		public bool CruTrackingInUse { get; set; }
		[Display(Name="Cyclists")]
		public int CyclistsRequested { get; set; }
		public DateTime Date { get; set; }
		public string Description { get; set; }
		[Display(Name="DIPS Number")]
		public int DipsNumber { get; set; }
		[Display(Name="Doctors Available")]
		public bool DoctorsPresent { get; set; }
		[Display(Name="End Time")]
		public TimeSpan EndTime { get; set; }
		[Display(Name="Bad Weather Expected")]
		public bool ExpectingBadWeather { get; set; }
		[Display(Name="Fallback Radio Channel")]
		public string FallbackRadioChannel { get; set; }
		[Display(Name="First Aiders")]
		public int FirstAidersAvailable { get; set; }
		[Display(Name="First Aid Units")]
		public int FirstAidUnitsAvailable { get; set; }
		[Display(Name="Has Serious History")]
		public bool HasSeriousHistory { get; set; }
		[Display(Name="High Speed Roads Expected")]
		public bool HighSpeedRoadsAtEvent { get; set; }
		public int Id { get; set; }
		public string Location { get; set; }
		[Required]
		public string Name { get; set; }
		[Display(Name="Paramedics Available")]
		public bool ParamedicsAvailable { get; set; }
		[Display(Name="Post Code")]
		public string PostCode { get; set; }
		[Display(Name="Radio Channel")]
		public string RadioChannel { get; set; }
		[Display(Name="Solo-Responding Expected")]
		public bool SoloRespondingExpected { get; set; }
		[Display(Name="Start Time")]
		public TimeSpan StartTime { get; set; }
		public EventStatus Status { get; set; }
		[Display(Name="Airwave In Use")]
		public bool UsingAirwave { get; set; }
		[Display(Name="SJA Radios In Use")]
		public bool UsingSJARadio { get; set; }
		[Display(Name="Event Needs Wide Distribution")]
		public bool WiderDistribution { get; set; }
		[Display(Name="Date Confirmed")]
		public bool DateConfirmed { get; set; }
		public void UpdateItem(Event item)
		{
			item.AmbulancesAvailable = AmbulancesAvailable;
			item.ControlPhoneNumber = ControlPhoneNumber;
			item.CruTrackingInUse = CruTrackingInUse;
			item.CyclistsRequested = CyclistsRequested;
			item.Date = Date;
			item.Description = Description;
			item.DipsNumber = DipsNumber;
			item.DoctorsPresent = DoctorsPresent;
			item.EndTime = EndTime;
			item.ExpectingBadWeather = ExpectingBadWeather;
			item.FallbackRadioChannel = FallbackRadioChannel;
			item.FirstAidersAvailable = FirstAidersAvailable;
			item.FirstAidUnitsAvailable = FirstAidUnitsAvailable;
			item.HasSeriousHistory = HasSeriousHistory;
			item.HighSpeedRoadsAtEvent = HighSpeedRoadsAtEvent;
			item.Id = Id;
			item.Location = Location;
			item.Name = Name;
			item.ParamedicsAvailable = ParamedicsAvailable;
			item.PostCode = PostCode;
			item.RadioChannel = RadioChannel;
			item.SoloRespondingExpected = SoloRespondingExpected;
			item.StartTime = StartTime;
			item.Status = Status;
			item.UsingAirwave = UsingAirwave;
			item.UsingSJARadio = UsingSJARadio;
			item.WiderDistribution = WiderDistribution;
			item.DateConfirmed = DateConfirmed;
		}
	}
	[GeneratedCode("Model Generator", "v1"), ExcludeFromCodeCoverage]
	public partial class ScheduleItemUpdate : IUpdateViewModel<ScheduleItem>
	{
		public ScheduleItemUpdate() { }

		public ScheduleItemUpdate(ScheduleItem item)
		{
			Id = item.Id;
			Action = item.Action;
			Time = item.Time;
		}
		public int Id { get; set; }
		[Required]
		public string Action { get; set; }
		public TimeSpan Time { get; set; }
		public void UpdateItem(ScheduleItem item)
		{
			item.Id = Id;
			item.Action = Action;
			item.Time = Time;
		}
	}
}

#pragma warning restore 1591