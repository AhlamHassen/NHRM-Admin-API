using System;
using System.Collections.Generic;

namespace NHRM_Admin_API.Model
{
    public class AddPatientModel
    {
        public NewPatientModel Patient {get; set;}
        public List<int> PatientCategories { get; set; } = new List<int>();// List of int, each int represents a category id
        #nullable enable

        //initialize list to return empty array instead of null
        public List<PatientMeasurementViewModel>? PatientMeasurements { get; set; }

        public AddPatientModel(NewPatientModel patient, List<int> patientCategories, List<PatientMeasurementViewModel>? patientMeasurements)
        {
            Patient = patient;
            PatientCategories = patientCategories;
            PatientMeasurements = patientMeasurements;
        }
        
    }

    public class PatientMeasurementViewModel
    {
        public int MeasurementId { get; set; }
        public int CategoryId { get; set; }
        public int Frequency { get; set; }

        public PatientMeasurementViewModel(int measurementId, int categoryId, int frequency)
        {
            MeasurementId = measurementId;
            CategoryId = categoryId;
            Frequency = frequency;
        }
    }
  
}