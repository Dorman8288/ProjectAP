using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectAP.Sources.Accounts
{
    public class Admin : Account
    {
        public static double totalCash = 0;
        static double _VipAmount = 100;
        public static double VipAmount
        {
            get { return _VipAmount; }
            set { if (value < 0) throw new Exception("Price should be Positive"); else _VipAmount = value; }
        }
        public Admin(string name, string familyName, string email, string phoneNumber, string password) : base(name, familyName, email, phoneNumber, password) 
        {
        }
    }
}
