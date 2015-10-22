using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnightWatchWebAPI.Models
{
    public class HelpDeskTickets
    {

        public int ticketID { get; set; } //id in local database
        public int referenceID { get; set; } //id in hesk db
        public string name { get; set; }
        public string email { get; set; }
        public string ip { get; set; }
        public string dateIssued { get; set; } //date ticket was issued
        public int category { get; set; } 
        //1 : General
        //2 : Request for Student Virtual machine
        //3 : Request for Specialty Servers
        //4 : Classroom Technology Issues
        //5 : Office Technology Issues
        //6 : Departmental Website Update
        //7 : Dean's Office Adminsitrative Support
        //8 : IT Adminstrative Support
        //9 : CSSWE Admministrative Support
        public int status { get; set; }
        //0 : New
        //1 : Waiting reply
        //2 : Replied
        //3 : Resolved
        //4 : In-progess
        //5 : On-hold
        public int priority { get; set; }
        //0 : critical
        //1 : high
        //2 : medium
        //3 : low
        public DateTime lastChangedDate {get; set;}

    }
}