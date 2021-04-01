﻿using System;
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

namespace FootDev2.Pages
{
    /// <summary>
    /// Логика взаимодействия для Squad.xaml
    /// </summary>
    public partial class Squad : Page
    {
        public Squad()
        {
            InitializeComponent();
            ListViewSquad.ItemsSource = context.ViewAllInfo.ToList();
        }
    }
}
