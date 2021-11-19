using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Globalization;
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

        [HttpGet]
        [Route("GetAlerts")]
        public async Task<ActionResult<IEnumerable<ViewAlerts>>> GetAlerts()
        {
            var alerts = await context.view_Alerts
                //Gets alerts that are Null or Snooze
                .Where(a => a.Status == null || a.Status == "Snooze")
                .OrderBy(a => a.DateTimeRaised)
                .Select(va => new { va.Identifier, va.PatientName, va.PatientID, va.AlertTitle })
                .ToListAsync();
            return Ok(alerts);
        }

        [HttpGet]
        [Route("GetLog")]
        public async Task<ActionResult<IEnumerable<AlertsLog>>> GetAlertsLog()
        {
            IEnumerable<AlertsLog> logs = await context.view_Log
                .OrderBy(a => a.DateTimeActioned)
                .ToListAsync();
            return Ok(logs);
        }

        //Updates alerts
        [HttpPut]
        [Route("UpdateAlert")]
        public async Task<ActionResult<UpdateAlertResponse>> UpdateAlert([FromBody] AlertsRequest alertRequest)
        {
            //Find alert
            Alert alert = await context.tbl_Alert
                .FirstOrDefaultAsync(a => a.AlertID == alertRequest.Identifier);

            //Alert Validation
            if (alert == null)
            {
                return BadRequest(String.Format("{0} is not a valid alert ID", alertRequest.Identifier));
            }
            switch (alert.Status)
            {
                case "Snooze":
                    break;
                case "Actioned":
                    break;
                case "Dismiss":
                    break;
                default:
                    return BadRequest(String.Format("{0} is not a valid Status Please enter either Actioned, Dismiss or Snooze", alert.Status));
            }

            alert.Status = alertRequest.Status;
            alert.StaffID = alertRequest.StaffID;
            alert.DateTimeActioned = DateTime.Now;
            context.SaveChanges();

            return Ok();
        }

        [HttpPost]
        [Route("SurveyCheck")]
        public async Task<ActionResult<Boolean>> SurveyCheck()
        {
            var now = DateTime.Now;

            //get list of alerts created today
            var alerts = await context.tbl_Alert
                .Where(a => a.DateTimeRaised > new DateTime(now.Year, now.Month, now.Day, 0, 0, 0))
                .Where(a => a.AlertTypeID == 6)
                .ToListAsync();

            //get list of rows from survey check view
            var missedSurvies = await context.view_Survey_Check
            .ToListAsync();

            // if alert for missed survey was alredy created don't create another one
            Boolean isSurveyAlert;
            List<string> URList = new List<string>();

            foreach (var survey in missedSurvies)
            {
                isSurveyAlert =
                alerts.Find(a => a.URNumber == survey.URNumber) == null ? false : true;

                // if alert is not yet created create one
                if (!isSurveyAlert && !URList.Contains(survey.URNumber))
                {
                    var newAlert = new Alert();
                    newAlert.AlertTypeID = 6;
                    newAlert.DateTimeRaised = DateTime.Now;
                    newAlert.URNumber = survey.URNumber;
                    newAlert.TriggerValue = 1;

                    context.tbl_Alert.Add(newAlert);
                }
                URList.Add(survey.URNumber);
            }

            context.SaveChanges();
            return Ok(alerts);
        }
    }
}