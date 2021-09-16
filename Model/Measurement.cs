using System;
using System.Collections.Generic;

#nullable disable

namespace NHRM_Admin_API.Model
{
    public partial class Measurement
    {
        public Measurement()
        {
            DataPoints = new HashSet<DataPoint>();
            PatientMeasurements = new HashSet<PatientMeasurement>();
            TemplateMeasurements = new HashSet<TemplateMeasurement>();
        }

        public int MeasurementId { get; set; }
        public string MeasurementName { get; set; }
        public int Frequency { get; set; }

        public virtual ICollection<DataPoint> DataPoints { get; set; }
        public virtual ICollection<PatientMeasurement> PatientMeasurements { get; set; }
        public virtual ICollection<TemplateMeasurement> TemplateMeasurements { get; set; }
    }
}
