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
using System.Windows.Shapes;
using static FootDev2.AppData.AppDataClass;
using static FootDev2.HelperClass.CheckRole;
using  FootDev2.AppData;
using System.Collections.ObjectModel;

namespace FootDev2.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddTraits.xaml
    /// </summary>
    public partial class AddTraits : Window
    {
        ObservableCollection<Traits> traitsList = new ObservableCollection<Traits>();
        public AddTraits()
        {
            InitializeComponent();


            List<ViewAllInfo> players = context.ViewAllInfo.ToList();
            CmbPlayer.DisplayMemberPath = "FullName";
            players.Insert(0, new ViewAllInfo() { Name = "Choose Player" });
            CmbPlayer.ItemsSource = players;
            CmbPlayer.SelectedIndex = 0;

            List<Traits> traits = context.Traits.ToList();
            CmbTrait.DisplayMemberPath = "Name";
            traits.Insert(0, new Traits() { Name = "Choose Trait" });
            CmbTrait.ItemsSource = traits;
            CmbTrait.SelectedIndex = 0;
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnAddTrait_Click(object sender, RoutedEventArgs e)
        {
            if (CmbPlayer.SelectedIndex != 0 || CmbTrait.SelectedIndex != 0)
            {
                if ((traitsList.Where(i => i.IdTraits == (CmbTrait.SelectedValue as Traits).IdTraits).ToList().Count) == 0)
                {
                    traitsList.Add(CmbTrait.SelectedValue as Traits);
                }
            }
            ListViewTraits.ItemsSource = traitsList;

        }


        private void BtnConfirm_Click(object sender, RoutedEventArgs e)
        {
            try { 

            if (CmbPlayer.SelectedIndex == 0 || traitsList.Count == 0)
            {
                MessageBox.Show("Choose player or trait", "Error");
            }
            else
            {
                var resultClick = MessageBox.Show("Are you sure you want to add traits to player?", "Addition traits", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (resultClick == MessageBoxResult.Yes)
                {
                    foreach (var item in traitsList)
                    {
                        context.PlayerToTraits.Add(new PlayerToTraits
                        {
                            IdTrait = item.IdTraits,
                            IdPlayer = CmbPlayer.SelectedIndex
                        });
                    }
                }
             }

            
                context.SaveChanges();

                Close();

            }
            catch
            {
                MessageBox.Show("Error", "Error");
            }

        }

    }
}
