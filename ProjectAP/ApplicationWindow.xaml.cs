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

namespace ProjectAP
{
    /// <summary>
    /// Interaction logic for ApplicationWindow.xaml
    /// </summary>
    public partial class ApplicationWindow : Window
    {
        public ApplicationWindow()
        {
            InitializeComponent();
        }

        private void Store_Button_Click(object sender, RoutedEventArgs e)
        {
            PageNavigator.SelectedIndex = 0;
        }

        private void Cart_Button_Click(object sender, RoutedEventArgs e)
        {
            PageNavigator.SelectedIndex = 1;
        }

        private void Inventory_Button_Click(object sender, RoutedEventArgs e)
        {
            PageNavigator.SelectedIndex = 2;
        }

        private void Settings_Button_Click(object sender, RoutedEventArgs e)
        {
            PageNavigator.SelectedIndex = 3;
        }

        private void SignOut_Button_Click(object sender, RoutedEventArgs e)
        {
            AuthorizationWindow window = new AuthorizationWindow();
            window.Show();
            Close();
        }
    }
}
