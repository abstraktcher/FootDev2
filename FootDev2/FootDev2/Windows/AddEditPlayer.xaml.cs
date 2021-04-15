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
           

            //           CmbPositions.ItemsSource = context.Position.ToList();
            //CmbPositions.DisplayMemberPath = "NamePosition";
            //CmbPositions.SelectedIndex = 0;

          
        }

        public AddEditPlayer(ViewAllInfo player)
        {
            InitializeComponent();

            CmbGender.ItemsSource = context.Gender.ToList();
            CmbGender.DisplayMemberPath = "NameGender";

            CmbLeg.ItemsSource = context.DominantLeg.ToList();
            CmbLeg.DisplayMemberPath = "Name";

            CmbNationality.ItemsSource = context.Nationality.ToList();
            CmbNationality.DisplayMemberPath = "NationalityName";


            TxtFirstName.Text = player.FirstName.ToString();
            TxtLastName.Text = player.LastName.ToString();
            TxtMiddleName.Text = player.MiddleName.ToString();
            TxtEmail.Text = player.Email.ToString();
            TxtPhone.Text = player.PhoneNumber.ToString();
            TxtPassword.Text = player.Password.ToString();
            CmbGender.SelectedIndex = player.idGender - 1;
            CmbLeg.SelectedIndex = (int)(player.IdDominantLeg - 1);

           
            //imgMaterial.Source = new BitmapImage(new Uri(material.Image));

            
            //var supMaterial = Context.MaterialSupp.Where(i => i.IdMaterial == material.ID).ToList();

        }


    }
}
