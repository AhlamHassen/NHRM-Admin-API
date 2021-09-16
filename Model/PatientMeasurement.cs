using System;
using System.Collections.Generic;

#nullable disable

namespace NHRM_Admin_API.Model
{
    public partial class PatientMeasurement
    {
        public PatientMeasurement()
        {
            MeasurementRecords = new HashSet<MeasurementRecord>();
        }

        public int MeasurementId { get; set; }
        public int CategoryId { get; set; }
        public string Urnumber { get; set; }
        public int Frequency { get; set; }
        public DateTime FrequencySetDate { get; set; }

        public virtual Measurement Measurement { get; set; }
        public virtual PatientCategory PatientCategory { get; set; }
        public virtual ICollection<MeasurementRecord> MeasurementRecords { get; set; }
    }
}
