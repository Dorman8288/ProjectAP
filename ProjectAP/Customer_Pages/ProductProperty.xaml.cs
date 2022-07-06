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
using System.Linq;
using ProjectAP.Dialogs;

namespace ProjectAP.Customer_Pages
{
    /// <summary>
    /// Interaction logic for ProductProperty.xaml
    /// </summary>
    public partial class ProductProperty : UserControl
    {
        public static Customer ActiveAccount;
        public static Product product;
        public ProductProperty()
        {
            InitializeComponent();
            //MessageBox.Show($"{product.name} {ActiveAccount.name}");
            //ImageDisplayer.Source = new BitmapImage(new Uri(product.imagePath, UriKind.Relative));
        }

        private void Back_Button_Click(object sender, RoutedEventArgs e)
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(ApplicationWindow))
                {
                    (window as ApplicationWindow).PageNavigator.SelectedIndex = 0;
                }
            }
            BuyButtonText.Text = "Add to Cart";
            bookmarkToggle.IsChecked = false;
        }

        private void Add_To_Cart_Button_Click(object sender, RoutedEventArgs e)
        {
            if(!ActiveAccount.cart.allProducts.Contains((DataContext as Product)))
                ActiveAccount.cart.AddToCart(DataContext as Product);
            else
            {
                BuyButtonText.Text = "Already in Cart";
            }
        }

        private void BookMarkButton_Checked(object sender, RoutedEventArgs e)
        {
            if (!ActiveAccount.bookMarks.Contains((DataContext as Product)))
                ActiveAccount.bookMarks.Add(DataContext as Product);
            else
            {
                bookmarkToggle.IsChecked = true;
            }
        }

        private void bookmarkToggle_Unchecked(object sender, RoutedEventArgs e)
        {
            if (ActiveAccount.bookMarks.Contains((DataContext as Product)))
                ActiveAccount.bookMarks.Remove(DataContext as Product);
            else
            {
                bookmarkToggle.IsChecked = false;
            }
        }

        private void Buy_Button_Click(object sender, RoutedEventArgs e)
        {
            transaction_Dialog dialog = new transaction_Dialog((DataContext as Product).CalculatePrice(), ActiveAccount);
            dialog.ShowDialog();
            if (dialog.transactionResult)
            {
                ActiveAccount.inventory.Add(DataContext as Product);
            }
        }
    }
}
