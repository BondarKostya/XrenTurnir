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
    /// Логика взаимодействия для SportListView.xaml
    /// </summary>
    public partial class SportListView : UserControl
    {
        public SportListView()
        {
            InitializeComponent();
        }

        public Sport.SportServiceClient client;

        public event Action<ExcelLibrary.Data> OnToQuery;

        private void sportList_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ParticipantDetail detail = new ParticipantDetail();
            var data = (sender as ListView).SelectedItem as ExcelLibrary.Data;
            detail.client = client;
            detail.DataContext = data;

            detail.ShowDialog();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            e.Handled = true;

            var data = (sender as Button).DataContext as ExcelLibrary.Data;

            OnToQuery?.Invoke(data);
        }
    }
}
