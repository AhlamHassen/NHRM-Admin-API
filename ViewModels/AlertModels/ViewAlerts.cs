using System;


#nullable enable
namespace NHRM_Admin_API.ViewModels.AlertModels
{
    public class ViewAlerts
    {

        public ViewAlerts(int identifier, string patientName, string patientID, string alertTitle, int? staffID, DateTime dateTimeRaised)
        {
            this.Identifier = identifier;
            this.PatientName = patientName;
            this.PatientID = patientID;
            this.AlertTitle = alertTitle;
            this.StaffID = staffID;
            this.DateTimeRaised = dateTimeRaised;
        }
        public int Identifier { get; set; }
        public string PatientName { get; set; }
        public string PatientID { get; set; }
        public string AlertTitle { get; set; }
        public int? StaffID { get; set; }
        public string? Status { get; set; }
        public DateTime DateTimeRaised { get; set; }
        public DateTime? DateTimeActioned { get; set; }

    }
}

