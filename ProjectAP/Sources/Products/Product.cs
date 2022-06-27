using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ProjectAP.Sources.Products
{
    class Product
    {
        string _name;
        int ID;
        int _rating;
        double _price;
        string _description;
        string filePath;

        string name
        {
            get { return _name; }
            set { if (value == "") throw new Exception("Product name cannot be empty"); else _name = value; }
        }
        int rating 
        {
            get { return _rating; }
            set { if (!(0 <= value && value <= 5)) throw new Exception("Rating should be between 0 and 5"); else _rating = value; }
        }
        double price
        {
            get { return _price; }
            set { if (value < 0) throw new Exception("Price should be Positive"); else _price = value; }
        }
        string description
        {
            get { return _description; }
            set { if (value == "") throw new Exception("Product name cannot be empty"); else _description = value; }
        }
        public Product(string name, int ID, double price, string description, string filePath, int rating)
        {
            this.name = name;
            this.ID = ID;
            this.price = price;
            this.description = description;
            this.filePath = filePath;
            this.rating = rating;
        }
    }
}
