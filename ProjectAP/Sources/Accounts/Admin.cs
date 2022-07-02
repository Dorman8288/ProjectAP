using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectAP.Sources.Accounts
{
    class Admin : Account
    {
        public Admin(string name, string familyName, string email, string phoneNumber, string password) : base(name, familyName, email, phoneNumber, password) 
        { 
        }
    }
}
