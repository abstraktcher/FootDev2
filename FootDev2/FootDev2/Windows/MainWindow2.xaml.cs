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
    /// Логика взаимодействия для MainWindow2.xaml
    /// </summary>
    public partial class MainWindow2 : Window
    {
        public MainWindow2()
        {
            InitializeComponent();
        }

        private void CloseImage2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BtnAuthorization_Click(object sender, RoutedEventArgs e)
        {
            var accountPlayer = context.Player.ToList().Where(i => i.Email == TextLogin.Text && i.Password == TextPassword.Password).FirstOrDefault();

            var accountPerson = context.Personnel.ToList().Where(i => i.Email == TextLogin.Text && i.Password == TextPassword.Password).FirstOrDefault();


            if (accountPlayer is Player player)
            {
                VarCheckRole = context.Player.Where(i => i.Email == TextLogin.Text && i.Password == TextPassword.Password).Select(b => b.IdRole).FirstOrDefault();
                PlayerWindow playerwindow = new PlayerWindow();
                this.Hide();
                playerwindow.Show();
                this.Close();
            }

            if (accountPerson is Personnel person)
            {
                VarCheckRole = context.Personnel.Where(i => i.Email == TextLogin.Text && i.Password == TextPassword.Password).Select(b => b.IdRole).FirstOrDefault();
                if (VarCheckRole == 1)
                {
                    ManagerWindow managerwindow = new ManagerWindow();
                    this.Hide();
                    managerwindow.Show();
                    this.Close();
                }
                if (VarCheckRole == 3)
                {
                    MessageBox.Show("Service is temporarily unavailable. We are sorry", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                if (VarCheckRole == 4)
                {
                    MessageBox.Show("Service is temporarily unavailable. We are sorry", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
