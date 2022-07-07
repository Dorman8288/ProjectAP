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
using System.Windows.Shapes;
using ProjectAP.Sources;
using ProjectAP.Sources.Accounts;

namespace ProjectAP.Customer_Pages
{
    /// <summary>
    /// Interaction logic for SettingsPage.xaml
    /// </summary>
    public partial class SettingsPage : UserControl
    {
        public static Customer ActiveAccount;
        public SettingsPage()
        {
            InitializeComponent();
        }

        private void Apply_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (FirstNameTextBox.Text != "")
                    ActiveAccount.name = FirstNameTextBox.Text;
                if (LastNameTextBox.Text != "")
                    ActiveAccount.familyName = LastNameTextBox.Text;
                if (EmailTextBox.Text != "")
                    ActiveAccount.email = EmailTextBox.Text;
                if (phoneNumberTextBox.Text != "")
                    ActiveAccount.phoneNumber = phoneNumberTextBox.Text;
                if (PasswordTextbox.Password != "")
                    ActiveAccount.password = PasswordTextbox.Password;
                ErrorDisplayer.Foreground = Brushes.Green;
                ErrorDisplayer.Text = "Successful";
            }
            catch(Exception error)
            {
                ErrorDisplayer.Foreground = Brushes.Red;
                ErrorDisplayer.Text = error.Message;
            }
            
        }
    }
}
