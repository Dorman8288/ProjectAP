using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ProjectAP.Sources
{
    public class Product
    {
        string _name;
        public int ID { get; }
        int _rating;
        public int numOfRatings = 0;
        double _price;
        string _description;
        public string filePath { get; }
        double _discount;
        string _author;
        public string imagePath { get; }
        public bool isVip { get; } = false;
        public string author
        {
            get { return _author; }
            private set { if (value == "") throw new Exception("Product name cannot be empty"); else _author = value; }
        }
        public double discount
        {
            get { return _discount; }
            private set
            {
                if (!(0 < value && value <= 1)) throw new Exception("discount amount is invalid");
                else
                {
                    _discount = value;
                }
            }
        }
        public string name
        {
            get { return _name; }
            private set { if (value == "") throw new Exception("Product name cannot be empty"); else _name = value; }
        }
        public int rating 
        {
            get { return _rating; }
            private set { if (!(0 <= value && value <= 5)) throw new Exception("Rating should be between 0 and 5"); else _rating = value; }
        }
        public double price
        {
            get { return _price; }
            private set { if (value < 0) throw new Exception("Price should be Positive"); else _price = value; }
        }
        public string description
        {
            get { return _description; }
            private set { if (value == "") throw new Exception("Product name cannot be empty"); else _description = value; }
        }
        public void AddDiscount(int value)
        {
            discount = (double)value / 100;
        }
        public Product(string name, int ID, double price, string description, string filePath, int rating, string author, string imagePath, bool isVip)
        {
            this.name = name;
            this.ID = ID;
            this.price = price;
            this.description = description;
            this.filePath = filePath;
            this.rating = rating;
            this.author = author;
            this.imagePath = imagePath;
            this.isVip = isVip;
        }
        public double CalculatePrice()
        {
            return price * (1 - discount);
        }
        public void addRating(int value)
        {
            rating = ((rating * numOfRatings) + value) / (numOfRatings + 1);
            numOfRatings++;
        }
    }
}
