using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Kinect;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        KinectSensor sensor;
        public Form1()
        {
            InitializeComponent();
        }

        private void sensor_SkeletonFrameReady(object sender, SkeletonFrameReadyEventArgs e)
        {
            Skeleton[] skeletons = new Skeleton[0];

            using (SkeletonFrame skeletonFrame = e.OpenSkeletonFrame())
            {
                if (skeletonFrame != null)
                {
                    skeletons = new Skeleton[skeletonFrame.SkeletonArrayLength];
                    skeletonFrame.CopySkeletonDataTo(skeletons);
                }
            }

            if (skeletons.Length != 0)
            {
                foreach (Skeleton skel in skeletons)
                {

                    if (skel.TrackingState == SkeletonTrackingState.Tracked)
                    {
                        Joint joint0 = skel.Joints[JointType.Head];
                        var a = sensor.CoordinateMapper.MapSkeletonPointToDepthPoint(joint0.Position, DepthImageFormat.Resolution640x480Fps30);
                        label1.Text = Convert.ToString(a.X + ":" + a.Y);
                    }
                    else if (skel.TrackingState == SkeletonTrackingState.PositionOnly)
                    {
                        
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sensor = KinectSensor.KinectSensors.Where(item => item.Status == KinectStatus.Connected).FirstOrDefault();
            if (!sensor.SkeletonStream.IsEnabled)
            {
                sensor.SkeletonStream.Enable();
                sensor.SkeletonFrameReady += sensor_SkeletonFrameReady;
            }
            try
            {
                sensor.Start();
            }
            catch
            {
                sensor = null;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
