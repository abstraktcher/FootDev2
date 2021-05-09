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

namespace FootDev2.CommonPages
{
    /// <summary>
    /// Логика взаимодействия для PageDF.xaml
    /// </summary>
    public partial class PageDF : Page
    {
        public PageDF()
        {
            InitializeComponent(); 
            ListViewDF.ItemsSource = context.ViewDFCharacteristics.ToList(); //filling the table with data from the Database from ViewDF
        }
        public void Filter()
        {
            var list = context.ViewDFCharacteristics.Where(i => i.FullName.Contains(TxtSearch.Text)).ToList(); //declaration of List, assigning a value to it, containing data from the view, where the name contains data from the search
            ListViewDF.ItemsSource = list; //assigning a table value from this List

        }

        private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter(); //filter method application
        }

        private void BtnResetFilters_Click(object sender, RoutedEventArgs e)
        {

            TxtSearch.Text = "";//Clearing Text Box
        }
    }
}
