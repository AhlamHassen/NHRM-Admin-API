using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.ObjectPool;
using Microsoft.OpenApi.Any;
using NHRM_Admin_API.Methods;
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

        //Gets All Alerts where status is either Null or Dissmissed orders by Date time raised
        [HttpGet]
        [Route("GetAlerts")]
        public async Task<ActionResult<IEnumerable<ViewAlerts>>> GetAlerts()
        {

            var alerts = await context.view_Alerts
                //Potential Option if actioned, dissmissed or Snooze don't need to be shown
                .Where(a => a.Status == "Snoozed" || a.Status == null)
                .OrderBy(a => a.DateTimeRaised)
                .Select(va => new { va.Identifier, va.PatientName, va.PatientID, va.AlertTitle })
                .ToListAsync();
            return Ok(alerts);
        }

        //Gets Alert Log
        [HttpGet]
        [Route("GetLog")]
        public async Task<ActionResult<IEnumerable<AlertsLog>>> GetAlertLog()
        {
            AlertsLog[] log = await context.view_Log
                .OrderBy(a => a.DateTimeActioned)
                .ToArrayAsync();
            return Ok(log);
        }

        //Updates alerts
        [HttpPut]
        [Route("UpdateAlert")]
        public async Task<ActionResult> UpdateAlert([FromBody] AlertsRequest alertRequest)
        {
            //Find alert
            Alert alert = await context.tbl_Alert
                .FirstOrDefaultAsync(a => a.AlertID == alertRequest.Identifier);

            //Validation Checks
            if (alert == null) return BadRequest("Request isn't a valid Status Please enter either Actioned, Dismiss or Snooze");
            switch (alertRequest.Status)
            {
                case "Snooze":
                    break;
                case "Dissmiss":
                    break;
                case "Actioned":
                    break;
                default:
                    return BadRequest("Request isn't a valid Status Please enter either Actioned, Dismiss or Snooze");
            }

            // Setting up response variables
            alert.Status = alertRequest.Status;
            alert.StaffID = alertRequest.StaffID;
            alert.DateTimeActioned = DateTime.Now;
            context.SaveChanges();
            return Ok();
        }
    }
}