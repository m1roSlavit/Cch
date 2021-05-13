using System;
using Microsoft.Kinect;
using System.Linq;
using Microsoft.Kinect.Toolkit.Controls;
using Microsoft.Kinect.Toolkit;
using Microsoft.Kinect.Toolkit.Fusion;
using Microsoft.Kinect.Toolkit.Interaction;
using Microsoft.Kinect.Toolkit.BackgroundRemoval;


namespace test1
{
    class Program
    {
        static void SkeletonsReady(object sender, SkeletonFrameReadyEventArgs e)
        {
            Console.WriteLine("sensor_SkeletonFrameReady");
        }
        static void Main(string[] args)
        {
            KinectSensor kinect = KinectSensor.KinectSensors.Where(s => s.Status == KinectStatus.Connected).FirstOrDefault();
            kinect.Start();
        }
    }
}
