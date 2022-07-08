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
using ProjectAP.Sources;
using ProjectAP.Sources.Accounts;
using ProjectAP.admin_section_develop;

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
            try
            {
                Account account = DataManager.getAccount(EmailTextBox.Text);
                if (account.password != PasswordBox.Password) throw new Exception("Password dosent match");
                if(account is Customer)
                {
                    ApplicationWindow window = new ApplicationWindow(account as Customer);
                    window.Show();
                    Application.Current.Windows.OfType<AuthorizationWindow>().First().Close();
                }
                if(account is Admin)
                {
                    admin_main_section window = new admin_main_section(account as Admin);
                    window.Show();
                    Application.Current.Windows.OfType<AuthorizationWindow>().First().Close();
                }
            }
            catch(Exception error)
            {
                ErrorDisplayer.Foreground = Brushes.Red;
                ErrorDisplayer.Text = "*" + error.Message;
            }
            
        }

        private void Reset_Button_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
