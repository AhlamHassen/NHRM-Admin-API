using System;
using System.Collections.Generic;

#nullable disable

namespace NHRM_Admin_API.Model
{
    public partial class TemplateResource
    {
        public int CategoryId { get; set; }
        public int ResourceId { get; set; }

        public virtual TemplateCategory Category { get; set; }
        public virtual Resource Resource { get; set; }
    }
}
