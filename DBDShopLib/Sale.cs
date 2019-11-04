using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBDShopLib
{
    public class Sale
    {
        public int producto;
        public int pedido;
        public int cantidad;
        public double precio;
        public string fecha;
        public string cliente;

        public Sale(int idProducto,int idPedido,int pCantidad,double pPrecio,string pFecha,string pCliente)
        {
            producto = idProducto;
            pedido = idPedido;
            cantidad = pCantidad;
            precio = pPrecio;
            fecha = pFecha;
            cliente = pCliente;
        }
        public Sale(int idProducto, int idPedido, int pCantidad, double pPrecio)
        {
            producto = idProducto;
            pedido = idPedido;
            cantidad = pCantidad;
            precio = pPrecio;
            fecha = "";
            cliente = "";
        }
    }
}
