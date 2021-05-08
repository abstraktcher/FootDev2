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
    /// Логика взаимодействия для AddReprimand.xaml
    /// </summary>
    public partial class AddReprimand : Window
    {
        public AddReprimand()
        {
            InitializeComponent();
            CmbPlayer.ItemsSource = context.ViewAllInfo.ToList();
            CmbPlayer.DisplayMemberPath = "FullName";
            CmbPlayer.SelectedIndex = 0;

            CmbPunishment.ItemsSource = context.Punishment.ToList();
            CmbPunishment.DisplayMemberPath = "PunishmentName";
            CmbPunishment.SelectedIndex = 0;
        }

        public AddReprimand(ViewReprimands reprimand)
        {
            InitializeComponent();
            CmbPlayer.ItemsSource = context.ViewAllInfo.ToList();
            CmbPlayer.DisplayMemberPath = "FullName";
            CmbPlayer.SelectedIndex = 0;

            CmbPunishment.ItemsSource = context.Punishment.ToList();
            CmbPunishment.DisplayMemberPath = "PunishmentName";
            CmbPunishment.SelectedIndex = 0;


            CmbPlayer.SelectedIndex = reprimand.IdPlayer - 1;
            CmbPunishment.SelectedIndex = reprimand.IdPunishment - 1;
            TxtReprimand.Text = reprimand.Reprimand.ToString();


            DPDate.SelectedDate = reprimand.Date;
        }


        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BtnConfirm_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(TxtReprimand.Text) || CmbPlayer.SelectedIndex != 0 || DPDate.SelectedDate != null || CmbPunishment.SelectedIndex != 0)
                {
                    if (VarIdReprimand == 0)
                    {
                        Reprimand addreprimand = new Reprimand();
                        addreprimand.IdPlayer = CmbPlayer.SelectedIndex + 1;
                        addreprimand.Date = (DateTime)DPDate.SelectedDate;
                        addreprimand.IdPunishment = (byte)(CmbPunishment.SelectedIndex + 1);
                        addreprimand.ReprimandName = TxtReprimand.Text;

                        context.Reprimand.Add(addreprimand);
                        context.SaveChanges();
                        MessageBox.Show("Reprimand was successfully added", "Success", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                        Close();
                    }
                    else
                    {
                        var editReprimand = context.Reprimand.Where(i => i.IdPlaToRep == VarIdReprimand).FirstOrDefault();

                        editReprimand.IdPlayer = CmbPlayer.SelectedIndex + 1;
                        editReprimand.ReprimandName = TxtReprimand.Text;
                        editReprimand.Date = (DateTime)DPDate.SelectedDate;
                        editReprimand.IdPunishment = (byte)(CmbPunishment.SelectedIndex + 1);

                        context.SaveChanges();
                        VarIdReprimand = 0;
                        MessageBox.Show("Reprimand was successfully changed", "Success", MessageBoxButton.OK, MessageBoxImage.Asterisk);
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
    }
}
