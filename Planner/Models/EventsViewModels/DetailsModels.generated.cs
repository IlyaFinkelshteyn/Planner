﻿using Planner.Models.EventsModel;
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
	public partial class DeploymentDetails
	{
		public DeploymentDetails(Deployment item)
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
	}
	[GeneratedCode("Model Generator", "v1"), ExcludeFromCodeCoverage]
	public partial class EventDetails
	{
		public EventDetails(Event item)
		{
			AmbulancesAvailable = item.AmbulancesAvailable;
			ControlPhoneNumber = item.ControlPhoneNumber;
			CruTrackingInUse = item.CruTrackingInUse;
			CyclistsRequested = item.CyclistsRequested;
			Date = item.Date;
			Deployments = item.Deployments.Select(i=> new DeploymentDetails(i));
			Description = item.Description;
			DipsNumber = item.DipsNumber;
			DoctorsPresent = item.DoctorsPresent;
			EndTime = item.EndTime;
			ExpectedIncidents = item.ExpectedIncidents.Select(i=> new ExpectedIncidentDetails(i));
			ExpectingBadWeather = item.ExpectingBadWeather;
			FallbackRadioChannel = item.FallbackRadioChannel;
			FirstAidersAvailable = item.FirstAidersAvailable;
			FirstAidUnitsAvailable = item.FirstAidUnitsAvailable;
			HasSeriousHistory = item.HasSeriousHistory;
			HighSpeedRoadsAtEvent = item.HighSpeedRoadsAtEvent;
			Id = item.Id;
			Location = item.Location;
			Name = item.Name;
			NoGoAreas = item.NoGoAreas.Select(i=> new NoGoAreaDetails(i));
			Notes = item.Notes.Select(i=> new NoteDetails(i));
			ParamedicsAvailable = item.ParamedicsAvailable;
			PostCode = item.PostCode;
			RadioChannel = item.RadioChannel;
			Schedule = item.Schedule.Select(i=> new ScheduleItemDetails(i));
			SoloRespondingExpected = item.SoloRespondingExpected;
			StartTime = item.StartTime;
			Status = item.Status;
			UsingAirwave = item.UsingAirwave;
			UsingSJARadio = item.UsingSJARadio;
			WiderDistribution = item.WiderDistribution;
			DateConfirmed = item.DateConfirmed;
			Created = item.Created;
			LastUpdated = item.LastUpdated;
			CreatedBy = item.CreatedBy;
			UpdatedBy = item.UpdatedBy;
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
		public virtual IEnumerable<DeploymentDetails> Deployments { get; set; }
		public string Description { get; set; }
		[Display(Name="DIPS Number")]
		public int DipsNumber { get; set; }
		[Display(Name="Doctors Available")]
		public bool DoctorsPresent { get; set; }
		[Display(Name="End Time")]
		public TimeSpan EndTime { get; set; }
		public virtual IEnumerable<ExpectedIncidentDetails> ExpectedIncidents { get; set; }
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
		public string Name { get; set; }
		public virtual IEnumerable<NoGoAreaDetails> NoGoAreas { get; set; }
		public virtual IEnumerable<NoteDetails> Notes { get; set; }
		[Display(Name="Paramedics Available")]
		public bool ParamedicsAvailable { get; set; }
		[Display(Name="Post Code")]
		public string PostCode { get; set; }
		[Display(Name="Radio Channel")]
		public string RadioChannel { get; set; }
		public virtual IEnumerable<ScheduleItemDetails> Schedule { get; set; }
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
		public DateTime Created { get; set; }
		public DateTime LastUpdated { get; set; }
		public string CreatedBy { get; set; }
		public string UpdatedBy { get; set; }
	}
	[GeneratedCode("Model Generator", "v1"), ExcludeFromCodeCoverage]
	public partial class ExpectedIncidentDetails
	{
		public ExpectedIncidentDetails(ExpectedIncident item)
		{
			Id = item.Id;
			Name = item.Name;
		}

		public int Id { get; set; }
		public string Name { get; set; }
	}
	[GeneratedCode("Model Generator", "v1"), ExcludeFromCodeCoverage]
	public partial class NoGoAreaDetails
	{
		public NoGoAreaDetails(NoGoArea item)
		{
			Id = item.Id;
			Name = item.Name;
		}

		public int Id { get; set; }
		public string Name { get; set; }
	}
	[GeneratedCode("Model Generator", "v1"), ExcludeFromCodeCoverage]
	public partial class NoteDetails
	{
		public NoteDetails(Note item)
		{
			Id = item.Id;
			SortNumber = item.SortNumber;
			Text = item.Text;
		}

		public int Id { get; set; }
		public int SortNumber { get; set; }
		public string Text { get; set; }
	}
	[GeneratedCode("Model Generator", "v1"), ExcludeFromCodeCoverage]
	public partial class ScheduleItemDetails
	{
		public ScheduleItemDetails(ScheduleItem item)
		{
			Id = item.Id;
			Action = item.Action;
			Time = item.Time;
		}

		public int Id { get; set; }
		public string Action { get; set; }
		public TimeSpan Time { get; set; }
	}
}

#pragma warning restore 1591