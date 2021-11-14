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

        private AlertMethods alertMethods = new AlertMethods();

        public AlertsController(NHRMDBContext _context, IConfiguration configuration)
        {
            context = _context;
            Configuration = configuration;
        }

        //Gets All new or snoozed Alerts orders by Date time raised
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ViewAlerts>>> GetAlerts()
        {
            
            var alerts = await context.view_Alerts
                                                //Potential Option if actioned, dissmissed or Snooze don't need to be shown
                                                .Where(a => a.Status == null)                                                                                     
                                                .OrderBy(a => a.DateTimeRaised)
                                                .Select(va => new {va.Identifier, va.PatientName, va.PatientID, va.AlertTitle})
                                                .ToListAsync();
            return Ok(alerts);
        }

        //gets alert logs for the logs page
        [HttpGet]
        [Route("Log")]
        public async Task<ActionResult<IEnumerable<AlertsLog>>> GetAlertsLog()
        {
            //Other option convert time span to string
            //List<AlertLogResponse> alertsLogResponse = new List<AlertLogResponse>();

            IEnumerable<AlertsLog> alerts = await context.view_Log
                                                //Potential Option if null don't show in log
                                                .Where(a => a.Proceeding != null)                                                                                                                                    
                                                .OrderBy(a => a.DateTimeActioned)                                                                                      
                                                .ToListAsync();

                     
            return Ok(alerts);
        }        

        //Updates alerts
        [HttpPut]         
        public async Task<ActionResult<UpdateAlertResponse>> UpdateAlert([FromBody] AlertsRequest alertReq)
        {
            var response = new UpdateAlertResponse();
            //Find alert
            Alert alert = await context.tbl_Alert
                .FirstOrDefaultAsync(a => a.AlertID == alertReq.Identifier);

            //check alert is null
            if (alert == null)
            {
                response = alertMethods.AlertIsNull(alertReq);

                return Ok(response);
            }

            //Check if status is valid                        
            if (!alertMethods.isValidStatus(alertReq))
            {
                response = alertMethods.AlertNotValid(alertReq);
                return Ok(response);
            } 

            //change alert if snooze add 30 min current time and that will be the new value
//-----------potential option for snooze set a time when that time passes the api sends these alerts again--------------------//
            // if(alertReq.Status == "Snooze")
            // {
            //     alert.Status = alertReq.Status;
            //     DateTime currentTime = DateTime.Now;
            //     alert.DateTimeActioned = currentTime.AddMinutes(30);

            //     await context.SaveChangesAsync();

            //     response = new UpdateAlertResponse(alert, true, "Alert Successfully Updated");
            //     return Ok(response);

            // }

            alert.Status = alertReq.Status;
            alert.StaffID = alertReq.StaffID;
            alert.DateTimeActioned = DateTime.Now;

            context.SaveChanges();

            response = new UpdateAlertResponse(alert, true, "Alert Successfully Updated");
            return Ok(response);

        }

        //UnSnooze All Alerts
        [HttpPut]
        [Route("UnSnooze")]
        public async Task<ActionResult<Boolean>> UnSnoozeAlerts() {
            //Find alert
            IEnumerable<Alert> snoozeAlert = await context.tbl_Alert
                .Where(a => a.Status == "Snooze")
                .ToListAsync();
            
            foreach (var alert in snoozeAlert)
            {
                alert.Status = null;
            }

            context.SaveChanges();


            return Ok(snoozeAlert);

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

            foreach (var survey in missedSurvies)
            {
                isSurveyAlert =
                alerts.Find(a => a.URNumber == survey.URNumber) == null ? false : true;

                // if alert is not yet created create one
                if(!isSurveyAlert)
                {
                    var newAlert = new Alert();
                    newAlert.AlertTypeID = 6;
                    newAlert.DateTimeRaised = DateTime.Now;
                    newAlert.URNumber = survey.URNumber;
                    newAlert.TriggerValue = 1;

                    context.tbl_Alert.Add(newAlert);
                }
            }

            context.SaveChanges();
            
            return Ok(true);


        }
    }
}