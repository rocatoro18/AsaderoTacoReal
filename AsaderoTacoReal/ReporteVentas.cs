using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsaderoTacoReal
{
    class ReporteVentas
    {
        private string codigo;
        private string producto;
        private int cantidad;
        private double precio;
        private double precio_total;
        private string fecha;
        private int sucursal;

        public string Codigo { get => codigo; set => codigo = value; }
        public string Producto { get => producto; set => producto = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public double Precio { get => precio; set => precio = value; }
        public double Precio_total { get => precio_total; set => precio_total = value; }
        public string Fecha { get => fecha; set => fecha = value; }
        public int Sucursal { get => sucursal; set => sucursal = value; }
    }
}
