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
    /// Логика взаимодействия для CurrentSportListView.xaml
    /// </summary>
    public partial class CurrentSportListView : UserControl
    {
        public CurrentSportListView()
        {
            InitializeComponent();
        }

        private void sportList_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ParticipantDetail detail = new ParticipantDetail();
            var data = (sender as ListView).SelectedItem as ExcelLibrary.Data;
            detail.DataContext = data;

            detail.ShowDialog();
        }

        public void Update()
        {
            sportList.Items.Refresh();
        }
    }
}
