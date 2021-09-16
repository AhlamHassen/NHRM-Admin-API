using System;
using System.Collections.Generic;

#nullable disable

namespace NHRM_Admin_API.Model
{
    public partial class ResourceDialog
    {
        public int ResourceDialogId { get; set; }
        public string Heading { get; set; }
        public string Content { get; set; }
        public string Video { get; set; }
        public int ResourceId { get; set; }

        public virtual Resource Resource { get; set; }
    }
}
