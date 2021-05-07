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
    /// Логика взаимодействия для Predispositions.xaml
    /// </summary>
    public partial class Predispositions : Page
    {
        public Predispositions()
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

        private void BtnEditPredisposition_Click(object sender, RoutedEventArgs e)
        {
            try

            {

                if (ListViewPredispositions.SelectedItem is FootDev2.AppData.ViewPredispositions predisposition)
                {
                    VarIdPredisp = predisposition.IdPredToPla;
                    VarIdPredisposition = predisposition.IdPredisposition;
                    AddPredisp addpredisp = new AddPredisp(ListViewPredispositions.SelectedItem as FootDev2.AppData.ViewPredispositions);
                    this.Opacity = 0.3;
                    Filter();
                    addpredisp.ShowDialog();
                    Filter();
                    this.Opacity = 1;
                }
                else
                {
                    MessageBox.Show("You did not select player", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                }

            }
            catch
            {
                MessageBox.Show("Error", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }



        }

        private void BtnAddPredisposition_Click(object sender, RoutedEventArgs e)
        {
            AddPredisp addpredisp = new AddPredisp();
            this.Opacity = 0.3;
            Filter();
            addpredisp.ShowDialog();
            Filter();
            this.Opacity = 1;
        }

        private void BtnDeletePredisposition_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (ListViewPredispositions.SelectedItem is FootDev2.AppData.ViewPredispositions predisp)
            {
                var result = MessageBox.Show($@"Are you sure you want to delete information about this predisposition? {predisp.Fullname}  {predisp.PredispositionName}, All  data will be permanently deleted", "Remove Information",
                    MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    context.PredispositionToPlayer.Remove(context.PredispositionToPlayer.Where(i => i.IdPredToPla == predisp.IdPredToPla).FirstOrDefault());
                    context.SaveChanges();
                    MessageBox.Show("Removing ", "Success", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    Filter();


                }
            }
            else
            {
                MessageBox.Show("Select entry!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
            catch
            {
                MessageBox.Show("Error ", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
}

        private void CmbPredisposition_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }

    }
}
