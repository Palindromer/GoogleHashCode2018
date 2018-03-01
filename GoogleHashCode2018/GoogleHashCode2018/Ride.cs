using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace GoogleHashCode2018
{
    public class Ride
    {
        public int Id=0;
        public Point StartPoint;
        public Point FinishPoint;
        public int EarlierTime;
        public int LatestTime;

        public Ride(int id,int startX, int startY, int finishX, int finishY, int eatlierTime, int latestTime)
        {
            Id=id;
            StartPoint.X = startX;
            StartPoint.Y = startY;
            FinishPoint.X = finishX;
            FinishPoint.Y = finishY;
            EarlierTime = eatlierTime;
            LatestTime = latestTime-distance;
        }

        public int distance
        {
            get
            {
                return  Math.Abs(StartPoint.X - FinishPoint.X)  + Math.Abs(StartPoint.Y - FinishPoint.Y);
            }
        }

        public int commonTime
        {
            get
            {
                return LatestTime - EarlierTime;
            }
        }

        public int DistanceToRide(Car car)
        {
            return Math.Abs(StartPoint.X - car.currentPositioin.X) + Math.Abs(StartPoint.Y - car.currentPositioin.Y);
        }
    }
}
