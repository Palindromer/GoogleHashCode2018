using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace GoogleHashCode2018
{
    public class Car
    {
        public int Id;
        public List<Ride> rides;
        public Point currentPositioin; 
        public int currentStep;

        public Car(int id)
        {
            Id = id;
        }

        public override string ToString()
        {
            var result = rides.Count() + " "+ string.Join(" ", rides.Select(r => r.Id.ToString()));
            return result;
        }
    }
}
