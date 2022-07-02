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
namespace ProjectAP.page
{
    /// <summary>
    /// Interaction logic for SignupUserControll.xaml
    /// </summary>
    public partial class SignupUserControll : UserControl
    {
        public SignupUserControll()
        {
            InitializeComponent();
        }

        private void Register_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ErrorDisplayer.Text = "";
                Customer newCustomer = new Customer(FirstNameTextBox.Text, LastNameTextBox.Text, EmailTextBox.Text, phoneNumberTextBox.Text, PasswordTextbox.Password);
                DataManager.AddAccount(newCustomer);
                ErrorDisplayer.Foreground = Brushes.Green;
                ErrorDisplayer.Text = "*Your account has been registered";
            }
            catch(Exception error)
            {
                ErrorDisplayer.Foreground = Brushes.Red;
                ErrorDisplayer.Text = "*" + error.Message;
            }
        }
    }
}
