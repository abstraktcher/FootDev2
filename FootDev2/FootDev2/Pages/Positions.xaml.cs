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
    /// Логика взаимодействия для Positions.xaml
    /// </summary>
    public partial class Positions : Page
    {
        public Positions()
        {
            InitializeComponent();
            ListViewPositions.ItemsSource = context.ViewShowPositions.OrderBy(i => i.Positions).ToList();

        }

        public void Filter()
        {
            var list = context.ViewShowPositions.Where(i => i.Fullname.Contains(TxtSearch.Text)).ToList();
            ListViewPositions.ItemsSource = list;

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

          
            TxtSearch.Text = "";
        }

        private void CmbPositions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }


        private void BtnAddPosition_Click(object sender, RoutedEventArgs e)
        {
            AddPosition addPosition = new AddPosition();
            this.Opacity = 0.3;
            Filter();
            addPosition.ShowDialog();
            Filter();
            this.Opacity = 1;
        }

        private void BtnDeletePosition_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (ListViewPositions.SelectedItem is ViewShowPositions positions)
                {
                    var result = MessageBox.Show($@"Are you sure you want to delete information about this player? {positions.Fullname} All  data will be permanently deleted", "Remove Information",
                        MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        var positionslist = context.PlayerToPosition.Where(i => i.IdPlayer == positions.IdPlayer).ToList();
                        foreach (var item in positionslist)
                        {
                            context.PlayerToPosition.Remove(context.PlayerToPosition.Where(i => i.IdPlayer == positions.IdPlayer).FirstOrDefault());
                            context.SaveChanges();
                        }
                        MessageBox.Show("Removing ", "Success", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        ListViewPositions.ItemsSource = context.ViewPlayerTraits.ToList();
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
    }
}
