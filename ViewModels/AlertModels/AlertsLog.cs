using System;
using Newtonsoft.Json;

namespace NHRM_Admin_API.ViewModels.AlertModels
{
    public class AlertsLog
    {
       


        public AlertsLog(int alertID, String uRNumber/*, String alertTitle*/, int staffID, String proceeding, DateTime dateTimeActioned)
        {
            this.AlertID = alertID;
            this.URNumber = uRNumber;
            //this.AlertTitle = alertTitle;
            this.StaffID = staffID;
            this.Proceeding = proceeding;
            this.DateTimeActioned = dateTimeActioned;

        }
        public int AlertID { get; set; }
        public String URNumber { get; set; }
        public int StaffID { get; set; }
        public String Proceeding { get; set; }

        //public String AlertTitle { get; set; }
        public DateTime DateTimeActioned { get; set; }

    }
}

// export interface AlertLogResponse {
//     AlertID: number,
//     URNumber: string,
//     StaffID: number,
//     Proceeding: string,
//     DateTimeActioned: Date,
// }