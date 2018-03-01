using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace GoogleHashCode2018
{
    public class Algorithm
    {
        public Car[] PickUpRide(List<Ride> rideList, Settings settings)
        {
            Car[] cars = new Car[settings.CarCount];            

            for (int i = 0; i < cars.Length; i++)
            {
                cars[i] = new Car(i + 1)
                {
                    rides = new List<Ride>()
                };
                for (int k = 0; k < 100; k++)
                {
                   var orderedRideList = rideList.OrderByDescending(x => {

                       var nearStep = CalculateNearStep(x, cars[i]);
                       return nearStep == 0 ? int.MaxValue : (x.distance / nearStep);
                       }).ToList();
                    if (orderedRideList.Count() < 1) break;
                    var ourRide = orderedRideList.First();
                    if (cars[i].currentStep <= settings.StepCount)
                    {
                       
                        cars[i].rides.Add(ourRide);
                        cars[i].currentPositioin = ourRide.FinishPoint;
                        cars[i].currentStep += ourRide.distance + CalculateNearStep(ourRide, cars[i]);
                        rideList.Remove(ourRide);
                    }
                    else break;
                }
            }
            return cars;
        }

        public void CreateFile(Car[] cars)
        {
            var path = "resultE.txt";
            
                var content = cars.Select(car => $"{car.ToString()}");
            File.WriteAllLines(path, content);             
            
        }

        public int CalculateNearStep(Ride ride, Car car)
        {
            return Math.Max(ride.DistanceToRide(car), ride.EarlierTime - car.currentStep);
        }

    }
}
