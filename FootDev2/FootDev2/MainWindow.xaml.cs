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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FootDev2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AuthBtn_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrWhiteSpace(TextLogin.Text) || string.IsNullOrWhiteSpace(TextPassword.Password))
            {
                MessageBox.Show("Password or Login cannot be empty", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        private void RegBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MinimazeImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void CloseImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void TextLogin_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "1234567890abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ_@".IndexOf(e.Text) < 0;
        }

        private void TextPassword_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "1234567890abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ#$%&'()*+,-./:;<=>?@[]^_`{|}~!$&".IndexOf(e.Text) < 0;
        }

        private void TextLogin_PreviewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if(e.Command == ApplicationCommands.Copy ||
                e.Command == ApplicationCommands.Cut ||
                e.Command == ApplicationCommands.Paste)
            {
                e.Handled = true;
            }
        }

        private void TextPassword_PreviewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if(e.Command == ApplicationCommands.Copy ||
                e.Command == ApplicationCommands.Cut ||
                e.Command == ApplicationCommands.Paste)
            {
                e.Handled = true;
            }
        }

        private void TextLogin_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void TextPassword_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }
    }
}
