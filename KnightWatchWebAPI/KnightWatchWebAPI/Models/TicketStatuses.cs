using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnightWatchWebAPI.Models
{
    public class TicketStatuses
    {
        public int newStatus { get; set; } //0
        public int waitingReply { get; set; } //1
        public int replied { get; set; } //2
        public int resolved { get; set; }//3
        public int inProgress { get; set; } //4
        public int onHold { get; set; } //5
    }
}