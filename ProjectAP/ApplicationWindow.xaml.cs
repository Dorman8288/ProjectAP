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
    /// Interaction logic for ApplicationWindow.xaml
    /// </summary>
    public partial class ApplicationWindow : Window
    {
        public Customer ActiveAccount;
        public ApplicationWindow(Customer ActiveAccount)
        {
            InitializeComponent();
            this.ActiveAccount = ActiveAccount;
            Customer_Pages.ProductProperty.ActiveAccount = ActiveAccount;
        }
        public ApplicationWindow()
        {
            InitializeComponent();
            DataManager.AddAccount(new Customer("amdor", "amdor", "dorman8288@gmail.com", "09385017532", "Amdor8288"));
            ActiveAccount = DataManager.getAccount("dorman8288@gmail.com") as Customer;
            ActiveAccount.AddBalance(123412.543);
            CustomerChip.Icon = char.ToUpper(ActiveAccount.name[0]);
            CustomerChip.Content = ActiveAccount.name + ' ' + ActiveAccount.familyName;
            BalanceDisplay.Text = ActiveAccount.balance.ToString();
            Customer_Pages.ProductProperty.ActiveAccount = ActiveAccount;
            Customer_Pages.InventoryPage.ActiveAccount = ActiveAccount;
            try
            {
                DataManager.AddAccount(new Admin("Admin", "Admin", "Admin@gmail.com", "09385017532", "Admin1234"));    
                DataManager.AddProduct(new Product("testName1", 1, 100, "this is simple test1", @"FinalProject.pdf", 2, "TestAuthor1", @"../Resources/TestImage1.jpg"));
                DataManager.AddProduct(new Product("testName2", 2, 100, "this is simple test2", @"FinalProject.pdf", 2, "TestAuthor2", @"../Resources/TestImage2.jpg"));
                DataManager.AddProduct(new Product("testName3", 3, 100, "this is simple test3", @"FinalProject.pdf", 2, "TestAuthor3", @"../Resources/TestImage3.jpg"));
                DataManager.AddProduct(new Product("testName4", 4, 100, "this is simple test4", @"FinalProject.pdf", 2, "TestAuthor4", @"../Resources/TestImage4.png"));
            }
            catch
            {

            }
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

        private void Wallet_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("hello");
        }
    }
}
