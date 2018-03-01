using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


namespace GoogleHashCode2018
{
    public class FileParser
    {
        public CityData ParseFile(string path)
        {
            string[] stringArray = new string[6];
            stringArray = File.ReadAllLines(path);
            CityData cityData = new CityData();
            cityData.rides = new Ride[stringArray.Length - 1];

            cityData.settings = getSetting(stringArray[0]);
            
            for(int i=1; i<stringArray.Length;i++)
            {
                cityData.rides[i - 1] = ParseFirstLive(stringArray[i],i-1);
            }
            Console.WriteLine("Finish parae");
            double average = cityData.rides.Average(x => x.distance); 
            return cityData;
        }
    
        public Settings getSetting(string line)
        {
            string[] stringArray = (line.Split(' '));
            Settings setting = new Settings();
            setting.Size.X = Int32.Parse(stringArray[0]);
            setting.Size.Y = Int32.Parse(stringArray[1]); 
            setting.CarCount = Int32.Parse(stringArray[2]);
            setting.RideCount = Int32.Parse(stringArray[3]);
            setting.Bonus = Int32.Parse(stringArray[4]);
            setting.StepCount = Int32.Parse(stringArray[5]);
            return setting;
        }

        public Ride ParseFirstLive(string line,int id)
        {
            string[] stringArray = (line.Split(' '));
            Ride ride = new Ride(id,
                Int32.Parse(stringArray[0]),
                Int32.Parse(stringArray[1]),
                Int32.Parse(stringArray[2]),
                Int32.Parse(stringArray[3]),
                Int32.Parse(stringArray[4]),
                Int32.Parse(stringArray[5]));            
            return ride;
        }

    }
}
