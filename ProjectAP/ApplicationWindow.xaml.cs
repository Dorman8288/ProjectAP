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
using System.Collections.ObjectModel;

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
            Customer_Pages.CartPage.ActiveAccount = ActiveAccount;
            Customer_Pages.VipPage.ActiveAccount = ActiveAccount;
            Customer_Pages.SettingsPage.ActiveAccount = ActiveAccount;
            try
            {
                DataManager.AddAccount(new Admin("Admin", "Admin", "Admin@gmail.com", "09385017532", "Admin1234"));    
                DataManager.AddProduct(new Product("testName1", 1, 100, "this is simple test1", @"..\..\..\Resources\FinalProject.pdf", 2, "TestAuthor1", @"../Resources/TestImage1.jpg", true));
                DataManager.AddProduct(new Product("testName2", 2, 100, "this is simple test2", @"..\..\..\Resources\FinalProject.pdf", 2, "TestAuthor2", @"../Resources/TestImage2.jpg", true));
                DataManager.AddProduct(new Product("testName3", 3, 100, "this is simple test3", @"..\..\..\Resources\FinalProject.pdf", 2, "TestAuthor3", @"../Resources/TestImage3.jpg", false));
                DataManager.AddProduct(new Product("testName4", 4, 100, "this is simple test4", @"..\..\..\Resources\FinalProject.pdf", 2, "TestAuthor4", @"../Resources/TestImage4.png", false));
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
            ObservableCollection<Product> OC = new ObservableCollection<Product>();
            ActiveAccount.cart.allProducts.ForEach(x => OC.Add(x));
            PageNavigator.SelectedIndex = 1;
            Cart.CartDisplayer.ItemsSource = OC;
            Cart.BuyButton.Text = ActiveAccount.cart.CalculatePrice().ToString();
        }

        private void Inventory_Button_Click(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Product> OC = new ObservableCollection<Product>();
            ActiveAccount.inventory.ForEach(x => OC.Add(x));
            PageNavigator.SelectedIndex = 2;
            inventory.Displayer.ItemsSource = OC;
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

        private void Vip_Button_Click(object sender, RoutedEventArgs e)
        {
            PageNavigator.SelectedIndex = 5;
            if (ActiveAccount.HaveVip())
            {
                Vip.buyButton.IsEnabled = false;
                Vip.buyButton.Content = $"You have VIP until {ActiveAccount.VIPExpieringDate}";
            }
            else
            {
                Vip.buyButton.IsEnabled = true;
                Vip.buyButton.Content = $"Buy VIP";
            }
        }
    }
}
