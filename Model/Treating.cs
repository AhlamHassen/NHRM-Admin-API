using System;
using System.Collections.Generic;

#nullable disable

namespace NHRM_Admin_API.Model
{
    public partial class Treating
    {
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Urnumber { get; set; }
        public int StaffId { get; set; }

        public virtual staff Staff { get; set; }
        public virtual Patient UrnumberNavigation { get; set; }
    }
}
