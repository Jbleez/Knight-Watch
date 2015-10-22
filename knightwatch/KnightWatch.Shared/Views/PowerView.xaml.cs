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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace KnightWatch.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PowerView : Page
    {
        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();

        PowerManagement pm = new PowerManagement();
        Fan fanOne = new Fan(1);

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

        public PowerView()
        {
            this.InitializeComponent();
            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += navigationHelper_LoadState;
            this.navigationHelper.SaveState += navigationHelper_SaveState;
            this.getData(true);
            this.Loaded += mainPage_Loaded;


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
        List<stripChart> clearlist(List<stripChart> l)
        {
            
            Random r = new Random();
            if (l == null)
            { 
            l.Add(new stripChart(1, (double)r.Next(0, 200)));
            l.Add(new stripChart(2, (double)r.Next(0, 200)));
            l.Add(new stripChart(3, (double)r.Next(0, 200)));
            l.Add(new stripChart(4, (double)r.Next(0, 200)));
            l.Add(new stripChart(5, (double)r.Next(0, 200)));
            l.Add(new stripChart(6, (double)r.Next(0, 200)));
            l.Add(new stripChart(7, (double)r.Next(0, 200)));
            l.Add(new stripChart(8, (double)r.Next(0, 200)));
            l.Add(new stripChart(9, (double)r.Next(0, 200)));
                }
            return l;
        }
        private void LoadChartContents()
        {
            Random r = new Random();
            List<ChartData> ChartDataListfan1 = new List<ChartData>();
            List<ChartData> ChartDataListfan2 = new List<ChartData>();
            List<ChartData> ChartDataListfan3 = new List<ChartData>();
            ChartData cd = new ChartData();
            //  List<ChartData> ChartDataListfan4 = new List<ChartData>();

            /// Fan One

                // Speed
                fanGauge0.Value = fanOne.getSpeed().speed;
            
                // Temp
                List<ChartData> fanOneTemp = new List<ChartData>();
                fanOneTemp.Add(new ChartData(1, fanOne.getTemp().returnAirTemp));
                (fan1SupplyTemp.Series[0] as LineSeries).ItemsSource = fanOneTemp;

                // Cooling
                List<ChartData> fanOneCoolingDemand = new List<ChartData>();
                List<ChartData> fanOneCoolingOutput = new List<ChartData>();
                fanOneCoolingDemand.Add(new ChartData(1, fanOne.getCooling().coolDemand));
                fanOneCoolingOutput.Add(new ChartData(1, fanOne.getCooling().coolOutput));
                (fan1Cooldemand.Series[0] as AreaSeries).ItemsSource = fanOneCoolingDemand;
                (fan1Cooldemand.Series[1] as AreaSeries).ItemsSource = fanOneCoolingOutput;

            /// End Fan One
            
            //fanGauge1.Value = r.Next(0, 200);
            //fanGauge3.Value = r.Next(0, 200);

            //supplyfan
            
            //ChartDataListfan1.Add(new ChartData(2, r.Next(0, 200)));
            //ChartDataListfan1.Add(new ChartData(3, r.Next(0, 200)));
            //ChartDataListfan1.Add(new ChartData(4, r.Next(0, 200)));

            /*
            //outfan
            ChartDataListfan1.Add(new ChartData(5, r.Next(0, 200)));
            ChartDataListfan1.Add(new ChartData(6, r.Next(0, 200)));
            ChartDataListfan1.Add(new ChartData(7, r.Next(0, 200)));
            ChartDataListfan1.Add(new ChartData(8, r.Next(0, 200)));
          .
            //coutput
            ChartDataListfan1.Add(new ChartData(9, r.Next(0, 200)));
       
            //superheat

            //supplyfan
            ChartDataListfan1.Add(new ChartData(1, r.Next(0, 200)));
            ChartDataListfan1.Add(new ChartData(2, r.Next(0, 200)));
            ChartDataListfan1.Add(new ChartData(3, r.Next(0, 200)));
            ChartDataListfan1.Add(new ChartData(4, r.Next(0, 78)));


            ChartDataListfan2.Add(new ChartData(5, r.Next(0,200)));
            ChartDataListfan2.Add(new ChartData(6, r.Next(0, 200)));
            ChartDataListfan2.Add(new ChartData(7, r.Next(0, 200)));
            ChartDataListfan2.Add(new ChartData(8, r.Next(0, 200)));
            */


            /*
            (fan1Output.Series[0] as LineSeries).ItemsSource = ChartDataListfan1;

            (fan1Cooldemand.Series[0] as AreaSeries).ItemsSource = ChartDataListfan2;
            (fan1Cooldemand.Series[1] as AreaSeries).ItemsSource = ChartDataListfan1;

            (fan1SupplyTemp.Series[0] as LineSeries).ItemsSource = ChartDataListfan1;
            (fan1Output.Series[0] as LineSeries).ItemsSource = ChartDataListfan1;
            (fan1Superheat.Series[0] as LineSeries).ItemsSource = ChartDataListfan1; 
            */


            //fan2
            /*
            (fan2SupplyTemp.Series[0] as LineSeries).ItemsSource = ChartDataListfan1;
            (fan2Output.Series[0] as LineSeries).ItemsSource = ChartDataListfan1;

            (fan2Cooldemand.Series[0] as AreaSeries).ItemsSource = ChartDataListfan2;
            (fan2Cooldemand.Series[1] as AreaSeries).ItemsSource = ChartDataListfan1;

            (fan2SupplyTemp.Series[0] as LineSeries).ItemsSource = ChartDataListfan1;
            (fan2Output.Series[0] as LineSeries).ItemsSource = ChartDataListfan1;
            (fan2Superheat.Series[0] as LineSeries).ItemsSource = ChartDataListfan1;
            
            //fan3
            (fan3SupplyTemp.Series[0] as LineSeries).ItemsSource = ChartDataListfan1;
            (fan3Output.Series[0] as LineSeries).ItemsSource = ChartDataListfan1;

            (fan3Cooldemand.Series[0] as AreaSeries).ItemsSource = ChartDataListfan2;
            (fan3Cooldemand.Series[1] as AreaSeries).ItemsSource = ChartDataListfan1;

            (fan3SupplyTemp.Series[0] as LineSeries).ItemsSource = ChartDataListfan1;
            (fan3Output.Series[0] as LineSeries).ItemsSource = ChartDataListfan1;
            (fan3Superheat.Series[0] as LineSeries).ItemsSource = ChartDataListfan1;
            */
       
     
            List<stripChart> strip1Chart = new List<stripChart>();
            List<stripChart> strip2Chart = new List<stripChart>();
            List<stripChart> strip3Chart = new List<stripChart>();

            strip1Chart = clearlist(strip1Chart);
            strip2Chart = clearlist(strip2Chart);
            strip3Chart = clearlist(strip3Chart);

            // Strip Data

            List<ChartData> strip1_1 = new List<ChartData>(); strip1_1.Add(new ChartData(1, pm.GetCurrentPDUData().module1load1));
            List<ChartData> strip1_2 = new List<ChartData>(); strip1_1.Add(new ChartData(1, pm.GetCurrentPDUData().module1load2));
            List<ChartData> strip1_3 = new List<ChartData>(); strip1_1.Add(new ChartData(1, pm.GetCurrentPDUData().module1load3));
            (strip1.Series[0] as LineSeries).ItemsSource = strip1_1;
            (strip1.Series[1] as LineSeries).ItemsSource = strip1_2;
            (strip1.Series[2] as LineSeries).ItemsSource = strip1_3;

            (strip2.Series[0] as LineSeries).ItemsSource = ChartDataListfan1;
            (strip2.Series[1] as LineSeries).ItemsSource = ChartDataListfan1;
            (strip2.Series[2] as LineSeries).ItemsSource = ChartDataListfan1;

            (strip3.Series[0] as LineSeries).ItemsSource = ChartDataListfan1;
            (strip3.Series[1] as LineSeries).ItemsSource = ChartDataListfan1;
            (strip3.Series[2] as LineSeries).ItemsSource = ChartDataListfan1;
            (strip4.Series[0] as LineSeries).ItemsSource = ChartDataListfan1;
            (strip4.Series[1] as LineSeries).ItemsSource = ChartDataListfan1;
            (strip4.Series[2] as LineSeries).ItemsSource = ChartDataListfan1;
            (strip5.Series[0] as LineSeries).ItemsSource = ChartDataListfan1;
            (strip5.Series[1] as LineSeries).ItemsSource = ChartDataListfan1;
            (strip5.Series[2] as LineSeries).ItemsSource = ChartDataListfan1;
            (strip6.Series[0] as LineSeries).ItemsSource = ChartDataListfan1;
            (strip6.Series[1] as LineSeries).ItemsSource = ChartDataListfan1;
            (strip6.Series[2] as LineSeries).ItemsSource = ChartDataListfan1;
            



            //fanGauge0.Value = new Random().Next(0, 200);
            //fanGauge1.Value = new Random().Next(0, 85);
            //fanGauge3.Value = new Random().Next(0, 336);
        
            //((PieSeries)this.piec.Series[0]).DependentRangeAxis = new LinearAxis() { Minimum = 0, Maximum = 20, Orientation = AxisOrientation.X, Interval = 2 };

           // (BarChart.Series[0] as BarSeries).ItemsSource = ChartDataList;
           //((BarSeries)this.BarChart.Series[0]).DependentRangeAxis = new LinearAxis() { Minimum = 0, Maximum = 20, Orientation = AxisOrientation.X, Interval = 2 };

        }



        bool liveUpdate = true;
        int ticks = 0;
        public async void getData(bool again)
        {

            this.liveUpdate = again;
            this.Loaded += mainPage_Loaded;


            this.LoadChartContents();


            //raw.Text = pr.stringify() + " (" + ticks + ") / " + pr.lastResp;


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

        private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(powerstripsView));
        }

        private void HyperlinkButton_Click1(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(pduView));
        }

    }
}