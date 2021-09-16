using System;
using System.Collections.Generic;

#nullable disable

namespace NHRM_Admin_API.Model
{
    public partial class Resource
    {
        public Resource()
        {
            PatientResources = new HashSet<PatientResource>();
            ResourceDialogs = new HashSet<ResourceDialog>();
            TemplateResources = new HashSet<TemplateResource>();
        }

        public int ResourceId { get; set; }
        public string Title { get; set; }
        public string Prompt { get; set; }
        public string Content { get; set; }
        public int TypeId { get; set; }

        public virtual ResourceType Type { get; set; }
        public virtual ICollection<PatientResource> PatientResources { get; set; }
        public virtual ICollection<ResourceDialog> ResourceDialogs { get; set; }
        public virtual ICollection<TemplateResource> TemplateResources { get; set; }
    }
}
