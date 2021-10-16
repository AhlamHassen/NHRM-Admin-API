using System;
using NHRM_Admin_API.ViewModels.AlertModels;

namespace NHRM_Admin_API.ViewModels.AlertModels
{
    public class UpdateAlertResponse
    {

        public UpdateAlertResponse(Alert alert, Boolean success, string message)
        {
            this.Alert = alert;
            this.Success = success;
            this.Message = message;

        }
        
        public Alert Alert { get; set; }
        public Boolean Success { get; set; }
        public string Message { get; set; }

        public UpdateAlertResponse()
        {

        }

    }


}