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
using System.Windows.Shapes;

namespace SeinSport
{
    /// <summary>
    /// Логика взаимодействия для ParticipantDetail.xaml
    /// </summary>
    public partial class ParticipantDetail : Window
    {
        public ParticipantDetail()
        {
            InitializeComponent();
            initDetailFormWithModel();
        }

        public void initDetailFormWithModel()
        {
            fioTB.Text = "Бондар К.Б";
            clubTB.Text = "Бондар К.Б";
            trenerTB.Text = "Бондар К.Б";

            bornTB.Text = "Бондар К.Б";
            weightTB.Text = "Бондар К.Б";
            categoryTB.Text = "Бондар К.Б";

            exers1_1.Text = "Бондар К.Б";
            exers1_2.Text = "Бондар К.Б";
            exers1_3.Text = "Бондар К.Б";

            exers2_1.Text = "Бондар К.Б";
            exers2_2.Text = "Бондар К.Б";
            exers2_3.Text = "Бондар К.Б";

            exers3_1.Text = "Бондар К.Б";
            exers3_2.Text = "Бондар К.Б";
            exers3_3.Text = "Бондар К.Б";

        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            //TODO: back action
            this.Close();
        }

        private void timerSwitcher_Click(object sender, RoutedEventArgs e)
        {
            //TODO: timer switch click
        }
    }
}
