using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DBDShopLib;
using System.Collections.Generic;


namespace Tests
{
    [TestClass]
    public class DBDShopTests
    {
        [TestMethod]
        public void AddAndTestData()
        {
            //Connect to the test database
            Client client= new Client("NW0HSO5HO7", "NW0HSO5HO7", "ZEALzol3dN");
            //Get all the existing products
            List<Producto> products = client.GetProducts();
            //Delete all the products
            client.DeleteProducts(products);
            //Check we deleted all the products
            products = client.GetProducts();
            Assert.IsTrue(products.Count == 0);

            //Insert test data
            client.InsertTestData();
            //Check they were correctly inserted
            products= client.GetProducts();
            Assert.IsTrue(products.Count == 2);
        }
        [TestMethod]
        public void ConnectionBDTest()
		{
			m_connection = new MySqlConnection();
			m_connection.ConnectionString =
			"Server=myremotesql.com ;" +
			"database= NW0HSO5HO7;" +
			"UID=NW0HSO5HO7; " +
			"password=ZEALzol3dN;";
            //Check the connection
			Assert.IsTrue(m_connection.Open()=true);
		}
        [TestMethod]
        public void InsertProductTest()
        {
			//Connect to the test database
			Client client = new Client("NW0HSO5HO7", "NW0HSO5HO7", "ZEALzol3dN");
			//Get all the existing products
			List<Producto> products = client.GetProducts();
			//Delete all the products
			client.DeleteProducts(products);
			//Insert a product
			client.insertProduct(24, "Manzana", 3);
			//Connect to BD
			m_connection = new MySqlConnection();
			m_connection.ConnectionString =
			"Server=myremotesql.com ;" +
			"database= NW0HSO5HO7;" +
			"UID=NW0HSO5HO7; " +
			"password=ZEALzol3dN;";
			m_connection.Open() = true;

            //Get product from BD
			string query = "SELECT * FROM producto";
			MySqlCommand cmd = new MySqlCommand(query, m_connection);
			MySqlDataReader reader = cmd.ExecuteReader();
			while (reader.Read())
			{
                //Check if is the same product
				Assert.IsTrue(int.Parse(reader.GetValue(0).ToString())=24);
				Assert.IsTrue(reader.GetValue(1).ToString()="Manzana");
				Assert.IsTrue(int.Parse(reader.GetValue(2).ToString())=3);
				
			}
			reader.Close();
			

		}
        [TestMethod]
        public void SetPriceTest()
		{
			//Connect to the test database
			Client client = new Client("NW0HSO5HO7", "NW0HSO5HO7", "ZEALzol3dN");
			//Connect to BD
			m_connection = new MySqlConnection();
			m_connection.ConnectionString =
			"Server=myremotesql.com ;" +
			"database= NW0HSO5HO7;" +
			"UID=NW0HSO5HO7; " +
			"password=ZEALzol3dN;";
			m_connection.Open() = true;

			//Get product from BD
			string query = "INSERT INTO producto_pedido VALUES (23, 12, 3, 6.25)";
			MySqlCommand cmd = new MySqlCommand(query, m_connection);
			cmd.ExecuteNonQuery();

			//Set price
			client.modificarPrecio(3.58, 23 );

			//Check if were correctly modify
			// Get product from BD
			query = "SELECT precio FROM producto_pedido WHERE producto = 23 AND pedido = 12";
			MySqlCommand cmd = new MySqlCommand(query, m_connection);
			MySqlDataReader reader = cmd.ExecuteReader();
			while (reader.Read())
			{
				//Check if is the same price
				Assert.IsTrue(float.Parse(reader.GetValue(0).ToString())=3.58);
				

			}
			reader.Close();

			//Delete test product
			query = "DELETE FROM producto_pedido WHERE producto=23 AND pedido=12";
			MySqlCommand cmd = new MySqlCommand(query, m_connection);
			cmd.ExecuteNonQuery();

		}
    }
}
