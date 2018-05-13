using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WeatherProject
{
    public class XMLProcessor
    {
        List<RegionData> regionDataList;
        XDocument xdoc;
        public XMLProcessor(XDocument xdoc)
        {
            this.xdoc = xdoc;
            this.regionDataList = new List<RegionData>();
        }

        public List<RegionData> GetRegionData()
        {
            var q = xdoc.Element("weatherdata").Elements("datapoint").GroupBy(e => e.Element("location").Value);
            IEnumerable<RegionData> d = xdoc.Element("weatherdata").Elements("datapoint").GroupBy(e => e.Element("location").Value)
                .Select(x => new RegionData
                {
                    RegionName = x.Key,
                    AvgRainfall = x.Elements("rainfall").Average(f => double.Parse(f.Value)),
                    MinTemperature = x.Elements("temperature").Min(f => double.Parse(f.Value)),
                    MaxTemperature = x.Elements("temperature").Max(f => double.Parse(f.Value))
                 
                });

            regionDataList = d.ToList();
            return regionDataList;
        }
    }
}
