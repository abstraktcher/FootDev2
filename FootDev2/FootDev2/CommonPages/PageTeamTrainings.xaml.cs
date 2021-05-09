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

namespace FootDev2.CommonPages
{
    /// <summary>
    /// Логика взаимодействия для PageTeamTrainings.xaml
    /// </summary>
    public partial class PageTeamTrainings : Page
    {
        public PageTeamTrainings()
        {
            InitializeComponent(); 
            ListViewTeamTrainings.ItemsSource = context.ViewTeamTrainings.ToList();

            List<Training> trainings = context.Training.ToList();
            trainings.Insert(0, new Training() { TrainingName = "All" });
            CmbTraining.ItemsSource = trainings;
            CmbTraining.DisplayMemberPath = "TrainingName";
            CmbTraining.SelectedIndex = 0;
            CmbSort.SelectedIndex = 0;



            CmbSort.ItemsSource = new List<string>()
            {
                "By default", "By  Date", "By Club"
            };
        }

        private void CmbTraining_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
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
            var list = context.ViewTeamTrainings.Where(i => i.TrainingName.Contains(TxtSearch.Text)).ToList();

            var selectFilter = CmbTraining.SelectedIndex;

            if (selectFilter != 0)
            {
                ListViewTeamTrainings.ItemsSource = list.Where(i => i.IdTraining == selectFilter).ToList();
            }


            switch (CmbSort.SelectedIndex)
            {

                case 1:
                    list = list.OrderByDescending(i => i.Date).ToList();
                    break;
                case 2:
                    list = list.OrderByDescending(i => i.ClubName).ToList();
                    break;
            }
            ListViewTeamTrainings.ItemsSource = list;

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


    }
}
