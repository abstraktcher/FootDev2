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
            var accountPlayer = context.Player.ToList().Where(i => i.Email == TextLogin.Text && i.Password == TextPassword.Password).FirstOrDefault(); //select an entry from the Database according to the corresponding data of the text fields(Player)

            var accountPerson = context.Personnel.ToList().Where(i => i.Email == TextLogin.Text && i.Password == TextPassword.Password).FirstOrDefault();//select an entry from the Database according to the corresponding data of the text fields(Person)

            if (accountPlayer == null && accountPerson == null) //Checking is there entry or the entered data is not correct
            {
                MessageBox.Show("Wrong Email or Password", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (accountPlayer is Player player) // If entered data is correct and and this is the player's data, then the Player window opens
                {
                    VarCheckRole = context.Player.Where(i => i.Email == TextLogin.Text && i.Password == TextPassword.Password).Select(b => b.IdRole).FirstOrDefault(); //assigning a variable to a value
                    PlayerWindow playerwindow = new PlayerWindow();
                    this.Hide();
                    playerwindow.Show();
                    this.Close();
                }
                 
                if (accountPerson is Personnel person) // If entered data is correct and and this is the manager's data, then the Manager window opens
                {


                    VarCheckRole = context.Personnel.Where(i => i.Email == TextLogin.Text && i.Password == TextPassword.Password).Select(b => b.IdRole).FirstOrDefault();
                    if (VarCheckRole == 1)
                    {
                        ManagerWindow managerwindow = new ManagerWindow();
                        this.Hide();
                        managerwindow.Show();
                        this.Close();
                    }
                    if (VarCheckRole == 3) // If entered data is correct and and this is the medic's data, then  an error occurs because the window has not been developed yet
                    {
                        MessageBox.Show("Service is temporarily unavailable. We are sorry", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    if (VarCheckRole == 4) // If entered data is correct and and this is the coaches data, then  an error occurs because the window has not been developed yet
                    {
                        MessageBox.Show("Service is temporarily unavailable. We are sorry", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }

                }
            }

           
        }
    }
}
