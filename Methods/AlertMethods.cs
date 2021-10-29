using System;
using System.Collections.Generic;
using NHRM_Admin_API.ViewModels.AlertModels;

namespace NHRM_Admin_API.Methods
{
    public class AlertMethods
    {
        //Alert Valid Status
        public Boolean isValidStatus(AlertsRequest alertReq)
        {
            var statusOptions = new List<string>() {"Actioned","Snooze","Dismiss"};
            return statusOptions.Contains(alertReq.Status);
        }

        //Alert does not exist response
        public UpdateAlertResponse AlertIsNull(AlertsRequest alertReq)
        {
            return new UpdateAlertResponse(null, false, "Alert ID: "+ alertReq.Identifier +" does not exist");
        }

        //Alert is not valid response
        public UpdateAlertResponse AlertNotValid(AlertsRequest alertReq)
        {                       
            return new UpdateAlertResponse(null, false, alertReq.Status 
            + " " + "is not a valid Status Please enter either Actioned,Snooze or Dismiss");                       
        }


        public AlertMethods()
        {
            
        }
    }
}