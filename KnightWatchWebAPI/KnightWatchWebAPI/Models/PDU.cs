using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnightWatchWebAPI.Models
{
    public class PDU
    {
        //each load is power in KW

        public double module1load1 { get; set; }
        public double module1load2 { get; set; }
        public double module1load3 { get; set; }
        public double module2load1 { get; set; }
        public double module2load2 { get; set; }
        public double module2load3 { get; set; }
        public double module3load1 { get; set; }
        public double module3load2 { get; set; }
        public double module3load3 { get; set; }
        public double module4load1 { get; set; }
        public double module4load2 { get; set; }
        public double module4load3 { get; set; }
        public double module5load1 { get; set; }
        public double module5load2 { get; set; }
        public double module5load3 { get; set; }
        public double module6load1 { get; set; }
        public double module6load2 { get; set; }
        public double module6load3 { get; set; }
    }
}