﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ProjectAP.Sources;

namespace ProjectAP.Customer_Pages
{
    /// <summary>
    /// Interaction logic for ProductProperty.xaml
    /// </summary>
    public partial class ProductProperty : UserControl
    {
        public static Account ActiveAccount;
        public static Product product;
        public ProductProperty()
        {
            InitializeComponent();
            //MessageBox.Show($"{product.name} {ActiveAccount.name}");
            //ImageDisplayer.Source = new BitmapImage(new Uri(product.imagePath, UriKind.Relative));
        }
    }
}
