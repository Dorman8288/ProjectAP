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
using System.IO;
using System.ServiceProcess;
using System.Diagnostics;
using System.ComponentModel.DataAnnotations;

namespace ProjectAP.Customer_Pages
{
    /// <summary>
    /// Interaction logic for InventoryPage.xaml
    /// </summary>
    public partial class InventoryPage : UserControl
    {
        public static Customer ActiveAccount;
        public InventoryPage()
        {
            InitializeComponent();
        }
        private void Search_Button_Click(object sender, RoutedEventArgs e)
        {
            Displayer.ItemsSource = Displayer.ItemsSource.Cast<Product>().Where(x => Regex.IsMatch(x.name, @"^.*" + NameSearchBox.Text + @".*$") && Regex.IsMatch(x.author, @"^.*" + AuthorSearchBox.Text + @".*$"));
        }

        private void Select_Book_Button_Click(object sender, RoutedEventArgs e)
        {
            //System.Diagnostics.Process.Start(((sender as Button).DataContext as Product).filePath);
            Process opening = new Process();
            opening.StartInfo.UseShellExecute = true;
            opening.StartInfo.FileName = ((sender as Button).DataContext as Product).filePath;
            opening.Start();
        }
    }
}
