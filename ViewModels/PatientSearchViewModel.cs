using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace NHRM_Admin_API.ViewModels
{
    public class PatientSearchViewModel
    {
        public string Urnumber { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public string Dob { get; set; }
    }
}