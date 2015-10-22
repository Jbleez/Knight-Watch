using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace KnightWatch.Services
{
    class Navigation
    {
        private static Frame frame
        {
            get
            {

                Frame rootFrame = Window.Current.Content as Frame;

                // Do not repeat app initialization when the Window already has content,
                // just ensure that the window is active
                if (rootFrame == null)
                {
                    // Create a Frame to act as the navigation context and navigate to the first page
                    rootFrame = new Frame();

                    // Place the frame in the current Window
                    Window.Current.Content = rootFrame;
                }
                return rootFrame;
            }
        }


        public static void GoBack()
        {

            if ((Window.Current.Content as Frame).CanGoBack)
                (Window.Current.Content as Frame).GoBack();
            else
                GotoMainPage();
        }

        public static bool GotoMainPage()
        {

            return (Window.Current.Content as Frame).Navigate(typeof(MainPage));
        }

        public static bool GotoPM()
        {
            return (Window.Current.Content as Frame).Navigate(typeof(Views.PowerView));
        }
        public static bool GotoNM()
        {
            return (Window.Current.Content as Frame).Navigate(typeof(Views.NetworkM));
        }
        public static bool GotoVE()
        {
            return (Window.Current.Content as Frame).Navigate(typeof(Views.VirtualE));
        }
        public static bool GotoBS()
        {
            return (Window.Current.Content as Frame).Navigate(typeof(Views.BackupsView));
        }
        public static bool GotoHelpDesk()
        {
            return (Window.Current.Content as Frame).Navigate(typeof(Views.HelpDesk));
        }
        public static bool GotoAB()
        {
            return (Window.Current.Content as Frame).Navigate(typeof(Views.AdminView));
        }

    }
    }
