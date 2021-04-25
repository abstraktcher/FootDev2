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

namespace FootDev2.Pages
{
    /// <summary>
    /// Логика взаимодействия для Tournaments.xaml
    /// </summary>
    public partial class Tournaments : Page
    {
        public Tournaments()
        {
            InitializeComponent();
            ListViewTournaments.ItemsSource = context.ViewInfoTournament.ToList();
            CmbSort.ItemsSource = new List<string>()
            {
                "By default", "By  Date", "By Prize Pool"
            };

            var Country = context.Country.ToList();
            foreach (var i in Country)
            {
                CmbCountry.Add(i.CountryName);
            }

            listFiltr.Insert(0, "All Countries");
            cmbFiltr.ItemsSource = listFiltr;
            cmbFiltr.SelectedIndex = 0;
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
            var list = context.ViewInfoTournament.Where(i => i.TournamentName.Contains(TxtSearch.Text)).ToList();

         
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
        }

    //    private void BtnEditPlayer_Click(object sender, RoutedEventArgs e)
    //    {
    //        try
    //        {

    //            if (ListViewSquad.SelectedItem is ViewAllInfo player)
    //            {
    //                VarIdPlayer = player.IdPlayer;
    //                AddEditPlayer addEditMateralWindow = new AddEditPlayer(ListViewSquad.SelectedItem as ViewAllInfo);
    //                this.Opacity = 0.3;
    //                Filter();
    //                addEditMateralWindow.ShowDialog();
    //                Filter();
    //                this.Opacity = 1;
    //            }
    //            else
    //            {
    //                MessageBox.Show("You did not select player", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

    //            }

    //        }
    //        catch
    //        {
    //            MessageBox.Show("Error", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
    //        }



    //    }

    //    private void BtnAddPlayer_Click(object sender, RoutedEventArgs e)
    //    {
    //        AddEditPlayer addEditMateralWindow = new AddEditPlayer();
    //        this.Opacity = 0.3;
    //        Filter();
    //        addEditMateralWindow.ShowDialog();
    //        Filter();
    //        this.Opacity = 1;
    //    }

    //    private void BtnDeletePlayer_Click(object sender, RoutedEventArgs e)
    //    {
    //        try
    //        {

    //            if (ListViewSquad.SelectedItem is ViewAllInfo player)
    //            {
    //                var result = MessageBox.Show($@"Are you sure you want to delete this player?{player.FullName}, All related data will be permanently deleted", "Remove Player",
    //                    MessageBoxButton.YesNo, MessageBoxImage.Question);
    //                if (result == MessageBoxResult.Yes)
    //                {
    //                    context.Player.Remove(context.Player.Where(i => i.IdPlayer == player.IdPlayer).FirstOrDefault());
    //                    context.SaveChanges();
    //                    MessageBox.Show("Removing ", "Success", MessageBoxButton.OK, MessageBoxImage.Exclamation);
    //                    Filter();


    //                }
    //            }
    //            else
    //            {
    //                MessageBox.Show("Select player!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
    //            }

    //        }
    //        catch
    //        {
    //            MessageBox.Show("Error ", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
    //        }
    //    }
    //}

        private void BtnDeleteTournament_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnDeleteTournament_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void BtnEditTournament_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnAddTournament_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
