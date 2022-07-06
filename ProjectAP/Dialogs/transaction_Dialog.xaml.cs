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
    /// Interaction logic for transaction_Dialog.xaml
    /// </summary>
    public partial class transaction_Dialog : Window
    {
        Customer ActiveAccount;
        double transactionValue;
        public bool transactionResult;
        public transaction_Dialog(double value, Customer ActiveAccount)
        {
            InitializeComponent();
            this.ActiveAccount = ActiveAccount;
            transactionValue = value;
            TransactionAmountText.Text = $"You should pay {transactionValue}";
            TransactionAmountText2.Text = $"You should pay {transactionValue}";
            WalletAmountText.Text = $"You have {ActiveAccount.balance} in your Wallet";
            if(ActiveAccount.balance >= transactionValue)
            {
                PayButton.IsEnabled = true;
            }
        }

        private void Accept_Transaction_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ActiveAccount.CardIsValid(CardNumber.Text, CVV2.Text, int.Parse(Year.Text), int.Parse(Month.Text)))
                {
                    transactionResult = true;
                    ActiveAccount.totalSell += transactionValue;
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

        private void PayButton_Click(object sender, RoutedEventArgs e)
        {
            ActiveAccount.balance -= transactionValue;
            transactionResult = true;
            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(ApplicationWindow))
                {
                    (window as ApplicationWindow).BalanceDisplay.Text = ActiveAccount.balance.ToString();
                }
            }
            Close();
        }
    }
}
