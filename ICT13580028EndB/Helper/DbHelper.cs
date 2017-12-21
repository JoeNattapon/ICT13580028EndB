using System;
using SQLite;
using ICT13580028EndB.Model;
using System.Collections.Generic;
using System.Linq;

namespace ICT13580028EndB.Helper
{
    public class DbHelper
    {
        SQLiteConnection db;

		public DbHelper(string dbPath)
		{
			db = new SQLiteConnection(dbPath);
			db.CreateTable<Product>();
		}

		public int AddProduct(Product product)
		{
			return db.Insert(product);
		}

		public List<Product> GetProducts()
		{
			return db.Table<Product>().ToList();
		}


		public int UpdateProduct(Product product)
		{
			return db.Update(product);
		}

		public int DeleteProduct(Product product)
		{
			return db.Delete(product);
		}
    }
}
