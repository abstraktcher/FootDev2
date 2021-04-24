using FootDev2.AppData;
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

namespace FootDev2.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddEditRespPers.xaml
    /// </summary>
    public partial class AddEditRespPers : Window
    {
        public AddEditRespPers()
        {
            InitializeComponent();
            CmbGender.ItemsSource = context.Gender.ToList();
            CmbGender.DisplayMemberPath = "NameGender";

            CmbPlayer.ItemsSource = context.ViewAllInfo.ToList();
            CmbPlayer.DisplayMemberPath = "FullName";

        }

        public AddEditRespPers(ViewResponsiblePerson person)
        {
            InitializeComponent();
            TxtFirstName.Text = person.FirstName.ToString();
            TxtLastName.Text = person.LastName.ToString();
            TxtMiddleName.Text = person.MiddleName.ToString();
            TxtPhone.Text = person.Resp_Person_s_phone.ToString();
            CmbGender.SelectedItem = person.NameGender;

            CmbGender.ItemsSource = context.Gender.ToList();
            CmbGender.DisplayMemberPath = "NameGender";

            CmbPlayer.ItemsSource = context.ViewAllInfo.ToList();
            CmbPlayer.DisplayMemberPath = "FullName";

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

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {

            TxtFirstName.Clear();
            TxtLastName.Clear();
            TxtMiddleName.Clear();          
            CmbGender.SelectedItem = null;
            CmbPlayer.SelectedItem = null;
        }

        private void BtnConfirm_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtFirstName.Text) || string.IsNullOrWhiteSpace(TxtLastName.Text))
            {
                MessageBox.Show("Write  Name", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                if (string.IsNullOrWhiteSpace(TxtPhone.Text))
                {
                    MessageBox.Show("Write Phone", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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
                            if (CmbPlayer.SelectedItem == null)
                            {
                                MessageBox.Show("Choose player", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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
                                            try
                                            {

                                                if (VarIdPlayer != 0)

                                                {

                                                    Random random = new Random();
                                                    var resultClick = MessageBox.Show("Do you want to edit the information?", "Adding new player", MessageBoxButton.YesNo, MessageBoxImage.Question);
                                                    if (resultClick == MessageBoxResult.Yes)
                                                    {

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
                                                        var PersonVar = context.ResponsiblePerson.Where(i => i.IdRespPerson == VarIdPlayer).FirstOrDefault();

                                                        PersonVar.FirstName = TxtFirstName.Text;
                                                        PersonVar.LastName = TxtLastName.Text;
                                                        PersonVar.MiddleName = TxtMiddleName.Text;
                                                        PersonVar.PhoneNumber = TxtPhone.Text;
                                                        PersonVar.IdGender = (byte)(CmbGender.SelectedIndex + 1);

                                            //context.Player.Remove(context.Player.Where(i => i.IdPlayer == player.IdPlayer).FirstOrDefault());

                                            context.PlayerToRespReson.Remove(context.PlayerToRespReson.Where(i => i.IdRespPers == PersonVar.IdRespPerson).FirstOrDefault());

                                            context.PlayerToRespReson.Add(new PlayerToRespReson
                                            {
                                                IdPlayer = CmbPlayer.SelectedIndex + 1,
                                                IdRespPers = PersonVar.IdRespPerson
                                            });


                                            //var clientVAR = context.Client.Where(i => i.ID == IdClientVar).FirstOrDefault();
                                            //clientVAR.LastName = TBLName.Text;
                                            //clientVAR.FirstName = TBFName.Text;
                                            //clientVAR.Patronymic = TBMName.Text;
                                            //clientVAR.Email = TBEmail.Text;
                                            //clientVAR.Phone = TBPhone.Text;
                                            //clientVAR.Birthday = DatePickerBD.SelectedDate;
                                            //clientVAR.GenderCode = CBGender.Text;
                                            //context.SaveChanges();


                                            context.SaveChanges();
                                                        MessageBox.Show("Information was successfully changed", "Success", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                                                        VarIdPlayer = 0;
                                                        Close();
                                                    }
                                                    else
                                                    {
                                                        return;
                                                    }
                                                }
                                                else

                                                {
                                                    ResponsiblePerson addResp = new ResponsiblePerson();
                                                    addResp.FirstName = TxtFirstName.Text;
                                                    addResp.LastName = TxtLastName.Text;
                                                    addResp.MiddleName = TxtMiddleName.Text;
                                                    addResp.PhoneNumber = TxtPhone.Text;
                                                    addResp.IdGender = (byte)(CmbGender.SelectedIndex + 1);


                                        context.PlayerToRespReson.Add(new PlayerToRespReson
                                        {
                                            IdPlayer = CmbPlayer.SelectedIndex + 1,
                                            IdRespPers = addResp.IdRespPerson
                                        });
                                                   


                                                    //context.LanguageToPlayer.Add(new LanguageToPlayer
                                                    //{
                                                    //    IdLanguage = 1,
                                                    //    IdPlayer = addPlayer.IdPlayer
                                                    //});


                                                    context.ResponsiblePerson.Add(addResp);
                                                    context.SaveChanges();
                                                    MessageBox.Show("Person was successfully added", "Success", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                                                    Close();
                                                }

                                            }
                                            catch
                                            {
                                                MessageBox.Show("Error", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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
                            }
                        }
                
                }
            }
        }
    }
    }
