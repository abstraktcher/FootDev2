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

        

        private void BtnPositions_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new Positions();
        }

        private void BtnPredispositions_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new Predispositions();
        }

        private void BtnGkCharacteristics_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new GKCharacteristics();
        }

        private void BtnDFCharacteristics_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new DFCharacteristics();
        }

        private void BtnMFCharacteristics_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new MFCharacteristics();
        }

        private void BtnFWCharacteristics_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new FWCharacteristics();
        }

        private void BtnTeamTrainings_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new TeamTrainings();
        }

        private void BtnIndTrainings_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new IndividualTrainings();
        }

        private void BtnExerciseForTest_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new ExcForTest();
        }
    }
}
