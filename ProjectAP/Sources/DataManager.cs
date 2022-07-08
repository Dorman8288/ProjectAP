using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Windows;
using System.Data.SqlClient;
using ProjectAP.Sources.Accounts;

namespace ProjectAP.Sources
{
    public static class DataManager
    {
        static SqlConnection connection = new SqlConnection("Server=localhost;Integrated security=SSPI;database=master;");
        static SqlCommand command;
        static string sql;
        static List<Account> allAccounts = new List<Account>();
        static List<Product> allProducts = new List<Product>();
        static List<Product> nonVip = new List<Product>();
        static List<Product> Vip = new List<Product>();
        public static void Initialize()
        {
            try
            {
                connection.Open();
                sql = "DROP DATABASE IF EXISTS[ProjectAP]; CREATE DATABASE[ProjectAP]";
                command = new SqlCommand(sql, connection);
                command.ExecuteNonQuery();

                StringBuilder sb = new StringBuilder();
                sb.Append("USE ProjectAP; ");
                sb.Append("IF NOT EXISTS");
                sb.Append("(");
                sb.Append("SELECT * FROM sysobjects WHERE name='Customers' AND xtype='U'");
                sb.Append(")");
                sb.Append("CREATE TABLE Customers(");
                sb.Append(" Email NVARCHAR(32) NOT NULL PRIMARY KEY, ");
                sb.Append(" FirstName NVARCHAR(32), ");
                sb.Append(" LastName NVARCHAR(32), ");
                sb.Append(" PhoneNumber NVARCHAR(11), ");
                sb.Append(" Password NVARCHAR(32), ");
                sb.Append(" Balance FLOAT, ");
                sb.Append(" TotalSell FLOAT, ");
                sb.Append(" VipExpiringDate NVARCHAR(40) ");
                sb.Append("); ");
                sql = sb.ToString();
                command = new SqlCommand(sql, connection);
                command.ExecuteNonQuery();

                sb.Clear();
                sb.Append("USE ProjectAP; ");
                sb.Append("IF NOT EXISTS");
                sb.Append("(");
                sb.Append("SELECT * FROM sysobjects WHERE name='Products' AND xtype='U'");
                sb.Append(")");
                sb.Append("CREATE TABLE Products(");
                sb.Append(" ID INT NOT NULL PRIMARY KEY, ");
                sb.Append(" Name NVARCHAR(32), ");
                sb.Append(" Description NTEXT, ");
                sb.Append(" Author NVARCHAR(32), ");
                sb.Append(" Price FLOAT, ");
                sb.Append(" TotalSell FLOAT, ");
                sb.Append(" Rating INT, ");
                sb.Append(" NumberOfRating INT, ");
                sb.Append(" IsVip BIT, ");
                sb.Append(" ImagePath NTEXT, ");
                sb.Append(" FilePath NTEXT, ");
                sb.Append(" Discount FLOAT, ");
                sb.Append("); ");
                sql = sb.ToString();
                command = new SqlCommand(sql, connection);
                command.ExecuteNonQuery();

                sb.Clear();
                sb.Append("USE ProjectAP; ");
                sb.Append("IF NOT EXISTS");
                sb.Append("(");
                sb.Append("SELECT * FROM sysobjects WHERE name='Container' AND xtype='U'");
                sb.Append(")");
                sb.Append("CREATE TABLE Container(");
                sb.Append(" Email NVARCHAR(32) NOT NULL PRIMARY KEY, ");
                sb.Append(" Inventory NTEXT, ");
                sb.Append(" Cart NTEXT, ");
                sb.Append(" Bookmarks NTEXT");
                sb.Append("); ");
                sql = sb.ToString();
                command = new SqlCommand(sql, connection);
                command.ExecuteNonQuery();
            }
            catch(SqlException e){
                MessageBox.Show(e.Message, "error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public static void Save()
        {
            try
            {
                Initialize();
                SaveCustomers();
                SaveProducts();
                SaveRelations();
                connection.Close();
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message, "error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public static void SaveRelations()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT Container (Email, Inventory, Cart, Bookmarks) ");
            sb.Append("VALUES (@email, @inventory, @cart, @bookmark);");
            sql = sb.ToString();
            command = new SqlCommand(sql, connection);
            foreach (var account in allAccounts)
            {
                if (account is Customer)
                {
                    Customer customer = account as Customer;
                    command.Parameters.AddWithValue("@email", customer.email);
                    command.Parameters.AddWithValue("@inventory", customer.InventoryToString());
                    command.Parameters.AddWithValue("@cart", customer.CartToString());
                    command.Parameters.AddWithValue("@bookmark", customer.BookmarkToString());
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                }
            }
        }
        public static void SaveCustomers()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT Customers (Email, FirstName, LastName, PhoneNumber, Password, Balance, TotalSell, VipExpiringDate) ");
            sb.Append("VALUES (@email, @firstName, @lastName, @phoneNumber, @password, @balance, @totalSell, @vipExpiringDate);");
            sql = sb.ToString();
            command = new SqlCommand(sql, connection);
            foreach (var account in allAccounts)
            {
                if (account is Customer)
                {
                    Customer customer = account as Customer;
                    command.Parameters.AddWithValue("@email", customer.email);
                    command.Parameters.AddWithValue("@firstName", customer.name);
                    command.Parameters.AddWithValue("@lastName", customer.familyName);
                    command.Parameters.AddWithValue("@phoneNumber", customer.phoneNumber);
                    command.Parameters.AddWithValue("@password", customer.password);
                    command.Parameters.AddWithValue("@balance", customer.balance);
                    command.Parameters.AddWithValue("@totalSell", customer.totalSell);
                    command.Parameters.AddWithValue("@vipExpiringDate", customer.VIPExpieringDate.ToString());
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                }
            }
        }
        public static void SaveProducts()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT Products (ID, Name, Description, Author, Price, TotalSell, Rating, NumberOfRating, IsVip, ImagePath, FilePath, Discount) ");
            sb.Append("VALUES (@ID, @name, @description, @author, @price, @totalSell, @rating, @numberOfRating, @isVip, @imagePath, @filePath, @discount);");
            sql = sb.ToString();
            command = new SqlCommand(sql, connection);
            foreach (var product in allProducts)
            {
                command.Parameters.AddWithValue("@ID", product.ID);
                command.Parameters.AddWithValue("@name", product.name);
                command.Parameters.AddWithValue("@description", product.description);
                command.Parameters.AddWithValue("@author", product.author);
                command.Parameters.AddWithValue("@price", product.price);
                command.Parameters.AddWithValue("@totalSell", product.totalSell);
                command.Parameters.AddWithValue("@rating", product.rating);
                command.Parameters.AddWithValue("@numberOfRating", product.numOfRatings);
                command.Parameters.AddWithValue("@isVip", product.isVip);
                command.Parameters.AddWithValue("@imagePath", product.imagePath);
                command.Parameters.AddWithValue("@filePath", product.filePath);
                command.Parameters.AddWithValue("@discount", product.discount);
                
                command.ExecuteNonQuery();
                command.Parameters.Clear();
            }
        }
        public static void Load()
        {
            LoadCustomers();
            LoadProducts();
            LoadRelations();
            connection.Close();
        }
        public static void LoadCustomers()
        {
            sql = "USE ProjectAP; SELECT Email, FirstName, LastName, PhoneNumber, Password, Balance, TotalSell, VipExpiringDate FROM Customers;";
            connection.Open();
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Customer newCustomer = new Customer(reader.GetString(1), reader.GetString(2), reader.GetString(0), reader.GetString(3), reader.GetString(4), DateTime.Parse(reader.GetString(7)));
                        AddAccount(newCustomer);
                        newCustomer.balance = reader.GetDouble(5);
                        newCustomer.totalSell = reader.GetDouble(6);
                    }
                }
            }
            connection.Close();
        }
        public static void LoadProducts()
        {
            sql = "USE ProjectAP; SELECT ID, Name, Description, Author, Price, TotalSell, Rating, NumberOfRating, IsVip, ImagePath, FilePath, Discount FROM Products;";
            connection.Open();
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Product newProduct = new Product(reader.GetString(1), reader.GetInt32(0), reader.GetDouble(4), reader.GetString(2), reader.GetString(10), reader.GetInt32(6), reader.GetString(3), reader.GetString(9), reader.GetBoolean(8));
                        AddProduct(newProduct);
                        newProduct.totalSell = reader.GetDouble(5);
                        newProduct.numOfRatings = reader.GetInt32(7);
                        newProduct.discount = reader.GetDouble(11);
                    }
                }
            }
            connection.Close();
        }
        public static void LoadRelations()
        {
            sql = "USE ProjectAP; SELECT Email, Inventory, Cart, Bookmarks FROM Container;";
            connection.Open();
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Customer account = getAccount(reader.GetString(0)) as Customer;
                        account.StringToInventory(reader.GetString(1));
                        account.StringToCart(reader.GetString(2));
                        account.StringToBookmarks(reader.GetString(3));
                    }
                }
            }
            connection.Close();
        }
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
        public static List<Product> getAllProducts()
        {
            return allProducts;
        }
        public static List<Product> getAllNonVipProducts()
        {
            return nonVip;
        }
        public static void AddProduct(Product input)
        {
            if (allProducts.Any(x => input.ID == x.ID)) throw new Exception("this ID is registered");
            allProducts.Add(input);
            if (input.isVip)
                Vip.Add(input);
            else
                nonVip.Add(input);
        }
        public static List<Product> getAllVIPProducts()
        {
            return Vip;
        }
    }
}
