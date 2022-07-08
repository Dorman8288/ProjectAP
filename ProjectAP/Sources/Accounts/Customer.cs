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
        public string BookmarkToString()
        {
            string ans = "";
            foreach(var item in bookMarks)
            {
                ans += item.ID + ",";
            }
            return ans;
        }
        public string InventoryToString()
        {
            string ans = "";
            foreach (var item in inventory)
            {
                ans += item.ID + ",";
            }
            return ans;
        }
        public string CartToString()
        {
            string ans = "";
            foreach (var item in cart.allProducts)
            {
                ans += item.ID + ",";
            }
            return ans;
        }
        public void StringToBookmarks(string input)
        {
            string[] temp = input.Split(',');
            foreach (var item in temp)
            {
                if(item != "")
                {
                    Product product = DataManager.getAllProducts().Find(x => x.ID == int.Parse(item));
                    bookMarks.Add(product);
                }
            }
        }
        public void StringToInventory(string input)
        {
            string[] temp = input.Split(',');
            foreach (var item in temp)
            {
                if (item != "")
                {
                    Product product = DataManager.getAllProducts().Find(x => x.ID == int.Parse(item));
                    inventory.Add(product);
                }
            }
        }
        public void StringToCart(string input)
        {
            string[] temp = input.Split(',');
            foreach (var item in temp)
            {
                if (item != "")
                {
                    Product product = DataManager.getAllProducts().Find(x => x.ID == int.Parse(item));
                    cart.allProducts.Add(product);
                }
            }
        }
    }
}
