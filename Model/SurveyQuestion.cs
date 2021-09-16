using System;
using System.Collections.Generic;

#nullable disable

namespace NHRM_Admin_API.Model
{
    public partial class SurveyQuestion
    {
        public SurveyQuestion()
        {
            SurveyAnswers = new HashSet<SurveyAnswer>();
        }

        public int MeasurementId { get; set; }
        public int DataPointNumber { get; set; }
        public string CategoryName { get; set; }
        public string Question { get; set; }

        public virtual DataPoint DataPoint { get; set; }
        public virtual ICollection<SurveyAnswer> SurveyAnswers { get; set; }
    }
}
