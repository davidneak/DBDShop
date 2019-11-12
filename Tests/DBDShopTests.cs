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
            Client client = new Client("NW0HSO5HO7", "NW0HSO5HO7", "ZEALzol3dN");
            Assert.IsTrue(client.checkConnection());
            /*
			m_connection = new MySqlConnection();
			m_connection.ConnectionString =
			"Server=myremotesql.com ;" +
			"database= NW0HSO5HO7;" +
			"UID=NW0HSO5HO7; " +
			"password=ZEALzol3dN;";
            //Check the connection
			Assert.IsTrue(m_connection.Open()=true);*/
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

            //Get product from BD
            client.GetProducts();
			

		}
        [TestMethod]
        public void SetPriceTest()
		{
			//Connect to the test database
			Client client = new Client("NW0HSO5HO7", "NW0HSO5HO7", "ZEALzol3dN");

            //Connect to BD
            /*m_connection = new MySqlConnection();
			m_connection.ConnectionString =
			"Server=myremotesql.com ;" +
			"database= NW0HSO5HO7;" +
			"UID=NW0HSO5HO7; " +
			"password=ZEALzol3dN;";
			m_connection.Open() = true;
            */

            //Get product from BD
            client.buyProduct(5,220,3,5);

			//Set price
			client.modificarPrecio(3.58, 23 );

            //Check if were correctly modify
            // Get product from BD
            client.GetProducts();

            //Delete test product
            //Assume producto and producto_pedido are correctly related and product reference in producto_pedido will be deleted on cascade
            int[] aids = {23};
            client.DeleteProducts(aids);
		}
    }
}
