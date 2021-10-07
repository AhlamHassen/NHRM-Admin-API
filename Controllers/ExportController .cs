using System;
using Microsoft.AspNetCore.Mvc;
using NHRM_Admin_API.Model;
using CsvHelper;
using System.Linq;
using System.IO;
using Microsoft.Extensions.Configuration;
using System.Globalization;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace NHRM_Admin_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExportController : ControllerBase
    {

        private readonly NHRMDBContext context;
        public IConfiguration Configuration { get; }

        public ExportController(NHRMDBContext _context, IConfiguration configuration)
        {
            context = _context;
            Configuration = configuration;
        }

        //'ExportPatient' is given a Urnumber, Lower date range & Upper date range 
        // In response 'ExportPatient' creates a CSV and then as of now the CSV's are sent to a folder and a success or failiure is returned


        [HttpPost]
        [Route("ExportAll")]
        public async Task<IActionResult> ExportAll([FromBody] ExportAllRequest exportRequest)
        {
            DateTime startDate; DateTime endDate;
            // Parse strings into Datetime format
            // try
            // {
            startDate = DateTime.ParseExact(exportRequest.StartDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            endDate = DateTime.ParseExact(exportRequest.EndDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            // }
            // catch (System.FormatException)
            // {
            //     return BadRequest();
            // }

            // Validate & Error checking dates

            // Declare CSV storage location 
            var path = Path.Combine(Environment.CurrentDirectory, $"CSV's/PatientRecords_{DateTime.Now.ToString("dd-MM-yyyy")}.csv");

            // Convert into CSV
            using (var streamWriter = new StreamWriter(path))
            {
                using (var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture))
                {
                    // Get Data
                    List<ViewTableData> data = await context.ViewTableData.ToListAsync();
                    csvWriter.WriteRecords(data);
                }
            }
            return Ok();
        }
    }
}