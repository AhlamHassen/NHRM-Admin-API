using System;
using System.Collections.Generic;

#nullable disable

namespace NHRM_Admin_API.Model
{
    public partial class Patient
    {
        public Patient()
        {
            PatientCategories = new HashSet<PatientCategory>();
            PatientRecords = new HashSet<PatientRecord>();
            Treatings = new HashSet<Treating>();
        }

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

        public virtual staff RegisteredByNavigation { get; set; }
        public virtual ICollection<PatientCategory> PatientCategories { get; set; }
        public virtual ICollection<PatientRecord> PatientRecords { get; set; }
        public virtual ICollection<Treating> Treatings { get; set; }
    }
}
