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
    /// Логика взаимодействия для AddNewPredisp.xaml
    /// </summary>
    public partial class AddNewPredisp : Window
    {
        public AddNewPredisp()
        {
            InitializeComponent();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnConfirm_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrEmpty(TxtName.Text))
            {
                MessageBox.Show("Name cannot be empty", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            Predisposition addpred = new Predisposition();
            addpred.Description = TxtDescription.Text;
            addpred.PredispositionName = TxtName.Text;
            addpred.Treatment = TxtTreatment.Text;
            context.Predisposition.Add(addpred);
            context.SaveChanges();
            MessageBox.Show("Information was successfully added", "Success", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            Close();
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

        private void TxtName_PreviewExecuted(object sender, ExecutedRoutedEventArgs e)
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

        private void TxtName_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZäöÖÄ ".IndexOf(e.Text) < 0;
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
    }
}
