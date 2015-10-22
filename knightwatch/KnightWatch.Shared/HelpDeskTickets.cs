using System;
using System.Net.Http;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using WinRTXamlToolkit.Controls.DataVisualization.Charting;
using Windows.UI.Xaml;

namespace KnightWatch
{
    class HelpDeskTickets
    {
        PriorityResponse priorityResponse = new PriorityResponse();
        StatusResponse statusResponse = new StatusResponse();
        CategoryResponse categoryResponse = new CategoryResponse();
        CriticalResponse critResponse = new CriticalResponse();


        public HelpDeskTickets()
        {
            priorityResponse.read();
            statusResponse.read();
            categoryResponse.read();
            critResponse.read();
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

        public CriticalResponse GetHelpDeskCriticalNotification()
        {
            return this.critResponse;
        }
    }

    [DataContract]
    internal class CriticalResponse : JSONReader
    {

        [DataMember]
        public bool isCritical { set { this._isCritical = value; this.initialized = true; } get { return this._isCritical; } }
        private bool _isCritical = false;

        public bool initialized = false;

        override public string webURI()
        {
            return "api/HelpDeskCriticalNotification/GetHelpDeskCriticalNotification/";
        }
        override public string dummyReply()
        {
            return "false";
        }
        override public void parse(string reply)
        {
            this.isCritical = (reply.Equals("true"));
        }
        public string stringify()
        {
            return Convert.ToString(this.isCritical);
        }

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
            return "api/HelpDeskTickets/GetCurrentCategory/";
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

        public const int PRIORITY_low = 3;
        public const int PRIORITY_medium = 2;
        public const int PRIORITY_high = 1;
        public const int PRIORITY_critical = 0;

        public const int STATUS_newStatus = 0;
        public const int STATUS_waitingReply = 1;
        public const int STATUS_replied = 2;
        public const int STATUS_resolved = 3;
        public const int STATUS_inProgress = 4;
        public const int STATUS_onHold = 5;

        public const int CATEGORY_general = 1;
        public const int CATEGORY_reqForStudentVM = 2;
        public const int CATEGORY_reqForSpecialityServers = 3;
        public const int CATEGORY_classTechIssues = 4;
        public const int CATEGORY_officeTechIssues = 5;
        public const int CATEGORY_departmentalWebsiteUpdate = 6;
        public const int CATEGORY_deanOfficeAdminSupport = 7;
        public const int CATEGORY_itAdminSupport = 8;
        public const int CATEGORY_csswweAdminSupport = 9;

        private string baseURI = "http://168.28.189.116/KnightWatch/api/HelpDeskTickets/";
        private string rUri = "";
        public int lastResp = 0;
        private HttpClient htClient = new HttpClient();

        public async Task<int> search(int priority = -1, int status = -1, int category = -1)
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
                this.lastResp = Convert.ToInt32(await htClient.GetStringAsync(url));
            }
            catch (Exception ex)
            {
                this.lastResp = -1;
            }

            return this.lastResp;
        }


    }

    class ChartHelper
    {
        protected TicketSearch ts = new TicketSearch();
        protected BarSeries freshSeries(string title)
        {
            BarSeries bs = new BarSeries();
            bs.Title = title;
            bs.Margin = new Thickness(0);
            bs.IndependentValuePath = "Name";
            bs.DependentValuePath = "Amount";
            //bs.DependentRangeAxis = new LinearAxis() { Orientation = AxisOrientation.X, Minimum = 0 , };
            return bs;
        }
    }

    class StatusChart : ChartHelper
    {
        Chart myChart = null;

        // CATEGORIES GO INTO THE STATUS CHART
        BarSeries bsCategoryGeneral;
        BarSeries bsCategoryStudentVM;
        BarSeries bsCategorySpecialityServers;
        BarSeries bsCategoryClassTech;
        BarSeries bsCategoryOfficeTech;
        BarSeries bsCategoryWebsiteUpdate;
        BarSeries bsCategoryDeanAdmin;
        BarSeries bsCategoryItAdmin;
        BarSeries bsCategoryCsswweAdmin;

        public StatusChart(Chart mychart)
        {
            this.myChart = mychart;
            this.myChart.Series.Clear();
            this.bsCategoryGeneral = freshSeries("general"); this.myChart.Series.Add(bsCategoryGeneral);
            this.bsCategoryStudentVM = freshSeries("reqForStudentVM"); this.myChart.Series.Add(bsCategoryStudentVM);
            this.bsCategorySpecialityServers = freshSeries("reqForSpecialityServers"); this.myChart.Series.Add(bsCategorySpecialityServers);
            this.bsCategoryClassTech = freshSeries("classTechIssues"); this.myChart.Series.Add(bsCategoryClassTech);
            this.bsCategoryOfficeTech = freshSeries("officeTechIssues"); this.myChart.Series.Add(bsCategoryOfficeTech);
            this.bsCategoryWebsiteUpdate = freshSeries("departmentalWebsiteUpdate"); this.myChart.Series.Add(bsCategoryWebsiteUpdate);
            this.bsCategoryDeanAdmin = freshSeries("deanOfficeAdminSupport"); this.myChart.Series.Add(bsCategoryDeanAdmin);
            this.bsCategoryItAdmin = freshSeries("itAdminSupport"); this.myChart.Series.Add(bsCategoryItAdmin);
            this.bsCategoryCsswweAdmin = freshSeries("csswweAdminSupport"); this.myChart.Series.Add(bsCategoryCsswweAdmin);
            readAll();
        }

        public async void readAll()
        {
            while(true)
            {
                readBsCategoryGeneral();
                readBsCategoryStudentVM();
                readBsCategorySpecialityServers();
                readBsCategoryClassTech();
                readBsCategoryOfficeTech();
                readBsCategoryWebsiteUpdate();
                readBsCategoryDeanAdmin();
                readBsCategoryItAdmin();
                readBsCategoryCsswweAdmin();
                await Task.Delay(10000);
            }
        }

        public async void readBsCategoryGeneral()
        {
            List<ChartData> barSeriesData = new List<ChartData>();
            barSeriesData.Add(new ChartData("New", await ts.search(category: TicketSearch.CATEGORY_general, status: TicketSearch.STATUS_newStatus)));
            barSeriesData.Add(new ChartData("Replied", await ts.search(category: TicketSearch.CATEGORY_general, status: TicketSearch.STATUS_replied)));
            barSeriesData.Add(new ChartData("In Progress", await ts.search(category: TicketSearch.CATEGORY_general, status: TicketSearch.STATUS_inProgress)));
            barSeriesData.Add(new ChartData("On Hold", await ts.search(category: TicketSearch.CATEGORY_general, status: TicketSearch.STATUS_onHold)));
            barSeriesData.Add(new ChartData("Waiting Reply", await ts.search(category: TicketSearch.CATEGORY_general, status: TicketSearch.STATUS_waitingReply)));
            barSeriesData.Add(new ChartData("Resolved", await ts.search(category: TicketSearch.CATEGORY_general, status: TicketSearch.STATUS_resolved)));
            bsCategoryGeneral.ItemsSource = barSeriesData;
        }

        public async void readBsCategoryStudentVM()
        {
            List<ChartData> barSeriesData = new List<ChartData>();
            barSeriesData.Add(new ChartData("New", await ts.search(category: TicketSearch.CATEGORY_reqForStudentVM, status: TicketSearch.STATUS_newStatus)));
            barSeriesData.Add(new ChartData("Replied", await ts.search(category: TicketSearch.CATEGORY_reqForStudentVM, status: TicketSearch.STATUS_replied)));
            barSeriesData.Add(new ChartData("In Progress", await ts.search(category: TicketSearch.CATEGORY_reqForStudentVM, status: TicketSearch.STATUS_inProgress)));
            barSeriesData.Add(new ChartData("On Hold", await ts.search(category: TicketSearch.CATEGORY_reqForStudentVM, status: TicketSearch.STATUS_onHold)));
            barSeriesData.Add(new ChartData("Waiting Reply", await ts.search(category: TicketSearch.CATEGORY_reqForStudentVM, status: TicketSearch.STATUS_waitingReply)));
            barSeriesData.Add(new ChartData("Resolved", await ts.search(category: TicketSearch.CATEGORY_reqForStudentVM, status: TicketSearch.STATUS_resolved)));
            bsCategoryStudentVM.ItemsSource = barSeriesData;
        }

        public async void readBsCategorySpecialityServers()
        {
            List<ChartData> barSeriesData = new List<ChartData>();
            barSeriesData.Add(new ChartData("New", await ts.search(category: TicketSearch.CATEGORY_reqForSpecialityServers, status: TicketSearch.STATUS_newStatus)));
            barSeriesData.Add(new ChartData("Replied", await ts.search(category: TicketSearch.CATEGORY_reqForSpecialityServers, status: TicketSearch.STATUS_replied)));
            barSeriesData.Add(new ChartData("In Progress", await ts.search(category: TicketSearch.CATEGORY_reqForSpecialityServers, status: TicketSearch.STATUS_inProgress)));
            barSeriesData.Add(new ChartData("On Hold", await ts.search(category: TicketSearch.CATEGORY_reqForSpecialityServers, status: TicketSearch.STATUS_onHold)));
            barSeriesData.Add(new ChartData("Waiting Reply", await ts.search(category: TicketSearch.CATEGORY_reqForSpecialityServers, status: TicketSearch.STATUS_waitingReply)));
            barSeriesData.Add(new ChartData("Resolved", await ts.search(category: TicketSearch.CATEGORY_reqForSpecialityServers, status: TicketSearch.STATUS_resolved)));
            bsCategorySpecialityServers.ItemsSource = barSeriesData;
        }

        public async void readBsCategoryClassTech()
        {
            List<ChartData> barSeriesData = new List<ChartData>();
            barSeriesData.Add(new ChartData("New", await ts.search(category: TicketSearch.CATEGORY_classTechIssues, status: TicketSearch.STATUS_newStatus)));
            barSeriesData.Add(new ChartData("Replied", await ts.search(category: TicketSearch.CATEGORY_classTechIssues, status: TicketSearch.STATUS_replied)));
            barSeriesData.Add(new ChartData("In Progress", await ts.search(category: TicketSearch.CATEGORY_classTechIssues, status: TicketSearch.STATUS_inProgress)));
            barSeriesData.Add(new ChartData("On Hold", await ts.search(category: TicketSearch.CATEGORY_classTechIssues, status: TicketSearch.STATUS_onHold)));
            barSeriesData.Add(new ChartData("Waiting Reply", await ts.search(category: TicketSearch.CATEGORY_classTechIssues, status: TicketSearch.STATUS_waitingReply)));
            barSeriesData.Add(new ChartData("Resolved", await ts.search(category: TicketSearch.CATEGORY_classTechIssues, status: TicketSearch.STATUS_resolved)));
            bsCategoryClassTech.ItemsSource = barSeriesData;
        }

        public async void readBsCategoryOfficeTech()
        {
            List<ChartData> barSeriesData = new List<ChartData>();
            barSeriesData.Add(new ChartData("New", await ts.search(category: TicketSearch.CATEGORY_officeTechIssues, status: TicketSearch.STATUS_newStatus)));
            barSeriesData.Add(new ChartData("Replied", await ts.search(category: TicketSearch.CATEGORY_officeTechIssues, status: TicketSearch.STATUS_replied)));
            barSeriesData.Add(new ChartData("In Progress", await ts.search(category: TicketSearch.CATEGORY_officeTechIssues, status: TicketSearch.STATUS_inProgress)));
            barSeriesData.Add(new ChartData("On Hold", await ts.search(category: TicketSearch.CATEGORY_officeTechIssues, status: TicketSearch.STATUS_onHold)));
            barSeriesData.Add(new ChartData("Waiting Reply", await ts.search(category: TicketSearch.CATEGORY_officeTechIssues, status: TicketSearch.STATUS_waitingReply)));
            barSeriesData.Add(new ChartData("Resolved", await ts.search(category: TicketSearch.CATEGORY_officeTechIssues, status: TicketSearch.STATUS_resolved)));
            bsCategoryOfficeTech.ItemsSource = barSeriesData;
        }

        public async void readBsCategoryWebsiteUpdate()
        {
            List<ChartData> barSeriesData = new List<ChartData>();
            barSeriesData.Add(new ChartData("New", await ts.search(category: TicketSearch.CATEGORY_departmentalWebsiteUpdate, status: TicketSearch.STATUS_newStatus)));
            barSeriesData.Add(new ChartData("Replied", await ts.search(category: TicketSearch.CATEGORY_departmentalWebsiteUpdate, status: TicketSearch.STATUS_replied)));
            barSeriesData.Add(new ChartData("In Progress", await ts.search(category: TicketSearch.CATEGORY_departmentalWebsiteUpdate, status: TicketSearch.STATUS_inProgress)));
            barSeriesData.Add(new ChartData("On Hold", await ts.search(category: TicketSearch.CATEGORY_departmentalWebsiteUpdate, status: TicketSearch.STATUS_onHold)));
            barSeriesData.Add(new ChartData("Waiting Reply", await ts.search(category: TicketSearch.CATEGORY_departmentalWebsiteUpdate, status: TicketSearch.STATUS_waitingReply)));
            barSeriesData.Add(new ChartData("Resolved", await ts.search(category: TicketSearch.CATEGORY_departmentalWebsiteUpdate, status: TicketSearch.STATUS_resolved)));
            bsCategoryWebsiteUpdate.ItemsSource = barSeriesData;
        }

        public async void readBsCategoryDeanAdmin()
        {
            List<ChartData> barSeriesData = new List<ChartData>();
            barSeriesData.Add(new ChartData("New", await ts.search(category: TicketSearch.CATEGORY_deanOfficeAdminSupport, status: TicketSearch.STATUS_newStatus)));
            barSeriesData.Add(new ChartData("Replied", await ts.search(category: TicketSearch.CATEGORY_deanOfficeAdminSupport, status: TicketSearch.STATUS_replied)));
            barSeriesData.Add(new ChartData("In Progress", await ts.search(category: TicketSearch.CATEGORY_deanOfficeAdminSupport, status: TicketSearch.STATUS_inProgress)));
            barSeriesData.Add(new ChartData("On Hold", await ts.search(category: TicketSearch.CATEGORY_deanOfficeAdminSupport, status: TicketSearch.STATUS_onHold)));
            barSeriesData.Add(new ChartData("Waiting Reply", await ts.search(category: TicketSearch.CATEGORY_deanOfficeAdminSupport, status: TicketSearch.STATUS_waitingReply)));
            barSeriesData.Add(new ChartData("Resolved", await ts.search(category: TicketSearch.CATEGORY_deanOfficeAdminSupport, status: TicketSearch.STATUS_resolved)));
            bsCategoryDeanAdmin.ItemsSource = barSeriesData;
        }

        public async void readBsCategoryItAdmin()
        {
            List<ChartData> barSeriesData = new List<ChartData>();
            barSeriesData.Add(new ChartData("New", await ts.search(category: TicketSearch.CATEGORY_itAdminSupport, status: TicketSearch.STATUS_newStatus)));
            barSeriesData.Add(new ChartData("Replied", await ts.search(category: TicketSearch.CATEGORY_itAdminSupport, status: TicketSearch.STATUS_replied)));
            barSeriesData.Add(new ChartData("In Progress", await ts.search(category: TicketSearch.CATEGORY_itAdminSupport, status: TicketSearch.STATUS_inProgress)));
            barSeriesData.Add(new ChartData("On Hold", await ts.search(category: TicketSearch.CATEGORY_itAdminSupport, status: TicketSearch.STATUS_onHold)));
            barSeriesData.Add(new ChartData("Waiting Reply", await ts.search(category: TicketSearch.CATEGORY_itAdminSupport, status: TicketSearch.STATUS_waitingReply)));
            barSeriesData.Add(new ChartData("Resolved", await ts.search(category: TicketSearch.CATEGORY_itAdminSupport, status: TicketSearch.STATUS_resolved)));
            bsCategoryItAdmin.ItemsSource = barSeriesData;
        }

        public async void readBsCategoryCsswweAdmin()
        {
            List<ChartData> barSeriesData = new List<ChartData>();
            barSeriesData.Add(new ChartData("New", await ts.search(category: TicketSearch.CATEGORY_csswweAdminSupport, status: TicketSearch.STATUS_newStatus)));
            barSeriesData.Add(new ChartData("Replied", await ts.search(category: TicketSearch.CATEGORY_csswweAdminSupport, status: TicketSearch.STATUS_replied)));
            barSeriesData.Add(new ChartData("In Progress", await ts.search(category: TicketSearch.CATEGORY_csswweAdminSupport, status: TicketSearch.STATUS_inProgress)));
            barSeriesData.Add(new ChartData("On Hold", await ts.search(category: TicketSearch.CATEGORY_csswweAdminSupport, status: TicketSearch.STATUS_onHold)));
            barSeriesData.Add(new ChartData("Waiting Reply", await ts.search(category: TicketSearch.CATEGORY_csswweAdminSupport, status: TicketSearch.STATUS_waitingReply)));
            barSeriesData.Add(new ChartData("Resolved", await ts.search(category: TicketSearch.CATEGORY_csswweAdminSupport, status: TicketSearch.STATUS_resolved)));
            bsCategoryCsswweAdmin.ItemsSource = barSeriesData;
        }
  

    }

    class CategoryChart : ChartHelper
    {
        Chart myChart = null;

        // CATEGORIES GO INTO THE STATUS CHART
        BarSeries bsPriorityLow;
        BarSeries bsPriorityMedium;
        BarSeries bsPriorityHigh;
        BarSeries bsPriorityCritical;


        public CategoryChart(Chart mychart)
        {
            this.myChart = mychart;
            this.myChart.Series.Clear();
            this.bsPriorityLow = freshSeries("Low"); this.myChart.Series.Add(bsPriorityLow);
            this.bsPriorityMedium = freshSeries("Medium"); this.myChart.Series.Add(bsPriorityMedium);
            this.bsPriorityHigh = freshSeries("High"); this.myChart.Series.Add(bsPriorityHigh);
            this.bsPriorityCritical = freshSeries("Critical"); this.myChart.Series.Add(bsPriorityCritical);
            readAll();
        }

        public async void readAll()
        {
            while (true)
            {
                readBsPriorityLow();
                readBsPriorityMedium();
                readBsPriorityHigh();
                readBsPriorityCritical();
                await Task.Delay(10000);
            }
        }

        public async void readBsPriorityLow()
        {

            List<ChartData> barSeriesData = new List<ChartData>();
            barSeriesData.Add(new ChartData("CATEGORY_general", await ts.search(category: TicketSearch.CATEGORY_general, priority: TicketSearch.PRIORITY_low)));
            barSeriesData.Add(new ChartData("CATEGORY_reqForStudentVM", await ts.search(category: TicketSearch.CATEGORY_reqForStudentVM, priority: TicketSearch.PRIORITY_low)));
            barSeriesData.Add(new ChartData("CATEGORY_reqForSpecialityServers", await ts.search(category: TicketSearch.CATEGORY_reqForSpecialityServers, priority: TicketSearch.PRIORITY_low)));
            barSeriesData.Add(new ChartData("CATEGORY_classTechIssues", await ts.search(category: TicketSearch.CATEGORY_classTechIssues, priority: TicketSearch.PRIORITY_low)));
            barSeriesData.Add(new ChartData("CATEGORY_officeTechIssues", await ts.search(category: TicketSearch.CATEGORY_officeTechIssues, priority: TicketSearch.PRIORITY_low)));
            barSeriesData.Add(new ChartData("CATEGORY_departmentalWebsiteUpdate", await ts.search(category: TicketSearch.CATEGORY_departmentalWebsiteUpdate, priority: TicketSearch.PRIORITY_low)));
            barSeriesData.Add(new ChartData("CATEGORY_deanOfficeAdminSupport", await ts.search(category: TicketSearch.CATEGORY_deanOfficeAdminSupport, priority: TicketSearch.PRIORITY_low)));
            barSeriesData.Add(new ChartData("CATEGORY_itAdminSupport", await ts.search(category: TicketSearch.CATEGORY_itAdminSupport, priority: TicketSearch.PRIORITY_low)));
            barSeriesData.Add(new ChartData("CATEGORY_csswweAdminSupport", await ts.search(category: TicketSearch.CATEGORY_csswweAdminSupport, priority: TicketSearch.PRIORITY_low)));
            bsPriorityLow.ItemsSource = barSeriesData;
        }

        public async void readBsPriorityMedium()
        {
            List<ChartData> barSeriesData = new List<ChartData>();
            barSeriesData.Add(new ChartData("CATEGORY_general", await ts.search(category: TicketSearch.CATEGORY_general, priority: TicketSearch.PRIORITY_medium)));
            barSeriesData.Add(new ChartData("CATEGORY_reqForStudentVM", await ts.search(category: TicketSearch.CATEGORY_reqForStudentVM, priority: TicketSearch.PRIORITY_medium)));
            barSeriesData.Add(new ChartData("CATEGORY_reqForSpecialityServers", await ts.search(category: TicketSearch.CATEGORY_reqForSpecialityServers, priority: TicketSearch.PRIORITY_medium)));
            barSeriesData.Add(new ChartData("CATEGORY_classTechIssues", await ts.search(category: TicketSearch.CATEGORY_classTechIssues, priority: TicketSearch.PRIORITY_medium)));
            barSeriesData.Add(new ChartData("CATEGORY_officeTechIssues", await ts.search(category: TicketSearch.CATEGORY_officeTechIssues, priority: TicketSearch.PRIORITY_medium)));
            barSeriesData.Add(new ChartData("CATEGORY_departmentalWebsiteUpdate", await ts.search(category: TicketSearch.CATEGORY_departmentalWebsiteUpdate, priority: TicketSearch.PRIORITY_medium)));
            barSeriesData.Add(new ChartData("CATEGORY_deanOfficeAdminSupport", await ts.search(category: TicketSearch.CATEGORY_deanOfficeAdminSupport, priority: TicketSearch.PRIORITY_medium)));
            barSeriesData.Add(new ChartData("CATEGORY_itAdminSupport", await ts.search(category: TicketSearch.CATEGORY_itAdminSupport, priority: TicketSearch.PRIORITY_medium)));
            barSeriesData.Add(new ChartData("CATEGORY_csswweAdminSupport", await ts.search(category: TicketSearch.CATEGORY_csswweAdminSupport, priority: TicketSearch.PRIORITY_medium)));
            bsPriorityMedium.ItemsSource = barSeriesData;
        }

        public async void readBsPriorityHigh()
        {
            List<ChartData> barSeriesData = new List<ChartData>();
            barSeriesData.Add(new ChartData("CATEGORY_general", await ts.search(category: TicketSearch.CATEGORY_general, priority: TicketSearch.PRIORITY_high)));
            barSeriesData.Add(new ChartData("CATEGORY_reqForStudentVM", await ts.search(category: TicketSearch.CATEGORY_reqForStudentVM, priority: TicketSearch.PRIORITY_high)));
            barSeriesData.Add(new ChartData("CATEGORY_reqForSpecialityServers", await ts.search(category: TicketSearch.CATEGORY_reqForSpecialityServers, priority: TicketSearch.PRIORITY_high)));
            barSeriesData.Add(new ChartData("CATEGORY_classTechIssues", await ts.search(category: TicketSearch.CATEGORY_classTechIssues, priority: TicketSearch.PRIORITY_high)));
            barSeriesData.Add(new ChartData("CATEGORY_officeTechIssues", await ts.search(category: TicketSearch.CATEGORY_officeTechIssues, priority: TicketSearch.PRIORITY_high)));
            barSeriesData.Add(new ChartData("CATEGORY_departmentalWebsiteUpdate", await ts.search(category: TicketSearch.CATEGORY_departmentalWebsiteUpdate, priority: TicketSearch.PRIORITY_high)));
            barSeriesData.Add(new ChartData("CATEGORY_deanOfficeAdminSupport", await ts.search(category: TicketSearch.CATEGORY_deanOfficeAdminSupport, priority: TicketSearch.PRIORITY_high)));
            barSeriesData.Add(new ChartData("CATEGORY_itAdminSupport", await ts.search(category: TicketSearch.CATEGORY_itAdminSupport, priority: TicketSearch.PRIORITY_high)));
            barSeriesData.Add(new ChartData("CATEGORY_csswweAdminSupport", await ts.search(category: TicketSearch.CATEGORY_csswweAdminSupport, priority: TicketSearch.PRIORITY_high)));
            bsPriorityHigh.ItemsSource = barSeriesData;
        }

        public async void readBsPriorityCritical()
        {
            List<ChartData> barSeriesData = new List<ChartData>();
            barSeriesData.Add(new ChartData("CATEGORY_general", await ts.search(category: TicketSearch.CATEGORY_general, priority: TicketSearch.PRIORITY_critical)));
            barSeriesData.Add(new ChartData("CATEGORY_reqForStudentVM", await ts.search(category: TicketSearch.CATEGORY_reqForStudentVM, priority: TicketSearch.PRIORITY_critical)));
            barSeriesData.Add(new ChartData("CATEGORY_reqForSpecialityServers", await ts.search(category: TicketSearch.CATEGORY_reqForSpecialityServers, priority: TicketSearch.PRIORITY_critical)));
            barSeriesData.Add(new ChartData("CATEGORY_classTechIssues", await ts.search(category: TicketSearch.CATEGORY_classTechIssues, priority: TicketSearch.PRIORITY_critical)));
            barSeriesData.Add(new ChartData("CATEGORY_officeTechIssues", await ts.search(category: TicketSearch.CATEGORY_officeTechIssues, priority: TicketSearch.PRIORITY_critical)));
            barSeriesData.Add(new ChartData("CATEGORY_departmentalWebsiteUpdate", await ts.search(category: TicketSearch.CATEGORY_departmentalWebsiteUpdate, priority: TicketSearch.PRIORITY_critical)));
            barSeriesData.Add(new ChartData("CATEGORY_deanOfficeAdminSupport", await ts.search(category: TicketSearch.CATEGORY_deanOfficeAdminSupport, priority: TicketSearch.PRIORITY_critical)));
            barSeriesData.Add(new ChartData("CATEGORY_itAdminSupport", await ts.search(category: TicketSearch.CATEGORY_itAdminSupport, priority: TicketSearch.PRIORITY_critical)));
            barSeriesData.Add(new ChartData("CATEGORY_csswweAdminSupport", await ts.search(category: TicketSearch.CATEGORY_csswweAdminSupport, priority: TicketSearch.PRIORITY_critical)));
            bsPriorityCritical.ItemsSource = barSeriesData;
        }



    }

    class PriorityChart : ChartHelper
    {
        Chart myChart = null;

        // STATUSES GO INTO THE PRIORITY CHART
        BarSeries bsStatusNew;
        BarSeries bsStatusReplied;
        BarSeries bsStatusInProgress;
        BarSeries bsStatusOnHold;
        BarSeries bsStatusWaitingReply;
        BarSeries bsStatusResolved;


        public PriorityChart(Chart mychart)
        {
            this.myChart = mychart;
            this.myChart.Series.Clear();
            this.bsStatusNew = freshSeries("New"); this.myChart.Series.Add(bsStatusNew);
            this.bsStatusReplied = freshSeries("Replied"); this.myChart.Series.Add(bsStatusReplied);
            this.bsStatusInProgress = freshSeries("In Progress"); this.myChart.Series.Add(bsStatusInProgress);
            this.bsStatusOnHold = freshSeries("On Hold"); this.myChart.Series.Add(bsStatusOnHold);
            this.bsStatusWaitingReply = freshSeries("Waiting Reply"); this.myChart.Series.Add(bsStatusWaitingReply);
            this.bsStatusResolved = freshSeries("Resolved"); this.myChart.Series.Add(bsStatusResolved);
            readAll();
        }

        public async void readAll()
        {
            while (true)
            {
                readBsStatusNew();
                readBsStatusReplied();
                readBsStatusInProgress();
                readBsStatusOnHold();
                readBsStatusWaitingReply();
                readBsStatusResolved();
                await Task.Delay(10000);
            }
        }

        public async void readBsStatusNew()
        {

            List<ChartData> barSeriesData = new List<ChartData>();
            barSeriesData.Add(new ChartData("Low", await ts.search(status: TicketSearch.STATUS_newStatus, priority: TicketSearch.PRIORITY_low)));
            barSeriesData.Add(new ChartData("Medium", await ts.search(status: TicketSearch.STATUS_newStatus, priority: TicketSearch.PRIORITY_medium)));
            barSeriesData.Add(new ChartData("High", await ts.search(status: TicketSearch.STATUS_newStatus, priority: TicketSearch.PRIORITY_high)));
            barSeriesData.Add(new ChartData("Critical", await ts.search(status: TicketSearch.STATUS_newStatus, priority: TicketSearch.PRIORITY_critical)));
            bsStatusNew.ItemsSource = barSeriesData;
        }

        public async void readBsStatusReplied()
        {
            List<ChartData> barSeriesData = new List<ChartData>();
            barSeriesData.Add(new ChartData("Low", await ts.search(status: TicketSearch.STATUS_replied, priority: TicketSearch.PRIORITY_low)));
            barSeriesData.Add(new ChartData("Medium", await ts.search(status: TicketSearch.STATUS_replied, priority: TicketSearch.PRIORITY_medium)));
            barSeriesData.Add(new ChartData("High", await ts.search(status: TicketSearch.STATUS_replied, priority: TicketSearch.PRIORITY_high)));
            barSeriesData.Add(new ChartData("Critical", await ts.search(status: TicketSearch.STATUS_replied, priority: TicketSearch.PRIORITY_critical)));
            bsStatusReplied.ItemsSource = barSeriesData;
        }

        public async void readBsStatusInProgress()
        {
            List<ChartData> barSeriesData = new List<ChartData>();
            barSeriesData.Add(new ChartData("Low", await ts.search(status: TicketSearch.STATUS_inProgress, priority: TicketSearch.PRIORITY_low)));
            barSeriesData.Add(new ChartData("Medium", await ts.search(status: TicketSearch.STATUS_inProgress, priority: TicketSearch.PRIORITY_medium)));
            barSeriesData.Add(new ChartData("High", await ts.search(status: TicketSearch.STATUS_inProgress, priority: TicketSearch.PRIORITY_high)));
            barSeriesData.Add(new ChartData("Critical", await ts.search(status: TicketSearch.STATUS_inProgress, priority: TicketSearch.PRIORITY_critical)));
            bsStatusInProgress.ItemsSource = barSeriesData;
        }

        public async void readBsStatusOnHold()
        {
            List<ChartData> barSeriesData = new List<ChartData>();
            barSeriesData.Add(new ChartData("Low", await ts.search(status: TicketSearch.STATUS_onHold, priority: TicketSearch.PRIORITY_low)));
            barSeriesData.Add(new ChartData("Medium", await ts.search(status: TicketSearch.STATUS_onHold, priority: TicketSearch.PRIORITY_medium)));
            barSeriesData.Add(new ChartData("High", await ts.search(status: TicketSearch.STATUS_onHold, priority: TicketSearch.PRIORITY_high)));
            barSeriesData.Add(new ChartData("Critical", await ts.search(status: TicketSearch.STATUS_onHold, priority: TicketSearch.PRIORITY_critical)));
            bsStatusOnHold.ItemsSource = barSeriesData;
        }

        public async void readBsStatusWaitingReply()
        {
            List<ChartData> barSeriesData = new List<ChartData>();
            barSeriesData.Add(new ChartData("Low", await ts.search(status: TicketSearch.STATUS_waitingReply, priority: TicketSearch.PRIORITY_low)));
            barSeriesData.Add(new ChartData("Medium", await ts.search(status: TicketSearch.STATUS_waitingReply, priority: TicketSearch.PRIORITY_medium)));
            barSeriesData.Add(new ChartData("High", await ts.search(status: TicketSearch.STATUS_waitingReply, priority: TicketSearch.PRIORITY_high)));
            barSeriesData.Add(new ChartData("Critical", await ts.search(status: TicketSearch.STATUS_waitingReply, priority: TicketSearch.PRIORITY_critical)));
            bsStatusWaitingReply.ItemsSource = barSeriesData;
        }

        public async void readBsStatusResolved()
        {
            List<ChartData> barSeriesData = new List<ChartData>();
            barSeriesData.Add(new ChartData("Low", await ts.search(status: TicketSearch.STATUS_resolved, priority: TicketSearch.PRIORITY_low)));
            barSeriesData.Add(new ChartData("Medium", await ts.search(status: TicketSearch.STATUS_resolved, priority: TicketSearch.PRIORITY_medium)));
            barSeriesData.Add(new ChartData("High", await ts.search(status: TicketSearch.STATUS_resolved, priority: TicketSearch.PRIORITY_high)));
            barSeriesData.Add(new ChartData("Critical", await ts.search(status: TicketSearch.STATUS_resolved, priority: TicketSearch.PRIORITY_critical)));
            bsStatusResolved.ItemsSource = barSeriesData;
        }



    }


}
