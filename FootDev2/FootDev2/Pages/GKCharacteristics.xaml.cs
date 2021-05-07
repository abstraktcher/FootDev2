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
    /// Логика взаимодействия для GKCharacteristics.xaml
    /// </summary>
    public partial class GKCharacteristics : Page
    {
        public GKCharacteristics()
        {
            InitializeComponent();
            ListViewGK.ItemsSource = context.ViewGkCharacteristics.ToList();

        }

        public void Filter()
        {
            var list = context.ViewGkCharacteristics.Where(i => i.FullName.Contains(TxtSearch.Text)).ToList();
            ListViewGK.ItemsSource = list;

        }

        private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }

        private void BtnResetFilters_Click(object sender, RoutedEventArgs e)
        {

            TxtSearch.Text = "";
        }

        private void BtnDeleteCharacteristics_Click(object sender, RoutedEventArgs e)
        {
            //try
            //{

            if (ListViewGK.SelectedItem is FootDev2.AppData.ViewGkCharacteristics gkchara)
            {
                var result = MessageBox.Show($@"Are you sure you want to delete this characteristics? {gkchara.FullName}, All  data will be permanently deleted", "Remove Information",
                    MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    context.PlayerToGKCharacteristics.Remove(context.PlayerToGKCharacteristics.Where(i => i.IdPlaToGK == gkchara.IdPlaToGK).FirstOrDefault());
                    context.SaveChanges();
                    MessageBox.Show("Removing ", "Success", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    Filter();


                }
            }
            else
            {
                MessageBox.Show("Select entry!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            //}
            //catch
            //{
            //    MessageBox.Show("Error ", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            //}
        }

        private void BtnEditCharacteristics_Click(object sender, RoutedEventArgs e)
        {
            try

            {

                if (ListViewGK.SelectedItem is FootDev2.AppData.ViewGkCharacteristics gkchara)
                {
                    VarIdCharacteristics = gkchara.IdPlaToGK;
                    VarIdChara = gkchara.IdGKChar
                    AddPredisp addpredisp = new AddPredisp(ListViewPredispositions.SelectedItem as FootDev2.AppData.ViewPredispositions);
                    this.Opacity = 0.3;
                    Filter();
                    addpredisp.ShowDialog();
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

        private void BtnAddCharacteristics_Click(object sender, RoutedEventArgs e)
        {
            AddPredisp addpredisp = new AddPredisp();
            this.Opacity = 0.3;
            Filter();
            addpredisp.ShowDialog();
            Filter();
            this.Opacity = 1;
        }
    }
}
