using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace WeatherProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        XMLProcessor proc;
        List<RegionData> regionDataList;
        XDocument xdoc;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            XDocument xdoc = XDocument.Load("weatherdata.xml");
            proc = new XMLProcessor(xdoc);
            Task.Run(() => CheckXMLForUpdate());

        }

        private void CheckXMLForUpdate()
        {
            while (true)
            {
                xdoc = XDocument.Load("weatherdata.xml");
                proc = new XMLProcessor(xdoc);
                regionDataList = proc.GetRegionData();
                Dispatcher.Invoke(() => listbox.ItemsSource = regionDataList);
                Thread.Sleep(1000);
            }
            
        }
    }
}
