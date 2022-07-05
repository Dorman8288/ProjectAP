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
using System.Text.RegularExpressions;

namespace ProjectAP.Customer_Pages
{
    /// <summary>
    /// Interaction logic for ProductDisplayer.xaml
    /// </summary>
    public partial class ProductDisplayer : UserControl
    {
        List<Product> nonVipProducts;
        public ProductDisplayer()
        {
            InitializeComponent();
            nonVipProducts = DataManager.getAllNonVipProducts();
            Displayer.ItemsSource = nonVipProducts;
        }
        private void Search_Button_Click(object sender, RoutedEventArgs e)
        {
            Displayer.ItemsSource = Displayer.ItemsSource.Cast<Product>().Where(x => Regex.IsMatch(x.name, @"^.*" + NameSearchBox.Text + @".*$") && Regex.IsMatch(x.author, @"^.*" + AuthorSearchBox.Text + @".*$"));
        }

        private void Select_Book_Button_Click(object sender, RoutedEventArgs e)
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(ApplicationWindow))
                {
                    (window as ApplicationWindow).PageNavigator.SelectedIndex = 4;
                    (window as ApplicationWindow).Property.DataContext = (sender as Button).DataContext as Product;
                }
            }
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            
        }

        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
    }
}
