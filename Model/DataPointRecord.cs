using System;
using System.Collections.Generic;

#nullable disable

namespace NHRM_Admin_API.Model
{
    public partial class DataPointRecord
    {
        public int MeasurementId { get; set; }
        public int DataPointNumber { get; set; }
        public double Value { get; set; }
        public int MeasurementRecordId { get; set; }

        public virtual DataPoint DataPoint { get; set; }
        public virtual MeasurementRecord MeasurementRecord { get; set; }
    }
}
