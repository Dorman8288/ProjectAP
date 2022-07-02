using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

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
            if (allAccounts.Any(x => input.email == x.email)) throw new Exception("this email is registered");
            allAccounts.Add(input);
        }
    }
}
