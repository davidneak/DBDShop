using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DBDShopApp.Properties;
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

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form3 f1 = new Form3();
            f1.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<Producto> products = m_client.GetProducts();
            listBox1.Items.Clear();
            foreach (Producto    product in products)
            {
                listBox1.Items.Add(product.descripcion);
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }

    
}
