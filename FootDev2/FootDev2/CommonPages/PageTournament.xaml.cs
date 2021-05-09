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
using FootDev2.Windows;
using FootDev2.AppData;
using static FootDev2.HelperClass.CheckRole;


namespace FootDev2.CommonPages
{
    /// <summary>
    /// Логика взаимодействия для PageTournament.xaml
    /// </summary>
    public partial class PageTournament : Page
    {
        public PageTournament()
        {
            InitializeComponent();
            ListViewTournaments.ItemsSource = context.Tournament.ToList(); CmbSort.ItemsSource = new List<string>()
            {
                "By default", "By  Date", "By Prize Pool"
            };

            List<string> listCountry = new List<string>();

            var Country = context.Country.ToList();
            foreach (var i in Country)
            {
                listCountry.Add(i.CountryName);
            }

            listCountry.Insert(0, "All Countries");
            CmbCountry.ItemsSource = listCountry;
            CmbCountry.SelectedIndex = 0;

            CmbSort.SelectedIndex = 0;


        }


        public void Filter()
        {
            var list = context.Tournament.Where(i => i.TournamentName.Contains(TxtSearch.Text)).ToList();

            var selectFilter = CmbCountry.SelectedItem;

            if (CmbCountry.SelectedIndex != 0)
            {
                list = list.Where(i => i.Country == selectFilter.ToString()).ToList();
                ListViewTournaments.ItemsSource = list;
            }
            else
            {
                ListViewTournaments.ItemsSource = list;
            }

            switch (CmbSort.SelectedIndex)
            {

                case 1:
                    list = list.OrderByDescending(i => i.DateStart).ToList();
                    break;
                case 2:
                    list = list.OrderByDescending(i => i.PrizePool).ToList();
                    break;
            }
            ListViewTournaments.ItemsSource = list;



            if (CBDate.IsChecked == true)
            {
                list = list.Where(i => i.DateStart.HasValue && i.DateStart.Value.Month == DateTime.Now.Month).ToList();
                ListViewTournaments.ItemsSource = list;
            }
            else
            {
                list = context.Tournament.ToList();
            }







        }

        private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }

        private void CmbGender_SelectionChanged(object sender, SelectionChangedEventArgs e)
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
            CmbCountry.SelectedIndex = 0;
            CBDate.IsChecked = false;
        }

        private void CmbCountry_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }

        private void CBDate_Checked(object sender, RoutedEventArgs e)
        {
            Filter();
        }

        private void CBDate_Unchecked(object sender, RoutedEventArgs e)
        {
            Filter();
        }

    }
}
