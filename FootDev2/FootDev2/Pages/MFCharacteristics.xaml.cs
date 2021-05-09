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
    /// Логика взаимодействия для MFCharacteristics.xaml
    /// </summary>
    public partial class MFCharacteristics : Page
    {
        public MFCharacteristics()
        {
            InitializeComponent();
            ListViewMF.ItemsSource = context.ViewMFCharacteristics.ToList();
        }

        public void Filter()
        {
            var list = context.ViewMFCharacteristics.Where(i => i.FullName.Contains(TxtSearch.Text)).ToList();
            ListViewMF.ItemsSource = list;

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

                if (ListViewMF.SelectedItem is FootDev2.AppData.ViewMFCharacteristics mfchara)
                {
                    var result = MessageBox.Show($@"Are you sure you want to delete this characteristics? {mfchara.FullName}, All  data will be permanently deleted", "Remove Information",
                        MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        context.PlayerToMFCharacteristics.Remove(context.PlayerToMFCharacteristics.Where(i => i.IdPlToChar == mfchara.IdPlToChar).FirstOrDefault());
                        context.SaveChanges();
                        context.MidFielderCharacteristics.Remove(context.MidFielderCharacteristics.Where(i => i.IdMDFChar == mfchara.IdCharacteristics).FirstOrDefault());
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

                if (ListViewMF.SelectedItem is FootDev2.AppData.ViewMFCharacteristics mfchara)
                {
                    VarIdCharacteristics = mfchara.IdPlToChar;
                    VarIdChara = mfchara.IdCharacteristics;
                    AddMfCharacteristics addmf = new AddMfCharacteristics(ListViewMF.SelectedItem as FootDev2.AppData.ViewMFCharacteristics);
                    this.Opacity = 0.3;
                    Filter();
                    addmf.ShowDialog();
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
            AddMfCharacteristics addmf = new AddMfCharacteristics();
            this.Opacity = 0.3;
            Filter();
            addmf.ShowDialog();
            Filter();
            this.Opacity = 1;
        }
    }
}
