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
    /// Логика взаимодействия для PageExercise.xaml
    /// </summary>
    public partial class PageExercise : Page
    {
        public PageExercise()
        {
            InitializeComponent();
            ListViewExe.ItemsSource = context.ViewExcForTest.Where(i => i.IdPlayer == VarCheckRole).ToList();


            CmbExcercise.ItemsSource = context.Exercise.ToList();
            CmbExcercise.DisplayMemberPath = "ExerciseName";
            CmbExcercise.SelectedIndex = 0;
            CmbSort.SelectedIndex = 0;



            CmbSort.ItemsSource = new List<string>()
            {
                "By default", "By  Date", "By Exercise"
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
            var list = context.ViewExcForTest.Where(i => i.ExerciseName.Contains(TxtSearch.Text)).ToList();

            var selectFilter = CmbExcercise.SelectedIndex;

            if (selectFilter != 0)
            {
                ListViewExe.ItemsSource = list.Where(i => i.IdExercise == selectFilter).ToList();
            }


            switch (CmbSort.SelectedIndex)
            {

                case 1:
                    list = list.OrderByDescending(i => i.DateTesting).ToList();
                    break;
                case 2:
                    list = list.OrderByDescending(i => i.IdExercise).ToList();
                    break;
            }
            ListViewExe.ItemsSource = list;

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
            CmbExcercise.SelectedIndex = 0;
            CmbSort.SelectedIndex = 0;
            TxtSearch.Text = "";
        }

        private
 void CmbTraining_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }

        private void CmbExcercise_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }
    }
}
