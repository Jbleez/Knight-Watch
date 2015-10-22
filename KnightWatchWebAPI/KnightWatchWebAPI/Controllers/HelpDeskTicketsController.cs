using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using KnightWatchWebAPI.Models;
using KnightWatchWebAPI.Services;
using System.Collections;

namespace KnightWatchWebAPI.Controllers
{
    public class HelpDeskTicketsController : ApiController
    {   
        private HelpDeskService helpDeskService;

        public HelpDeskTicketsController(){
            this.helpDeskService = new HelpDeskService();
        }

        /// <summary>
        /// Get all the number of help desk tickets by their current priorities
        /// </summary>
        /// <returns></returns>
        
        
        [ActionName("GetCurrentPriority")]
        public TicketPriorities GetTicketsByCurrentPriority()
        {
            TicketPriorities pr = new TicketPriorities();
            ArrayList res = new ArrayList();
            res = this.helpDeskService.getNumberOfTicketsByCurrentPriority();
            Int16 zero = 0;
            Int16 one = 1;
            Int16 two = 2;
            Int16 three = 3;

            for (int i = 0; i < res.Count; i++)
            {
                
                if (res[i].Equals(zero))
                {
                    pr.critical++;
                }
                else if(res[i].Equals(one)){
                    pr.high++;
                }

                else if(res[i].Equals(two)){
                    pr.medium++;
                }

                else if(res[i].Equals(three)){
                    pr.low++;
                }

            }

            return pr;
        }

        
        [ActionName("PostCurrentPriority")]
        public TicketPriorities PostTicketsByCurrentPriority()
        {

            TicketPriorities pr = new TicketPriorities();
            ArrayList res = new ArrayList();
            res = this.helpDeskService.getNumberOfTicketsByCurrentPriority();
            Int16 zero = 0;
            Int16 one = 1;
            Int16 two = 2;
            Int16 three = 3;

            for (int i = 0; i < res.Count; i++)
            {

                if (res[i].Equals(zero))
                {
                    pr.critical++;
                }
                else if (res[i].Equals(one))
                {
                    pr.high++;
                }

                else if (res[i].Equals(two))
                {
                    pr.medium++;
                }

                else if (res[i].Equals(three))
                {
                    pr.low++;
                }

            }

            return pr;
        }


        [ActionName("GetCurrentStatus")]
        public TicketStatuses GetTicketsByCurrentStatus()
        {
            TicketStatuses stats = new TicketStatuses();
            ArrayList res = new ArrayList();
            res = this.helpDeskService.getNumberOfTicketsByCurrentStatus();
            Int16 zero = 0;
            Int16 one = 1;
            Int16 two = 2;
            Int16 three = 3;
            Int16 four = 4;
            Int16 five = 5;

            for (int i = 0; i < res.Count; i++)
            {

                if (res[i].Equals(zero))
                {
                    stats.newStatus++;
                }
                else if (res[i].Equals(one))
                {
                    stats.waitingReply++;
                }

                else if (res[i].Equals(two))
                {
                    stats.replied++;
                }

                else if (res[i].Equals(three))
                {
                    stats.resolved++;
                }
                else if (res[i].Equals(four))
                {
                    stats.inProgress++;
                }

                else if (res[i].Equals(five))
                {
                    stats.onHold++;
                }

            }

            return stats;
        }

        
        [ActionName("PostCurrentStatus")]
        public TicketStatuses PostTicketsByCurrentStatus()
        {
            TicketStatuses stats = new TicketStatuses();
            ArrayList res = new ArrayList();
            res = this.helpDeskService.getNumberOfTicketsByCurrentStatus();
            Int16 zero = 0;
            Int16 one = 1;
            Int16 two = 2;
            Int16 three = 3;
            Int16 four = 4;
            Int16 five = 5;

            for (int i = 0; i < res.Count; i++)
            {

                if (res[i].Equals(zero))
                {
                    stats.newStatus++;
                }
                else if (res[i].Equals(one))
                {
                    stats.waitingReply++;
                }

                else if (res[i].Equals(two))
                {
                    stats.replied++;
                }

                else if (res[i].Equals(three))
                {
                    stats.resolved++;
                }
                else if (res[i].Equals(four))
                {
                    stats.inProgress++;
                }

                else if (res[i].Equals(five))
                {
                    stats.onHold++;
                }

            }

            return stats;
        }

        
        [ActionName("GetCurrentCategory")]
        public TicketCategories GetTicketsByCurrentCategory()
        {
            TicketCategories cat = new TicketCategories();
            ArrayList res = new ArrayList();
            res = this.helpDeskService.getNumberOfTicketsByCurrentCategory();
            
            Int16 one = 1;
            Int16 two = 2;
            Int16 three = 3;
            Int16 four = 4;
            Int16 five = 5;
            Int16 six = 6;
            Int16 seven = 7;
            Int16 eight = 8;
            Int16 nine = 9;
            for (int i = 0; i < res.Count; i++)
            {
                
                if (res[i].Equals(one))
                {
                    cat.general++;

                }

                else if (res[i].Equals(two))
                {
                    cat.reqForStudentVM++;

                }
                else if (res[i].Equals(three))
                {
                    cat.reqForSpecialityServers++;

                }
                else if (res[i].Equals(four))
                {
                    cat.classTechIssues++;

                }
                else if (res[i].Equals(five))
                {
                    cat.officeTechIssues++;

                }
                else if (res[i].Equals(six))
                {
                    cat.departmentalWebsiteUpdate++;

                }
                else if (res[i].Equals(seven))
                {
                    cat.deanOfficeAdminSupport++;
                }

                else if(res[i].Equals(eight))
                {
                    cat.itAdminSupport++;
                }

                else if(res[i].Equals(nine))
                {
                    cat.csswweAdminSupport++;
                }
            }

            return cat;
        }

        
        [ActionName("PostCurrentCategory")]
        public TicketCategories PostTicketsByCurrentCategory()
        {
            TicketCategories cat = new TicketCategories();
            ArrayList res = new ArrayList();
            res = this.helpDeskService.getNumberOfTicketsByCurrentCategory();

            Int16 one = 1;
            Int16 two = 2;
            Int16 three = 3;
            Int16 four = 4;
            Int16 five = 5;
            Int16 six = 6;
            Int16 seven = 7;
            Int16 eight = 8;
            Int16 nine = 9;
            for (int i = 0; i < res.Count; i++)
            {

                if (res[i].Equals(one))
                {
                    cat.general++;

                }

                else if (res[i].Equals(two))
                {
                    cat.reqForStudentVM++;

                }
                else if (res[i].Equals(three))
                {
                    cat.reqForSpecialityServers++;

                }
                else if (res[i].Equals(four))
                {
                    cat.classTechIssues++;

                }
                else if (res[i].Equals(five))
                {
                    cat.officeTechIssues++;

                }
                else if (res[i].Equals(six))
                {
                    cat.departmentalWebsiteUpdate++;

                }
                else if (res[i].Equals(seven))
                {
                    cat.deanOfficeAdminSupport++;
                }

                else if (res[i].Equals(eight))
                {
                    cat.itAdminSupport++;
                }

                else if (res[i].Equals(nine))
                {
                    cat.csswweAdminSupport++;
                }
            }

            return cat;
        }

        //returns the number of current tickets with a particular status and priority 
        public int GetTicketsPerStatusPerPriority(int status, int priority)
        {
            
            return this.helpDeskService.getNumberOfTicketsPerCurrentStatusPerCurrentPriority(status, priority);

        }

        public int PostTicketsPerStatusPerPriority(int status, int priority)
        {
            return this.helpDeskService.getNumberOfTicketsPerCurrentStatusPerCurrentPriority(status, priority);

        }

        public int GetTicketsPerCurrentCategoryPerStatus(int category, int status)
        {
            return this.helpDeskService.getNumberOfTicketsPerCurrentCategoryPerCurrentStatus(category, status);

        }

        public int PostTicketsPerCurrentCategoryPerStatus(int category, int status)
        {
            return this.helpDeskService.getNumberOfTicketsPerCurrentCategoryPerCurrentStatus(category, status);

        }

        public int GetTicketsPerCurrentCategoryPerPriority(int category, int priority)
        {
            return this.helpDeskService.getNumberOfTicketsPerCurrentCategoryPerCurrentPriority(category, priority);

        }

        public int PostTicketsPerCurrentCategoryPerPriority(int category, int priority)
        {
            return this.helpDeskService.getNumberOfTicketsPerCurrentCategoryPerCurrentPriority(category, priority);

        }

        public int GetTicketsPerCurrentCategoryPerStatusPerPriority(int category, int priority, int status)
        {
            return this.helpDeskService.getNumberOfTicketsPerCurrentCategoryPerCurrentPriorityPerStatus(category, priority, status);

        }

        public int PostTicketsPerCurrentCategoryPerStatusPerPriority(int category, int priority, int status)
        {
            return this.helpDeskService.getNumberOfTicketsPerCurrentCategoryPerCurrentPriorityPerStatus(category, priority, status);

        }

        
        [ActionName("GetPastCategory")]
        public TicketCategories GetTicketsByPastCategory(Int64 startTicks, Int64 endTicks)
        {
            TicketCategories cat = new TicketCategories();
            ArrayList res = new ArrayList();
            //DateTime start = new DateTime(2014, 06, 30);

            //DateTime end = new DateTime(2014, 07, 1);
            res = this.helpDeskService.getNumberOfTicketsByPastCategory(startTicks, endTicks);

            Int16 one = 1;
            Int16 two = 2;
            Int16 three = 3;
            Int16 four = 4;
            Int16 five = 5;
            Int16 six = 6;
            Int16 seven = 7;
            Int16 eight = 8;
            Int16 nine = 9;
            for (int i = 0; i < res.Count; i++)
            {

                if (res[i].Equals(one))
                {
                    cat.general++;

                }

                else if (res[i].Equals(two))
                {
                    cat.reqForStudentVM++;

                }
                else if (res[i].Equals(three))
                {
                    cat.reqForSpecialityServers++;

                }
                else if (res[i].Equals(four))
                {
                    cat.classTechIssues++;

                }
                else if (res[i].Equals(five))
                {
                    cat.officeTechIssues++;

                }
                else if (res[i].Equals(six))
                {
                    cat.departmentalWebsiteUpdate++;

                }
                else if (res[i].Equals(seven))
                {
                    cat.deanOfficeAdminSupport++;
                }

                else if (res[i].Equals(eight))
                {
                    cat.itAdminSupport++;
                }

                else if (res[i].Equals(nine))
                {
                    cat.csswweAdminSupport++;
                }
            }

            return cat;
        }


        [ActionName("PostPastCategory")]
        public TicketCategories PostTicketsByPastCategory(Int64 startTicks, Int64 endTicks)
        {
            TicketCategories cat = new TicketCategories();
            ArrayList res = new ArrayList();

            //DateTime start = new DateTime(2014, 06, 30);

            //DateTime end = new DateTime(2014, 07, 1);
            res = this.helpDeskService.getNumberOfTicketsByPastCategory(startTicks, endTicks);

            Int16 one = 1;
            Int16 two = 2;
            Int16 three = 3;
            Int16 four = 4;
            Int16 five = 5;
            Int16 six = 6;
            Int16 seven = 7;
            Int16 eight = 8;
            Int16 nine = 9;
            for (int i = 0; i < res.Count; i++)
            {

                if (res[i].Equals(one))
                {
                    cat.general++;

                }

                else if (res[i].Equals(two))
                {
                    cat.reqForStudentVM++;

                }
                else if (res[i].Equals(three))
                {
                    cat.reqForSpecialityServers++;

                }
                else if (res[i].Equals(four))
                {
                    cat.classTechIssues++;

                }
                else if (res[i].Equals(five))
                {
                    cat.officeTechIssues++;

                }
                else if (res[i].Equals(six))
                {
                    cat.departmentalWebsiteUpdate++;

                }
                else if (res[i].Equals(seven))
                {
                    cat.deanOfficeAdminSupport++;
                }

                else if (res[i].Equals(eight))
                {
                    cat.itAdminSupport++;
                }

                else if (res[i].Equals(nine))
                {
                    cat.csswweAdminSupport++;
                }
            }

            return cat;
        }

        [ActionName("GetPastPriority")]
        public TicketPriorities GetTicketsByPassPriority(Int64 startTicks, Int64 endTicks)
        {
            TicketPriorities pr = new TicketPriorities();
            ArrayList res = new ArrayList();

            //DateTime start = new DateTime(2014, 06, 30);

            //DateTime end = new DateTime(2014, 07, 1);

            res = this.helpDeskService.getNumberOfTicketsByPastPriority(startTicks, endTicks);

            Int16 zero = 0;
            Int16 one = 1;
            Int16 two = 2;
            Int16 three = 3;

            for (int i = 0; i < res.Count; i++)
            {

                if (res[i].Equals(zero))
                {
                    pr.critical++;
                }
                else if (res[i].Equals(one))
                {
                    pr.high++;
                }

                else if (res[i].Equals(two))
                {
                    pr.medium++;
                }

                else if (res[i].Equals(three))
                {
                    pr.low++;
                }

            }

            return pr;
        }


        [ActionName("PostPastPriority")]
        public TicketPriorities PostTicketsByPastPriority(Int64 startTicks, Int64 endTicks)
        {

            TicketPriorities pr = new TicketPriorities();
            ArrayList res = new ArrayList();

            res = this.helpDeskService.getNumberOfTicketsByPastPriority(startTicks, endTicks);
            Int16 zero = 0;
            Int16 one = 1;
            Int16 two = 2;
            Int16 three = 3;

            for (int i = 0; i < res.Count; i++)
            {

                if (res[i].Equals(zero))
                {
                    pr.critical++;
                }
                else if (res[i].Equals(one))
                {
                    pr.high++;
                }

                else if (res[i].Equals(two))
                {
                    pr.medium++;
                }

                else if (res[i].Equals(three))
                {
                    pr.low++;
                }

            }

            return pr;
        }

        [ActionName("GetPastStatus")]
        public TicketStatuses GetTicketsByPastStatus(Int64 startTicks, Int64 endTicks)
        {
            TicketStatuses stats = new TicketStatuses();
            ArrayList res = new ArrayList();
            //DateTime start = new DateTime(2014, 06, 30);

            //DateTime end = new DateTime(2014, 07, 1);

            res = this.helpDeskService.getNumberOfTicketsByPastStatus(startTicks, endTicks);
            Int16 zero = 0;
            Int16 one = 1;
            Int16 two = 2;
            Int16 three = 3;
            Int16 four = 4;
            Int16 five = 5;

            for (int i = 0; i < res.Count; i++)
            {

                if (res[i].Equals(zero))
                {
                    stats.newStatus++;
                }
                else if (res[i].Equals(one))
                {
                    stats.waitingReply++;
                }

                else if (res[i].Equals(two))
                {
                    stats.replied++;
                }

                else if (res[i].Equals(three))
                {
                    stats.resolved++;
                }
                else if (res[i].Equals(four))
                {
                    stats.inProgress++;
                }

                else if (res[i].Equals(five))
                {
                    stats.onHold++;
                }

            }

            return stats;
        }


        [ActionName("PostPastStatus")]
        public TicketStatuses PostTicketsByPastStatus(Int64 startTicks, Int64 endTicks)
        {
            TicketStatuses stats = new TicketStatuses();
            ArrayList res = new ArrayList();
            res = this.helpDeskService.getNumberOfTicketsByPastStatus(startTicks, endTicks);
            Int16 zero = 0;
            Int16 one = 1;
            Int16 two = 2;
            Int16 three = 3;
            Int16 four = 4;
            Int16 five = 5;

            for (int i = 0; i < res.Count; i++)
            {

                if (res[i].Equals(zero))
                {
                    stats.newStatus++;
                }
                else if (res[i].Equals(one))
                {
                    stats.waitingReply++;
                }

                else if (res[i].Equals(two))
                {
                    stats.replied++;
                }

                else if (res[i].Equals(three))
                {
                    stats.resolved++;
                }
                else if (res[i].Equals(four))
                {
                    stats.inProgress++;
                }

                else if (res[i].Equals(five))
                {
                    stats.onHold++;
                }

            }

            return stats;
        }

        [ActionName("GetPriorityBeforeDate")]
        public TicketPriorities GetTicketsByPriorityBeforeDate(Int64 markTicks)
        {
            TicketPriorities pr = new TicketPriorities();
            ArrayList res = new ArrayList();

            //DateTime mark = new DateTime(2014, 09, 3);

            res = this.helpDeskService.getNumberOfTicketsByPriorityBeforeDate(markTicks);

            Int16 zero = 0;
            Int16 one = 1;
            Int16 two = 2;
            Int16 three = 3;

            for (int i = 0; i < res.Count; i++)
            {

                if (res[i].Equals(zero))
                {
                    pr.critical++;
                }
                else if (res[i].Equals(one))
                {
                    pr.high++;
                }

                else if (res[i].Equals(two))
                {
                    pr.medium++;
                }

                else if (res[i].Equals(three))
                {
                    pr.low++;
                }

            }

            return pr;
        }


        [ActionName("PostPriorityBeforeDate")]
        public TicketPriorities PostTicketsByPriorityBeforeDate(Int64 markTicks)
        {
            TicketPriorities pr = new TicketPriorities();
            ArrayList res = new ArrayList();

            DateTime mark = new DateTime(2014, 09, 3);

            res = this.helpDeskService.getNumberOfTicketsByPriorityBeforeDate(markTicks);
            Int16 zero = 0;
            Int16 one = 1;
            Int16 two = 2;
            Int16 three = 3;

            for (int i = 0; i < res.Count; i++)
            {

                if (res[i].Equals(zero))
                {
                    pr.critical++;
                }
                else if (res[i].Equals(one))
                {
                    pr.high++;
                }

                else if (res[i].Equals(two))
                {
                    pr.medium++;
                }

                else if (res[i].Equals(three))
                {
                    pr.low++;
                }

            }

            return pr;
        }

        [ActionName("GetStatusBeforeDate")]
        public TicketStatuses GetTicketsByStatusBeforeDate(Int64 markTicks)
        {
            TicketStatuses stats = new TicketStatuses();
            ArrayList res = new ArrayList();
            //DateTime mark = new DateTime(2014, 09, 3);

            res = this.helpDeskService.getNumberOfTicketsByStatusBeforeDate(markTicks);
            Int16 zero = 0;
            Int16 one = 1;
            Int16 two = 2;
            Int16 three = 3;
            Int16 four = 4;
            Int16 five = 5;

            for (int i = 0; i < res.Count; i++)
            {

                if (res[i].Equals(zero))
                {
                    stats.newStatus++;
                }
                else if (res[i].Equals(one))
                {
                    stats.waitingReply++;
                }

                else if (res[i].Equals(two))
                {
                    stats.replied++;
                }

                else if (res[i].Equals(three))
                {
                    stats.resolved++;
                }
                else if (res[i].Equals(four))
                {
                    stats.inProgress++;
                }

                else if (res[i].Equals(five))
                {
                    stats.onHold++;
                }

            }

            return stats;
        }


        [ActionName("PostStatusBeforeDate")]
        public TicketStatuses PostTicketsByStatusBeforeDate(Int64 markTicks)
        {
            TicketStatuses stats = new TicketStatuses();
            ArrayList res = new ArrayList();

            res = this.helpDeskService.getNumberOfTicketsByStatusBeforeDate(markTicks);
            Int16 zero = 0;
            Int16 one = 1;
            Int16 two = 2;
            Int16 three = 3;
            Int16 four = 4;
            Int16 five = 5;

            for (int i = 0; i < res.Count; i++)
            {

                if (res[i].Equals(zero))
                {
                    stats.newStatus++;
                }
                else if (res[i].Equals(one))
                {
                    stats.waitingReply++;
                }

                else if (res[i].Equals(two))
                {
                    stats.replied++;
                }

                else if (res[i].Equals(three))
                {
                    stats.resolved++;
                }
                else if (res[i].Equals(four))
                {
                    stats.inProgress++;
                }

                else if (res[i].Equals(five))
                {
                    stats.onHold++;
                }

            }

            return stats;
        }


        [ActionName("GetCategoryBeforeDate")]
        public TicketCategories GetTicketsByCategoryBeforeDate(Int64 markTicks)
        {
            TicketCategories cat = new TicketCategories();
            ArrayList res = new ArrayList();
            //DateTime mark = new DateTime(2014, 09, 3);
            res = this.helpDeskService.getNumberOfTicketsByCategoryBeforeDate(markTicks);

            Int16 one = 1;
            Int16 two = 2;
            Int16 three = 3;
            Int16 four = 4;
            Int16 five = 5;
            Int16 six = 6;
            Int16 seven = 7;
            Int16 eight = 8;
            Int16 nine = 9;
            for (int i = 0; i < res.Count; i++)
            {

                if (res[i].Equals(one))
                {
                    cat.general++;

                }

                else if (res[i].Equals(two))
                {
                    cat.reqForStudentVM++;

                }
                else if (res[i].Equals(three))
                {
                    cat.reqForSpecialityServers++;

                }
                else if (res[i].Equals(four))
                {
                    cat.classTechIssues++;

                }
                else if (res[i].Equals(five))
                {
                    cat.officeTechIssues++;

                }
                else if (res[i].Equals(six))
                {
                    cat.departmentalWebsiteUpdate++;

                }
                else if (res[i].Equals(seven))
                {
                    cat.deanOfficeAdminSupport++;
                }

                else if (res[i].Equals(eight))
                {
                    cat.itAdminSupport++;
                }

                else if (res[i].Equals(nine))
                {
                    cat.csswweAdminSupport++;
                }
            }

            return cat;
        }


        [ActionName("PostCategoryBeforeDate")]
        public TicketCategories PostTicketsByCategoryBeforeDate(Int64 markTicks)
        {
            TicketCategories cat = new TicketCategories();
            ArrayList res = new ArrayList();
            res = this.helpDeskService.getNumberOfTicketsByCategoryBeforeDate(markTicks);

            Int16 one = 1;
            Int16 two = 2;
            Int16 three = 3;
            Int16 four = 4;
            Int16 five = 5;
            Int16 six = 6;
            Int16 seven = 7;
            Int16 eight = 8;
            Int16 nine = 9;
            for (int i = 0; i < res.Count; i++)
            {

                if (res[i].Equals(one))
                {
                    cat.general++;

                }

                else if (res[i].Equals(two))
                {
                    cat.reqForStudentVM++;

                }
                else if (res[i].Equals(three))
                {
                    cat.reqForSpecialityServers++;

                }
                else if (res[i].Equals(four))
                {
                    cat.classTechIssues++;

                }
                else if (res[i].Equals(five))
                {
                    cat.officeTechIssues++;

                }
                else if (res[i].Equals(six))
                {
                    cat.departmentalWebsiteUpdate++;

                }
                else if (res[i].Equals(seven))
                {
                    cat.deanOfficeAdminSupport++;
                }

                else if (res[i].Equals(eight))
                {
                    cat.itAdminSupport++;
                }

                else if (res[i].Equals(nine))
                {
                    cat.csswweAdminSupport++;
                }
            }

            return cat;
        }

        public int GetTicketsPerStatusPerPriorityBeforeDate(int status, int priority, Int64 markTicks)
        {

            return this.helpDeskService.getNumberOfTicketsPerStatusPerPriorityBeforeDate(status, priority, markTicks);

        }

        public int PostTicketsPerStatusPerPriorityBeforeDate(int status, int priority, Int64 markTicks)
        {

            return this.helpDeskService.getNumberOfTicketsPerStatusPerPriorityBeforeDate(status, priority, markTicks);

        }

        public int GetTicketsPerCategoryPerStatusBeforeDate(int category, int status, Int64 markTicks)
        {
            return this.helpDeskService.getNumberOfTicketsPerCategoryPerStatusBeforeDate(category, status, markTicks);

        }

        public int PostTicketsPerCategoryPerStatusBeforeDate(int category, int status, Int64 markTicks)
        {
            return this.helpDeskService.getNumberOfTicketsPerCategoryPerStatusBeforeDate(category, status, markTicks);

        }

        public int GetTicketsPerCategoryPerPriorityBeforeDate(int category, int priority, Int64 markTicks)
        {
            return this.helpDeskService.getNumberOfTicketsPerCategoryPerPriorityBeforeDate(category, priority, markTicks);

        }

        public int PostTicketsPerCategoryPerPriorityBeforeDate(int category, int priority, Int64 markTicks)
        {
            return this.helpDeskService.getNumberOfTicketsPerCategoryPerPriorityBeforeDate(category, priority, markTicks);

        }

        public int GetTicketsPerCategoryPerStatusPerPriorityBeforeDate(int category, int priority, int status, Int64 markTicks)
        {
            return this.helpDeskService.getNumberOfTicketsPerCategoryPerPriorityPerStatusBeforeDate(category, priority, status, markTicks);

        }

        public int PostTicketsPerCategoryPerStatusPerPriorityBeforeDate(int category, int priority, int status, Int64 markTicks)
        {
            return this.helpDeskService.getNumberOfTicketsPerCategoryPerPriorityPerStatusBeforeDate(category, priority, status, markTicks);

        }
    }
}
