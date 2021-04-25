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
using static FootDev2.AppData.AppDataClass;
using FootDev2.AppData;
using FootDev2.Windows;
using static FootDev2.HelperClass.CheckRole;

namespace FootDev2.Pages
{
    /// <summary>
    /// Логика взаимодействия для ResponsiblePerson.xaml
    /// </summary>
    public partial class ResponsiblePerson : Page
    {
        public ResponsiblePerson()
        {
            InitializeComponent();
            ListViewRespPerson.ItemsSource = context.ViewResponsiblePerson.ToList();

        }


       



        private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            var list = context.ViewResponsiblePerson.Where(i => i.Player.Contains(TxtSearch.Text)).ToList();

            ListViewRespPerson.ItemsSource = list;
        }


        private void BtnResetFilters_Click(object sender, RoutedEventArgs e)
        {
            TxtSearch.Text = "";
            CBShowWithoutResp.IsChecked = false;

        }

        private void BtnEditPerson_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (ListViewRespPerson.SelectedItem is ViewResponsiblePerson person)
                {
                    VarIdPlayer = (int)person.IdRespPerson;
                    AddEditRespPers addEditRespPers = new AddEditRespPers(ListViewRespPerson.SelectedItem as ViewResponsiblePerson);
                    this.Opacity = 0.3;
                    //Filter();
                    addEditRespPers.ShowDialog();
                    //Filter();
                    this.Opacity = 1;
                }
                else
                {
                    MessageBox.Show("You did not select person", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                }

            }
            catch
            {
                MessageBox.Show("Error", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }



        }

        private void BtnAddPerson_Click(object sender, RoutedEventArgs e)
        {
            AddEditRespPers AddEditRespPers = new AddEditRespPers();
            this.Opacity = 0.3;
            ListViewRespPerson.ItemsSource = context.ViewResponsiblePerson.ToList();
            AddEditRespPers.ShowDialog();
            ListViewRespPerson.ItemsSource = context.ViewResponsiblePerson.ToList();
            this.Opacity = 1;
        }

        private void BtnDeletePerson_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (ListViewRespPerson.SelectedItem is ViewResponsiblePerson person)
                {
                    var result = MessageBox.Show($@"Are you sure you want to delete this person's Responsible Person?{person.Player}, All related data will be permanently deleted", "Remove Responsible Person",
                        MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        context.ResponsiblePerson.Remove(context.ResponsiblePerson.Where(i => i.IdRespPerson == person.IdRespPerson).FirstOrDefault());
                        context.SaveChanges();
                        MessageBox.Show("Removing ", "Success", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        ListViewRespPerson.ItemsSource = context.ViewResponsiblePerson.ToList();

                    }
                }
                else
                {
                    MessageBox.Show("Select person!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    ListViewRespPerson.ItemsSource = context.ViewResponsiblePerson.ToList();
                }

            }
            catch
            {
                MessageBox.Show("Error ", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CBShowWithoutResp_Checked(object sender, RoutedEventArgs e)
        {

            var list = context.ViewResponsiblePerson.Where(i => i.Pesponsible_Person == "").ToList();
            ListViewRespPerson.ItemsSource = list;
            
        }

        private void CBShowWithoutResp_Unchecked(object sender, RoutedEventArgs e)
        {

            ListViewRespPerson.ItemsSource = context.ViewResponsiblePerson.ToList();

        }
    }
}
