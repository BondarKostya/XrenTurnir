using System;
using System.Collections.Generic;
using System.Linq;
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
using System.ServiceModel;
using WcfLiblary;

namespace SeinSportView
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SportService.OnNewChampion += SportService_OnNewChampion;
        }

        private void SportService_OnNewChampion(Data obj)
        {
            this.DataContext = obj;            
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            host.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(host== null)
            {
                host = new ServiceHost(typeof(SportService), new Uri(string.Format("http://{0}:8098/Sport", ipBox.Text)));
                host.AddServiceEndpoint(typeof(ISportService), new WSHttpBinding(), string.Format("http://{0}:8098/Sport", ipBox.Text));                
            }

            host.Open();
        }
    }
}
