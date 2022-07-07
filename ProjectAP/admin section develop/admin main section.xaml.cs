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


namespace ProjectAP.admin_section_develop
{
   
    public partial class admin_main_section : Window
    {
        Admin ActiveAccount;
        public admin_main_section(Admin ActiveAccount)
        {
            InitializeComponent();
            this.ActiveAccount = ActiveAccount;
        }






        // func


        //account
        private void Account_apply_vip_value(object sender, RoutedEventArgs e)
        {
            double value = 0;
            try
            {
                value = double.Parse(VIP_value_account.Text);
            }
            catch
            {
                account_setting_errors.Text = "input digit";
                account_setting_errors.Foreground = new System.Windows.Media.SolidColorBrush(Colors.DarkRed);
            }
        }



        //book
        private void Book_search_book(object sender, RoutedEventArgs e)
        {
            string search = Book_search_nameorcode.Text;
        }

        //load other info from database

        //add

        bool add_vip_value = false;
        private void add_creat_book(object sender, RoutedEventArgs e)
        {
            bool vip = add_vip_value;
            string name = add_name.Text;
            string writer = add_writer.Text;
            string detail = add_detail.Text;
            int print_year;
            double cost;
            int code;


            try
            {
                print_year = int.Parse(add_printyear.Text);
                cost = double.Parse(add_cost.Text);

                code = int.Parse(add_procode.Text);
            }
            catch
            {
                add_errors.Text = "input number";
                add_errors.Foreground = new System.Windows.Media.SolidColorBrush(Colors.DarkRed);
            }
             
        }
       

        private void add_browse(object sender, RoutedEventArgs e)
        {
            //amir
            //browse file from explorer
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
        private void edit_browse_Click(object sender, RoutedEventArgs e)
        {
            //amir
            //browse file from explorer
        }

        private void edit_delete_Click(object sender, RoutedEventArgs e)
        {
            
            if((edit_detail.Text==null)|| (edit_name.Text==null)|| (edit_cost.Text==null)|| (edit_writer.Text==null)|| (edit_printyear.Text==null)|| (edit_procode.Text==null))
            {
                edit_errors.Text = "one or several fields is empty";
                edit_errors.Foreground = new System.Windows.Media.SolidColorBrush(Colors.DarkRed);
            }
            else
            {
                //amir
                // delete book with 
            }
        }

        private void edit_apply_Click(object sender, RoutedEventArgs e)
        {
            if ((edit_detail.Text == null) || (edit_name.Text == null) || (edit_cost.Text == null) || (edit_writer.Text == null) || (edit_printyear.Text == null) || (edit_procode.Text == null))
            {
                edit_errors.Text = "one or several fields is empty";
                edit_errors.Foreground = new System.Windows.Media.SolidColorBrush(Colors.DarkRed);
            }
            else
            {
                //amir
                // edit book with
            }

            //bookname=edit_name.Text ;
            //bookwriter=edit_writer.Text ;
            //bookcost= edit_cost.Text ;
            //bookdetail=edit_detail.Text ;
            //bookyear=edit_printyear.Text ;
            //bookcode=edit_procode.Text ;
            //bookvip=edit_viptoggle ;

        }
        bool edit_vip =false;
        private void edit_search_Click(object sender, RoutedEventArgs e)
        {
            if(edit_procode==null)
            {
                edit_errors.Text = "first search code";
                edit_errors.Foreground = new System.Windows.Media.SolidColorBrush(Colors.DarkRed);
            }
            else
            {
                //امیر اینجا باید فیلد های محصول از دیتا بیس لود بشه
                //بعدش ادمین میتونه تغییرات مورد نظرش رو انجام بده و در آخر اپلای رو بزنه
                //edit_name.Text = "";
                //edit_writer.Text = "";
                //edit_cost.Text = "";
                //edit_detail.Text = "";
                //edit_printyear.Text = "";
                //edit_procode.Text = "";
               // edit_viptoggle = checked;
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
    }
}
