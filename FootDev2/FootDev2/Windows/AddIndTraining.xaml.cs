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
    /// Логика взаимодействия для AddIndTraining.xaml
    /// </summary>
    public partial class AddIndTraining : Window
    {
        public AddIndTraining()
        {
            InitializeComponent(); 
            CmbPlayer.ItemsSource = context.ViewAllInfo.ToList();
            CmbPlayer.DisplayMemberPath = "FullName";
            CmbPlayer.SelectedIndex = 0;

            CmbTraining.ItemsSource = context.Training.ToList();
            CmbTraining.DisplayMemberPath = "TrainingName";
            CmbTraining.SelectedIndex = 0;
        }

        public AddIndTraining(ViewIndTrainings indTrain)
        {
            InitializeComponent();
            CmbPlayer.ItemsSource = context.ViewAllInfo.ToList();
            CmbPlayer.DisplayMemberPath = "FullName";
            CmbPlayer.SelectedIndex = 0;

            CmbTraining.ItemsSource = context.Training.ToList();
            CmbTraining.DisplayMemberPath = "TrainingName";
            CmbTraining.SelectedIndex = 0;

            CmbPlayer.SelectedIndex = indTrain.IdPlayer - 1;
            CmbTraining.SelectedIndex = indTrain.Idtraining - 1;
            DPDate.SelectedDate = indTrain.DateStart;
        }


        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BtnConfirm_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (CmbTraining.SelectedIndex != 0 || CmbPlayer.SelectedIndex != 0 || DPDate.SelectedDate != null)
                {
                    if (VarIdTraining == 0)
                    {
                        IndividualTraining addtrain = new IndividualTraining();
                        addtrain.IdPlayer = CmbPlayer.SelectedIndex + 1;
                        addtrain.DateStart = (DateTime)DPDate.SelectedDate;
                        addtrain.Idtraining = CmbTraining.SelectedIndex + 1;

                        context.IndividualTraining.Add(addtrain);
                        context.SaveChanges();
                        MessageBox.Show("Training was successfully added", "Success", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                        Close();
                    }
                    else
                    {
                        var editTrain = context.IndividualTraining.Where(i => i.IdIndTra == VarIdTraining).FirstOrDefault();

                        editTrain.IdPlayer = CmbPlayer.SelectedIndex + 1;
                        editTrain.Idtraining = CmbTraining.SelectedIndex + 1;
                        editTrain.DateStart = (DateTime)DPDate.SelectedDate;

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
