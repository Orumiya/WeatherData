using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WeatherProject;

namespace WeatherTest
{
    [TestFixture]
    public class WeatherTestClass
    {
        XMLProcessor proc;

        public WeatherTestClass()
        {

        }
        [Test]
        public void WhenGettingWeatherXML_ThenRegionDataAverageIsOk()
        {
            XDocument xdoc = new XDocument(
                new XElement("weatherdata",
                new XElement("datapoint",
                new XElement("date", 111111),
                new XElement("temperature", 10),
                new XElement("location", "Budapest"),
                new XElement("rainfall", 12)),
                new XElement("datapoint",
                new XElement("date", 111111),
                new XElement("temperature", 6),
                new XElement("location", "Budapest"),
                new XElement("rainfall", 6)),
                new XElement("datapoint",
                new XElement("date", 111111),
                new XElement("temperature", 4),
                new XElement("location", "Kalocsa"),
                new XElement("rainfall", 10)),
                new XElement("datapoint",
                new XElement("date", 111111),
                new XElement("temperature", 8),
                new XElement("location", "Kalocsa"),
                new XElement("rainfall", 4))));
            proc = new XMLProcessor(xdoc);

            List<RegionData> regionDataList = proc.GetRegionData();
            RegionData data = regionDataList.Single(e => e.RegionName.Equals("Budapest"));
            Assert.That(data.AvgRainfall, Is.EqualTo(9));
        }

        [Test]
        public void WhenGettingWeatherXML_ThenMinTempIsOk()
        {
            XDocument xdoc = new XDocument(
                new XElement("weatherdata",
                new XElement("datapoint",
                new XElement("date", 111111),
                new XElement("temperature", 10),
                new XElement("location", "Budapest"),
                new XElement("rainfall", 12)),
                new XElement("datapoint",
                new XElement("date", 111111),
                new XElement("temperature", 6),
                new XElement("location", "Budapest"),
                new XElement("rainfall", 6)),
                new XElement("datapoint",
                new XElement("date", 111111),
                new XElement("temperature", 4),
                new XElement("location", "Kalocsa"),
                new XElement("rainfall", 10)),
                new XElement("datapoint",
                new XElement("date", 111111),
                new XElement("temperature", 8),
                new XElement("location", "Kalocsa"),
                new XElement("rainfall", 4))));
            proc = new XMLProcessor(xdoc);

            List<RegionData> regionDataList = proc.GetRegionData();
            RegionData data = regionDataList.Single(e => e.RegionName.Equals("Budapest"));
            Assert.That(data.MinTemperature, Is.EqualTo(6));
        }

        [Test]
        public void WhenGettingWeatherXML_ThenMaxTempIsOk()
        {
            XDocument xdoc = new XDocument(
                new XElement("weatherdata",
                new XElement("datapoint",
                new XElement("date", 111111),
                new XElement("temperature", 10),
                new XElement("location", "Budapest"),
                new XElement("rainfall", 12)),
                new XElement("datapoint",
                new XElement("date", 111111),
                new XElement("temperature", 6),
                new XElement("location", "Budapest"),
                new XElement("rainfall", 6)),
                new XElement("datapoint",
                new XElement("date", 111111),
                new XElement("temperature", 4),
                new XElement("location", "Kalocsa"),
                new XElement("rainfall", 10)),
                new XElement("datapoint",
                new XElement("date", 111111),
                new XElement("temperature", 8),
                new XElement("location", "Kalocsa"),
                new XElement("rainfall", 4))));
            proc = new XMLProcessor(xdoc);

            List<RegionData> regionDataList = proc.GetRegionData();
            RegionData data = regionDataList.Single(e => e.RegionName.Equals("Kalocsa"));
            Assert.That(data.MaxTemperature, Is.EqualTo(8));
        }
    }
}
