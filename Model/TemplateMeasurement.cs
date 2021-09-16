using System;
using System.Collections.Generic;

#nullable disable

namespace NHRM_Admin_API.Model
{
    public partial class TemplateMeasurement
    {
        public int MeasurementId { get; set; }
        public int CategoryId { get; set; }

        public virtual TemplateCategory Category { get; set; }
        public virtual Measurement Measurement { get; set; }
    }
}
