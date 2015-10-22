using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnightWatchWebAPI.Models
{
    public class Temperatures
    {
        //temperatures in degrees Fahrenheit (F)
        public double supplyAirTemp { get; set; }
        public double returnAirTemp { get; set; }
        public double rackInTemp { get; set; }
    }
}