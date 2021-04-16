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
using FootDev2.AppData;
using FootDev2.Windows;
using static FootDev2.AppData.AppDataClass;

namespace FootDev2.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddEditPlayer.xaml
    /// </summary>
    public partial class AddEditPlayer : Window
    {
        public AddEditPlayer()
        {
            InitializeComponent();
           

            //           CmbPositions.ItemsSource = context.Position.ToList();
            //CmbPositions.DisplayMemberPath = "NamePosition";
            //CmbPositions.SelectedIndex = 0;

          
        }

        public AddEditPlayer(ViewAllInfo player)
        {
            InitializeComponent();

            CmbGender.ItemsSource = context.Gender.ToList();
            CmbGender.DisplayMemberPath = "NameGender";

            CmbLeg.ItemsSource = context.DominantLeg.ToList();
            CmbLeg.DisplayMemberPath = "Name";

            CmbNationality.ItemsSource = context.Nationality.ToList();
            CmbNationality.DisplayMemberPath = "NationalityName";


            TxtFirstName.Text = player.FirstName.ToString();
            TxtLastName.Text = player.LastName.ToString();
            TxtMiddleName.Text = player.MiddleName.ToString();
            TxtEmail.Text = player.Email.ToString();
            TxtPhone.Text = player.PhoneNumber.ToString();
            TxtPassword.Text = player.Password.ToString();
            CmbGender.SelectedIndex = player.idGender - 1;
            CmbLeg.SelectedIndex = (int)(player.IdDominantLeg - 1);

           
            //imgMaterial.Source = new BitmapImage(new Uri(material.Image));

            
            //var supMaterial = Context.MaterialSupp.Where(i => i.IdMaterial == material.ID).ToList();

        }

        private void BtnConfirm_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtFirstName.Text) || string.IsNullOrWhiteSpace(TxtLastName.Text))
            {
                MessageBox.Show("Write your Name", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        private void TxtFirstName_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZäöÖÄ".IndexOf(e.Text) < 0;
        }

        private void TxtLastName_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZäöÖÄ".IndexOf(e.Text) < 0;
        }

        private void TxtMiddleName_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZäöÖÄ".IndexOf(e.Text) < 0;
        }

        private void TxtPhone_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "1234567890".IndexOf(e.Text) < 0;
        }

        private void TxtEmail_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "1234567890abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ_@".IndexOf(e.Text) < 0;
        }

        private void TxtPassword_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "1234567890abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ#$%&'()*+,-./:;<=>?@[]^_`{|}~!$&".IndexOf(e.Text) < 0;
        }

        private void TxtFirstName_PreviewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (e.Command == ApplicationCommands.Copy ||
                e.Command == ApplicationCommands.Cut ||
                e.Command == ApplicationCommands.Paste)
            {
                e.Handled = true;
            }
        }

        private void TxtLastName_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (e.Command == ApplicationCommands.Copy ||
                e.Command == ApplicationCommands.Cut ||
                e.Command == ApplicationCommands.Paste)
            {
                e.Handled = true;
            }
        }

        private void TxtMiddleName_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (e.Command == ApplicationCommands.Copy ||
                e.Command == ApplicationCommands.Cut ||
                e.Command == ApplicationCommands.Paste)
            {
                e.Handled = true;
            }
        }

        private void TxtPhone_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (e.Command == ApplicationCommands.Copy ||
                e.Command == ApplicationCommands.Cut ||
                e.Command == ApplicationCommands.Paste)
            {
                e.Handled = true;
            }
        }

        private void TxtEmail_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (e.Command == ApplicationCommands.Copy ||
                e.Command == ApplicationCommands.Cut ||
                e.Command == ApplicationCommands.Paste)
            {
                e.Handled = true;
            }
        }

        private void TxtPassword_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (e.Command == ApplicationCommands.Copy ||
                e.Command == ApplicationCommands.Cut ||
                e.Command == ApplicationCommands.Paste)
            {
                e.Handled = true;
            }
        }
    }
}
