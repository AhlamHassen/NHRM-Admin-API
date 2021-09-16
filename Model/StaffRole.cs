using System;
using System.Collections.Generic;

#nullable disable

namespace NHRM_Admin_API.Model
{
    public partial class StaffRole
    {
        public StaffRole()
        {
            staff = new HashSet<staff>();
        }

        public int RoleId { get; set; }
        public string StaffType { get; set; }

        public virtual ICollection<staff> staff { get; set; }
    }
}
