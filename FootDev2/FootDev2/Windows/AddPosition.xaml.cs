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
using FootDev2.AppData;
using System.Collections.ObjectModel;

namespace FootDev2.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddPosition.xaml
    /// </summary>
    public partial class AddPosition : Window
    {
        
        ObservableCollection<Position> positionsList = new ObservableCollection<Position>();
        public AddPosition()
        {
            InitializeComponent();

            List<ViewAllInfo> players = context.ViewAllInfo.ToList();
            CmbPlayer.DisplayMemberPath = "FullName";
            players.Insert(0, new ViewAllInfo() { Name = "Choose Player" });
            CmbPlayer.ItemsSource = players;
            CmbPlayer.SelectedIndex = 0;

            List<Position> positions = context.Position.ToList();
            CmbPosition.DisplayMemberPath = "NamePosition";
            positions.Insert(0, new Position() { NamePosition = "Choose Trait" });
            CmbPosition.ItemsSource = positions;
            CmbPosition.SelectedIndex = 0;
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnAddPosition_Click(object sender, RoutedEventArgs e)
        {
            if (CmbPlayer.SelectedIndex != 0 || CmbPosition.SelectedIndex != 0)
            {
                if ((positionsList.Where(i => i.IdPosition == (CmbPosition.SelectedValue as Position).IdPosition).ToList().Count) == 0)
                {
                    positionsList.Add(CmbPosition.SelectedValue as Position);
                }
            }
            ListViewTraits.ItemsSource = positionsList;

        }


        private void BtnConfirm_Click(object sender, RoutedEventArgs e)
        {

            if (CmbPlayer.SelectedIndex == 0 || positionsList.Count == 0)
            {
                MessageBox.Show("Choose player or position", "Error");
            }
            else
            {
                var resultClick = MessageBox.Show("Are you sure you want to add position to player?", "Addition position", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (resultClick == MessageBoxResult.Yes)
                {
                    foreach (var item in positionsList)
                    {
                        context.PlayerToPosition.Add(new PlayerToPosition
                        {
                            IdPosition = item.IdPosition,
                            IdPlayer = CmbPlayer.SelectedIndex
                        });
                    }
                }


                context.SaveChanges();

                Close();

            }

        }
    }
}
