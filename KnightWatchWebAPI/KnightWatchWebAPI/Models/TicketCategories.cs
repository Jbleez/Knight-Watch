using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnightWatchWebAPI.Models
{
    public class TicketCategories
    {
        public int general { get; set; }//1
        public int reqForStudentVM { get; set; }//2
        public int reqForSpecialityServers { get; set; } //3
        public int classTechIssues { get; set; } //4
        public int officeTechIssues { get; set; } //5
        public int departmentalWebsiteUpdate { get; set; } //6
        public int deanOfficeAdminSupport { get; set; }//7
        public int itAdminSupport { get; set; }//8
        public int csswweAdminSupport { get; set; } //9
    }
}