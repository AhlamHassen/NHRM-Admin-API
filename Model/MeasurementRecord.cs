using System;
using System.Collections.Generic;

#nullable disable

namespace NHRM_Admin_API.Model
{
    public partial class MeasurementRecord
    {
        public MeasurementRecord()
        {
            DataPointRecords = new HashSet<DataPointRecord>();
        }

        public int MeasurementRecordId { get; set; }
        public DateTime DateTimeRecorded { get; set; }
        public int MeasurementId { get; set; }
        public int CategoryId { get; set; }
        public string Urnumber { get; set; }

        public virtual PatientMeasurement PatientMeasurement { get; set; }
        public virtual ICollection<DataPointRecord> DataPointRecords { get; set; }
    }
}
