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
        System.Windows.Threading.DispatcherTimer timer;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            timer = new System.Windows.Threading.DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;

            SportService.OnNewChampion += SportService_OnNewChampion;
            SportService.OnStartTimer += SportService_OnStartTimer;
            SportService.OnStopTimer += SportService_OnStopTimer;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            int time = int.Parse(timerBlock.Text);

            if (time == 0)
            {
                timerBlock.Text = "Время вышло";
                secondBlock.Text = "";
                timer.Stop();
                return;
            }

            time--;
            timerBlock.Text = time.ToString();
        }

        private void SportService_OnStopTimer()
        {
            timer.Stop();
        }

        private void SportService_OnStartTimer()
        {
            timer.Start();
        }

        private void SportService_OnNewChampion(Data obj)
        {
            this.DataContext = obj;
            timerBlock.Text = "60";
            secondBlock.Text = "c";
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            host?.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(host== null)
            {
                host = new ServiceHost(typeof(SportService), new Uri(string.Format("http://{0}:8097/Sport", ipBox.Text)));
                var binding = new WSHttpBinding();
                binding.ReceiveTimeout = TimeSpan.FromHours(5);
                binding.SendTimeout = TimeSpan.FromHours(5);
                host.AddServiceEndpoint(typeof(ISportService), binding, string.Format("http://{0}:8097/Sport", ipBox.Text));                
            }

            host.Open();

            (sender as Button).IsEnabled = false;
        }
    }
}
