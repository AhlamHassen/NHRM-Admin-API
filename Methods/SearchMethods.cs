using System;
using System.Collections.Generic;
using NHRM_Admin_API.ViewModels.AlertModels;
using NHRM_Admin_API.Model;
using NHRM_Admin_API.ViewModels;

namespace NHRM_Admin_API.Methods
{
    public class SearchMethods
    {
        //create a method that takes a list of Patient and returns a list of PatientSearchViewModel
        //im not entirely sure why but the program wont pick this class up - further investigation required
        // ive temp added them to the bottom of the admin controller - but can move them back here once issue is fixed

        public IEnumerable<PatientSearchViewModel> ConvertPatientList(List<Patient> patients)
        {
            List<PatientSearchViewModel> patientSearchViewModels = new List<PatientSearchViewModel>();
            foreach (Patient patient in patients)
            {
                patientSearchViewModels.Add(new PatientSearchViewModel
                {
                    Urnumber = patient.Urnumber,
                    FirstName = patient.FirstName,
                    SurName = patient.SurName,
                    //convert patient dob to a string
                    Dob = patient.Dob.ToString("dd/MM/yyyy")
                });

            }

            return patientSearchViewModels;
        }
    }

}