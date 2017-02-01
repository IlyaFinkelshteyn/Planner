using System.ComponentModel.DataAnnotations;

namespace Planner.Models.EventsModel
{
    public enum Qualification
    {
        [Display(Name = "Advanced First Aider")]
        AdvancedFirstAider = 1,

        [Display(Name = "Emergency Transport Attendant")]
        EmergencyTransportAttendant = 2,

        [Display(Name = "Emergency Medical Technician")]
        EmergencyMedicalTechnician = 3,

        Paramedic = 4,
        Technician = 5,
        Doctor = 6,
        Nurse = 7
    }
}