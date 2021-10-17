using System;
using Newtonsoft.Json;

namespace NHRM_Admin_API.ViewModels.AlertModels
{
    public class AlertsLog
    {
        public AlertsLog(int alertID, String uRNumber, String alertTitle, int staffID, String proceeding, DateTime date, TimeSpan time)
        {
            this.AlertID = alertID;
            this.URNumber = uRNumber;
            this.AlertTitle = alertTitle;
            this.StaffID = staffID;
            this.Proceeding = proceeding;
            this.Date = date;
            this.Time = time;

        }


        public int AlertID { get; set; }
        public String URNumber { get; set; }
        public String AlertTitle { get; set; }
        public int StaffID { get; set; }
        public String Proceeding { get; set; }         
        public DateTime Date { get; set; }

        public TimeSpan Time { get; set; }

    }
}