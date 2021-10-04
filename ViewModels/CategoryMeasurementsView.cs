using System;
using System.Collections.Generic;

namespace NHRM_Admin_API.ViewModels
{
    public class CategoryMeasurementsView
    {
        public CategoryMeasurementsView()
        {
            
        }

        public int MeasurementID { get; set; }
        public string MeasurementName { get; set; }
        public int CategoryID { get; set; }
        public int Frequency { get; set; }
        
       
        
    }

}