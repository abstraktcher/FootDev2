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
    /// Логика взаимодействия для DFCharacteristics.xaml
    /// </summary>
    public partial class DFCharacteristics : Page
    {
        public DFCharacteristics()
        {
            InitializeComponent();
            ListViewDF.ItemsSource = context.ViewDFCharacteristics.ToList();
        }
        public void Filter()
        {
            var list = context.ViewDFCharacteristics.Where(i => i.FullName.Contains(TxtSearch.Text)).ToList();
            ListViewDF.ItemsSource = list;

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

                if (ListViewDF.SelectedItem is FootDev2.AppData.ViewDFCharacteristics dfchara)
                {
                    var result = MessageBox.Show($@"Are you sure you want to delete this characteristics? {dfchara.FullName}, All  data will be permanently deleted", "Remove Information",
                        MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        context.PlayerToDFCharacteristics.Remove(context.PlayerToDFCharacteristics.Where(i => i.IdPlaToDF == dfchara.IdPlaToDF).FirstOrDefault());
                        context.SaveChanges();
                        context.DefenderCharacteristics.Remove(context.DefenderCharacteristics.Where(i => i.IdDFChar == dfchara.IdDFChar).FirstOrDefault());
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

                if (ListViewDF.SelectedItem is FootDev2.AppData.ViewDFCharacteristics dfchara)
                {
                    VarIdCharacteristics = dfchara.IdPlaToDF;
                    VarIdChara = dfchara.IdDFChar;
                    AddDFCharacteristics adddf = new AddDFCharacteristics(ListViewDF.SelectedItem as FootDev2.AppData.ViewDFCharacteristics);
                    this.Opacity = 0.3;
                    Filter();
                    adddf.ShowDialog();
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
            AddDFCharacteristics adddf = new AddDFCharacteristics();
            this.Opacity = 0.3;
            Filter();
            adddf.ShowDialog();
            Filter();
            this.Opacity = 1;
        }
    }
}
