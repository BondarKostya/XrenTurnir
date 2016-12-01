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

namespace SeinSport
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


        public List<Object> requestDataForTab(int tab) 
        {
            return null;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SportListView sportView = new SportListView();
            SportListView testView = new SportListView();

            sportView.level.Text = "От 100";
            sportView.DataContext = Init();

            testView.level.Text = "До 100";
            testView.DataContext = Init(false);

            sportPanel.Children.Add(sportView);
            sportPanel.Children.Add(testView);                    
        }

        private List<ExcelLibrary.Data> Init(bool first = true)
        {
            List<ExcelLibrary.Data> result = new List<ExcelLibrary.Data>();

            if (first)
            {
                ExcelLibrary.Data data = new ExcelLibrary.Data();
                data.Name = "Test Morjoviy";
                data.Level = "Medium";
                data.Place = 1;
                data.Club = "NaVi";
                data.Assotiation = "LoL";
                data.Number = 51;
                data.Weight = 73.6;
                result.Add(data);

                ExcelLibrary.Data user = new ExcelLibrary.Data();
                user.Name = "User Morj";
                user.Level = "Hard";
                user.Place = 2;
                user.Club = "SKT T1";
                user.Assotiation = "LoL";
                user.Number = 38;
                user.Weight = 93.6;
                result.Add(user);

                ExcelLibrary.Data heavy = new ExcelLibrary.Data();
                heavy.Name = "Heavy";
                heavy.Level = "TryHard";
                heavy.Place = 0;
                heavy.Club = "Cloud9";
                heavy.Assotiation = "LoL";
                heavy.Number = 7;
                heavy.Weight = 103.6;
                result.Add(heavy);
            }
            else
            {
                ExcelLibrary.Data data = new ExcelLibrary.Data();
                data.Name = "Last Morjoviy";
                data.Level = "Low";
                data.Place = 1;
                data.Club = "NaVi";
                data.Assotiation = "LoL";
                data.Number = 51;
                data.Weight = 73.6;
                result.Add(data);

                ExcelLibrary.Data user = new ExcelLibrary.Data();
                user.Name = "User Second";
                user.Level = "Try";
                user.Place = 2;
                user.Club = "SKT T1";
                user.Assotiation = "LoL";
                user.Number = 38;
                user.Weight = 93.6;
                result.Add(user);
            }

            return result;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var item = sportPanel.Children[0];
            sportPanel.Children.Remove(item);
            sportPanel.Children.Add(item);
        }
    }
}
