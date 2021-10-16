using System;
using Microsoft.VisualBasic;

#nullable enable
namespace NHRM_Admin_API.Model.AlertModels
{
    public class ViewAlerts
    {

        public int Identifier { get; set; }
        public string PatientName { get; set; }
        public string PatientID { get; set; }
        public string AlertTitle { get; set; }
        public string? Status { get; set; }
        public DateTime DateTimeRaised { get; set; }
        public DateTime? DateTimeActioned { get; set; }

        public ViewAlerts(int identifier, string patientName, string patientID, string alertTitle, string status, DateTime dateTimeRaised) 
        {
            this.Identifier = identifier;
                this.PatientName = patientName;
                this.PatientID  = patientID ;
                this.AlertTitle = alertTitle;
                this.Status = status;
                this.DateTimeRaised = dateTimeRaised;
               
        }
    }
}

