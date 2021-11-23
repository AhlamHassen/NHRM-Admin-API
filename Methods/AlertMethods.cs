using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using NHRM_Admin_API.ViewModels.AlertModels;

namespace NHRM_Admin_API.Methods
{
    public class AlertMethods : ControllerBase
    {
        //Alert Valid Status
        public Boolean isValidStatus(AlertsRequest alertReq)
        {
            var statusOptions = new List<string>() {"Actioned","Dismiss","Snooze"};
            return statusOptions.Contains(alertReq.Status);
        }

        //Alert does not exist response
        public BadRequestObjectResult AlertIsNull(AlertsRequest alertReq)
        {
            return BadRequest(String.Format("{0} is not a valid alert ID", alertReq.Identifier));
        }

        //Alert is not valid response
        public BadRequestObjectResult AlertNotValid(AlertsRequest alertReq)
        {                       
            return BadRequest(String.Format("{0} is not a valid Status Please enter either Actioned, Dismiss or Snooze", alertReq.Status));
        }


        public AlertMethods()
        {
            
        }
    }
}