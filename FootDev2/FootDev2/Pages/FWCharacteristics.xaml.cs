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
    /// Логика взаимодействия для FWCharacteristics.xaml
    /// </summary>
    public partial class FWCharacteristics : Page
    {
        public FWCharacteristics()
        {
            InitializeComponent();
            ListViewFW.ItemsSource = context.ViewStrikerCharacteristics.ToList();
        }

        public void Filter()
        {
            var list = context.ViewStrikerCharacteristics.Where(i => i.FullName.Contains(TxtSearch.Text)).ToList();
            ListViewFW.ItemsSource = list;

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
            try
            {

                if (ListViewFW.SelectedItem is FootDev2.AppData.ViewStrikerCharacteristics fwchara)
                {
                    var result = MessageBox.Show($@"Are you sure you want to delete this characteristics? {fwchara.FullName}, All  data will be permanently deleted", "Remove Information",
                        MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        context.PlayerToFWCharacteristics.Remove(context.PlayerToFWCharacteristics.Where(i => i.IdPlaToFW == fwchara.IdPlaToFW).FirstOrDefault());
                        context.SaveChanges();
                        context.ForwardCharacteristics.Remove(context.ForwardCharacteristics.Where(i => i.IdFWChar == fwchara.IdFWChar).FirstOrDefault());
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

        private void BtnEditCharacteristics_Click(object sender, RoutedEventArgs e)
        {
            try

            {

                if (ListViewFW.SelectedItem is FootDev2.AppData.ViewStrikerCharacteristics fwchara)
                {
                    VarIdCharacteristics = fwchara.IdPlaToFW;
                    VarIdChara = fwchara.IdFWChar;
                    AddFWCharacteristics addfw = new AddFWCharacteristics(ListViewFW.SelectedItem as FootDev2.AppData.ViewStrikerCharacteristics);
                    this.Opacity = 0.3;
                    Filter();
                    addfw.ShowDialog();
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
            AddFWCharacteristics addfw = new AddFWCharacteristics();
            this.Opacity = 0.3;
            Filter();
            addfw.ShowDialog();
            Filter();
            this.Opacity = 1;
        }
    }
}
