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
using static FootDev2.AppData.AppDataClass;
using FootDev2.AppData;
using FootDev2.Windows;
using static FootDev2.HelperClass.CheckRole;

namespace FootDev2.Pages
{
    /// <summary>
    /// Логика взаимодействия для IndividualTrainings.xaml
    /// </summary>
    public partial class IndividualTrainings : Page
    {
        public IndividualTrainings()
        {
            InitializeComponent();
            ListViewIndTrainings.ItemsSource = context.ViewIndTrainings.ToList();

            List<Training> trainings = context.Training.ToList();
            trainings.Insert(0, new Training() { TrainingName = "All" });
            CmbTraining.ItemsSource = trainings;
            CmbTraining.DisplayMemberPath = "TrainingName";
            CmbTraining.SelectedIndex = 0;
            CmbSort.SelectedIndex = 0;



            CmbSort.ItemsSource = new List<string>()
            {
                "By default", "By  Date", "By Training"
            };
        }



        //    
        //   

        //    if (CheckThisMonth.IsChecked == true)
        //    {
        //        list = list.Where(i => i.Birthday.HasValue && i.Birthday.Value.Month == DateTime.Now.Month).ToList();
        //    }
        //    listViewClients.ItemsSource = list;

        //    
        //}

        public void Filter()
        {
            var list = context.ViewIndTrainings.Where(i => i.FullName.Contains(TxtSearch.Text)).ToList();

            var selectFilter = CmbTraining.SelectedIndex;

            if (selectFilter != 0)
            {
                ListViewIndTrainings.ItemsSource = list.Where(i => i.Idtraining == selectFilter).ToList();
            }


            switch (CmbSort.SelectedIndex)
            {

                case 1:
                    list = list.OrderByDescending(i => i.DateStart).ToList();
                    break;
                case 2:
                    list = list.OrderByDescending(i => i.TrainingName).ToList();
                    break;
            }
            ListViewIndTrainings.ItemsSource = list;

        }

        private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }


        private void CmbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }

        private void BtnResetFilters_Click(object sender, RoutedEventArgs e)
        {
            CmbTraining.SelectedIndex = 0;
            CmbSort.SelectedIndex = 0;
            TxtSearch.Text = "";
        }


        private void BtnAddTraining_Click(object sender, RoutedEventArgs e)
        {
            AddIndTraining addIndTraining = new AddIndTraining();
            this.Opacity = 0.3;
            Filter();
            addIndTraining.ShowDialog();
            Filter();
            this.Opacity = 1;
        }

        private void BtnEditTraining_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (ListViewIndTrainings.SelectedItem is ViewIndTrainings indTraining)
                {
                    VarIdTraining = indTraining.Idtraining;
                    AddIndTraining addTeamTraining = new AddIndTraining(ListViewIndTrainings.SelectedItem as ViewIndTrainings);
                    this.Opacity = 0.3;
                    Filter();
                    addTeamTraining.ShowDialog();
                    Filter();
                    this.Opacity = 1;
                }
                else
                {
                    MessageBox.Show("You did not select player", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                }

            }
            catch
            {
                MessageBox.Show("Error", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }



        }

        private void BtnDeleteTraining_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (ListViewIndTrainings.SelectedItem is ViewIndTrainings training)
                {
                    var result = MessageBox.Show($@"Are you sure you want to delete this training?{training.FullName} {training.DateStart}, All related data will be permanently deleted", "Remove training",
                        MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        context.IndividualTraining.Remove(context.IndividualTraining.Where(i => i.IdIndTra == training.IdIndTra).FirstOrDefault());
                        context.SaveChanges();
                        MessageBox.Show("Removing ", "Success", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        Filter();


                    }
                }
                else
                {
                    MessageBox.Show("Select player!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }
            catch
            {
                MessageBox.Show("Error ", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CmbTraining_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }
    }
}
