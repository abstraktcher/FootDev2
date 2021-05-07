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
    /// Логика взаимодействия для AddPredisp.xaml
    /// </summary>
    public partial class AddPredisp : Window
    {
        public AddPredisp()
        {
            InitializeComponent(); 
            List<Predisposition> predispositions = context.Predisposition.ToList();
            CmbPredisposition.DisplayMemberPath = "PredispositionName";
            predispositions.Insert(0, new Predisposition() { PredispositionName = "Choose predisposition" });
            CmbPredisposition.ItemsSource = predispositions;
            CmbPredisposition.SelectedIndex = 0;

            List<ViewAllInfo> player = context.ViewAllInfo.ToList();
            CmbPlayer.DisplayMemberPath = "FullName";
            player.Insert(0, new ViewAllInfo() { FullName = "Choose player" });
            CmbPlayer.ItemsSource = player;
            CmbPlayer.SelectedIndex = 0;
        }


            public AddPredisp(ViewPredispositions predisp)
            {
                InitializeComponent();
                List<Predisposition> predispositions = context.Predisposition.ToList();
                CmbPredisposition.DisplayMemberPath = "PredispositionName";
                predispositions.Insert(0, new Predisposition() { PredispositionName = "Choose predisposition" });
                CmbPredisposition.ItemsSource = predispositions;
                CmbPredisposition.SelectedIndex = 0;

                CmbPlayer.ItemsSource = context.ViewAllInfo.ToList();
                CmbPlayer.DisplayMemberPath = "FullName";
                CmbPlayer.SelectedIndex = predisp.IdPlayer;

                TxtTreatment.Text = predisp.Treatment.ToString();
                TxtDescription.Text = predisp.Description.ToString();


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
            CmbPredisposition.SelectedIndex = 0;
        }


        private void BtnConfirm_Click(object sender, RoutedEventArgs e)
        {
            if (CmbPredisposition.SelectedIndex == 0 || CmbPlayer.SelectedIndex == 0)
            {
                MessageBox.Show("Write  information", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
               
                    //try
                    //{

                        if (VarIdPredisp != 0 || VarIdPredisposition != 0)

                        {

                            var resultClick = MessageBox.Show("Do you want to edit the information?", "Editing information", MessageBoxButton.YesNo, MessageBoxImage.Question);
                            if (resultClick == MessageBoxResult.Yes)
                            {
                            var predisposition = context.Predisposition.Where(i => i.IdPredisposition == VarIdPredisposition).FirstOrDefault();
                            predisposition.Description = TxtDescription.Text;
                            predisposition.Treatment = TxtTreatment.Text;
                            context.SaveChanges();

                        var predisp = context.PredispositionToPlayer.Where(i => i.IdPredToPla == VarIdPredisp).FirstOrDefault();

                                predisp.IdPredisposition = CmbPredisposition.SelectedIndex;
                                predisp.IdPlayer = CmbPlayer.SelectedIndex;
                                context.SaveChanges();
                                MessageBox.Show("Information was successfully changed", "Success", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                                VarIdPredisp = 0;
                                VarIdPredisposition = 0;
                                Close();
                            }
                            else
                            {
                                return;
                            }
                        }
                        else

                        {
                         
                            PredispositionToPlayer addPredToPla = new PredispositionToPlayer();
                            addPredToPla.IdPredisposition = CmbPredisposition.SelectedIndex;
                            addPredToPla.IdPlayer = CmbPlayer.SelectedIndex;
                            
                            context.PredispositionToPlayer.Add(addPredToPla);
                            context.SaveChanges();


                            MessageBox.Show("Information about predisposition was successfully added", "Success", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                            Close();
                        }


                    //}
                    //catch
                    //{
                    //    MessageBox.Show("Error", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    //}
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

        private void BtnAddPredisp_Click(object sender, RoutedEventArgs e)
        {
            AddNewPredisp addnewpred = new AddNewPredisp();
            this.Opacity = 0.3;
            addnewpred.ShowDialog();
            List<Predisposition> predispositions = context.Predisposition.ToList();
            CmbPredisposition.DisplayMemberPath = "PredispositionName";
            predispositions.Insert(0, new Predisposition() { PredispositionName = "Choose predisposition" });
            CmbPredisposition.ItemsSource = predispositions;
            CmbPredisposition.SelectedIndex = 0;
            this.Opacity = 1;

        }
    }
}
