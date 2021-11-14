using System;

namespace NHRM_Admin_API.ViewModels.AlertModels
{
    public class SurveyCheck
    {
        public int MeasurementID { get; set; }
        public int CategoryID { get; set; }
        public string URNumber { get; set; }
        public DateTime DateTimeRecorded { get; set; }
        public int Frequency { get; set; }
    }
}