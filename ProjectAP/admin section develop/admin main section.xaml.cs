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
using ProjectAP.Sources.Accounts;
using ProjectAP.Sources;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.Win32;
using System.IO;

namespace ProjectAP.admin_section_develop
{
   
    public partial class admin_main_section : Window
    {
        Admin ActiveAccount;
        ObservableCollection<Customer> customers = new ObservableCollection<Customer>();
        public admin_main_section(Admin ActiveAccount)
        {
            InitializeComponent();
            this.ActiveAccount = ActiveAccount;
            DataManager.GetAllCustomers().ForEach(x => customers.Add(x));
;            customerDataGrid.ItemsSource = customers;
        }

        private void Search_Button_Click(object sender, RoutedEventArgs e)
        {
            customerDataGrid.ItemsSource = customerDataGrid.ItemsSource.Cast<Customer>().Where(x => Regex.IsMatch(x.email, @"^.*" + EmailSearchBox.Text + @".*$") && Regex.IsMatch(x.name, @"^.*" + FirstNameSearchBox.Text + @".*$"));
        }




        // func


        //account
        private void Account_apply_vip_value(object sender, RoutedEventArgs e)
        {
            double value = 0;
            try
            {
                value = double.Parse(VIP_value_account.Text);
                Admin.VipAmount = value;
                account_setting_errors.Text = "Successful";
                account_setting_errors.Foreground = new SolidColorBrush(Colors.Green);
            }
            catch
            {
                account_setting_errors.Text = "input digit";
                account_setting_errors.Foreground = new SolidColorBrush(Colors.DarkRed);
            }
        }



        //book
        private void Book_search_book(object sender, RoutedEventArgs e)
        {
            string search = Book_search_nameorcode.Text;
        }

        //load other info from database

        //add
        



        //path and vip
        bool add_vip_value = false;
        string add_filepath = "";
        string add_imagepath = "";
        private void add_creat_book(object sender, RoutedEventArgs e)
        {
            try
            {
                if ((add_name.Text == null) || (add_writer.Text == null) || (add_detail.Text == null) || (add_printyear.Text == null) || (add_cost.Text == null) || (add_procode.Text == null) || (add_filepath == null) || (add_imagepath == null))
                {
                    add_errors.Text = "empty field!";
                    add_errors.Foreground = new System.Windows.Media.SolidColorBrush(Colors.DarkRed);
                }
                else
                {
                    bool vip = add_vip_value;
                    string name = add_name.Text;
                    string writer = add_writer.Text;
                    string detail = add_detail.Text;
                    int print_year;
                    double cost = 0;
                    int code = 0;

                    print_year = int.Parse(add_printyear.Text);
                    cost = double.Parse(add_cost.Text);

                    code = int.Parse(add_procode.Text);
                    if (add_filepath == "" || add_imagepath == "") throw new Exception("please select files");
                    Product first;
                    if (cost != 0 && code != 0)
                    {
                        first = new Product(name, code, cost, detail, add_filepath, 5, writer, add_imagepath, vip);
                        DataManager.AddProduct(first);
                        add_errors.Foreground = new SolidColorBrush(Colors.Green);
                        add_errors.Text = "seccusfull!";
                    }
                }
            }
            catch (Exception error)
            {
                add_errors.Text = error.Message;
                add_errors.Foreground = new SolidColorBrush(Colors.DarkRed);
            }
        }   

        private void add_browse(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "PDF files (*.pdf)|*.pdf";
            if (dialog.ShowDialog() == true)
            {
                string extention = System.IO.Path.GetExtension(dialog.FileName);
                File.Copy(dialog.FileName, @"../../../Resources/" + add_procode.Text + extention, true);
                add_filepath = @"..\..\..\Resources\" + add_procode.Text  + extention;
            }
        }


        private void add_imagebrowse_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files (*.png;*.jpeg)|*.png;*.jpeg";
            if (dialog.ShowDialog() == true)
            {
                string extention = System.IO.Path.GetExtension(dialog.FileName);
                File.Copy(dialog.FileName, @"../../../Resources/" + add_procode.Text + extention, true);
                add_imagepath = @"..\..\..\Resources\" + add_procode.Text + extention;
            }
        }

        private void add_vipvalue_Checked(object sender, RoutedEventArgs e)
        {
            add_vip_value = true;
        }

        private void add_vipvalue_Unchecked(object sender, RoutedEventArgs e)
        {
            add_vip_value = false;
        }





        //edit



        //path
        string edit_filepath = "";
        string edit_imagepath = "";
        private void edit_browse_Click(object sender, RoutedEventArgs e)
        {
            //OpenFileDialog fdlg = new OpenFileDialog();
            //fdlg.Title = "C# Corner Open File Dialog";
            //fdlg.InitialDirectory = @"c:\";
            //fdlg.Filter = "All files (*.*)|*.*|All files (*.*)|*.*";
            //fdlg.FilterIndex = 2;
            //fdlg.RestoreDirectory = true;
            //if (fdlg.ShowDialog() == DialogResult.OK)
            //{

            //}
            //amir
            //browse file from explorer
        }

        private void edit_browseimage_Click(object sender, RoutedEventArgs e)
        {
            //OpenFileDialog fdlg = new OpenFileDialog();
            //fdlg.Title = "C# Corner Open File Dialog";
            //fdlg.InitialDirectory = @"c:\";
            //fdlg.Filter = "All files (*.*)|*.*|All files (*.*)|*.*";
            //fdlg.FilterIndex = 2;
            //fdlg.RestoreDirectory = true;
            //if (fdlg.ShowDialog() == DialogResult.OK)
            //{

            //}
            //amir
            //browse file from explorer
        }

        private void edit_delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (edit_procode.Text == "")
                    throw new Exception("you should enter product code first");
                Product product = DataManager.getAllProducts().Single(x => x.ID == int.Parse(edit_procode.Text));
                DataManager.getAllProducts().Remove(product);
                edit_errors.Text = "successful";
                edit_errors.Foreground = new SolidColorBrush(Colors.Green);
            }
            catch(Exception error)
            {
                edit_errors.Text = error.Message;
                edit_errors.Foreground = new SolidColorBrush(Colors.DarkRed);
            }
        }
        bool edit_vip = false;
        private void edit_apply_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (edit_procode.Text == "")
                    throw new Exception("you should enter product code first");
                Product product = DataManager.getAllProducts().Single(x => x.ID == int.Parse(edit_procode.Text));

                if (edit_name.Text != "")
                    product.name = edit_name.Text;
                if (edit_writer.Text != "")
                    product.author = edit_writer.Text;
                if (edit_cost.Text != "")
                    product.price = double.Parse(edit_cost.Text);
                if (edit_detail.Text != "")
                    product.description = edit_detail.Text;
                product.isVip = edit_vip;

                edit_errors.Text = "successful";
                edit_errors.Foreground = new SolidColorBrush(Colors.Green);
            }
            catch(Exception error) 
            { 
                edit_errors.Text = error.Message;
                edit_errors.Foreground = new SolidColorBrush(Colors.DarkRed);
            }
        }
        private void edit_viptoggle_Checked(object sender, RoutedEventArgs e)
        {
            //amir
            // load from data base
            edit_vip = true;
        }

        private void edit_viptoggle_Unchecked(object sender, RoutedEventArgs e)
        {
            //amir
            // load from data base
            edit_vip = false;
        }


        //discount
        private void dis_serach_Click(object sender, RoutedEventArgs e)
        {
            string search = dis_procode.Text;
            if(search==null)
            {
                dis_errors.Text = "first search";
                dis_errors.Foreground = new System.Windows.Media.SolidColorBrush(Colors.DarkRed);
            }
            //search this code
        }

        private void dis_apply_Click(object sender, RoutedEventArgs e)
        {
            int time = 0;
            string timecombo = dis_time.Text;
            if(timecombo== "30 min")
            {
                time = 30;
            }
            if (timecombo == "1 hr")
            {
                time = 60;
            }
            if (timecombo == "2 hr")
            {
                time = 120;
            }
            if (timecombo == "4 hr")
            {
                time = 240;
            }
            if (timecombo == "12 hr")
            {
                time = 720;
            }



            double value=0;
            try
            {
                value = double.Parse(dis_value.Text);
            }
            catch
            {

            }
            if(value==0)
            {
                dis_errors.Text = "input value";
                dis_errors.Foreground = new System.Windows.Media.SolidColorBrush(Colors.DarkRed);
            }

        }


        //wallet
        private void wallet_withdraw_accept_Click(object sender, RoutedEventArgs e)
        {
            string card = wallet_card.Text;
            //amir
            // regex then withdraw
        }

        private void wallet_withdraw_enable_Click(object sender, RoutedEventArgs e)
        {
            wallet_card.IsEnabled = true;
        }

        private void wallet_show_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("seccesful!","withdraw",MessageBoxButton.OK);
            wallet_value.Text = "6546$";
            // amir load this from data base
        }

        private void Back_Button_Click(object sender, RoutedEventArgs e)
        {
            AuthorizationWindow window = new AuthorizationWindow();
            window.Show();
            Close();
        }
    }
}
