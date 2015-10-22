using KnightWatch.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Windows.UI.Xaml.Shapes;
using WinRTXamlToolkit.Controls.DataVisualization.Charting;
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace KnightWatch
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        HelpDeskTickets hdt = new HelpDeskTickets();
        //Make a place to store the timer
        private readonly DispatcherTimer _timer;
        int timesTicked = 1;
        int timesToTick = 2;
        int count = 0;

        //Make a place to store the last time the displayed item was set
        private DateTime _lastChange;

        public MainPage()
        {
            


            this.InitializeComponent();

            TheFlipView.Items[0] = new HelpDesk();
            TheFlipView.Items[1] = new PowerView();
            TheFlipView.Items[2] = new NetworkM();
            TheFlipView.Items[3] = new VirtualE();
               //Configure the timer
            _timer = new DispatcherTimer
            {
                //Set the interval between ticks (in this case 8 seconds to see it working)
                Interval = TimeSpan.FromSeconds(8)
            };
            if (count == 0)
            { //Start the timer
                _timer.Start();
             
                //Change what's displayed when the timer ticks
                count++;
            }
          
            _timer.Tick += ChangePage;
            
          


          //  this.Loaded += MainPage_Loaded;
        }

        ObservableCollection<MainPageItems> itemList = new ObservableCollection<MainPageItems>();
        /// <summary>
        /// Changes when the timer ticks
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="o"></param>
        private void ChangePage(object sender, object o)
        {
            //Get the number of items in the flip view
             timesTicked++;
            if (timesTicked > timesToTick)
            {
                _timer.Stop();
                _timer.Start();
              
            }
    
            var newItemIndex=0;
            //Figure out the new item's index (the current index plus one, if the next item would be out of range, go back to zero)
            if (TheFlipView.SelectedIndex != 3)
                newItemIndex = TheFlipView.SelectedIndex + 1;
            else
            {
                newItemIndex = 0;
           
            }

            //Set the displayed item's index on the flip view

            TheFlipView.SelectedIndex = newItemIndex;

        }




        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
           /* itemList.Add(new MainPageItems() { Name = "Help Desk", Width = 250, ColSpan = 1, RowSpan = 1, UserImage = "Assets/s2.png" });
            itemList.Add(new MainPageItems() { Name = "Power Management", Width = 250, ColSpan = 1, RowSpan = 1, UserImage = "Assets/120405-1e-w.jpg" });
            itemList.Add(new MainPageItems() { Name = "Network Management", Width = 250, ColSpan = 1, RowSpan = 1, UserImage = "Assets/network_management_mid.jpg" });
            itemList.Add(new MainPageItems() { Name = "Virtual Environment", Width = 250, ColSpan = 1, RowSpan = 1, UserImage = "Assets/virtual-environment-easy-thumb.png" });
            itemList.Add(new MainPageItems() { Name = "Backup Status", Width=500, ColSpan = 1, RowSpan = 1, UserImage = "Assets/Settings-Backup-Sync-icon.png" });
            itemList.Add(new MainPageItems() { Name = "Admin Management", Width = 500, ColSpan = 1, RowSpan = 1, UserImage = "Assets/Administration.jpeg" });

            GridViewMainPage.ItemsSource = itemList;*/
        }

   /*  public void ItemClickHandler(object sender, ItemClickEventArgs e)
        {
            MainPageItems _item = e.ClickedItem as MainPageItems;

            if (_item.Name == "Help Desk")
              
                {
                    Services.Navigation.GotoHelpDesk();
                }
            else if (_item.Name == "Virtual Environment")
            {
                Services.Navigation.GotoVE();
            }
            else if (_item.Name == "Power Management")
            {
                Services.Navigation.GotoPM();
            }
            else if (_item.Name == "Network Management")
            {
                Services.Navigation.GotoNM();
            }

            else if (_item.Name == "Backup Status")
            {
                Services.Navigation.GotoBS();
            }
            else if (_item.Name == "Admin Management")
            {
                Services.Navigation.GotoAB();
            }
        
        
        }*/

      
     /* 
        private void RemoveRequest(MainPageItems item)
        {
            itemList.Remove(item);
        }
      * 
      * */
        /// <summary>
        /// When the user changes the item displayed manually, reset the timer so we don't advance at the remainder of the last interval
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DisplayedItemChanged(object sender, SelectionChangedEventArgs e)
        {
            //Show the time deltas...
            var currentTime = DateTime.Now;

            if (_lastChange != default(DateTime))
            {
                TimeDelta.Text = (currentTime - _lastChange).ToString();
            }

            _lastChange = currentTime;

           

        }
    }

}
