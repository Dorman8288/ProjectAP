using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectAP.Sources.Accounts
{
    public class Customer : Account
    {
        double _balance;
        public List<Product> inventory { get; } = new List<Product>();
        public List<Product> bookMarks { get; } = new List<Product>();
        public Cart cart { get; } = new Cart();
        public DateTime VIPExpieringDate;
        double balance
        {
            get { return balance; }
            set { if (value < 0) throw new Exception("balanace cant be negetive"); else _balance = value; }
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
        public void CheckOut()
        {
            balance -= cart.CalculatePrice();
            inventory.AddRange(cart.allProducts);
            cart.Reset();
        }
    }
}
