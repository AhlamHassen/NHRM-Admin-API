using System;
using System.Collections.Generic;

namespace NHRM_Admin_API.Model
{
    public class AddPatientModel
    {
        public Patient patient {get; set;}
        public List<PatientCategory> patientCategory {get; set;}
        public List<PatientMeasurement> patientMeasurement {get; set;}
        
        public AddPatientModel(Patient patient, List<PatientCategory> patientCategory, List<PatientMeasurement> patientMeasurement)
        {
            this.patient = patient;
            this.patientCategory = patientCategory;
            this.patientMeasurement = patientMeasurement;
        }
        
    }
}