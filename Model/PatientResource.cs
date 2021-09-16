using System;
using System.Collections.Generic;

#nullable disable

namespace NHRM_Admin_API.Model
{
    public partial class PatientResource
    {
        public int CategoryId { get; set; }
        public string Urnumber { get; set; }
        public int ResourceId { get; set; }

        public virtual PatientCategory PatientCategory { get; set; }
        public virtual Resource Resource { get; set; }
    }
}
