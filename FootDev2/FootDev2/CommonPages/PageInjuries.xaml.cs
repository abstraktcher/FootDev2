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
    /// Логика взаимодействия для PageInjuries.xaml
    /// </summary>
    public partial class PageInjuries : Page
    {
        public PageInjuries()
        {
            InitializeComponent(); ListViewInjuries.ItemsSource = context.Injuries.ToList();
            CmbSort.SelectedIndex = 0;
            CmbSort.ItemsSource = new List<string>()
            {
                "By default", "By Injury Date", "By Age"
            };



            List<Injury> injuries = context.Injury.ToList();
            CmbInjuries.DisplayMemberPath = "InjuryName";
            injuries.Insert(0, new Injury() { InjuryName = "All" });
            CmbInjuries.ItemsSource = injuries;
            CmbInjuries.SelectedIndex = 0;
        }

        public void Filter()
        {
            var list = context.Injuries.Where(i => i.FullName.Contains(TxtSearch.Text)).ToList();
            ListViewInjuries.ItemsSource = list;

            switch (CmbSort.SelectedIndex)
            {

                case 1:
                    list = list.OrderByDescending(i => i.DateOfInjury).ToList();
                    break;
                case 2:
                    list = list.OrderByDescending(i => i.Age).ToList();
                    break;
            }
            ListViewInjuries.ItemsSource = list;

            switch (CmbInjuries.SelectedIndex)
            {

                case 1:
                    list = list.OrderByDescending(i => i.DateOfInjury).ToList();
                    break;
                case 2:
                    list = list.OrderByDescending(i => i.Age).ToList();
                    break;
            }
            ListViewInjuries.ItemsSource = list;

            var selectFilter = CmbInjuries.SelectedIndex;

            if (selectFilter != 0)
            {
                ListViewInjuries.ItemsSource = list.Where(i => i.IdInjury == selectFilter).ToList();
            }

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

            CmbSort.SelectedIndex = 0;
            TxtSearch.Text = "";
            CmbInjuries.SelectedIndex = 0;
        }

        private void CmbInjuries_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }
    }
}
