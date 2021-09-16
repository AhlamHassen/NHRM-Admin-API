using System;
using System.Collections.Generic;

#nullable disable

namespace NHRM_Admin_API.Model
{
    public partial class DataPoint
    {
        public DataPoint()
        {
            DataPointRecords = new HashSet<DataPointRecord>();
        }

        public int MeasurementId { get; set; }
        public int DataPointNumber { get; set; }
        public int UpperLimit { get; set; }
        public int LowerLimit { get; set; }
        public string Name { get; set; }

        public virtual Measurement Measurement { get; set; }
        public virtual SurveyQuestion SurveyQuestion { get; set; }
        public virtual ICollection<DataPointRecord> DataPointRecords { get; set; }
    }
}
