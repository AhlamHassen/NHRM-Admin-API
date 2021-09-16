using System;
using System.Collections.Generic;

#nullable disable

namespace NHRM_Admin_API.Model
{
    public partial class ResourceType
    {
        public ResourceType()
        {
            Resources = new HashSet<Resource>();
        }

        public int ResourceTypeId { get; set; }
        public string TypeName { get; set; }

        public virtual ICollection<Resource> Resources { get; set; }
    }
}
