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
using  FootDev2.AppData;
using FootDev2.Windows;

namespace FootDev2.Pages
{
    /// <summary>
    /// Логика взаимодействия для Squad.xaml
    /// </summary>
    public partial class Squad : Page
    {
        public Squad()
        {
            InitializeComponent();
            ListViewSquad.ItemsSource = context.ViewAllInfo.ToList();
            List<Gender> genders = context.Gender.ToList();
            genders.Insert(0, new Gender() { NameGender = "All" });
            CmbGender.ItemsSource = genders;
            CmbGender.DisplayMemberPath = "NameGender";
            CmbGender.SelectedIndex = 0;

            CmbSort.ItemsSource = new List<string>()
            {
                "By default", "By Joining Date", "By Age"
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
            var list = context.ViewAllInfo.Where(i => i.FullName.Contains(TxtSearch.Text)).ToList();

            if (CmbGender.SelectedIndex == 0)
            {
                ListViewSquad.ItemsSource = list;
            }
            else
            {
                var Gender = CmbGender.SelectedItem as Gender;
                list = list.Where(i => i.NameGender == Gender.NameGender).ToList();
                ListViewSquad.ItemsSource = list;
            }

            switch (CmbSort.SelectedIndex)
            {
                
                case 1:
                    list = list.OrderByDescending(i => i.DateJoining).ToList();
                    break;
                case 2:
                    list = list.OrderByDescending(i => i.Age).ToList();
                    break;
            }
            ListViewSquad.ItemsSource = list;

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
            CmbGender.SelectedIndex = 0;
            CmbSort.SelectedIndex = 0;
            TxtSearch.Text = "";
        }

        private void BtnEditPlayer_Click(object sender, RoutedEventArgs e)
        {
            AddEditPlayer addEditMateralWindow = new AddEditPlayer(ListViewSquad.SelectedItem as Player);
            AddEditPlayer AddEditWindow = new AddEditPlayer();
            this.Opacity = 0.3;
            Filter();
            AddEditWindow.ShowDialog();
            this.Opacity = 1;
        }
    }
}
