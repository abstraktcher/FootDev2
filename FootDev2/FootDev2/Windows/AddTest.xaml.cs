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
    /// Логика взаимодействия для AddTest.xaml
    /// </summary>
    public partial class AddTest : Window
    {
        public AddTest()
        {
            InitializeComponent(); InitializeComponent();
            CmbPlayer.ItemsSource = context.ViewAllInfo.ToList();
            CmbPlayer.DisplayMemberPath = "FullName";
            CmbPlayer.SelectedIndex = 0;

            CmbExercise.ItemsSource = context.Exercise.ToList();
            CmbExercise.DisplayMemberPath = "ExerciseName";
            CmbExercise.SelectedIndex = 0;
        }

        public AddTest(ViewExcForTest test)
        {
            InitializeComponent();
            CmbPlayer.ItemsSource = context.ViewAllInfo.ToList();
            CmbPlayer.DisplayMemberPath = "FullName";
            CmbPlayer.SelectedIndex = 0;

            CmbExercise.ItemsSource = context.Exercise.ToList();
            CmbExercise.DisplayMemberPath = "ExerciseName";
            CmbExercise.SelectedIndex = 0;

            CmbExercise.SelectedIndex = test.IdExercise - 1;
            CmbPlayer.SelectedIndex = test.IdPlayer - 1;
            DPDate.SelectedDate = test.DateTesting;
            TxtTime.Text = test.Time.ToString();
            TxtNumber.Text = test.Number.ToString();

        }


        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BtnConfirm_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (CmbPlayer.SelectedIndex != 0 || CmbExercise.SelectedIndex != 0 || DPDate.SelectedDate != null)
                {
                    if (VarIdTraining == 0)
                    {
                        ExerciseForTest addtest = new ExerciseForTest();
                        addtest.IdPlayer = CmbPlayer.SelectedIndex + 1;
                        addtest.DateTesting = (DateTime)DPDate.SelectedDate;
                        addtest.IdExercise = CmbExercise.SelectedIndex + 1;
                        addtest.Time = TxtTime.Text;
                        addtest.Number = TxtNumber.Text;


                        context.ExerciseForTest.Add(addtest);
                        context.SaveChanges();
                        MessageBox.Show("Test was successfully added", "Success", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                        Close();
                    }
                    else
                    {
                        var editTest = context.ExerciseForTest.Where(i => i.IdExerciseForTest == VarIdTraining).FirstOrDefault();

                        editTest.IdPlayer = CmbPlayer.SelectedIndex + 1;
                        editTest.IdExercise = CmbExercise.SelectedIndex + 1;
                        editTest.DateTesting = (DateTime)DPDate.SelectedDate;
                        editTest.Time = TxtTime.Text;
                        editTest.Number = TxtNumber.Text;

                        context.SaveChanges();
                        VarIdTraining = 0;
                        MessageBox.Show("Training was successfully changed", "Success", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                        Close();
                    }
                }
                else
                {
                    MessageBox.Show("Fields cannot be empty", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }
            catch
            {
                MessageBox.Show("Try later!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void TxtNumber_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void TxtNumber_PreviewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (e.Command == ApplicationCommands.Copy ||
            e.Command == ApplicationCommands.Cut ||
            e.Command == ApplicationCommands.Paste)
            {
                e.Handled = true;
            }
        }

        private void TxtNumber_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            {
                e.Handled = "1234567890".IndexOf(e.Text) < 0;
            }
        }
    private void TxtTime_PreviewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (e.Command == ApplicationCommands.Copy ||
            e.Command == ApplicationCommands.Cut ||
            e.Command == ApplicationCommands.Paste)
            {
                e.Handled = true;
            }
        }
    }
}
