using FootDev2.Pages;
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

namespace FootDev2.Windows
{
    /// <summary>
    /// Логика взаимодействия для ManagerWindow.xaml
    /// </summary>
    public partial class ManagerWindow : Window
    {
        public ManagerWindow()
        {
            InitializeComponent();
            MainFrame.Content = new Squad();
        }

        

        private void BtnTournaments_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new Tournaments();
        }

        private void BtnInjuries_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new Injuries();
        }

        private void BtnSquad_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new Squad();
        }

        private void BtnTraits_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new Traits();
        }
    }
}
