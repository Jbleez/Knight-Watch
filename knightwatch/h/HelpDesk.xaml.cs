using KnightWatch.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using WinRTXamlToolkit.Controls.DataVisualization.Charting;



namespace KnightWatch.Views
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class HelpDesk : Page
    {

        private NavigationHelper navigationHelper;
        private int low, high, medium, critical;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();

        HelpDeskTickets hdt = new HelpDeskTickets();
        TicketSearch ts = new TicketSearch();


        /// <summary>
        /// This can be changed to a strongly typed view model.
        /// </summary>
        public ObservableDictionary DefaultViewModel
        {
            get { return this.defaultViewModel; }
        }

        /// <summary>
        /// NavigationHelper is used on each page to aid in navigation and 
        /// process lifetime management
        /// </summary>
        public NavigationHelper NavigationHelper
        {
            get { return this.navigationHelper; }
        }


        public HelpDesk()
        {
            this.InitializeComponent();
            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += navigationHelper_LoadState;
            this.navigationHelper.SaveState += navigationHelper_SaveState;
            this.getData(true);
            this.Loaded += mainPage_Loaded;
           
            low = 0;
            medium = 0;
            high = 0;
            critical = 0;
        }

        /// <summary>
        /// Populates the page with content passed during navigation. Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="sender">
        /// The source of the event; typically <see cref="NavigationHelper"/>
        /// </param>
        /// <param name="e">Event data that provides both the navigation parameter passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested and
        /// a dictionary of state preserved by this page during an earlier
        /// session. The state will be null the first time a page is visited.</param>
        private void navigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
        }

        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache.  Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="sender">The source of the event; typically <see cref="NavigationHelper"/></param>
        /// <param name="e">Event data that provides an empty dictionary to be populated with
        /// serializable state.</param>
        private void navigationHelper_SaveState(object sender, SaveStateEventArgs e)
        {
        }

        #region NavigationHelper registration

        /// The methods provided in this section are simply used to allow
        /// NavigationHelper to respond to the page's navigation methods.
        /// 
        /// Page specific logic should be placed in event handlers for the  
        /// <see cref="GridCS.Common.NavigationHelper.LoadState"/>
        /// and <see cref="GridCS.Common.NavigationHelper.SaveState"/>.
        /// The navigation parameter is available in the LoadState method 
        /// in addition to page state preserved during an earlier session.

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            navigationHelper.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            navigationHelper.OnNavigatedFrom(e);
        }

        #endregion
     


        void mainPage_Loaded(object sender, RoutedEventArgs e)
        {
            LoadChartContents();
        }

        private void LoadChartContents()
        {
            List<ChartData> ChartDataList = new List<ChartData>();
            ChartDataList.Add(new ChartData() { Name = "Low", Amount = low });
            ChartDataList.Add(new ChartData() { Name = "Medium", Amount = medium});
            ChartDataList.Add(new ChartData() { Name = "High", Amount = high });
            ChartDataList.Add(new ChartData() { Name = "critical", Amount = critical});
            (BarChart.Series[0] as BarSeries).ItemsSource = ChartDataList;
            ((BarSeries)this.BarChart.Series[0]).DependentRangeAxis = new LinearAxis() { Minimum = 0, Maximum = 20, Orientation = AxisOrientation.X, Interval=2 };
           
        }



        bool liveUpdate = true;
        int ticks = 0;
        public async void getData(bool again)
        {

            this.liveUpdate = again;
            this.Loaded += mainPage_Loaded;

            PriorityResponse pr = hdt.GetCurrentPriority();

            low = pr.low;
            medium = pr.medium;
            high = pr.high;
            critical = pr.critical;
            this.LoadChartContents();
            

            raw.Text = pr.stringify()+" ("+ticks+") / "+pr.lastResp;

            await Task.Delay(1000);

            // Just testing the searcher. 
            /*
            string reply = await ts.search(priority: 2, status: 1);
            raw.Text = reply;
            await Task.Delay(5000);
            */

            if (again)
            {
                await Task.Delay(1000);
                this.getData(this.liveUpdate);
                ticks++;
            }
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {

        }
           
        }
    
    }

