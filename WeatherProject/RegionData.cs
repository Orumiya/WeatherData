using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherProject
{
    class RegionData
    {
        private string regionName;

        public string RegionName
        {
            get { return regionName; }
            set { regionName = value; }
        }

        private double avgRainfall;

        public double AvgRainfall
        {
            get { return avgRainfall; }
            set { avgRainfall = value; }
        }

        public double MinTemperature { get; set; }

        public double MaxTemperature { get; set; }

    }
}
