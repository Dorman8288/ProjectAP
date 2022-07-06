using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace ProjectAP.Sources.Accounts
{
    public class Customer : Account
    {
        double _balance;
        double _totalSell = 0;
        public List<Product> inventory { get; } = new List<Product>();
        public List<Product> bookMarks { get; } = new List<Product>();
        public Cart cart { get; } = new Cart();
        public DateTime VIPExpieringDate;
        public double balance
        {
            get { return _balance; }
            set { if (value < 0) throw new Exception("balanace cant be negetive"); else _balance = value; }
        }
        public double totalSell
        {
            get { return _totalSell; }
            set { if (value < 0) throw new Exception("balanace cant be negetive"); else _totalSell = value; }
        }
        public Customer(string name, string familyName, string email, string phoneNumber, string password) : base(name, familyName, email, phoneNumber, password)
        {
            VIPExpieringDate = DateTime.Now;
        }
        public Customer(string name, string familyName, string email, string phoneNumber, string password ,DateTime VIP) : base(name, familyName, email, phoneNumber, password)
        {
            VIPExpieringDate = VIP;
        }
        public void AddBalance(double value)
        {
            balance += value;
        }
        public bool HaveVip()
        {
            return DateTime.Now < VIPExpieringDate;
        }
        public void AddVip(int month)
        {
            VIPExpieringDate = VIPExpieringDate.AddMonths(month);
        }
        public void CheckOut()
        {
            balance -= cart.CalculatePrice();
            inventory.AddRange(cart.allProducts);
            cart.Reset();
        }
    }
}
