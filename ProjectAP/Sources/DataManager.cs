using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Windows;

namespace ProjectAP.Sources
{
    public static class DataManager
    {
        static List<Account> allAccounts = new List<Account>();
        static List<Product> allProducts = new List<Product>();
        public static Account getAccount(string email)
        {
            try
            {
                return allAccounts.Single(x => x.email == email);
            }
            catch
            {
                throw new Exception("No email found");
            }
        }
        public static void AddAccount(Account input)
        {
            if (allAccounts.Any(x => input.email == x.email)) throw new Exception("this email is registered");
            allAccounts.Add(input);
        }
        public static List<Product> getAllNonVipProducts()
        {
            MessageBox.Show(allProducts.Count().ToString());
            List<Product> ans = allProducts;
            foreach (var product in ans)
            {
                MessageBox.Show(product.isVip.ToString());
            }
            return allProducts.Where(x => x.isVip == false).ToList();
        }
        public static void AddProduct(Product input)
        {
            if (allProducts.Any(x => input.ID == x.ID)) throw new Exception("this ID is registered");
            allProducts.Add(input);
        }
        public static List<Product> getAllVIPProducts()
        {
            return allProducts.Where(x => x.isVip == false).ToList();
        }
    }
}
