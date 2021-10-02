using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NHRM_Admin_API.Model;
using NHRM_Admin_API.ViewModels;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;


namespace NHRM_Admin_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryMeasurementController : ControllerBase
    {
        private readonly NHRMDBContext context;

        public CategoryMeasurementController(NHRMDBContext _context){
            context = _context;
        }

    //Get categories from DB
        [HttpGet]
        [Route("Categories")]
        public IEnumerable<AllCategoriesView> GetAllCategories()
        {
            
            return context.AllCategoriesView.ToList();
        }


         //Get category measurements based on Category Id's passed into the endpoint
        [HttpPut]
        [Route("CategoryMeasurements")]
        public IEnumerable<CategoryMeasurementsView> GetMeasurementsViews([FromBody] int[] categoryId){


            return context.CategoryMeasurements
            .Where(c => categoryId.Contains(c.CategoryID))
            .ToList();
        }
    }

   
        

     // Gets All Measurements -- this needs to be moved into its own controller prolly at some stage
     //I think this will be for the measurements view table data
        // [HttpGet]
        // [Route("GetMeasurements")]
        // public IEnumerable<MeasurementViewModel> GetMeasurements(){
            
        //     var measurments = context.Measurements.ToList();

        //     List<MeasurementViewModel> outputlist = new List<MeasurementViewModel>();
        //     foreach(var m in measurments){
               
        //         var mc = new MeasurementViewModel() { 
        //            MeasurementId = m.MeasurementId,
        //            MeasurementName = m.MeasurementName
        //         };
                
        //       outputlist.Add(mc);
        //     }
            
        //     return outputlist;
        // }

        

        // //todo make a categoriesView 
        // //todo make a measurementsView in db 
        // //todo work on inser
}