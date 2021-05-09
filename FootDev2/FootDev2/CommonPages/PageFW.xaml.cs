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
    /// Логика взаимодействия для PageFW.xaml
    /// </summary>
    public partial class PageFW : Page
    {
        public PageFW()
        {
            InitializeComponent();
            ListViewFW.ItemsSource = context.ViewStrikerCharacteristics.ToList();
        }

        public void Filter()
        {
            var list = context.ViewStrikerCharacteristics.Where(i => i.FullName.Contains(TxtSearch.Text)).ToList();
            ListViewFW.ItemsSource = list;

        }

        private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }

        private void BtnResetFilters_Click(object sender, RoutedEventArgs e)
        {

            TxtSearch.Text = "";
        }

    }
}
