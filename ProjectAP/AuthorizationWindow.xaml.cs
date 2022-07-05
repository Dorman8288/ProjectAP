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
using ProjectAP.Sources;
using ProjectAP.Sources.Accounts;

namespace ProjectAP
{
    /// <summary>
    /// Interaction logic for AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        public AuthorizationWindow()
        {
            InitializeComponent();
            try
            {
                DataManager.AddAccount(new Admin("Admin", "Admin", "Admin@gmail.com", "09385017532", "Admin1234"));
                DataManager.AddAccount(new Customer("amdor", "amdor", "dorman8288@gmail.com", "09385017532", "Amdor8288"));
                DataManager.AddProduct(new Product("testName", 1, 100, "this is simple test", @"FinalProject.pdf", 2, "TestAuthor", @"TestImage.jpg", true));
            }
            catch
            {

            }
        }
    }
}
