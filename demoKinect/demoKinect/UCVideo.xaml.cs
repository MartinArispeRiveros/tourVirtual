using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Windows.Media.Animation;

namespace demoKinect
{
    /// <summary>
    /// Interaction logic for UCVideo.xaml
    /// </summary>
    public partial class UCVideo : UserControl
    {
        UserControl ParentWindow { get; set; }
        public UCVideo()
        {
            InitializeComponent();
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
        }

        /*public void ShowDialogBox(UserControl parentWindow)
        {
            ParentWindow = parentWindow;
            
            Storyboard StatusFader = (Storyboard)Resources["StatusFader"];
            ParentWindow.IsEnabled = false;
            FrameworkElement root = (FrameworkElement)ParentWindow.Content;
            this.Height = root.ActualHeight;
            this.Width = root.ActualWidth;
            //TODO: Determine why there is 1 pixel extra whitespace.
            //Tried playing with Margins and Alignment to no avail.
            popup.Height = root.ActualHeight + 1;
            popup.Width = root.ActualWidth + 1;
            popup.IsOpen = true;
            StatusFader.Begin(popupBackground);
        }

        void StatusFader_Completed(object sender, EventArgs e)
        {
            popup.IsOpen = false;
            ParentWindow.IsEnabled = true;
        }*/

        private void PlayClic(object sender, RoutedEventArgs e)
        {
            VideoControl.Source = new Uri("T:/Archivos Tincho/Music/videos/motivacion/correr.mp4");
            VideoControl.Play();
        }

        private void PauseClic(object sender, RoutedEventArgs e)
        {
            VideoControl.Pause();
        }

        private void popup_Opened(object sender, EventArgs e)
        {

        }

    

       
    }
}
