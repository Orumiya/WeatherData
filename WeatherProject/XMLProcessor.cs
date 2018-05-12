using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WeatherProject
{
    class XMLProcessor
    {
        XDocument xdoc;
        public XMLProcessor(XDocument xdoc)
        {
            this.xdoc = xdoc;
        }

        public List<RegionData> GetRegionData()
        {
            List<RegionData> regionDataList = new List<RegionData>();
            var q = xdoc.Element("weatherdata").Elements("datapoint").GroupBy(e => e.Element("location").Value);
            IEnumerable<RegionData> d = xdoc.Element("weatherdata").Elements("datapoint").GroupBy(e => e.Element("location").Value)
                .Select(x => new RegionData
                {
                    RegionName = x.Key,
                    //AvgRainfall = x.Select(e => e.Elements("rainfall").Average(f => double.Parse(f.Value)))
                });


            //List<Datapoint> datapointList = new List<Datapoint>();
            //var q = xdoc.Element("weatherdata").Elements("datapoint").GroupBy(e => e.Element("location").Value);
            //IEnumerable<Datapoint> d = xdoc.Element("weatherdata").Elements("datapoint").GroupBy(e => e.Element("location").Value)
            //    .Select(x => new Datapoint
            //    {
            //        RegionName = x.Key,
            //        AvgRainfall = x.Select(e => e.Elements("rainfall").Average(f => double.Parse(f.Value)))
            //    });


            foreach (var item in d)
            {
                Console.WriteLine(item.RegionName);
            }

            var avgRain = q.Select(e => e.Elements("rainfall").Average(f => double.Parse(f.Value)));

            var minTemp = q.Select(e => e.Elements("temperature").Min(f => double.Parse(f.Value)));
            var maxTemp = q.Select(e => e.Elements("temperature").Max(f => double.Parse(f.Value)));
            

            foreach (var item in d)
            {
               
               
                );
                Console.WriteLine(regionDataList.Last().RegionName + " : " + regionDataList.Last().AvgRainfall);
            }
            
            return regionDataList;
        }
    }
}
