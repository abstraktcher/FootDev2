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

namespace FootDev2.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddTournament.xaml
    /// </summary>
    public partial class AddTournament : Window
    {
        public AddTournament()
        {
            InitializeComponent();

           
        }

        public AddTournament(Tournament tournament)
        {
            InitializeComponent();


            TxtTournamentName.Text = tournament.TournamentName.ToString();
            TxtSponsor.Text = tournament.Sponsor.ToString();
            TxtPrizePool.Text = tournament.PrizePool.ToString();
            TXTPArticipants.Text = tournament.NumberOfParticipants.ToString();
            TxtCity.Text = tournament.City.ToString();
            TxtCountry.Text = tournament.Country.ToString();


            DPEnd.SelectedDate = tournament.DateEnd;
            DPStart.SelectedDate = tournament.DateStart;

        }
        private void TxtTournamentName_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZäöÖÄ".IndexOf(e.Text) < 0;
        }

        private void TxtTournamentName_PreviewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (e.Command == ApplicationCommands.Copy ||
                e.Command == ApplicationCommands.Cut ||
                e.Command == ApplicationCommands.Paste)
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

            TxtTournamentName.Clear();
            TxtPrizePool.Clear();
            TxtSponsor.Clear();
            TxtCountry.Clear();
            TxtCity.Clear();
            TXTPArticipants.Clear();
            DPEnd.SelectedDate = null;
            DPStart.SelectedDate = null;
        }

        private void TxtPrizePool_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "1234567890.".IndexOf(e.Text) < 0;
        }

        private void TxtPrizePool_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (e.Command == ApplicationCommands.Copy ||
               e.Command == ApplicationCommands.Cut ||
               e.Command == ApplicationCommands.Paste)
            {
                e.Handled = true;
            }
        }


        private void CmbCity_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void CmbCity_PreviewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (e.Command == ApplicationCommands.Copy ||
               e.Command == ApplicationCommands.Cut ||
               e.Command == ApplicationCommands.Paste)
            {
                e.Handled = true;
            }
        }

        private void CmbCity_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZäöÖÄ".IndexOf(e.Text) < 0;
        }

        private void TBPArticipants_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void TBPArticipants_PreviewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (e.Command == ApplicationCommands.Copy ||
               e.Command == ApplicationCommands.Cut ||
               e.Command == ApplicationCommands.Paste)
            {
                e.Handled = true;
            }
        }

        private void TBPArticipants_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "1234567890.".IndexOf(e.Text) < 0;
        }

        private void TxtPrizePool_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void TxtPrizePool_PreviewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (e.Command == ApplicationCommands.Copy ||
               e.Command == ApplicationCommands.Cut ||
               e.Command == ApplicationCommands.Paste)
            {
                e.Handled = true;
            }
        }


        private void TxtSponsor_PreviewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (e.Command == ApplicationCommands.Copy ||
               e.Command == ApplicationCommands.Cut ||
               e.Command == ApplicationCommands.Paste)
            {
                e.Handled = true;
            }
        }

        private void TxtSponsor_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZäöÖÄ1234567890".IndexOf(e.Text) < 0;
        }



        private void BtnConfirm_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtCity.Text) || string.IsNullOrWhiteSpace(TxtPrizePool.Text) || string.IsNullOrWhiteSpace(TxtTournamentName.Text) || string.IsNullOrWhiteSpace(TXTPArticipants.Text))
            {
                MessageBox.Show("Write  information", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                if (string.IsNullOrWhiteSpace(TxtCountry.Text))
                {
                    MessageBox.Show("Choose country", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                else
                {
                    if (DPEnd.SelectedDate == null || DPEnd.SelectedDate == null)
                    {
                        MessageBox.Show("Choose dates", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    else
                    {

                        try
                        {

                            if (VarIdTournament != 0)

                            {

                            var resultClick = MessageBox.Show("Do you want to edit the information?", "Editing information", MessageBoxButton.YesNo, MessageBoxImage.Question);
                            if (resultClick == MessageBoxResult.Yes)
                            {
                                var tournament = context.Tournament.Where(i => i.IdTournament == VarIdTournament).FirstOrDefault();

                                tournament.TournamentName = TxtTournamentName.Text;
                                tournament.NumberOfParticipants = (byte?)Convert.ToInt32(TXTPArticipants.Text);
                                tournament.PrizePool = TxtPrizePool.Text;
                                tournament.DateEnd = DPEnd.SelectedDate;
                                tournament.DateStart = DPStart.SelectedDate;
                                tournament.Country = TxtCountry.Text;
                                tournament.Sponsor = TxtSponsor.Text;
                                tournament.City = TxtCity.Text;


                                context.SaveChanges();
                                MessageBox.Show("Information was successfully changed", "Success", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                                VarIdTournament = 0;
                                Close();
                            }
                            else
                            {
                                return;
                            }
                        }
                            else

                            {
                            Tournament addtour = new Tournament();
                            addtour.TournamentName = TxtTournamentName.Text;
                            addtour.Sponsor = TxtSponsor.Text;
                            addtour.Country = TxtCountry.Text;
                            addtour.City = TxtCity.Text;
                            addtour.DateEnd = DPEnd.SelectedDate;
                            addtour.DateStart = DPStart.SelectedDate;
                            addtour.NumberOfParticipants = (byte?)Convert.ToInt32(TXTPArticipants.Text);
                            addtour.PrizePool = TxtPrizePool.Text;

                            context.Tournament.Add(addtour);
                            context.SaveChanges();


                            MessageBox.Show("Tournament was successfully added", "Success", MessageBoxButton.OK, MessageBoxImage.Exclamation);
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

        }

    }
}
