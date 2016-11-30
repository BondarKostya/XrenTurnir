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
            mainGrid.NumberOfRows = 5;
            mainGrid.setSectionMargin(new Thickness(15, 10, 15, 30));

            mainGrid.setupRow(0, 10);
            mainGrid.setupRow(1, 5);
            mainGrid.setupRow(2, 2);

        }


        public List<Object> requestDataForTab(int tab) 
        {
            return null;
        }
    }
}
