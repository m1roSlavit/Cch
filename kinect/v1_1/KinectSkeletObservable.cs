using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Microsoft.Kinect;

namespace v1_1
{
    class KinectSkeletObservable
    {
        private List<IObserver> observers = new List<IObserver>();
        KinectSensor sensor;
        public KinectSkeletObservable()
        {
            sensor = KinectSensor.KinectSensors.Where(item => item.Status == KinectStatus.Connected).FirstOrDefault();
            if (!sensor.SkeletonStream.IsEnabled)
            {
                sensor.SkeletonStream.Enable();
                sensor.SkeletonFrameReady += Notify;
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

        public void Subscribe(IObserver observer)
        {
            observers.Add(observer);
        }

        public void Unsubscribe(IObserver observer)
        {
            observers.Remove(observer);
        }

        private void Notify(object sender, SkeletonFrameReadyEventArgs e)
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
                        Joint[] arr = {
                            skel.Joints[JointType.Head],
                            skel.Joints[JointType.ShoulderCenter],
                            skel.Joints[JointType.ShoulderRight],
                            skel.Joints[JointType.ShoulderLeft],
                            skel.Joints[JointType.ElbowRight],
                            skel.Joints[JointType.ElbowLeft],
                            skel.Joints[JointType.WristRight],
                            skel.Joints[JointType.WristLeft],
                            skel.Joints[JointType.HandRight],
                            skel.Joints[JointType.HandLeft],
                            skel.Joints[JointType.Spine],
                            skel.Joints[JointType.HipCenter],
                            skel.Joints[JointType.HipRight],
                            skel.Joints[JointType.HipLeft],
                            skel.Joints[JointType.KneeRight],
                            skel.Joints[JointType.KneeLeft],
                            skel.Joints[JointType.AnkleRight],
                            skel.Joints[JointType.AnkleLeft],
                            skel.Joints[JointType.FootRight],
                            skel.Joints[JointType.FootLeft],
                        };

                        Point[] pointsArr = new Point[20];
                        for (int i = 0; i < arr.Length; i++)
                        {
                            DepthImagePoint SkelPart = sensor.CoordinateMapper.MapSkeletonPointToDepthPoint(arr[i].Position, DepthImageFormat.Resolution640x480Fps30);
                            pointsArr[i] = new Point(SkelPart.X, SkelPart.Y);
                        }
                        for (int i = 0; i < observers.Count; i++)
                        {
                            observers[i].Update(pointsArr);
                        }
                    }
                    else if (skel.TrackingState == SkeletonTrackingState.PositionOnly)
                    {

                    }
                }
            }
        }
    }
}
