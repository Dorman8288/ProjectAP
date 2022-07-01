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
using System.Windows.Navigation;
using System.Linq;
using System.Windows.Shapes;

namespace ProjectAP.page
{
    /// <summary>
    /// Interaction logic for LoginUserControll.xaml
    /// </summary>
    public partial class LoginUserControll : UserControl
    {
        public LoginUserControll()
        {
            InitializeComponent();
        }

        private void Login_Button_Click(object sender, RoutedEventArgs e)
        {
            ApplicationWindow window = new ApplicationWindow();
            window.Show();
            Application.Current.Windows.OfType<AuthorizationWindow>().First(x => x.Title == "AuthorizationWindow").Close();
        }

        private void Reset_Button_Click(object sender, RoutedEventArgs e)
        {
            admin_section_develop.admin_main_section window = new admin_section_develop.admin_main_section();
            window.Show();
            Application.Current.Windows.OfType<AuthorizationWindow>().First(x => x.Title == "AuthorizationWindow").Close();
        }
    }
}
