using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBDShopLib
{
    public class Purchase
    {
        int idProd;
        string fecha;
        float precio;
        int cantidad;
        public Purchase(int id, string date, float price, int ammount)
        {
            idProd = id;
            fecha = date;
            precio = price;
            cantidad = ammount;
        }
    }
}
