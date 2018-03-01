using System;
using System.Linq;

namespace GoogleHashCode2018
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine("))");
            FileParser parser = new FileParser();
            CityData cityData = parser.ParseFile("e_high_bonus.in");
            Algorithm alg = new Algorithm();
            Car[] carsss = alg.PickUpRide(cityData.rides.ToList(), cityData.settings);
            alg.CreateFile(carsss);
            Console.WriteLine("end");
        }
    }
}
