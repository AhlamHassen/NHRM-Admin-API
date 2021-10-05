using System;

namespace NHRM_Admin_API.ViewModels
{
    public class ViewPatientInfoModel
    {
        public ViewPatientInfoModel(string urnumber, string title, string firstName, string surName, bool active, DateTime dob)
        {
            this.Urnumber = urnumber;
            this.Title = title;
            this.FirstName = firstName;
            this.SurName = surName;
            this.Active = active;
            this.Dob = dob;

        }
        public string Urnumber { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public bool Active { get; set; }
        public DateTime Dob { get; set; }
    }
}