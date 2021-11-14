using System;

#nullable enable
namespace NHRM_Admin_API.ViewModels.AlertModels
{
    public class Alert
    {
        public Alert()
        {
            
        }
        public Alert(int alertID, string uRNumber, int? staffID, int alertTypeID, int triggerValue, DateTime dateTimeRaised)
        {
            this.AlertID = alertID;
            this.URNumber = uRNumber;
            this.StaffID = staffID;
            this.AlertTypeID = alertTypeID;
            this.TriggerValue = triggerValue;
            this.DateTimeRaised = dateTimeRaised;

        }

        public int AlertID { get; set; }
        public string URNumber { get; set; }
        public int? StaffID { get; set; }
        public int AlertTypeID { get; set; }
        public int TriggerValue { get; set; }
        public DateTime DateTimeRaised { get; set; }
        public DateTime? DateTimeActioned { get; set; }
        public string? Status { get; set; }
        public string? Notes { get; set; }
    }
}