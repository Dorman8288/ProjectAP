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
using System.Linq;
using ProjectAP.Sources;
using ProjectAP.Sources.Accounts;
using ProjectAP.Dialogs;

namespace ProjectAP.Customer_Pages
{
    /// <summary>
    /// Interaction logic for CartPage.xaml
    /// </summary>
    public partial class CartPage : UserControl
    {
        public static Customer ActiveAccount;
        public CartPage()
        {
            InitializeComponent();
        }

        private void Remove_Button_Click(object sender, RoutedEventArgs e)
        {
            if (CartDisplayer.SelectedItem != null)
            {
                ActiveAccount.cart.remove(CartDisplayer.SelectedItem as Product);
                List<Product> newList = CartDisplayer.ItemsSource.Cast<Product>().ToList();
                newList.Remove(CartDisplayer.SelectedItem as Product);
                CartDisplayer.ItemsSource = newList;
                BuyButton.Text = ActiveAccount.cart.CalculatePrice().ToString();
            }
        }

        private void Buy_Button_Click(object sender, RoutedEventArgs e)
        {
            transaction_Dialog dialog = new transaction_Dialog(ActiveAccount.cart.CalculatePrice(), ActiveAccount);
            dialog.ShowDialog();
            if (dialog.transactionResult)
            {
                List<Product> newList = CartDisplayer.ItemsSource.Cast<Product>().ToList();
                newList.ForEach(x => x.totalSell += x.CalculatePrice());
                ActiveAccount.inventory.AddRange(newList);
                ActiveAccount.cart.Reset();
                CartDisplayer.ItemsSource = ActiveAccount.cart.allProducts;
                BuyButton.Text = ActiveAccount.cart.CalculatePrice().ToString();
            }
        }
    }
}
