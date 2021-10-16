using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.ObjectPool;
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

        //Gets All Alerts
        [HttpGet]
        [Route("GetAlerts")]
        public ActionResult<IEnumerable<ViewAlerts>> GetAlerts()
        {
            IEnumerable<ViewAlerts> alerts = context.view_Alerts
                                                .OrderBy(a => a.DateTimeRaised)
                                                .ToList();

            return Ok(alerts);
        }

    }
}