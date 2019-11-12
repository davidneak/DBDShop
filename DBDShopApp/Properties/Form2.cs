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



public partial class Form2 : Form
    {
        Client c;

        public Form2()
        {
            InitializeComponent();

            c = new Client("NW0HSO5HO7", "NW0HSO5HO7", "ZEALzol3dN");
            textBox1.Text = "Introducir parametros";
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
            
     
        }
        private void button1_Click(object sender, EventArgs e)
        {
            List<Producto> productos = c.GetOutOfStockProducts();

            listBox1.Items.Clear();
            foreach (Producto product in productos)
            {
             listBox1.Items.Add(product.descripcion);
            }
        
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string descripcion = "", id = "", stock = "";

            int i = 0;
            while (char.IsDigit(textBox1.Text[i]))
            {
                id += textBox1.Text[i];
                i++;
            }
            if (!char.IsDigit(textBox1.Text[i]))
                i++;
            while (char.IsLetter(textBox1.Text[i]))
            {
                descripcion += textBox1.Text[i];
                i++;
            }
            if (!char.IsDigit(textBox1.Text[i]))
                i++;
            while (i < textBox1.Text.Length && char.IsDigit(textBox1.Text[i]))
            {   
                stock += textBox1.Text[i];
                i++;
            }


            int s = int.Parse(stock);
            int cod = int.Parse(id);
            c.insertProduct(cod, descripcion, s);

    }
    private void button3_Click(object sender, EventArgs e)
        {

        }
}

