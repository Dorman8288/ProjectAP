using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectAP.Sources.Products
{
    class Book : Product
    {
        string _author;
        string imagePath;
        string author
        {
            get { return _author; }
            set { if (value == "") throw new Exception("Product name cannot be empty"); else _author = value; }
        }
        public Book(string name, int ID, double price, string description, string filePath, int rating, string author, string imagePath) : base(name, ID, price, description, filePath, rating)
        {
            this.author = author;
            this.imagePath = imagePath;
        }
    }
}
