using System;
using System.Net.Http;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;

namespace KnightWatch
{
    class HelpDeskTickets
    {
        PriorityResponse priorityResponse = new PriorityResponse();
        StatusResponse statusResponse = new StatusResponse();
        CategoryResponse categoryResponse = new CategoryResponse();

        public HelpDeskTickets()
        {
            priorityResponse.read();
            statusResponse.read();
            categoryResponse.read();
        }

        public PriorityResponse GetCurrentPriority()
        {
            return this.priorityResponse;
        }

        public StatusResponse GetCurrentStatus()
        {
            return this.statusResponse;
        }

        public CategoryResponse GetCurrentCategory()
        {
            return this.categoryResponse;
        }
    }

    [DataContract]
    internal abstract class JSONReader
    {
        private string baseURI = "http://168.28.189.116/KnightWatch/";
        public string lastResp = "JSONReader";

        public async void read()
        {
            HttpClient htClient = new HttpClient();
            string url = this.baseURI + this.webURI();
            try
            {
                this.lastResp = await htClient.GetStringAsync(url);
                this.parse(this.lastResp);
            }
            catch (Exception ex)
            {
                this.parse(this.dummyReply());
                lastResp = url+" // "+ex.ToString();
                // maybe do some error logging;
            }

            await Task.Delay(10000); // 10 secs
            this.read();
        }

        public string stringify()
        {
            MemoryStream stream1 = new MemoryStream();
            DataContractJsonSerializer ser = new DataContractJsonSerializer(this.GetType());
            ser.WriteObject(stream1, this);
            stream1.Position = 0;
            StreamReader sr = new StreamReader(stream1);
            return sr.ReadToEnd();
        }

        abstract public string webURI();
        abstract public string dummyReply();
        abstract public void parse(string reply);
    }

    [DataContract]
    internal class PriorityResponse : JSONReader
    {

        [DataMember]
        public int low { set { this._low = value; this.initialized = true; } get { return this._low; } }
        private int _low = 0;

        [DataMember]
        public int medium { set { this._medium = value; this.initialized = true; } get { return this._medium; } }
        private int _medium = 0;

        [DataMember]
        public int high { set { this._high = value; this.initialized = true; } get { return this._high; } }
        private int _high = 0;

        [DataMember]
        public int critical { set { this._critical = value; this.initialized = true; } get { return this._critical; } }
        private int _critical = 0;

        public bool initialized = false;

        override public string webURI()
        {
            return "api/HelpDeskTickets/GetCurrentPriority/";
        }
        override public string dummyReply()
        {
            return "{\"critical\": 1,\"high\": 2,\"medium\": 3,\"low\": 4}";
        }
        override public void parse(string reply)
        {
            PriorityResponse temp = new PriorityResponse();
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(PriorityResponse));

            MemoryStream stream1 = new MemoryStream();

            StreamWriter writer = new StreamWriter(stream1);
            writer.Write(reply);
            writer.Flush();

            stream1.Position = 0;
            temp = (PriorityResponse)ser.ReadObject(stream1);

            this.low = temp.low;
            this.medium = temp.medium;
            this.high = temp.high;
            this.critical = temp.critical;
        }

    }

    [DataContract]
    internal class StatusResponse : JSONReader
    {

        [DataMember]
        public int newStatus { set { this._newStatus = value; this.initialized = true; } get { return this._newStatus; } }
        private int _newStatus = 0;

        [DataMember]
        public int waitingReply { set { this._waitingReply = value; this.initialized = true; } get { return this._waitingReply; } }
        private int _waitingReply = 0;

        [DataMember]
        public int replied { set { this._replied = value; this.initialized = true; } get { return this._replied; } }
        private int _replied = 0;

        [DataMember]
        public int resolved { set { this._resolved = value; this.initialized = true; } get { return this._resolved; } }
        private int _resolved = 0;

        [DataMember]
        public int inProgress { set { this._inProgress = value; this.initialized = true; } get { return this._inProgress; } }
        private int _inProgress = 0;

        [DataMember]
        public int onHold { set { this._onHold = value; this.initialized = true; } get { return this._onHold; } }
        private int _onHold = 0;

        public bool initialized = false;

        override public string webURI()
        {
            return "api/HelpDeskTickets/GetCurrentStatus/";
        }
        override public string dummyReply()
        {
            return "{\"newStatus\": 1,\"waitingReply\": 2,\"replied\": 3,\"resolved\": 4,\"inProgress\": 5,\"onHold\": 6}";
        }
        override public void parse(string reply)
        {
            StatusResponse temp = new StatusResponse();
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(StatusResponse));

            MemoryStream stream1 = new MemoryStream();

            StreamWriter writer = new StreamWriter(stream1);
            writer.Write(reply);
            writer.Flush();

            stream1.Position = 0;
            temp = (StatusResponse)ser.ReadObject(stream1);

            this.newStatus = temp.newStatus;
            this.waitingReply = temp.waitingReply;
            this.replied = temp.replied;
            this.resolved = temp.resolved;
            this.inProgress = temp.inProgress;
            this.onHold = temp.onHold;
        }

    }
   
    [DataContract]
    internal class CategoryResponse : JSONReader
    {

        [DataMember]
        public int general { set { this._general = value; this.initialized = true; } get { return this._general; } }
        private int _general = 0;

        [DataMember]
        public int reqForStudentVM { set { this._reqForStudentVM = value; this.initialized = true; } get { return this._reqForStudentVM; } }
        private int _reqForStudentVM = 0;

        [DataMember]
        public int reqForSpecialityServers { set { this._reqForSpecialityServers = value; this.initialized = true; } get { return this._reqForSpecialityServers; } }
        private int _reqForSpecialityServers = 0;

        [DataMember]
        public int classTechIssues { set { this._classTechIssues = value; this.initialized = true; } get { return this._classTechIssues; } }
        private int _classTechIssues = 0;

        [DataMember]
        public int officeTechIssues { set { this._officeTechIssues = value; this.initialized = true; } get { return this._officeTechIssues; } }
        private int _officeTechIssues = 0;

        [DataMember]
        public int departmentalWebsiteUpdate { set { this._departmentalWebsiteUpdate = value; this.initialized = true; } get { return this._departmentalWebsiteUpdate; } }
        private int _departmentalWebsiteUpdate = 0;

        [DataMember]
        public int deanOfficeAdminSupport { set { this._deanOfficeAdminSupport = value; this.initialized = true; } get { return this._deanOfficeAdminSupport; } }
        private int _deanOfficeAdminSupport = 0;

        [DataMember]
        public int itAdminSupport { set { this._itAdminSupport = value; this.initialized = true; } get { return this._itAdminSupport; } }
        private int _itAdminSupport = 0;

        [DataMember]
        public int csswweAdminSupport { set { this._csswweAdminSupport = value; this.initialized = true; } get { return this._csswweAdminSupport; } }
        private int _csswweAdminSupport = 0;

        public bool initialized = false;

        override public string webURI()
        {
            return "api/HelpDeskTickets/GetCurrentStatus/";
        }
        override public string dummyReply()
        {
            return "{\"general\": 1,\"reqForStudentVM\": 2,\"reqForSpecialityServers\": 3,\"classTechIssues\": 4,\"officeTechIssues\": 5,\"departmentalWebsiteUpdate\": 6,\"deanOfficeAdminSupport\": 7,\"itAdminSupport\": 8,\"csswweAdminSupport\": 9}";
        }
        override public void parse(string reply)
        {
            CategoryResponse temp = new CategoryResponse();
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(CategoryResponse));

            MemoryStream stream1 = new MemoryStream();

            StreamWriter writer = new StreamWriter(stream1);
            writer.Write(reply);
            writer.Flush();

            stream1.Position = 0;
            temp = (CategoryResponse)ser.ReadObject(stream1);

            this.general = temp.general;
            this.reqForStudentVM = temp.reqForStudentVM;
            this.reqForSpecialityServers = temp.reqForSpecialityServers;
            this.classTechIssues = temp.classTechIssues;
            this.officeTechIssues = temp.officeTechIssues;
            this.departmentalWebsiteUpdate = temp.departmentalWebsiteUpdate;
            this.deanOfficeAdminSupport = temp.deanOfficeAdminSupport;
            this.itAdminSupport = temp.itAdminSupport;
            this.csswweAdminSupport = temp.csswweAdminSupport;
        }

    }

  
    class TicketSearch
    {

        private string baseURI = "http://168.28.189.116/KnightWatch/api/HelpDeskTickets/";
        private string rUri = "";
        public string lastResp = "TicketSearch";
        private HttpClient htClient = new HttpClient();

        public async Task<string> search(int priority = -1, int status = -1, int category = -1)
        {
            // Determine URL
            this.rUri = "";
            if (status != -1 && priority != -1 && category == -1)
            {
                this.rUri = "GetTicketsPerStatusPerPriority?status=" + status + "&priority=" + priority;
            }
            if (status != -1 && priority == -1 && category != -1)
            {
                this.rUri = "GetTicketsPerCurrentCategoryPerStatus?status=" + status + "&category=" + category;
            }
            if (status == -1 && priority != -1 && category != -1)
            {
                this.rUri = "GetTicketsPerCurrentCategoryPerPriority?priority=" + priority + "&category=" + category;
            }
            if (status != -1 && priority != -1 && category != -1)
            {
                this.rUri = "GetTicketsPerCurrentCategoryPerStatusPerPriority?priority=" + priority + "&category=" + category + "&status=" + status;
            }
            if (this.rUri == "") throw new Exception("Invalid Parameters for Search, requires at least 2");

            string url = this.baseURI + this.rUri;
            try
            {
                this.lastResp = await htClient.GetStringAsync(url);
            }
            catch (Exception ex)
            {
                this.lastResp = url + " // " + ex.ToString();
            }

            return this.lastResp;
        }


    }


}
