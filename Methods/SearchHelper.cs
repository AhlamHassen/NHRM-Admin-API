using System.Collections.Generic;
using System.Linq;
using NHRM_Admin_API.Model;
using NHRM_Admin_API.ViewModels;

namespace NHRM_Admin_API.Methods
{
    public class SearchHelper
    {
          public IEnumerable<PatientSearchViewModel> PatientListFixer(List<Patient> patients)
        {
            var patientSearchModelOutput = patients.Select(p => new PatientSearchViewModel { Urnumber = p.Urnumber, FirstName = p.FirstName, SurName = p.SurName, Dob = p.Dob.ToString("dd/MM/yyyy") }).ToList();
            return patientSearchModelOutput;
        }

        public IEnumerable<PatientSearchViewModel> PatientListEnumerableFixer(IEnumerable<Patient> patients)
        {
            var patientSearchModelOutput = patients.Select(p => new PatientSearchViewModel { Urnumber = p.Urnumber, FirstName = p.FirstName, SurName = p.SurName, Dob = p.Dob.ToString("dd/MM/yyyy") }).ToList();

            return patientSearchModelOutput;
        }
    }
}