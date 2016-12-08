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

namespace SeinSportTable
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

        public Sport.SportServiceClient client;
                
        public void Update()
        {
            sportList.Items.Refresh();
        }
    }
}
