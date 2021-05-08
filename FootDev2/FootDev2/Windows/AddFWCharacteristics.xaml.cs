using FootDev2.AppData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using static FootDev2.AppData.AppDataClass;
using static FootDev2.HelperClass.CheckRole;

namespace FootDev2.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddFWCharacteristics.xaml
    /// </summary>
    public partial class AddFWCharacteristics : Window
    {
        public AddFWCharacteristics()
        {
            InitializeComponent();
            InitializeComponent();
            List<ViewAllInfo> players = context.ViewAllInfo.ToList();
            CmbPlayer.DisplayMemberPath = "FullName";
            players.Insert(0, new ViewAllInfo() { FullName = "Choose player" });
            CmbPlayer.ItemsSource = players;
            CmbPlayer.SelectedIndex = 0;
        }

        public AddFWCharacteristics(ViewStrikerCharacteristics fwchara)
        {
            InitializeComponent();
            List<ViewAllInfo> players = context.ViewAllInfo.ToList();
            CmbPlayer.DisplayMemberPath = "FullName";
            players.Insert(0, new ViewAllInfo() { FullName = "Choose player" });
            CmbPlayer.ItemsSource = players;

            CmbPlayer.SelectedIndex = fwchara.IdPlayer;


            TxtAcceleration.Text = fwchara.AccelerationFW.ToString();
            TxtAgility.Text = fwchara.AgilityFW.ToString();
            TxtDribbling.Text = fwchara.DribblingFW.ToString();
            TxtFinishing.Text = fwchara.FinishingFW.ToString();
            TxtFitness.Text = fwchara.FitnessFW.ToString();
            TxtHeading.Text = fwchara.HeadingFW.ToString();
            TxtHeight.Text = fwchara.HeightFW.ToString();
            TxtJumping.Text = fwchara.JumpingFW.ToString();
            TxtLeadership.Text = fwchara.LeadershipFW.ToString(); ;
            TxtLongShots.Text = fwchara.LongShotsFW.ToString();
            TxtPace.Text = fwchara.PaceFW.ToString();
            TxtPassing.Text = fwchara.PassingFW.ToString();
            TxtPenalty.Text = fwchara.PenaltyFW.ToString();
            TxtStamina.Text = fwchara.StaminaFW.ToString();
            TxtStrength.Text = fwchara.StrengthFW.ToString();
            TxtTeamWork.Text = fwchara.TeamWorkFW.ToString();
            TxtWeight.Text = fwchara.WeightFW.ToString();
            TxtTechnique.Text = fwchara.TechniqueFW.ToString();
        }

        private void TxtCharacteristic_PreviewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (e.Command == ApplicationCommands.Copy ||
               e.Command == ApplicationCommands.Cut ||
               e.Command == ApplicationCommands.Paste)
            {
                e.Handled = true;
            }
        }

        private void TxtCharacteristic_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "1234567890".IndexOf(e.Text) < 0;
        }

        private void TxtCharacteristics_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            CmbPlayer.SelectedIndex = 0;
            TxtAcceleration.Clear(); TxtAgility.Clear(); TxtDribbling.Clear(); TxtFinishing.Clear(); TxtFitness.Clear();
            TxtHeading.Clear(); TxtHeight.Clear(); TxtJumping.Clear(); TxtLeadership.Clear(); TxtLongShots.Clear();
            TxtPace.Clear(); TxtPassing.Clear(); TxtPenalty.Clear(); TxtStamina.Clear(); TxtStrength.Clear();
            TxtTeamWork.Clear(); TxtTechnique.Clear(); TxtWeight.Clear();
        }

        private void BtnConfirm_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (CmbPlayer.SelectedIndex == 0 || string.IsNullOrEmpty(TxtAcceleration.Text) || string.IsNullOrEmpty(TxtAgility.Text) || string.IsNullOrEmpty(TxtDribbling.Text) || string.IsNullOrEmpty(TxtFinishing.Text) || string.IsNullOrEmpty(TxtFitness.Text) ||
      string.IsNullOrEmpty(TxtHeading.Text) || string.IsNullOrEmpty(TxtHeight.Text) || string.IsNullOrEmpty(TxtJumping.Text) || string.IsNullOrEmpty(TxtLeadership.Text) || string.IsNullOrEmpty(TxtLongShots.Text) ||
                    string.IsNullOrEmpty(TxtPace.Text) || string.IsNullOrEmpty(TxtPassing.Text) || string.IsNullOrEmpty(TxtPenalty.Text) || string.IsNullOrEmpty(TxtStamina.Text) || string.IsNullOrEmpty(TxtStrength.Text) || string.IsNullOrEmpty(TxtTeamWork.Text) || string.IsNullOrEmpty(TxtTechnique.Text) || string.IsNullOrEmpty(TxtWeight.Text))
                {
                    MessageBox.Show("Enter value! String caanot be empty", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    if (VarIdChara == 0 || VarIdCharacteristics == 0)
                    {
                        ForwardCharacteristics addFW = new ForwardCharacteristics();
                        addFW.AccelerationFW= (byte)Convert.ToInt32(TxtAcceleration.Text);
                        addFW.AgilityFW = (byte)Convert.ToInt32(TxtAgility.Text);
                        addFW.DribblingFW = (byte)Convert.ToInt32(TxtDribbling.Text);
                        addFW.FinishingFW = (byte)Convert.ToInt32(TxtFinishing.Text);
                        addFW.FitnessFW = (byte)Convert.ToInt32(TxtFitness.Text);
                        addFW.HeadingFW = (byte)Convert.ToInt32(TxtHeading.Text);
                        addFW.HeightFW = (byte)Convert.ToInt32(TxtHeight.Text);
                        addFW.JumpingFW = (byte)Convert.ToInt32(TxtJumping.Text);
                        addFW.LeadershipFW = (byte)Convert.ToInt32(TxtLeadership.Text);
                        addFW.LongShotsFW = (byte)Convert.ToInt32(TxtLongShots.Text);
                        addFW.PaceFW = (byte)Convert.ToInt32(TxtPace.Text);
                        addFW.PassingFW = (byte)Convert.ToInt32(TxtPassing.Text);
                        addFW.PenaltyFW = (byte)Convert.ToInt32(TxtPenalty.Text);
                        addFW.StaminaFW = (byte)Convert.ToInt32(TxtStamina.Text);
                        addFW.StrengthFW = (byte)Convert.ToInt32(TxtStrength.Text);
                        addFW.TeamWorkFW = (byte)Convert.ToInt32(TxtTeamWork.Text);
                        addFW.WeightFW = (byte)Convert.ToInt32(TxtWeight.Text);

                        context.ForwardCharacteristics.Add(addFW);
                        context.SaveChanges();

                        PlayerToFWCharacteristics addFW2 = new PlayerToFWCharacteristics();
                        addFW2.IdFWChar = addFW.IdFWChar;
                        addFW2.IdPlayer = CmbPlayer.SelectedIndex;

                        context.PlayerToFWCharacteristics.Add(addFW2);
                        context.SaveChanges();

                        MessageBox.Show("Information was successfully added", "Success", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        Close();
                    }
                    else
                    {
                        var resultClick = MessageBox.Show("Do you want to edit the information?", "Editing information", MessageBoxButton.YesNo, MessageBoxImage.Question);
                        if (resultClick == MessageBoxResult.Yes)
                        {
                            var editChara = context.ForwardCharacteristics.Where(i => i.IdFWChar == VarIdChara).FirstOrDefault();

                            editChara.AccelerationFW = (byte)Convert.ToInt32(TxtAcceleration.Text);
                            editChara.AgilityFW = (byte)Convert.ToInt32(TxtAgility.Text);
                            editChara.DribblingFW = (byte)Convert.ToInt32(TxtDribbling.Text);
                            editChara.FinishingFW = (byte)Convert.ToInt32(TxtFinishing.Text);
                            editChara.FitnessFW = (byte)Convert.ToInt32(TxtFitness.Text);
                            editChara.HeadingFW = (byte)Convert.ToInt32(TxtHeading.Text);
                            editChara.HeightFW = (byte)Convert.ToInt32(TxtHeight.Text);
                            editChara.JumpingFW = (byte)Convert.ToInt32(TxtJumping.Text);
                            editChara.LeadershipFW = (byte)Convert.ToInt32(TxtLeadership.Text);
                            editChara.LongShotsFW = (byte)Convert.ToInt32(TxtLongShots.Text);
                            editChara.PaceFW = (byte)Convert.ToInt32(TxtPace.Text);
                            editChara.PassingFW = (byte)Convert.ToInt32(TxtPassing.Text);
                            editChara.PenaltyFW = (byte)Convert.ToInt32(TxtPenalty.Text);
                            editChara.StaminaFW = (byte)Convert.ToInt32(TxtStamina.Text);
                            editChara.StrengthFW = (byte)Convert.ToInt32(TxtStrength.Text);
                            editChara.TeamWorkFW = (byte)Convert.ToInt32(TxtTeamWork.Text);
                            editChara.WeightFW = (byte)Convert.ToInt32(TxtWeight.Text);
                            context.SaveChanges();
                            var fwChara = context.PlayerToFWCharacteristics.Where(i => i.IdPlaToFW == VarIdCharacteristics).FirstOrDefault();

                            fwChara.IdFWChar = editChara.IdFWChar;
                            fwChara.IdPlayer = CmbPlayer.SelectedIndex;
                            context.SaveChanges();

                            MessageBox.Show("Information was successfully changed", "Success", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                            VarIdChara = 0;
                            VarIdCharacteristics = 0;
                            Close();
                        }
                    }
                }
        }
            catch
            {
                MessageBox.Show("Values should be in range from 1 to 40. Or try it later", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

}


    }
}
