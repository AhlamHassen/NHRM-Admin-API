using System;
using System.Collections.Generic;

#nullable disable

namespace NHRM_Admin_API.Model
{
    public partial class RecordCategory
    {
        public RecordCategory()
        {
            RecordTypes = new HashSet<RecordType>();
        }

        public int RecordCategoryId { get; set; }
        public string Category { get; set; }

        public virtual ICollection<RecordType> RecordTypes { get; set; }
    }
}
