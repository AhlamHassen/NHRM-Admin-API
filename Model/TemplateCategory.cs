using System;
using System.Collections.Generic;

#nullable disable

namespace NHRM_Admin_API.Model
{
    public partial class TemplateCategory
    {
        public TemplateCategory()
        {
            // PatientCategories = new HashSet<PatientCategory>();
            // TemplateMeasurements = new HashSet<TemplateMeasurement>();
            // TemplateResources = new HashSet<TemplateResource>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        // public virtual ICollection<PatientCategory> PatientCategories { get; set; }
        // public virtual ICollection<TemplateMeasurement> TemplateMeasurements { get; set; }
        // public virtual ICollection<TemplateResource> TemplateResources { get; set; }
    }
}
