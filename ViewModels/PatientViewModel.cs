using System;

namespace NHRM_Admin_API.ViewModels
{
    public class PatientViewModel
    {
        public string Urnumber { get; set; }
        public string Email { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public string Gender { get; set; }
        public DateTime Dob { get; set; }
        public string Address { get; set; }
        public string Suburb { get; set; }
        public string PostCode { get; set; }
        public string MobileNumber { get; set; }
        public string HomeNumber { get; set; }
        public string CountryOfBirth { get; set; }
        public string PreferredLanguage { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public bool LivesAlone { get; set; }
        public int RegisteredBy { get; set; }
        public bool Active { get; set; }

         public PatientViewModel(string urnumber, string email, string title, string firstName, string surName, string gender, DateTime dob, string address, string suburb, string postCode, string mobileNumber, string homeNumber, string countryOfBirth, string preferredLanguage, string password, string salt, bool livesAlone, int registeredBy, bool active)
        {
            Urnumber = urnumber;
            Email = email;
            Title = title;
            FirstName = firstName;
            SurName = surName;
            Gender = gender;
            Dob = dob;
            Address = address;
            Suburb = suburb;
            PostCode = postCode;
            MobileNumber = mobileNumber;
            HomeNumber = homeNumber;
            CountryOfBirth = countryOfBirth;
            PreferredLanguage = preferredLanguage;
            Password = password;
            Salt = salt;
            LivesAlone = livesAlone;
            RegisteredBy = registeredBy;
            Active = active;
        }
    }

    
}