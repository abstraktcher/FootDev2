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

namespace FootDev2.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddEditPlayer.xaml
    /// </summary>
    public partial class AddEditPlayer : Window
    {
        public AddEditPlayer()
        {
            InitializeComponent();
            CmbLanguages.ItemsSource = context.Languages.ToList();
            CmbLanguages.DisplayMemberPath = "LanguageName";
            CmbLanguages.SelectedIndex = 0;

            CmbPositions.ItemsSource = context.Position.ToList();
            CmbPositions.DisplayMemberPath = "NamePosition";
            CmbPositions.SelectedIndex = 0;

            CmbLeg.ItemsSource = context.DominantLeg.ToList();
            CmbLeg.DisplayMemberPath = "Name";

            CmbGender.ItemsSource = context.Gender.ToList();
            CmbGender.DisplayMemberPath = "NameGender";
        }

        public AddEditPlayer(Player player)
        {
            InitializeComponent();

            //cmbTypeMAterial.ItemsSource = Context.TypeMaterial.ToList();
            //cmbTypeMAterial.DisplayMemberPath = "Name";

            //cmbUnitMaterial.ItemsSource = Context.UntType.ToList();
            //cmbUnitMaterial.DisplayMemberPath = "Unit";


            //cmbSupplier.ItemsSource = Context.Supplier.ToList();
            //cmbSupplier.DisplayMemberPath = "Name";

            //txtName.Text = material.Name;
            //txtCount.Text = material.Count.ToString();
            //txtCountInBox.Text = material.CountInBox.ToString();
            //txtMinCount.Text = material.MinCount.ToString();
            //txtPrice.Text = material.Price.ToString();
            //cmbTypeMAterial.SelectedIndex = material.TypeId - 1;
            //cmbUnitMaterial.SelectedIndex = material.TypeDimension - 1;
            //imgMaterial.Source = new BitmapImage(new Uri(material.Image));

            //var supMaterial = Context.MaterialSupp.Where(i => i.IdMaterial == material.ID).ToList();

        }
    }
}
