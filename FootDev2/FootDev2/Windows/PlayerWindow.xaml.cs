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
using static FootDev2.HelperClass.CheckRole;
using FootDev2.CommonPages;

namespace FootDev2.Windows
{
    /// <summary>
    /// Логика взаимодействия для PlayerWindow.xaml
    /// </summary>
    public partial class PlayerWindow : Window
    {
        public PlayerWindow()
        {
            InitializeComponent();
            MainFrame.Content = new PageSquad();
        }



        private void BtnTournaments_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new PageTournament();
        }

        private void BtnInjuries_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new PageInjuries();
        }

        private void BtnSquad_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new PageSquad();
        }

        private void BtnPositions_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new PagePositions();
        }

        private void BtnPredispositions_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new PagePredispositions();
        }

        private void BtnGkCharacteristics_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new PageGK();
        }

        private void BtnDFCharacteristics_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new PageDF();
        }

        private void BtnMFCharacteristics_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new PageMF();
        }

        private void BtnFWCharacteristics_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new PageFW();
        }

        private void BtnTeamTrainings_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new PageTeamTrainings();
        }

        private void BtnIndTrainings_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new PageIndTraining();
        }

        private void BtnExerciseForTest_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new PageExercise();
        }


        private void BtnRespPeople_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new PageRespPers();
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            VarCheckRole = 0;
            MainWindow2 mnwndw = new MainWindow2();
            mnwndw.Show();
            this.Close();
        }
    }
}
