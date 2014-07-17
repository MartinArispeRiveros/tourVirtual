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
using System.Windows.Shapes;
using Microsoft.Kinect;
using Microsoft.Kinect.Toolkit;
using Microsoft.Kinect.Toolkit.Controls;
using System.IO;
using System.Windows.Media.Animation;

namespace demoKinect
{
    /// <summary>
    /// Interaction logic for video.xaml
    /// </summary>
    public partial class video : Window
    {
        
        public video()
        {
            InitializeComponent();
            VideoControl.Width = 440;
            VideoControl.Height = 280;
        }
        /*
        void PlayClick(object sender, EventArgs e)
        {
            
            VideoControl.Source = new Uri("T:/Archivos Tincho/Music/videos/motivacion/correr.mp4");
            VideoControl.Play();
        }
        void PauseClick(object sender, EventArgs e)
        {
            VideoControl.Pause();
        }
        void StopClick(object sender, EventArgs e)
        {
            VideoControl.Stop();
        }
        */
        private void PlayClic(object sender, RoutedEventArgs e)
        {
            VideoControl.Source = new Uri("T:/Archivos Tincho/Music/videos/motivacion/correr.mp4");
            VideoControl.Play();
        }

        private void PauseClic(object sender, RoutedEventArgs e)
        {
            VideoControl.Pause();
        }

        private void StopClic(object sender, RoutedEventArgs e)
        {
            VideoControl.Stop();
        }
    }
}
