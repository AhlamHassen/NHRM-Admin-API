using System;
using System.Collections.Generic;

#nullable disable

namespace NHRM_Admin_API.Model
{
    public partial class RecordType
    {
        public RecordType()
        {
            PatientRecords = new HashSet<PatientRecord>();
        }

        public int RecordTypeId { get; set; }
        public string RecordType1 { get; set; }
        public int RecordCategoryId { get; set; }

        public virtual RecordCategory RecordCategory { get; set; }
        public virtual ICollection<PatientRecord> PatientRecords { get; set; }
    }
}
