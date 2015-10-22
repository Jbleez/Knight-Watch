using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnightWatchWebAPI.Models 
{
    public class PowerStrip
    {
        
        public double power { get; set; }
        public double max_power { get; set; }
        public double energy { get; set; }
        //public double temp { get; set; }
        //public double humidity { get; set; }
    }
}