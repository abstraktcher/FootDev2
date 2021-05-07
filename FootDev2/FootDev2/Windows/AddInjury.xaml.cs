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
using static FootDev2.HelperClass.CheckRole;

namespace FootDev2.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddInjury.xaml
    /// </summary>
    public partial class AddInjury : Window
    {
        public AddInjury()
        {
            InitializeComponent();

            List<Injury> injuries = context.Injury.ToList();
            CmbInjury.DisplayMemberPath = "InjuryName";
            injuries.Insert(0, new Injury() { InjuryName = "Choose Injury" });
            CmbInjury.ItemsSource = injuries;
            CmbInjury.SelectedIndex = 0;

            List<ViewAllInfo> player = context.ViewAllInfo.ToList();
            CmbPlayer.DisplayMemberPath = "FullName";
            player.Insert(0, new ViewAllInfo() { FullName = "Choose player" });
            CmbPlayer.ItemsSource = player;
            CmbPlayer.SelectedIndex = 0;
        }


        public AddInjury(Injuries injury)
        {
            InitializeComponent();
            CmbInjury.ItemsSource = context.Injury.ToList();
            CmbInjury.DisplayMemberPath = "InjuryName";

            CmbPlayer.ItemsSource = context.ViewAllInfo.ToList();
            CmbPlayer.DisplayMemberPath = "FullName";

            TxtTreatment.Text = injury.Treatment.ToString();
            TxtDescription.Text = injury.Description.ToString();
            CmbInjury.SelectedIndex = injury.IdInjury - 1;
            CmbPlayer.SelectedIndex = injury.IdPlayer - 1;
            DpInjury.SelectedDate = injury.DateOfInjury;


        }
        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {

            TxtDescription.Clear();
            TxtTreatment.Clear();
            CmbPlayer.SelectedIndex = 0;
            CmbInjury.SelectedIndex = 0;
            DpInjury.SelectedDate = null;
            DpRecovery.SelectedDate = null;
        }

       
        private void BtnConfirm_Click(object sender, RoutedEventArgs e)
        {
            if ( CmbInjury.SelectedIndex == 0 || CmbPlayer.SelectedIndex == 0)
            {
                MessageBox.Show("Write  information", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                    if (DpInjury.SelectedDate == null)
                    {
                        MessageBox.Show("Choose date", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    else
                    {

                    try
                    {

                        if (VarIdInjury != 0)

                        {

                            var resultClick = MessageBox.Show("Do you want to edit the information?", "Editing information", MessageBoxButton.YesNo, MessageBoxImage.Question);
                            if (resultClick == MessageBoxResult.Yes)
                            {
                                var injury = context.InjuryToPlayer.Where(i => i.IdInjToPla == VarIdInjury).FirstOrDefault();

                                injury.IdInjury = CmbInjury.SelectedIndex + 1;
                                injury.IdPlayer = CmbPlayer.SelectedIndex + 1;
                                injury.Treatment = TxtTreatment.Text;
                                injury.Description = TxtDescription.Text;
                                injury.DateOfInjury = DpInjury.SelectedDate;
                                injury.DateOfRecovery = DpRecovery.SelectedDate;

                                
                                context.SaveChanges();
                                MessageBox.Show("Information was successfully changed", "Success", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                                VarIdInjury = 0;
                                Close();
                            }
                            else
                            {
                                return;
                            }
                        }
                        else

                        {
                            InjuryToPlayer addinjury = new InjuryToPlayer();
                            addinjury.IdInjury = CmbInjury.SelectedIndex;
                            addinjury.IdPlayer = CmbPlayer.SelectedIndex;
                            addinjury.Treatment = TxtTreatment.Text;
                            addinjury.Description = TxtDescription.Text;
                            addinjury.DateOfInjury = DpInjury.SelectedDate;
                            addinjury.DateOfRecovery = DpRecovery.SelectedDate;

                            context.InjuryToPlayer.Add(addinjury);
                            context.SaveChanges();


                            MessageBox.Show("Information about injury was successfully added", "Success", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                            Close();
                        }


                    }
                    catch
                    {
                        MessageBox.Show("Error", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    }
                }
            }

        }

       

        private void TxtDescription_PreviewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            {
                if (e.Command == ApplicationCommands.Copy ||
                    e.Command == ApplicationCommands.Cut ||
                    e.Command == ApplicationCommands.Paste)
                {
                    e.Handled = true;
                }
            }
        }

        private void TxtDescription_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZäöÖÄ ".IndexOf(e.Text) < 0;
        }

                private void TxtTreatment_PreviewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            {
                if (e.Command == ApplicationCommands.Copy ||
                    e.Command == ApplicationCommands.Cut ||
                    e.Command == ApplicationCommands.Paste)
                {
                    e.Handled = true;
                }
            }
        }

        private void TxtTreatment_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZäöÖÄ ".IndexOf(e.Text) < 0;
        }
    }
}
