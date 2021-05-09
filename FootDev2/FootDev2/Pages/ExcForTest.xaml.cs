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
    /// Логика взаимодействия для ExcForTest.xaml
    /// </summary>
    public partial class ExcForTest : Page
    {
        public ExcForTest()
        {
            InitializeComponent();
            ListViewExe.ItemsSource = context.ViewExcForTest.ToList();

          
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
            var list = context.ViewExcForTest.Where(i => i.FullName.Contains(TxtSearch.Text)).ToList();

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
        private void BtnDeleteTest_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (ListViewExe.SelectedItem is ViewExcForTest test)
                {
                    var result = MessageBox.Show($@"Are you sure you want to delete this test?{test.FullName} {test.DateTesting}, All related data will be permanently deleted", "Remove training",
                        MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        context.ExerciseForTest.Remove(context.ExerciseForTest.Where(i => i.IdExerciseForTest == test.IdExerciseForTest).FirstOrDefault());
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

        private void BtnEditTest_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (ListViewExe.SelectedItem is ViewExcForTest test)
                {
                    VarIdTraining = test.IdExerciseForTest;
                    AddTest addtest = new AddTest(ListViewExe.SelectedItem as ViewExcForTest);
                    this.Opacity = 0.3;
                    Filter();
                    addtest.ShowDialog();
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

        private void BtnAddTest_Click(object sender, RoutedEventArgs e)
        {
            AddTest addtest = new AddTest();
            this.Opacity = 0.3;
            Filter();
            addtest.ShowDialog();
            Filter();
            this.Opacity = 1;
        }

        private void CmbExcercise_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }
    }
}
