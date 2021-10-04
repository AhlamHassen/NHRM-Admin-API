using System;
using System.Collections.Generic;

#nullable disable

namespace NHRM_Admin_API.Model
{
    public partial class PatientCategory
    {
        public int CategoryId { get; set; }
        public string Urnumber { get; set; }

        public PatientCategory()
        {
            PatientMeasurements = new HashSet<PatientMeasurement>();
            PatientResources = new HashSet<PatientResource>();
        }

        public PatientCategory(int categoryId, string urnumber)
        {
            CategoryId = categoryId;
            Urnumber = urnumber;
        }

        public virtual TemplateCategory Category { get; set; }
        public virtual Patient UrnumberNavigation { get; set; }
        public virtual ConditionDetail ConditionDetail { get; set; }
        public virtual ICollection<PatientMeasurement> PatientMeasurements { get; set; }
        public virtual ICollection<PatientResource> PatientResources { get; set; }
    }
}
