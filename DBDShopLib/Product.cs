using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBDShopLib
{
    public class Producto
    {
        public int idproducto = 0;
        public string descripcion = null;
        public int stock = 0;

        public Producto(int id, string descripcion, int stock)
        {
            this.idproducto = id;
            this.descripcion = descripcion;
            this.stock = stock;
        }
    }
}
