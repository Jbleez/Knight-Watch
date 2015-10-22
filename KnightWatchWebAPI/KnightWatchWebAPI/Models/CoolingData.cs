using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnightWatchWebAPI.Models
{
    public class CoolingData
    {
        
        public double coolDemand { get; set; } //in KW
        public double coolOutput { get; set; } //in KW
        public double ratio { get; set; }
    }
}