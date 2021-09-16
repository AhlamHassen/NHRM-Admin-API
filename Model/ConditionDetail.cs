using System;
using System.Collections.Generic;

#nullable disable

namespace NHRM_Admin_API.Model
{
    public partial class ConditionDetail
    {
        public int CategoryId { get; set; }
        public string Urnumber { get; set; }
        public string Diagnosis { get; set; }
        public DateTime? ProcedureDate { get; set; }
        public DateTime? NextAppointment { get; set; }

        public virtual PatientCategory PatientCategory { get; set; }
    }
}
