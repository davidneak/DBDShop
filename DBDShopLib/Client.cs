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
    }
}
