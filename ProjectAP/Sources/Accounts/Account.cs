using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ProjectAP.Sources
{
    public class Account
    {
        string _name;
        string _familyName;
        string _email;
        string _phoneNumber;
        string _password;
        public string name
        {
            get { return _name; }
            set
            {
                if (!Regex.IsMatch(value, @"^[A-Za-z]{3,32}$")) throw new Exception("FirstName is not in the correct format");
                _name = value;
            }
        }
        public string familyName
        {
            get { return _familyName; }
            set
            {
                if (!Regex.IsMatch(value, @"^[A-Za-z]{3,32}$")) throw new Exception("LastName is not in the correct format");
                _familyName = value;
            }
        }
        public string email
        {
            get { return _email; }
            set
            {
                if (!Regex.IsMatch(value, @"^\w{1,32}@\w{1,32}\.\w{1,32}$")) throw new Exception("email is not in the correct format");
                _email = value;
            }
        }
        public string phoneNumber
        {
            get { return _phoneNumber; }
            set
            {
                if (!Regex.IsMatch(value, @"^09\d{9}$")) throw new Exception("phone number is not in the correct format");
                _phoneNumber = value;
            }
        }
        public string password
        {
            get { return _password; }
            set
            {
                if (!Regex.IsMatch(value, @"^(?=.*[a-z])(?=.*[A-Z]).{8,40}$")) throw new Exception("Password is not in the correct format");
                _password = value;
            }
        }
        public Account(string name, string familyName, string email, string phoneNumber, string password)
        {
            this.name = name;
            this.familyName = familyName;
            this.email = email;
            this.phoneNumber = phoneNumber;
            this.password = password;
        }
        public bool CardIsValid(string cardNumber, string CVV2, int year, int month) => CardDateIsValid(year, month) && CardCVV2IsValid(CVV2) && CardNumberIsValid(cardNumber);
        //utility
        bool CardDateIsValid(int year, int month)
        {
            if (DateTime.Now.Year == year) return DateTime.Now.Month <= month;
            else return DateTime.Now.Year <= year;
        }
        bool CardCVV2IsValid(string CVV2) => Regex.IsMatch(CVV2, @"^\d{3,4}$");
        public static bool CardNumberIsValid(string cardNumber)
        {
            if (!Regex.IsMatch(cardNumber, @"^\d{16}$")) return false;
            //luhn algorithm
            int product = 0;
            for(int i = 0; i < cardNumber.Length; i++)
            {
                int step;
                if(i % 2 == 0) 
                    step = 2 * (cardNumber[i] - 48);
                else 
                    step = 1 * (cardNumber[i] - 48);

                if (step >= 10) step = (step / 10) + (step % 10);

                product += step;
            }
            return product % 10 == 0;
        }
    }
}
