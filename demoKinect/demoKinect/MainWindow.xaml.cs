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
using Microsoft.Kinect;
using Microsoft.Kinect.Toolkit;
using Microsoft.Kinect.Toolkit.Controls;
using Microsoft.Kinect.Toolkit.Interaction;

namespace demoKinect
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private KinectSensorChooser sensorChooser;
        public MainWindow()
        {
            InitializeComponent();
            Loaded += OnLoaded;
       
            // Bind the sensor chooser's current sensor to the KinectRegion
            var regionSensorBinding = new Binding("Kinect") { Source = this.sensorChooser };
            BindingOperations.SetBinding(this.kinectRegion, KinectRegion.KinectSensorProperty, regionSensorBinding);

            // Clear out placeholder content
            //this.wrapPanel.Children.Clear();
        }
        private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            this.sensorChooser = new KinectSensorChooser();
            this.sensorChooser.KinectChanged += SensorChooserOnKinectChanged;
            this.sensorChooserUi.KinectSensorChooser = this.sensorChooser;
            this.sensorChooser.Start();
        }
        
        private void SensorChooserOnKinectChanged(object sender, KinectChangedEventArgs args)
        {
            //MessageBox.Show(args.NewSensor == null ? "No Kinect" : args.NewSensor.Status.ToString());
            bool error = false;
            if (args.OldSensor != null)
            {
                try
                { 
                    args.OldSensor.DepthStream.Range = DepthRange.Default;
                    args.OldSensor.SkeletonStream.EnableTrackingInNearRange = false;
                    args.OldSensor.DepthStream.Disable();
                    args.OldSensor.SkeletonStream.Disable();
                }
                catch(InvalidOperationException)
                {
                    error = true;
                }
            }
            if(args.NewSensor != null)
            {
                try
                {
                    args.NewSensor.DepthStream.Enable(DepthImageFormat.Resolution640x480Fps30);
                    args.NewSensor.SkeletonStream.Enable();
                    try 
                    {
                        args.NewSensor.DepthStream.Range = DepthRange.Near;
                        args.NewSensor.SkeletonStream.EnableTrackingInNearRange = true;
                        args.NewSensor.SkeletonStream.TrackingMode = SkeletonTrackingMode.Seated;
                    }
                    catch(InvalidOperationException)
                    {
                        args.NewSensor.DepthStream.Range = DepthRange.Default;
                        args.NewSensor.SkeletonStream.EnableTrackingInNearRange = false;
                    }
                }
                catch(InvalidOperationException)
                {
                    error = true;
                }
            }
            if (!error)
                kinectRegion.KinectSensor = args.NewSensor; 
        }
       
        public enum KinectStatus
        {
            Undefined,
            Disconnected,
            Connected,
            Initializing,
            Error,
            NotPowered,
            NotReady,
            DeviceNotGenuine,
            DeviceNotSupported,
            InsufficientBandwidth,
        }
        
        private void KinectTileButtonClick(object sender, RoutedEventArgs e)
        {
            
        }
        private void WindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.sensorChooser.Stop();
        }

        private void KinectTileButton_Click(object sender, RoutedEventArgs e)
        {
            
            var button = (KinectTileButton)e.OriginalSource;
            var video = new UCVideo();
            this.kinectRegionGrid.Children.Add(video);
            
            e.Handled = true;
        }

        

        private void KinectTileButton_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("esto lleva a una foto");
        }
    }
}
