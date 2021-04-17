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
        string pathPhoto = null;

        public AddEditPlayer()
        {
            InitializeComponent();
            CmbGender.ItemsSource = context.Gender.ToList();
            CmbGender.DisplayMemberPath = "NameGender";

            CmbNationality.ItemsSource = context.Nationality.ToList();
            CmbNationality.DisplayMemberPath = "NationalityName";

            CmbLeg.ItemsSource = context.DominantLeg.ToList();
            CmbLeg.DisplayMemberPath = "Name";


            //           CmbPositions.ItemsSource = context.Position.ToList();
            //CmbPositions.DisplayMemberPath = "NamePosition";
            //CmbPositions.SelectedIndex = 0;


        }

        public AddEditPlayer(ViewAllInfo player)
        {
            InitializeComponent();
            CmbGender.ItemsSource = context.Gender.ToList();
            CmbGender.DisplayMemberPath = "NameGender";

            CmbNationality.ItemsSource = context.Nationality.ToList();
            CmbNationality.DisplayMemberPath = "NationalityName";

            CmbLeg.ItemsSource = context.DominantLeg.ToList();
            CmbLeg.DisplayMemberPath = "Name";



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



            //imgMaterial.Source = new BitmapImage(new Uri(material.Image));


            //var supMaterial = Context.MaterialSupp.Where(i => i.IdMaterial == material.ID).ToList();

        }

        private void BtnConfirm_Click(object sender, RoutedEventArgs e)
        {

            string[] MAssStr = TxtEmail.Text.Split('@');

            if (string.IsNullOrWhiteSpace(TxtFirstName.Text) || string.IsNullOrWhiteSpace(TxtLastName.Text))
            {
                MessageBox.Show("Write your Name", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                if (string.IsNullOrWhiteSpace(TxtEmail.Text) || string.IsNullOrWhiteSpace(TxtPhone.Text))
                {
                    MessageBox.Show("Write your Email or Phone", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                else
                {
                    if (DpDateOfBirth.SelectedDate == null)
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
                                if (TxtPhone.Text.Length > 11 || TxtPhone.Text.Length < 10)
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
                                            if (VarIdPlayer != 0)
                                            {

                                                Random random = new Random();
                                                var resultClick = MessageBox.Show("Do you want to edit the information?", "Adding new player", MessageBoxButton.YesNo, MessageBoxImage.Question);
                                                if (resultClick == MessageBoxResult.Yes)
                                                {
                                                    Player addPlayer = new Player();
                                                    //if (pathPhoto != null)
                                                    //{
                                                    //    var format = pathPhoto.Split('.')[pathPhoto.Split('.').Length - 1];

                                                    //    string namePhoto = $@"\materials\{random.Next()}.{format}";

                                                    //    File.Copy(pathPhoto, $@"..\..\{namePhoto}");
                                                    //    addPlayer.PlayerImage = namePhoto;
                                                    //}

                                                    //var clientVAR = context.Client.Where(i => i.ID == IdClientVar).FirstOrDefault();

                                                    //context.SaveChanges();

                                                    //MessageBox.Show("Пользователь изменен!", "Успех", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                                                    //IdClientVar = 0;
                                                    //this.Close();

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


                                                   
                                                    context.SaveChanges();
                                                    MessageBox.Show("Information was successfully changed", "Success", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                                                    VarIdPlayer = 0;
                                                    Close();
                                                }

                                            }
                                            else
                                            {
                                                Player addPlayer = new Player();
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


                                                context.LanguageToPlayer.Add(new LanguageToPlayer
                                                {
                                                    IdLanguage = 1,
                                                    IdPlayer = addPlayer.IdPlayer
                                                });


                                                context.Player.Add(addPlayer);
                                                context.SaveChanges();
                                                MessageBox.Show("Player was successfully changed", "Success", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                                                Close();
                                            }



                                            //addMaterial.Size = "1*1";
                                            //addMaterial.TypeId = cmbTypeMAterial.SelectedIndex + 1;
                                            //addMaterial.Price = Convert.ToDecimal(txtPrice.Text);
                                            //addMaterial.Count = Convert.ToInt32(txtCount.Text);
                                            //addMaterial.MinCount = Convert.ToInt32(txtMinCount.Text);
                                            //addMaterial.CountInBox = Convert.ToInt32(txtCountInBox.Text);
                                            //addMaterial.TypeDimension = cmbUnitMaterial.SelectedIndex + 1;

                                            /*Context.Material.Add(addMaterial);*/ // добавление материала

                                            //добавление поставщиков для материала


                                            //    Context.SaveChanges();
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
            e.Handled = "1234567890abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ_@.".IndexOf(e.Text) < 0;
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

        private void TxtFirstName_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
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
