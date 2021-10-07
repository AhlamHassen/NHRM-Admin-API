using System;

namespace NHRM_Admin_API.Model
{
    public class ExportRequest
    {
        public string Urnumber { get; set; }
        // Getting sent as a string because angular makes it harder to pass datetime 
        public string StartDate { get; set; }
        // Getting sent as a string because angular makes it harder to pass datetime 
        public string EndDate { get; set; }
    }
}