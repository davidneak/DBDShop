using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBDShopLib
{
    public class Product
    {
        public int idproducto = 0;
        public string descripcion = null;
        public int stock = 0;
        public Product(int id, string descripcion, int stock)
        {
            this.idproducto = id;
            this.descripcion = descripcion;
            this.stock = stock;
        }
    }
}
