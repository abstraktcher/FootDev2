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
using FootDev2.AppData;
using FootDev2.Windows;
using static FootDev2.HelperClass.CheckRole;

namespace FootDev2.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddMfCharacteristics.xaml
    /// </summary>
    public partial class AddMfCharacteristics : Window
    {
        public AddMfCharacteristics()
        {
            InitializeComponent();
            List<ViewAllInfo> players = context.ViewAllInfo.ToList();
            CmbPlayer.DisplayMemberPath = "FullName";
            players.Insert(0, new ViewAllInfo() { FullName = "Choose player" });
            CmbPlayer.ItemsSource = players;
            CmbPlayer.SelectedIndex = 0;
        }


    public AddMfCharacteristics(ViewMFCharacteristics mfchara)
    {
        InitializeComponent();
        List<ViewAllInfo> players = context.ViewAllInfo.ToList();
        CmbPlayer.DisplayMemberPath = "FullName";
        players.Insert(0, new ViewAllInfo() { FullName = "Choose player" });
        CmbPlayer.ItemsSource = players;

        CmbPlayer.SelectedIndex = mfchara.IdPlayer;



        TxtAgility.Text = mfchara.AgilityMF.ToString();
        TxtConcentration.Text = mfchara.ConcentrationMF.ToString();
        TxtCorners.Text = mfchara.CornersMF.ToString();
        TxtDribbling.Text = mfchara.DribblingMF.ToString();
        TxtFitness.Text = mfchara.FitnessMF.ToString();
        TxtFreeKick.Text = mfchara.FreeKickMF.ToString();
        TxtHeight.Text = mfchara.HeightMF.ToString();
        TxtLeadership.Text = mfchara.LeadershipMF.ToString();
        TxtLongShots.Text = mfchara.LongShotsMF.ToString(); ;
        TxtMarking.Text = mfchara.MarkingMF.ToString();
        TxtPace.Text = mfchara.PaceMF.ToString();
        TxtPassing.Text = mfchara.PassingMF.ToString();
        TxtPenalty.Text = mfchara.PenaltyMF.ToString();
        TxtStamina.Text = mfchara.StaminaMF.ToString();
        TxtStrength.Text = mfchara.StrengthMF.ToString();
        TxtTeamWork.Text = mfchara.TeamWorkMF.ToString();
        TxtTechnique.Text = mfchara.TechniqueMF.ToString();
        TxtWeight.Text = mfchara.WeightMF.ToString();
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
        TxtAgility.Clear(); TxtConcentration.Clear(); TxtCorners.Clear(); TxtDribbling.Clear(); TxtFitness.Clear();
        TxtFreeKick.Clear(); TxtHeight.Clear(); TxtLeadership.Clear(); TxtLongShots.Clear(); TxtMarking.Clear();
        TxtPace.Clear(); TxtPassing.Clear(); TxtPenalty.Clear(); TxtStamina.Clear(); TxtStrength.Clear();
        TxtTeamWork.Clear(); TxtTechnique.Clear(); TxtWeight.Clear();
        }

    private void BtnConfirm_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            if (CmbPlayer.SelectedIndex == 0 || string.IsNullOrEmpty(TxtAgility.Text) || string.IsNullOrEmpty(TxtConcentration.Text) || string.IsNullOrEmpty(TxtCorners.Text) || string.IsNullOrEmpty(TxtDribbling.Text) || string.IsNullOrEmpty(TxtFitness.Text) ||
  string.IsNullOrEmpty(TxtFreeKick.Text) || string.IsNullOrEmpty(TxtHeight.Text) || string.IsNullOrEmpty(TxtLeadership.Text) || string.IsNullOrEmpty(TxtLongShots.Text) || string.IsNullOrEmpty(TxtMarking.Text) ||
                string.IsNullOrEmpty(TxtPace.Text) || string.IsNullOrEmpty(TxtPassing.Text) || string.IsNullOrEmpty(TxtPenalty.Text) || string.IsNullOrEmpty(TxtStamina.Text) || string.IsNullOrEmpty(TxtStrength.Text) || string.IsNullOrEmpty(TxtTeamWork.Text) || string.IsNullOrEmpty(TxtWeight.Text) || string.IsNullOrEmpty(TxtTechnique.Text))
                {
                MessageBox.Show("Enter value! String caanot be empty", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (VarIdChara == 0 || VarIdCharacteristics == 0)
                {
                    MidFielderCharacteristics addMF = new MidFielderCharacteristics();
                        addMF.AgilityMF = (byte)Convert.ToInt32(TxtAgility.Text);
                        addMF.ConcentrationMF = (byte)Convert.ToInt32(TxtConcentration.Text);
                        addMF.CornersMF = (byte)Convert.ToInt32(TxtCorners.Text);
                        addMF.DribblingMF = (byte)Convert.ToInt32(TxtDribbling.Text);
                        addMF.FitnessMF = (byte)Convert.ToInt32(TxtFitness.Text);
                        addMF.FreeKickMF = (byte)Convert.ToInt32(TxtFreeKick.Text);
                        addMF.HeightMF = (byte)Convert.ToInt32(TxtHeight.Text);
                        addMF.LeadershipMF = (byte)Convert.ToInt32(TxtLeadership.Text);
                        addMF.LongShotsMF = (byte)Convert.ToInt32(TxtLongShots.Text);
                        addMF.MarkingMF = (byte)Convert.ToInt32(TxtMarking.Text);
                        addMF.PaceMF = (byte)Convert.ToInt32(TxtPace.Text);
                        addMF.PassingMF = (byte)Convert.ToInt32(TxtPassing.Text);
                        addMF.PenaltyMF = (byte)Convert.ToInt32(TxtPenalty.Text);
                        addMF.StaminaMF = (byte)Convert.ToInt32(TxtStamina.Text);
                        addMF.StrengthMF = (byte)Convert.ToInt32(TxtStrength.Text);
                        addMF.TechniqueMF = (byte)Convert.ToInt32(TxtTechnique.Text);
                        addMF.WeightMF = (byte)Convert.ToInt32(TxtWeight.Text);

                    context.MidFielderCharacteristics.Add(addMF);
                    context.SaveChanges();

                    PlayerToMFCharacteristics addMfPla = new PlayerToMFCharacteristics();
                    addMfPla.IdCharacteristics = addMF.IdMDFChar;
                    addMfPla.IdPlayer = CmbPlayer.SelectedIndex;

                    context.PlayerToMFCharacteristics.Add(addMfPla);
                    context.SaveChanges();

                    MessageBox.Show("Information was successfully added", "Success", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    Close();
                }
                else
                {
                    var resultClick = MessageBox.Show("Do you want to edit the information?", "Editing information", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (resultClick == MessageBoxResult.Yes)
                    {
                        var editChara = context.MidFielderCharacteristics.Where(i => i.IdMDFChar == VarIdChara).FirstOrDefault();

                            editChara.AgilityMF = (byte)Convert.ToInt32(TxtAgility.Text);
                            editChara.ConcentrationMF = (byte)Convert.ToInt32(TxtConcentration.Text);
                            editChara.CornersMF = (byte)Convert.ToInt32(TxtCorners.Text);
                            editChara.DribblingMF = (byte)Convert.ToInt32(TxtDribbling.Text);
                            editChara.FitnessMF = (byte)Convert.ToInt32(TxtFitness.Text);
                            editChara.FreeKickMF = (byte)Convert.ToInt32(TxtFreeKick.Text);
                            editChara.HeightMF = (byte)Convert.ToInt32(TxtHeight.Text);
                            editChara.LeadershipMF = (byte)Convert.ToInt32(TxtLeadership.Text);
                            editChara.LongShotsMF = (byte)Convert.ToInt32(TxtLongShots.Text);
                            editChara.MarkingMF = (byte)Convert.ToInt32(TxtMarking.Text);
                            editChara.PaceMF = (byte)Convert.ToInt32(TxtPace.Text);
                            editChara.PassingMF = (byte)Convert.ToInt32(TxtPassing.Text);
                            editChara.PenaltyMF = (byte)Convert.ToInt32(TxtPenalty.Text);
                            editChara.StaminaMF = (byte)Convert.ToInt32(TxtStamina.Text);
                            editChara.StrengthMF = (byte)Convert.ToInt32(TxtStrength.Text);
                            editChara.TechniqueMF = (byte)Convert.ToInt32(TxtTechnique.Text);
                            editChara.WeightMF = (byte)Convert.ToInt32(TxtWeight.Text);
                            context.SaveChanges();
                        var mfChara = context.PlayerToMFCharacteristics.Where(i => i.IdPlToChar == VarIdCharacteristics).FirstOrDefault();

                        mfChara.IdCharacteristics = editChara.IdMDFChar;
                        mfChara.IdPlayer = CmbPlayer.SelectedIndex;
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
