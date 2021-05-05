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
    /// Логика взаимодействия для Traits.xaml
    /// </summary>
    public partial class Traits : Page
    {
        public Traits()
        {
            InitializeComponent();
            ListViewTraits.ItemsSource = context.ViewPlayerTraits.ToList();
        }

        public void Filter()
        {
            var list = context.ViewPlayerTraits.Where(i => i.Fullname.Contains(TxtSearch.Text)).ToList();
            ListViewTraits.ItemsSource = list;
        }
        private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            Filter();

        }

        private void BtnAddTrait_Click(object sender, RoutedEventArgs e)
        {
            AddTraits addTrait = new AddTraits();
            this.Opacity = 0.3;
            ListViewTraits.ItemsSource = context.ViewPlayerTraits.ToList();
            addTrait.ShowDialog();
            ListViewTraits.ItemsSource = context.ViewPlayerTraits.ToList();
            this.Opacity = 1;
        }

        private void BtnDeleteTrait_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (ListViewTraits.SelectedItem is ViewPlayerTraits traits)
                {
                    var result = MessageBox.Show($@"Are you sure you want to delete information about this player? {traits.Fullname} All  data will be permanently deleted", "Remove Information",
                        MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        var traitplayerlist = context.PlayerToTraits.Where(i => i.IdPlayer == traits.IdPlayer).ToList();
                        foreach (var item in traitplayerlist)
                        {
                            context.PlayerToTraits.Remove(context.PlayerToTraits.Where(i => i.IdPlayer == traits.IdPlayer).FirstOrDefault());
                            context.SaveChanges();
                        }
                        MessageBox.Show("Removing ", "Success", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        ListViewTraits.ItemsSource = context.ViewPlayerTraits.ToList();






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
