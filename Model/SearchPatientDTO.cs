using System;
using System.Collections.Generic;

#nullable disable

namespace NHRM_Admin_API.Model
{
    public partial class SearchPatientDTO
    {
        public string Urnumber { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }

    }
}
