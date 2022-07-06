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

namespace ProjectAP.Dialogs
{
    /// <summary>
    /// Interaction logic for ChargeWalletDialog.xaml
    /// </summary>
    public partial class ChargeWalletDialog : Window
    {
        public bool transactionResult;
        Customer ActiveAccount;
        public ChargeWalletDialog(Customer ActiveAccount)
        {
            InitializeComponent();
            this.ActiveAccount = ActiveAccount;
        }
        private void Accept_Transaction_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ActiveAccount.CardIsValid(CardNumber.Text, CVV2.Text, int.Parse(Year.Text), int.Parse(Month.Text)))
                {
                    ActiveAccount.AddBalance(double.Parse(Amount.Text));
                    foreach (Window window in Application.Current.Windows)
                    {
                        if (window.GetType() == typeof(ApplicationWindow))
                        {
                            (window as ApplicationWindow).BalanceDisplay.Text = ActiveAccount.balance.ToString();
                        }
                    }
                    transactionResult = true;
                    Close();
                }
                else
                {
                    information.Foreground = Brushes.Red;
                    information.Text = "Your Card Information is not valid!";
                }
            }
            catch
            {
                information.Foreground = Brushes.Red;
                information.Text = "Your Card Information is not valid!";
            }
        }

        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            transactionResult = false;
            Close();
        }
    }
}
