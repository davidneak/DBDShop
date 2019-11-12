using DBDShopLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBDShopApp.Properties
{
    public partial class Form3 : Form
    {
        Client c;

        public Form3()
        {
            InitializeComponent();

            c = new Client("NW0HSO5HO7", "NW0HSO5HO7", "ZEALzol3dN");
            textBox1.Text = "Escribir parametros";
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string precio = "", id = "";
       
            int i = 0;

            
                while (char.IsDigit(textBox1.Text[i]))
                {
                    precio += textBox1.Text[i];
                    i++;
                }
                
                if (!char.IsDigit(textBox1.Text[i]))
                {
                    i++;
                }
                while (i < textBox1.Text.Length && char.IsDigit(textBox1.Text[i]))
                {
                    id += textBox1.Text[i];
                    i++;
                }
              
            double p = double.Parse(precio);
            int cod = int.Parse(id);

            c.modificarPrecio(p, cod);

        }
    }
}
