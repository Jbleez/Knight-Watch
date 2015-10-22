using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;

namespace KnightWatchWebAPI.Models
{
    public class TicketPriorities
    {
        public int critical { get; set; } //0
        public int high { get; set; } //1
        public int medium { get; set; } //2
        public int low { get; set; } //3
        
        
    }
}