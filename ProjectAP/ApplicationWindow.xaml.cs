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
using ProjectAP.Dialogs;

namespace ProjectAP
{
    /// <summary>
    /// Interaction logic for ApplicationWindow.xaml
    /// </summary>
    public partial class ApplicationWindow : Window
    {
        public Customer ActiveAccount;
        public static bool transactionResult;
        public ApplicationWindow(Customer ActiveAccount)
        {
            InitializeComponent();
            this.ActiveAccount = ActiveAccount;
            Customer_Pages.ProductProperty.ActiveAccount = ActiveAccount;
            CustomerChip.Icon = char.ToUpper(ActiveAccount.name[0]);
            CustomerChip.Content = ActiveAccount.name + ' ' + ActiveAccount.familyName;
            BalanceDisplay.Text = ActiveAccount.balance.ToString();
            Customer_Pages.ProductProperty.ActiveAccount = ActiveAccount;
            Customer_Pages.InventoryPage.ActiveAccount = ActiveAccount;
            Customer_Pages.CartPage.ActiveAccount = ActiveAccount;
            Customer_Pages.VipPage.ActiveAccount = ActiveAccount;
            Customer_Pages.SettingsPage.ActiveAccount = ActiveAccount;
            Customer_Pages.ProductDisplayer.ActiveAccount = ActiveAccount;
            BalanceDisplay.DataContext = ActiveAccount;
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
            ChargeWalletDialog dialog = new ChargeWalletDialog(ActiveAccount);
            dialog.ShowDialog();
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

        private void Window_Closed(object sender, EventArgs e)
        {
            DataManager.Save();
        }
    }
}
