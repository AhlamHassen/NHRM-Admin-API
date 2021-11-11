using System;

namespace NHRM_Admin_API.ViewModels.AlertModels
{
    public class AlertsRequest
    {
        public int Identifier { get; set; }
        public string Status { get; set; }
        public int StaffID { get; set; }
        //public DateTime DateTimeActioned { get; set; }
    }
}