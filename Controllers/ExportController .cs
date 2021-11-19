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
        [HttpGet]
        [Route("ExportAllPatient")]
        // ExportAll grabs all recordings from all patients and exports them as an array
        public async Task<IActionResult> ExportAll()
        {
            return Ok(await context.ViewTableData.ToArrayAsync());
        }
        [HttpGet]
        [Route("ExportLog")]
        // ExportAll grabs all recordings from all patients and exports them as an array
        public async Task<IActionResult> ExportLog()
        {
            return Ok(await context.view_Log
            // OrderBy not working
            // .OrderBy(x => x.DateTimeActioned)
            .ToArrayAsync());
        }
    }
}