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
    /// Логика взаимодействия для PagePredispositions.xaml
    /// </summary>
    public partial class PagePredispositions : Page
    {
        public PagePredispositions()
        {
            InitializeComponent();
            ListViewPredispositions.ItemsSource = context.ViewPredispositions.ToList();

            List<Predisposition> predisp = context.Predisposition.ToList();
            CmbPredisposition.DisplayMemberPath = "PredispositionName";
            predisp.Insert(0, new Predisposition() { PredispositionName = "All" });
            CmbPredisposition.ItemsSource = predisp;
            CmbPredisposition.SelectedIndex = 0;
        }

        public void Filter()
        {
            var list = context.ViewPredispositions.Where(i => i.Fullname.Contains(TxtSearch.Text)).ToList();
            ListViewPredispositions.ItemsSource = list;

            var selectFilter = CmbPredisposition.SelectedIndex;

            if (selectFilter != 0)
            {
                ListViewPredispositions.ItemsSource = list.Where(i => i.IdPredisposition == selectFilter).ToList();
            }

        }

        private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }


        private void CmbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }

        private void BtnResetFilters_Click(object sender, RoutedEventArgs e)
        {

            CmbPredisposition.SelectedIndex = 0;
            TxtSearch.Text = "";
        }

        private void CmbPredisposition_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }
    }
}
