using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NHRM_Admin_API.Model;
using NHRM_Admin_API.ViewModels.AlertModels;

namespace NHRM_Admin_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlertsController : ControllerBase
    {
       private readonly NHRMDBContext context;
        public IConfiguration Configuration { get; }

        public AlertsController(NHRMDBContext _context, IConfiguration configuration)
        {
            context = _context;
            Configuration = configuration;
        }

        //Gets All Patients
        [HttpGet]
        [Route("GetAlerts")]
        public ActionResult<IEnumerable<ViewAlerts>> GetAlerts()
        {
            
            return Ok(context.view_Alerts.ToList());
        }

    }
}