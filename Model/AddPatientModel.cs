using System;
using System.Collections.Generic;

namespace NHRM_Admin_API.Model
{
    public class AddPatientModel
    {
        public Patient patient {get; set;}
        public List<PatientCategory> patientCategory {get; set;} = new List<PatientCategory>();        // list of ints
        public List<PatientMeasurement> patientMeasurement {get; set;}
        
        public AddPatientModel(Patient patient, List<PatientCategory> patientCategory, List<PatientMeasurement> patientMeasurement)
        {
            this.patient = patient;
            this.patientCategory = patientCategory;
            this.patientMeasurement = patientMeasurement;
        }
        
    }

    public class PatientMeasurementViewModel
    {
        // categoryId
        // measurement id
        // freq
    }

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
        public bool LivesAlone { get; set; }
        public int RegisteredBy { get; set; }
        public bool Active { get; set; }
    }
}