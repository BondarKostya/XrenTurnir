using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
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
using WcfLiblary;

namespace SeinSportTable
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        ServiceHost host;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (host == null)
            {
                host = new ServiceHost(typeof(SportService), new Uri(string.Format("http://{0}:8098/Sport", ipBox.Text)));
                host.AddServiceEndpoint(typeof(ISportService), new WSHttpBinding(), string.Format("http://{0}:8098/Sport", ipBox.Text));
                
            }

            host.Open();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SportService.OnNewQuery += SportService_OnNewQuery;
        }

        private void SportService_OnNewQuery(List<Data> obj)
        {
            List<ExcelLibrary.Data> data = new List<ExcelLibrary.Data>(obj.Count);
            foreach (var value in obj)
                data.Add(new ExcelLibrary.Data(value));

            currentListView.DataContext = data;
            currentListView.Update();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            if (host != null)
                host.Close();
        }
    }
}
