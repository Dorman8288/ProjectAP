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
using System.Diagnostics;
using MaterialDesignThemes.Wpf;
using ProjectAP.Dialogs;

namespace ProjectAP.Customer_Pages
{
    /// <summary>
    /// Interaction logic for VipPage.xaml
    /// </summary>
    public partial class VipPage : UserControl
    {
        public static Customer ActiveAccount;
        public VipPage()
        {
            InitializeComponent();
            Displayer.ItemsSource = DataManager.getAllVIPProducts();
        }

        private void VIP_Buy_Button_Click(object sender, RoutedEventArgs e)
        {
            transaction_Dialog dialog = new transaction_Dialog(Admin.VipAmount ,ActiveAccount);
            dialog.ShowDialog();
            if (dialog.transactionResult)
            {
                ActiveAccount.AddVip(1);
                buyButton.IsEnabled = false;
                buyButton.Content = $"You have VIP until {ActiveAccount.VIPExpieringDate}";
            }
        }
        private void Search_Button_Click(object sender, RoutedEventArgs e)
        {
            Displayer.ItemsSource = Displayer.ItemsSource.Cast<Product>().Where(x => Regex.IsMatch(x.name, @"^.*" + NameSearchBox.Text + @".*$") && Regex.IsMatch(x.author, @"^.*" + AuthorSearchBox.Text + @".*$"));
        }

        private void Select_Book_Button_Click(object sender, RoutedEventArgs e)
        {
            if (ActiveAccount.HaveVip())
            {
                Process opening = new Process();
                opening.StartInfo.UseShellExecute = true;
                opening.StartInfo.FileName = ((sender as Button).DataContext as Product).filePath;
                opening.Start();
            }
            else
            {
                MessageBox.Show("You dont have VIP" ,"Information", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            
        }
    }
}
