using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
using static FootDev2.HelperClass.CheckRole;

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
            CmbGender.ItemsSource = context.Gender.ToList();
            CmbGender.DisplayMemberPath = "NameGender";

            CmbNationality.ItemsSource = context.Nationality.ToList();
            CmbNationality.DisplayMemberPath = "NationalityName";

            CmbLeg.ItemsSource = context.DominantLeg.ToList();
            CmbLeg.DisplayMemberPath = "Name";

        }

        public AddEditPlayer(ViewAllInfo player)//the selected data is transferred from one window to that
        {
            InitializeComponent();
            CmbGender.ItemsSource = context.Gender.ToList();
            CmbGender.DisplayMemberPath = "NameGender";

            CmbNationality.ItemsSource = context.Nationality.ToList();
            CmbNationality.DisplayMemberPath = "NationalityName";

            CmbLeg.ItemsSource = context.DominantLeg.ToList();
            CmbLeg.DisplayMemberPath = "Name";

            //assigning values to fields from the passed object

            TxtFirstName.Text = player.FirstName.ToString();
            TxtLastName.Text = player.LastName.ToString();
            TxtMiddleName.Text = player.MiddleName.ToString();
            TxtEmail.Text = player.Email.ToString();
            TxtPhone.Text = player.PhoneNumber.ToString();
            TxtPassword.Text = player.Password.ToString();
            CmbGender.SelectedIndex = player.idGender - 1;
            CmbNationality.SelectedIndex = player.IdNationality - 1;
            DpDateOfBirth.SelectedDate = player.DateOfBirth;
            CmbLeg.SelectedIndex = player.IdDominantLeg - 1;


        }

        private void BtnConfirm_Click(object sender, RoutedEventArgs e)
        {
            

            string[] MAssStr = TxtEmail.Text.Split('@'); //creating an array to check if the entered mail is correct

            if (string.IsNullOrWhiteSpace(TxtFirstName.Text) || string.IsNullOrWhiteSpace(TxtLastName.Text)) //checking are Name-fileds filled
            {
                MessageBox.Show("Write your Name", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                if (string.IsNullOrWhiteSpace(TxtEmail.Text) || string.IsNullOrWhiteSpace(TxtPhone.Text))//Checking are Email and Phone fields filled
                {
                    MessageBox.Show("Write your Email or Phone", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                else
                {
                    if (DpDateOfBirth.SelectedDate == null) //checking is Date Of Birth filled
                    {
                        MessageBox.Show("Date of Birth cannot be empty", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    else
                    {
                        if (CmbGender.SelectedItem == null)
                        {
                            MessageBox.Show("Choose gender", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                        else
                        {
                            if (CmbNationality.SelectedItem == null)
                            {
                                MessageBox.Show("Choose nationality", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                                return;
                            }
                            else
                            {
                                if (TxtPhone.Text.Length > 11 || TxtPhone.Text.Length < 10) //checking is number entered properly
                                {
                                    MessageBox.Show("Phone must have  10 characters ", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                                    return;
                                }
                                else
                                {
                                    if (MAssStr.Length == 2)
                                    {
                                        if (MAssStr[1].Split('.').Length == 2)
                                        {

                                            try
                                            {

                                                if (VarIdPlayer != 0) //the variable is assigned a value if the window was called from the edit button. If not, then the value will be 0

                                                {

                                                    Random random = new Random(); 
                                                    var resultClick = MessageBox.Show("Do you want to edit the information?", "Adding new player", MessageBoxButton.YesNo, MessageBoxImage.Question);
                                                    if (resultClick == MessageBoxResult.Yes)
                                                    {

                                                        var PlayerVar = context.Player.Where(i => i.IdPlayer == VarIdPlayer).FirstOrDefault(); //creating variable with data where Id Player equals to Id Player from DataBase

                                                        PlayerVar.FirstName = TxtFirstName.Text;
                                                        PlayerVar.LastName = TxtLastName.Text;
                                                        PlayerVar.MiddleName = TxtMiddleName.Text;
                                                        PlayerVar.Email = TxtEmail.Text;
                                                        PlayerVar.PhoneNumber = TxtPhone.Text;
                                                        PlayerVar.DateOfBirth = DpDateOfBirth.SelectedDate;
                                                        PlayerVar.idGender = (byte)(CmbGender.SelectedIndex + 1);
                                                        PlayerVar.IdNationality = CmbNationality.SelectedIndex + 1;
                                                        PlayerVar.Password = TxtPassword.Text;
                                                        PlayerVar.IdRole = 2;
                                                        PlayerVar.DateJoining = DateTime.Now;
                                                        PlayerVar.IdDominantLeg = (byte)(CmbLeg.SelectedIndex + 1);
                                                        //assigning values to this variable to edit infromation
                                                      

                                                        context.SaveChanges(); //saving changes
                                                        MessageBox.Show("Information was successfully changed", "Success", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                                                        VarIdPlayer = 0;
                                                        Close();
                                                    }
                                                    else
                                                    {
                                                    return;
                                                    }
                                            }
                                            else //if Variable with Id = 0 then it is not editing it is Adding new player
                                                
                                                {
                                                    Player addPlayer = new Player();//creating a new instance of the class
                                                    addPlayer.FirstName = TxtFirstName.Text;
                                                    addPlayer.LastName = TxtLastName.Text;
                                                    addPlayer.MiddleName = TxtMiddleName.Text;
                                                    addPlayer.Email = TxtEmail.Text;
                                                    addPlayer.PhoneNumber = TxtPhone.Text;
                                                    addPlayer.DateOfBirth = DpDateOfBirth.SelectedDate;
                                                    addPlayer.idGender = (byte)(CmbGender.SelectedIndex + 1);
                                                    addPlayer.IdNationality = CmbNationality.SelectedIndex + 1;
                                                    addPlayer.Password = TxtPassword.Text;
                                                    addPlayer.IdRole = 2;
                                                    addPlayer.DateJoining = DateTime.Now;
                                                    addPlayer.IdDominantLeg = (byte)(CmbLeg.SelectedIndex + 1);
                                                        
                                                    

                                                    context.Player.Add(addPlayer); //adding new player
                                                    context.SaveChanges();
                                                    MessageBox.Show("Player was successfully added", "Success", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                                                    Close();
                                                }

                                            }
                                            catch
                                            {
                                                MessageBox.Show("Error", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                                            }

                                        }
                                        else
                                        {
                                            MessageBox.Show("Write Email properly (.) ", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                                            return;
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Write Email properly (@) ", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                                        return;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void TxtFirstName_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZäöÖÄ".IndexOf(e.Text) < 0; //symbols that you can enter in this field
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
            e.Handled = "1234567890abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ_@.".IndexOf(e.Text) < 0;
        }

        private void TxtPassword_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "1234567890abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ#$%&'()*+,-./:;<=>?@[]^_`{|}~!$&".IndexOf(e.Text) < 0;
        }

        private void TxtFirstName_PreviewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (e.Command == ApplicationCommands.Copy || //prohibiting to copy cut and paste
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

        private void TxtFirstName_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;  //prohibiting to press space
            }
        }

        private void TxtLastName_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void TxtMiddleName_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void TxtPhone_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void TxtEmail_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void TxtPassword_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            TxtFirstName.Clear();
            TxtLastName.Clear();
            TxtMiddleName.Clear();
            TxtEmail.Clear();
            TxtPhone.Clear();
            DpDateOfBirth.SelectedDate = null;
            CmbGender.SelectedItem = null;
            CmbNationality.SelectedItem = null;
        }
    }
}
