using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using KnightWatchWebAPI.Services;
namespace KnightWatchWebAPI.Controllers
{
    public class HelpDeskCriticalNotificationController : ApiController
    {
        private HelpDeskService helpDeskService;

        public HelpDeskCriticalNotificationController(){
            this.helpDeskService = new HelpDeskService();
        }
        public bool GetHelpDeskCriticalNotification()
        {
           
            return this.helpDeskService.getCriticalNotification();

        }

        public bool PostHelpDeskCriticalNotification()
        {
            
            return this.helpDeskService.getCriticalNotification();
        }
    }

}
