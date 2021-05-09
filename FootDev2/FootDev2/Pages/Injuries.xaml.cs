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
using  static FootDev2.AppData.AppDataClass;
using FootDev2.AppData;
using FootDev2.Windows;
using static FootDev2.HelperClass.CheckRole;

namespace FootDev2.CommonPages
{
    /// <summary>
    /// Логика взаимодействия для Injuries.xaml
    /// </summary>
    public partial class Injuries : Page
    {
        public int IdInjToPla { get; private set; }

        public Injuries()
        {
            InitializeComponent();
            ListViewInjuries.ItemsSource = context.Injuries.ToList();
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

private void BtnEditInjury_Click(object sender, RoutedEventArgs e)
{
            try

                {

                if (ListViewInjuries.SelectedItem is FootDev2.AppData.Injuries injury)
                {
                    VarIdInjury = injury.IdInjToPla;
                    AddInjury addInjury = new AddInjury(ListViewInjuries.SelectedItem as FootDev2.AppData.Injuries);
                    this.Opacity = 0.3;
                    Filter();
                    addInjury.ShowDialog();
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

private void BtnAddInjury_Click(object sender, RoutedEventArgs e)
{
            AddInjury addInjury = new AddInjury();
            this.Opacity = 0.3;
            Filter();
            addInjury.ShowDialog();
            Filter();
            this.Opacity = 1;
        }

private void BtnDeleteInjury_Click(object sender, RoutedEventArgs e)
{
            try
            {

                if (ListViewInjuries.SelectedItem is FootDev2.AppData.Injuries injury)
                {
                    var result = MessageBox.Show($@"Are you sure you want to delete information about this injury? {injury.FullName}  {injury.InjuryName}, All  data will be permanently deleted", "Remove Information",
                        MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        context.InjuryToPlayer.Remove(context.InjuryToPlayer.Where(i => i.IdInjToPla == injury.IdInjToPla).FirstOrDefault());
                        context.SaveChanges();
                        MessageBox.Show("Removing ", "Success", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        Filter();


                    }
                }
                else
                {
                    MessageBox.Show("Select entry!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }
            catch
            {
                MessageBox.Show("Error ", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CmbInjuries_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }
    }
}
