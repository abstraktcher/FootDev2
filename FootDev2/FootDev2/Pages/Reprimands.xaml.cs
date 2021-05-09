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
    /// Логика взаимодействия для Reprimands.xaml
    /// </summary>
    public partial class Reprimands : Page
    {
        public Reprimands()
        {
            InitializeComponent();
            ListViewReprimands.ItemsSource = context.ViewReprimands.ToList();
        }
        public void Filter()
        {
            var list = context.ViewReprimands.Where(i => i.FullName.Contains(TxtSearch.Text)).ToList();

            ListViewReprimands.ItemsSource = list;

        }

        private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }

        private void BtnResetFilters_Click(object sender, RoutedEventArgs e)
        {
            TxtSearch.Text = "";
        }



        private void BtnAddReprimand_Click(object sender, RoutedEventArgs e)
        {
            AddReprimand addReprimand = new AddReprimand();
            this.Opacity = 0.3;
            Filter();
            addReprimand.ShowDialog();
            Filter();
            this.Opacity = 1;
        }

        private void BtnDeleteReprimand_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (ListViewReprimands.SelectedItem is ViewReprimands reprimands)
                {
                    var result = MessageBox.Show($@"Are you sure you want to delete this reprimand?{reprimands.FullName}, All related data will be permanently deleted", "Remove Player",
                        MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        context.Reprimand.Remove(context.Reprimand.Where(i => i.IdPlaToRep == reprimands.IdPlaToRep).FirstOrDefault());
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

        private void BtnEditReprimand_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (ListViewReprimands.SelectedItem is ViewReprimands reprimand)
                {
                    VarIdReprimand = reprimand.IdPlaToRep;
                    AddReprimand addReprimand = new AddReprimand(ListViewReprimands.SelectedItem as ViewReprimands);
                    this.Opacity = 0.3;
                    Filter();
                    addReprimand.ShowDialog();
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
    }
}
