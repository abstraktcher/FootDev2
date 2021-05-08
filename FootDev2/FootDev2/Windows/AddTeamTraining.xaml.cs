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
using static FootDev2.AppData.AppDataClass;
using FootDev2.AppData;
using FootDev2.Windows;
using static FootDev2.HelperClass.CheckRole;

namespace FootDev2.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddTeamTraining.xaml
    /// </summary>
    public partial class AddTeamTraining : Window
    {
        public AddTeamTraining()
        {
            InitializeComponent();
            CmbTeam.ItemsSource = context.Club.ToList();
            CmbTeam.DisplayMemberPath = "ClubName";
            CmbTeam.SelectedIndex = 0;

            CmbTraining.ItemsSource = context.Training.ToList();
            CmbTraining.DisplayMemberPath = "TrainingName";
            CmbTraining.SelectedIndex = 0;
        }

        public AddTeamTraining(ViewTeamTrainings teamTrain)
        {
            InitializeComponent();
            CmbTeam.ItemsSource = context.Club.ToList();
            CmbTeam.DisplayMemberPath = "ClubName";
            CmbTeam.SelectedIndex = 0;

            CmbTraining.ItemsSource = context.Training.ToList();
            CmbTraining.DisplayMemberPath = "TrainingName";
            CmbTraining.SelectedIndex = 0;

            CmbTeam.SelectedIndex = teamTrain.IdTeam - 1;
            CmbTraining.SelectedIndex = teamTrain.IdTraining - 1;
            DPDate.SelectedDate = teamTrain.Date;
        }


        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BtnConfirm_Click(object sender, RoutedEventArgs e)
        {
            try
            {

            if(CmbTraining.SelectedIndex != 0 || CmbTeam.SelectedIndex != 0 || DPDate.SelectedDate != null)
            {
                if(VarIdTraining == 0)
                {
                    TrainToTeam addtrain = new TrainToTeam();
                    addtrain.IdTeam = CmbTeam.SelectedIndex + 1;
                    addtrain.Date = (DateTime)DPDate.SelectedDate;
                    addtrain.IdTraining = CmbTraining.SelectedIndex + 1;

                    context.TrainToTeam.Add(addtrain);
                    context.SaveChanges();
                    MessageBox.Show("Training was successfully added", "Success", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                    Close();
                }
                else
                {
                    var editTrain = context.TrainToTeam.Where(i => i.IdTTT == VarIdTraining).FirstOrDefault();

                    editTrain.IdTeam = CmbTeam.SelectedIndex + 1;
                    editTrain.IdTraining = CmbTraining.SelectedIndex + 1;
                    editTrain.Date = (DateTime)DPDate.SelectedDate;

                    context.SaveChanges();
                    VarIdTraining = 0;
                    MessageBox.Show("Training was successfully changed", "Success", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                    Close();
                }
            }
            else
            {
                MessageBox.Show("Fields cannot be empty", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            }
            catch
            {
                MessageBox.Show("Try later!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
