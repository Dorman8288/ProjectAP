using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ProjectAP.Sources.Accounts;

namespace ProjectAP.admin_section_develop
{
    public class book
    {

    }
    public partial class admin_main_section : Window
    {
        Admin ActiveAccount;
        public admin_main_section(Admin ActiveAccount)
        {
            InitializeComponent();
            this.ActiveAccount = ActiveAccount;
        }

        private void ToggleButton_Checked(object sender, RoutedEventArgs e)
        {

        }


        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void creat_book(object sender, RoutedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, RoutedEventArgs e)
        {

        }
        

    }
}
