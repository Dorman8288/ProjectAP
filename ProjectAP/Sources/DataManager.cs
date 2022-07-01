using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectAP.Sources
{
    public static class DataManager
    {
        static List<Account> allAccounts = new List<Account>();
        static List<Product> allProducts = new List<Product>();
        public static Account getAccount(string email)
        {
            return allAccounts.Find(x => x.email == email);
        }
        public static void AddAccount(Account input)
        {
            allAccounts.Add(input);
        }
    }
}
