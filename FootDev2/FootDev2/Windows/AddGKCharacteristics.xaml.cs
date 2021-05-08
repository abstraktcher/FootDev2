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
    /// Логика взаимодействия для AddGKCharacteristics.xaml
    /// </summary>
    public partial class AddGKCharacteristics : Window
    {
        public AddGKCharacteristics()
        {
            InitializeComponent();
            List<ViewAllInfo> players = context.ViewAllInfo.ToList();
            CmbPlayer.DisplayMemberPath = "FullName";
            players.Insert(0, new ViewAllInfo() { FullName = "Choose player" });
            CmbPlayer.ItemsSource = players;
            CmbPlayer.SelectedIndex = 0;
        }

        public  AddGKCharacteristics(ViewGkCharacteristics gkchara)
        {
            InitializeComponent();
            List<ViewAllInfo> players = context.ViewAllInfo.ToList();
            CmbPlayer.DisplayMemberPath = "FullName";
            players.Insert(0, new ViewAllInfo() { FullName = "Choose player" });
            CmbPlayer.ItemsSource = players;

            CmbPlayer.SelectedIndex = gkchara.IdPlayer;

            TxtAgility.Text = gkchara.AgilityGK.ToString();
            TxtAnticipation.Text = gkchara.AnticipationGK.ToString();
            TxtCommunication.Text = gkchara.CommunicationGK.ToString();
            TxtDecisions.Text = gkchara.DecisionsGK.ToString();
            TxtHeight.Text = gkchara.HeightGK.ToString();
            TxtJumping.Text = gkchara.JumpingGK.ToString();
            TxtKicking.Text = gkchara.KickingGK.ToString();
            TxtLeadership.Text = gkchara.LeadershipGK.ToString();
            TxtOneOnOnes.Text = gkchara.OneOnOnesGK.ToString(); ;
            TxtPenalty.Text = gkchara.PenaltyTakingGK.ToString();
            TxtPositioning.Text = gkchara.PositioningGK.ToString();
            TxtThrowing.Text = gkchara.ThrowingGK.ToString();
            TxtVision.Text = gkchara.VisionGK.ToString();
            TxtWeight.Text = gkchara.WeightGK.ToString();
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
            TxtAgility.Clear(); TxtAnticipation.Clear(); TxtCommunication.Clear(); TxtDecisions.Clear(); TxtJumping.Clear();
            TxtKicking.Clear(); TxtOneOnOnes.Clear(); TxtPenalty.Clear(); TxtPositioning.Clear();
            TxtThrowing.Clear(); TxtVision.Clear(); TxtWeight.Clear(); TxtHeight.Clear();
        }

        private void BtnConfirm_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (CmbPlayer.SelectedIndex == 0 || string.IsNullOrEmpty(TxtAgility.Text) || string.IsNullOrEmpty(TxtAnticipation.Text) || string.IsNullOrEmpty(TxtCommunication.Text) || string.IsNullOrEmpty(TxtDecisions.Text) || string.IsNullOrEmpty(TxtJumping.Text) ||
      string.IsNullOrEmpty(TxtKicking.Text) || string.IsNullOrEmpty(TxtOneOnOnes.Text) || string.IsNullOrEmpty(TxtPenalty.Text) || string.IsNullOrEmpty(TxtPositioning.Text) ||
     string.IsNullOrEmpty(TxtThrowing.Text) || string.IsNullOrEmpty(TxtVision.Text) || string.IsNullOrEmpty(TxtWeight.Text) || string.IsNullOrEmpty(TxtHeight.Text))
                {
                    MessageBox.Show("Enter value! String caanot be empty", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    if (VarIdChara == 0 || VarIdCharacteristics == 0)
                    {
                        GoalKeeperCharacteristics addGKChara = new GoalKeeperCharacteristics();
                        addGKChara.AgilityGK = (byte)Convert.ToInt32(TxtAgility.Text);
                        addGKChara.AnticipationGK = (byte)Convert.ToInt32(TxtAnticipation.Text);
                        addGKChara.CommunicationGK = (byte)Convert.ToInt32(TxtCommunication.Text);
                        addGKChara.DecisionsGK = (byte)Convert.ToInt32(TxtDecisions.Text);
                        addGKChara.HeightGK = (byte)Convert.ToInt32(TxtHeight.Text);
                        addGKChara.JumpingGK = (byte)Convert.ToInt32(TxtJumping.Text);
                        addGKChara.KickingGK = (byte)Convert.ToInt32(TxtKicking.Text);
                        addGKChara.LeadershipGK = (byte)Convert.ToInt32(TxtLeadership.Text);
                        addGKChara.OneOnOnesGK = (byte)Convert.ToInt32(TxtOneOnOnes.Text);
                        addGKChara.PenaltyTakingGK = (byte)Convert.ToInt32(TxtPenalty.Text);
                        addGKChara.PositioningGK = (byte)Convert.ToInt32(TxtPositioning.Text);
                        addGKChara.ThrowingGK = (byte)Convert.ToInt32(TxtThrowing.Text);
                        addGKChara.VisionGK = (byte)Convert.ToInt32(TxtVision.Text);
                        addGKChara.WeightGK = (byte)Convert.ToInt32(TxtWeight.Text);

                        context.GoalKeeperCharacteristics.Add(addGKChara);
                        context.SaveChanges();

                        PlayerToGKCharacteristics addGK = new PlayerToGKCharacteristics();
                        addGK.IdGKChar = addGKChara.IdGKChar;
                        addGK.IdPlayer = CmbPlayer.SelectedIndex;

                        context.PlayerToGKCharacteristics.Add(addGK);
                        context.SaveChanges();

                        MessageBox.Show("Information was successfully added", "Success", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        Close();
                    }
                    else
                    {
                        var resultClick = MessageBox.Show("Do you want to edit the information?", "Editing information", MessageBoxButton.YesNo, MessageBoxImage.Question);
                        if (resultClick == MessageBoxResult.Yes)
                        {
                            var editChara = context.GoalKeeperCharacteristics.Where(i => i.IdGKChar == VarIdChara).FirstOrDefault();

                            editChara.AgilityGK = (byte)Convert.ToInt32(TxtAgility.Text);
                            editChara.AnticipationGK = (byte)Convert.ToInt32(TxtAnticipation.Text);
                            editChara.CommunicationGK = (byte)Convert.ToInt32(TxtCommunication.Text);
                            editChara.DecisionsGK = (byte)Convert.ToInt32(TxtDecisions.Text);
                            editChara.HeightGK = (byte)Convert.ToInt32(TxtHeight.Text);
                            editChara.JumpingGK = (byte)Convert.ToInt32(TxtJumping.Text);
                            editChara.KickingGK = (byte)Convert.ToInt32(TxtKicking.Text);
                            editChara.LeadershipGK = (byte)Convert.ToInt32(TxtLeadership.Text);
                            editChara.OneOnOnesGK = (byte)Convert.ToInt32(TxtOneOnOnes.Text);
                            editChara.PenaltyTakingGK = (byte)Convert.ToInt32(TxtPenalty.Text);
                            editChara.PositioningGK = (byte)Convert.ToInt32(TxtPositioning.Text);
                            editChara.ThrowingGK = (byte)Convert.ToInt32(TxtThrowing.Text);
                            editChara.VisionGK = (byte)Convert.ToInt32(TxtVision.Text);
                            editChara.WeightGK = (byte)Convert.ToInt32(TxtWeight.Text);
                            context.SaveChanges();

                            var gkChara = context.PlayerToGKCharacteristics.Where(i => i.IdPlaToGK == VarIdCharacteristics).FirstOrDefault();

                            gkChara.IdGKChar = editChara.IdGKChar;
                            gkChara.IdPlayer = CmbPlayer.SelectedIndex;
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
