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
    /// Логика взаимодействия для AddDFCharacteristics.xaml
    /// </summary>
    public partial class AddDFCharacteristics : Window
    {
        public AddDFCharacteristics()
        {
            InitializeComponent();
            List<ViewAllInfo> players = context.ViewAllInfo.ToList();
            CmbPlayer.DisplayMemberPath = "FullName";
            players.Insert(0, new ViewAllInfo() { FullName = "Choose player" });
            CmbPlayer.ItemsSource = players;
            CmbPlayer.SelectedIndex = 0;
        }

        public AddDFCharacteristics(ViewDFCharacteristics dfchara)
        {
            InitializeComponent();
            List<ViewAllInfo> players = context.ViewAllInfo.ToList();
            CmbPlayer.DisplayMemberPath = "FullName";
            players.Insert(0, new ViewAllInfo() { FullName = "Choose player" });
            CmbPlayer.ItemsSource = players;

            CmbPlayer.SelectedIndex = dfchara.IdPlayer;



            TxtBravery.Text = dfchara.BraveryDF.ToString();
            TxtConcentration.Text = dfchara.ConcentrationDF.ToString();
            TxtCrossing.Text = dfchara.CrossingDF.ToString();
            TxtDribbling.Text = dfchara.DribblingDF.ToString();
            TxtHeading.Text = dfchara.HeadingDF.ToString();
            TxtHeight.Text = dfchara.HeightDF.ToString();
            TxtJumping.Text = dfchara.JumpingDF.ToString();
            TxtLeadership.Text = dfchara.LeadershipDF.ToString();
            TxtLongShots.Text = dfchara.LongShotsDF.ToString(); ;
            TxtMarking.Text = dfchara.MarkingDF.ToString();
            TxtPassing.Text = dfchara.PassingDF.ToString();
            TxtPositioning.Text = dfchara.PositioningDF.ToString();
            TxtStamina.Text = dfchara.StaminaDF.ToString();
            TxtStrength.Text = dfchara.StrengthDF.ToString();
            TxtTackling.Text = dfchara.TacklingDF.ToString();
            TxtWeight.Text = dfchara.WeightDF.ToString();
            TxtWorkRate.Text = dfchara.WorkRateDF.ToString();
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
            TxtBravery.Clear(); TxtConcentration.Clear(); TxtCrossing.Clear(); TxtDribbling.Clear(); TxtHeading.Clear();
            TxtHeight.Clear(); TxtJumping.Clear(); TxtLeadership.Clear(); TxtLongShots.Clear(); TxtStamina.Clear();
            TxtMarking.Clear(); TxtPassing.Clear(); TxtWeight.Clear();  TxtPositioning.Clear(); TxtStrength.Clear();
            TxtTackling.Clear(); TxtWorkRate.Clear();
        }

        private void BtnConfirm_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (CmbPlayer.SelectedIndex == 0 || string.IsNullOrEmpty(TxtBravery.Text) || string.IsNullOrEmpty(TxtConcentration.Text) || string.IsNullOrEmpty(TxtCrossing.Text) || string.IsNullOrEmpty(TxtDribbling.Text) || string.IsNullOrEmpty(TxtHeading.Text) ||
      string.IsNullOrEmpty(TxtHeight.Text) || string.IsNullOrEmpty(TxtJumping.Text) || string.IsNullOrEmpty(TxtLeadership.Text) || string.IsNullOrEmpty(TxtLongShots.Text) || string.IsNullOrEmpty(TxtTackling.Text) ||
                    string.IsNullOrEmpty(TxtMarking.Text) || string.IsNullOrEmpty(TxtPassing.Text) || string.IsNullOrEmpty(TxtPositioning.Text) || string.IsNullOrEmpty(TxtStamina.Text) || string.IsNullOrEmpty(TxtStrength.Text) || string.IsNullOrEmpty(TxtWorkRate.Text) || string.IsNullOrEmpty(TxtWeight.Text))
                {
                    MessageBox.Show("Enter value! String caanot be empty", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    if (VarIdChara == 0 || VarIdCharacteristics == 0)
                    {
                        DefenderCharacteristics addDF = new DefenderCharacteristics();
                        addDF.BraveryDF = (byte)Convert.ToInt32(TxtBravery.Text);
                        addDF.ConcentrationDF = (byte)Convert.ToInt32(TxtConcentration.Text);
                        addDF.CrossingDF = (byte)Convert.ToInt32(TxtCrossing.Text);
                        addDF.DribblingDF = (byte)Convert.ToInt32(TxtDribbling.Text);
                        addDF.HeadingDF = (byte)Convert.ToInt32(TxtHeading.Text);
                        addDF.HeightDF = (byte)Convert.ToInt32(TxtHeight.Text);
                        addDF.JumpingDF = (byte)Convert.ToInt32(TxtJumping.Text);
                        addDF.LeadershipDF = (byte)Convert.ToInt32(TxtLeadership.Text);
                        addDF.LongShotsDF = (byte)Convert.ToInt32(TxtLongShots.Text);
                        addDF.TacklingDF = (byte)Convert.ToInt32(TxtTackling.Text);
                        addDF.MarkingDF = (byte)Convert.ToInt32(TxtMarking.Text);
                        addDF.PassingDF = (byte)Convert.ToInt32(TxtPassing.Text);
                        addDF.PositioningDF = (byte)Convert.ToInt32(TxtPositioning.Text);
                        addDF.StaminaDF = (byte)Convert.ToInt32(TxtStamina.Text);
                        addDF.StrengthDF = (byte)Convert.ToInt32(TxtStrength.Text);
                        addDF.WorkRateDF = (byte)Convert.ToInt32(TxtWorkRate.Text);
                        addDF.WeightDF = (byte)Convert.ToInt32(TxtWeight.Text);

                        context.DefenderCharacteristics.Add(addDF);
                        context.SaveChanges();

                        PlayerToDFCharacteristics addDF2 = new PlayerToDFCharacteristics();
                        addDF2.IdDFChar = addDF.IdDFChar;
                        addDF2.IdPlayer = CmbPlayer.SelectedIndex;

                        context.PlayerToDFCharacteristics.Add(addDF2);
                        context.SaveChanges();

                        MessageBox.Show("Information was successfully added", "Success", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        Close();
                    }
                    else
                    {
                        var resultClick = MessageBox.Show("Do you want to edit the information?", "Editing information", MessageBoxButton.YesNo, MessageBoxImage.Question);
                        if (resultClick == MessageBoxResult.Yes)
                        {
                            var editChara = context.DefenderCharacteristics.Where(i => i.IdDFChar == VarIdChara).FirstOrDefault();

                            editChara.BraveryDF = (byte)Convert.ToInt32(TxtBravery.Text);
                            editChara.ConcentrationDF = (byte)Convert.ToInt32(TxtConcentration.Text);
                            editChara.CrossingDF = (byte)Convert.ToInt32(TxtCrossing.Text);
                            editChara.DribblingDF = (byte)Convert.ToInt32(TxtDribbling.Text);
                            editChara.HeadingDF = (byte)Convert.ToInt32(TxtHeading.Text);
                            editChara.HeightDF = (byte)Convert.ToInt32(TxtHeight.Text);
                            editChara.JumpingDF = (byte)Convert.ToInt32(TxtJumping.Text);
                            editChara.LeadershipDF = (byte)Convert.ToInt32(TxtLeadership.Text);
                            editChara.LongShotsDF = (byte)Convert.ToInt32(TxtLongShots.Text);
                            editChara.TacklingDF = (byte)Convert.ToInt32(TxtTackling.Text);
                            editChara.MarkingDF = (byte)Convert.ToInt32(TxtMarking.Text);
                            editChara.PassingDF = (byte)Convert.ToInt32(TxtPassing.Text);
                            editChara.PositioningDF = (byte)Convert.ToInt32(TxtPositioning.Text);
                            editChara.StaminaDF = (byte)Convert.ToInt32(TxtStamina.Text);
                            editChara.StrengthDF = (byte)Convert.ToInt32(TxtStrength.Text);
                            editChara.WorkRateDF = (byte)Convert.ToInt32(TxtWorkRate.Text);
                            editChara.WeightDF = (byte)Convert.ToInt32(TxtWeight.Text);
                            context.SaveChanges();
                            var dfChara = context.PlayerToDFCharacteristics.Where(i => i.IdPlaToDF == VarIdCharacteristics).FirstOrDefault();

                            dfChara.IdDFChar = editChara.IdDFChar;
                            dfChara.IdPlayer = CmbPlayer.SelectedIndex;
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
