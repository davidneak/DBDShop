using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace DBDShopLib
{
    public class Client
    {
        MySqlConnection m_connection = null;

        public Client(string databasename, string username, string password, string server= "remotemysql.com")
        {
            m_connection = new MySqlConnection();
            m_connection.ConnectionString =
            "Server=" + server + ";" +
            "database=" + databasename + ";" +
            "UID=" + username + ";" +
            "password=" + password + ";";
            m_connection.Open();
        }

        public void InsertTestData()
        {
            string query = "INSERT INTO producto VALUES(1,'Nocilla',50);";
            MySqlCommand cmd = new MySqlCommand(query, m_connection);
            cmd.ExecuteNonQuery();
            query = "INSERT INTO producto VALUES(2,'Patata',30);";
            cmd = new MySqlCommand(query, m_connection);
            cmd.ExecuteNonQuery();
        }
        
        public List<Producto> GetProducts()
        {
            List<Producto> products = new List<Producto>();

            string query = "SELECT * FROM producto";
            MySqlCommand cmd = new MySqlCommand(query, m_connection);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                
                int id= int.Parse(reader.GetValue(0).ToString());
                string description = reader.GetValue(1).ToString();
                int stock = int.Parse(reader.GetValue(2).ToString());
                Producto product = new Producto(id,description,stock);
                products.Add(product);
            }
            reader.Close();
            return products;
        }
        public List<Producto> GetOutOfStockProducts()
        {
            List<Producto> products = GetProducts();
            List<Producto> outOfStock = new List<Producto>();
            foreach(Producto product in products)
            {
                if(product.stock == 0)
                {
                    outOfStock.Add(product);
                }
            }
            return outOfStock;
        }
        public void insertProduct(int id, string descripcion, int stock)
        {
            string query = "INSERT INTO producto VALUES(@id, @descripcion, @stock)";
            MySqlCommand cmd = new MySqlCommand(query, m_connection);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@descripcion", descripcion);
            cmd.Parameters.AddWithValue("@stock", stock);
            cmd.ExecuteNonQuery();
        }

        public void DeleteProducts(List<Producto> products)
        {
            foreach(Producto product in products)
            {
                string query = "DELETE FROM producto WHERE Id =" + product.idproducto + ";";
                MySqlCommand cmd = new MySqlCommand(query, m_connection);
                cmd.ExecuteNonQuery();
            }
        }

        public void modificarPrecio(double precio, int id)
        {
            string query = " update producto_pedido set precio = " + precio + " where producto = " + id + ";";
            MySqlCommand cmd = new MySqlCommand(query, m_connection);
            cmd.ExecuteNonQuery();
        }

        public void buyProduct(int product, int ammount, string source)
        {

            string query = "INSERT INTO compras VALUES(SELECT precio from producto_distribuidor WHERE codproducto = " + product + "AND iddistribuidor = " + source + ",NOW()," + product + "," + ammount + ");";
            MySqlCommand cmd = new MySqlCommand(query, m_connection);
            cmd.ExecuteNonQuery();
            query = "UPDATE producto SET stock = stock + " + ammount + " WHERE idproducto = " + product + ");";
            cmd = new MySqlCommand(query, m_connection);
            cmd.ExecuteNonQuery();
        }

        public void sellProduct(int product, int ammount, string buyer)
        {

            int enStock = 0;
            string query = "SELECT stock FROM producto WHERE idproducto = " + product + ";";
            MySqlCommand cmd = new MySqlCommand(query, m_connection);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                enStock = int.Parse(reader.GetValue(0).ToString());
            }
            reader.Close();
            if (enStock >= ammount)
            {
                query = "UPDATE producto SET stock = stock - " + ammount + " WHERE idproducto = " + product + ");";
                cmd = new MySqlCommand(query, m_connection);
                cmd.ExecuteNonQuery();
            }
        }

        public List<Producto> getPurchases()
        {
            //WIP
            int precio = 0;
            string fecha = "";
            int producto = 0;
            int cantidad = 0;
            string query = "SELECT * FROM compras;";
            MySqlCommand cmd = new MySqlCommand(query, m_connection);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                precio = int.Parse(reader.GetValue(0).ToString());
                fecha = reader.GetValue(1).ToString();
                producto = int.Parse(reader.GetValue(2).ToString());
                cantidad = int.Parse(reader.GetValue(3).ToString());

            }
            reader.Close();
            return new List<Producto>();
        }

        public List<Sale> GetSales()
        {
            int prod = 0;
            int pedido = 0;
            int cantidad = 0;
            double precio = 0;
            string fecha = "";
            string cliente = "";
            List<Sale> sales = new List<Sale>();

            string query = "SELECT pedido,producto,cantidad,precio,fecha,idcliente FROM NW0HSO5HO7.producto_pedido INNER JOIN (SELECT * FROM pedido INNER JOIN pedido_cliente ON pedido.idpedido = pedido_cliente.codpedido) AS T ON producto_pedido.pedido = idpedido;";
            MySqlCommand cmd = new MySqlCommand(query, m_connection);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                prod = int.Parse(reader.GetValue(0).ToString());
                pedido = int.Parse(reader.GetValue(1).ToString());
                pedido = int.Parse(reader.GetValue(0).ToString());
                prod = int.Parse(reader.GetValue(1).ToString());
                cantidad = int.Parse(reader.GetValue(2).ToString());
                precio = double.Parse(reader.GetValue(3).ToString());
                fecha = reader.GetValue(4).ToString();
                cliente = reader.GetValue(5).ToString();
                Sale sale = new Sale(prod, pedido, cantidad, precio);
                sales.Add(sale);
            }
            reader.Close();
            return sales;
        }
    }
}
