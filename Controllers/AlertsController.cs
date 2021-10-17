using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        //Gets All Alerts orders by Date time raised
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ViewAlerts>>> GetAlerts()
        {
            
            IEnumerable<ViewAlerts> alerts = await context.view_Alerts
                                                //Potential Option if actioned or dissmissed don't need to be shown
                                                //.Where(a => a.Status == null || a.Status == "Snooze")                                                                                     
                                                .OrderBy(a => a.DateTimeRaised)
                                                .ToListAsync();
            return Ok(alerts);
        }

        //gets alert logs for the logs page
        [HttpGet]
        [Route("Log")]
        public async Task<ActionResult<IEnumerable<AlertsLog>>> GetAlertsLog()
        {
            List<AlertLogResponse> alertsLogResponse = new List<AlertLogResponse>();

            IEnumerable<AlertsLog> alerts = await context.view_Log
                                                //Potential Option if null don't show in log
                                                .Where(a => a.Proceeding != null)                                                                                     
                                                .OrderBy(a => a.Date)
                                                .OrderBy(a => a.Time)                                        
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

            //check alert is not null
            if (alert == null)
            {
                response = new UpdateAlertResponse(null, false, "Alert ID: "+ alertReq.Identifier +" does not exist");

                return Ok(response);
            }

            //Check if status is valid
            var statusOptions = new List<string>() {"Actioned","Snooze","Dismiss"};
            Boolean isValidStatus = statusOptions.Contains(alertReq.Status);

            if (!isValidStatus)
            {
                response = new UpdateAlertResponse(null, false, alertReq.Status 
                    + " " + "is not a valid Status Please enter either Actioned,Snooze or Dismiss");

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
            alert.DateTimeActioned = alertReq.DateTimeActioned;

            context.SaveChanges();

            response = new UpdateAlertResponse(alert, true, "Alert Successfully Updated");
            return Ok(response);

        }

    }
}