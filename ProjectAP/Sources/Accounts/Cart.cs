using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectAP.Sources.Accounts
{
    class Cart
    {
        public List<Product> allProducts { get; } = new List<Product>();
        public void AddToCart(params Product[] input)
        {
            foreach(var item in input)
                allProducts.Add(item);
        }
        public double CalculatePrice()
        {
            double sum = 0;
            foreach(var item in allProducts)
            {
                sum += item.CalculatePrice();
            }
            return sum;
        }
        public void remove(Product input)
        {
            allProducts.Remove(input);
        }
        public void Reset()
        {
            allProducts.Clear();
        }
    }
}
