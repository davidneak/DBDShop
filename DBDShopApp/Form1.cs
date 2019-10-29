using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DBDShopLib;

namespace DBDShopApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            m_client = new Client("NW0HSO5HO7", "NW0HSO5HO7", "ZEALzol3dN");
            textBox1.Text = "Connected to database";
        }

        Client m_client;

        private void button2_Click(object sender, EventArgs e)
        {
            m_client.InsertTestData();
            textBox1.Text = "Test data inserted in the database";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<Producto> products = m_client.GetProducts();
            listBox1.Items.Clear();
            foreach (Producto product in products)
            {
                listBox1.Items.Add(product.descripcion);
            }
        }
    }
}
