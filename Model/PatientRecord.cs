using System;
using System.Collections.Generic;

#nullable disable

namespace NHRM_Admin_API.Model
{
    public partial class PatientRecord
    {
        public DateTime DateTimeRecorded { get; set; }
        public string Notes { get; set; }
        public string Urnumber { get; set; }
        public int RecordTypeId { get; set; }

        public virtual RecordType RecordType { get; set; }
        // public virtual Patient UrnumberNavigation { get; set; }
    }
}
