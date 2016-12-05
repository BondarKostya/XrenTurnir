using ExcelLibrary;
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //SportListView sportView = new SportListView();
            //SportListView testView = new SportListView();

            //sportView.level.Text = "От 100";
            //sportView.DataContext = Init();

            //testView.level.Text = "До 100";
            //testView.DataContext = Init(false);

            //sportPanel.Children.Add(sportView);
            //sportPanel.Children.Add(testView);                    
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
            //var item = sportManPanel.Children[0];
            //sportManPanel.Children.Remove(item);
            //sportManPanel.Children.Add(item);

            currentListView.DataContext = null;
            currentListView.Update();
        }

        private void LoadClick(object sender, RoutedEventArgs e)
        {
            var data = ExcelLibrary.Engine.GetData("D:\\test.xlsx", "Man");

            manPanel.DataContext = data;

            Load(data, sportManPanel, currentView);
        }

        private void LoadWomanClick(object sender, RoutedEventArgs e)
        {
            var data = ExcelLibrary.Engine.GetData("D:\\test.xlsx", "Woman");

            womanPanel.DataContext = data;

            Load(data, sportWomanPanel, currentWomanView);
        }

        private void LoadData(List<Data> data, StackPanel panel)
        {
            var lowLvl = data.Where(x => x.Weight <= ExcelLibrary.Data.Low).ToList();
            var mediumLvl = data.Where(x => x.Weight > ExcelLibrary.Data.Low && x.Weight <= ExcelLibrary.Data.Medium).ToList();
            var hardLvl = data.Where(x => x.Weight > ExcelLibrary.Data.Medium && x.Weight <= ExcelLibrary.Data.Hard).ToList();
            var tryHardLvl = data.Where(x => x.Weight > ExcelLibrary.Data.Hard && x.Weight < ExcelLibrary.Data.TryHard).ToList();

            panel.Children.Clear();

            SportListView lowView = new SportListView();
            lowView.level.Text = "До 60 кг:";
            lowView.DataContext = lowLvl;

            SportListView mediumView = new SportListView();
            mediumView.level.Text = "До 80 кг:";
            mediumView.DataContext = mediumLvl;

            SportListView hardView = new SportListView();
            hardView.level.Text = "До 100 кг:";
            hardView.DataContext = hardLvl;

            SportListView tryhardView = new SportListView();
            tryhardView.level.Text = "До 150 кг:";
            tryhardView.DataContext = tryHardLvl;

            panel.Children.Add(lowView);
            panel.Children.Add(mediumView);
            panel.Children.Add(hardView);
            panel.Children.Add(tryhardView);
        }

        private void Load(List<Data> data, StackPanel panel, StackPanel currentPanel)
        {
            panel.Children.Clear();

            SportListView view = new SportListView();
            view.level.Text = "Учасники:";
            view.DataContext = data;
            view.OnToQuery += (champion) =>
            {
                CurrentSportListView currentView = currentPanel.Children[0] as CurrentSportListView;
                currentView.level.Text = "Текущий подход:";

                var currentData = currentView.DataContext as List<Data>;

                if (currentData == null)
                    currentData = new List<Data>();

                if (!currentData.Contains(champion))
                    currentData.Add(champion);

                currentView.DataContext = currentData;

                currentView.Update();

                //currentPanel.Children.Add(currentView);
            };

            panel.Children.Add(view);

            //(currentPanel.Children[0] as CurrentSportListView).sportList.ItemsSource = null;
        }

        private void SaveClick(object sender, RoutedEventArgs e)
        {
            var data = manPanel.DataContext as List<ExcelLibrary.Data>;

            data.ToExcel("D:\\test.xlsx", "Man");
        }

        private void SaveWomanClick(object sender, RoutedEventArgs e)
        {
            var data = womanPanel.DataContext as List<ExcelLibrary.Data>;

            data.ToExcel("D:\\test.xlsx", "Woman");
        }

        private void ToLastWoman(object sender, RoutedEventArgs e)
        {
            //var item = sportWomanPanel.Children[0];
            //sportWomanPanel.Children.Remove(item);
            //sportWomanPanel.Children.Add(item);

            currentWomanListView.DataContext = null;
            currentWomanListView.Update();
        }
    }
}
