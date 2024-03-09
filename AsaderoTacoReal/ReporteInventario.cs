using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsaderoTacoReal
{
    class ReporteInventario
    {
        private string codigo;
        private string nombre;
        private string descripcion;
        private double precio;
        private int existencias;
        private int sucursal;

        public ReporteInventario()
        {

        }

        public string Codigo { get => codigo; set => codigo = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public double Precio { get => precio; set => precio = value; }
        public int Existencias { get => existencias; set => existencias = value; }
        public int Sucursal { get => sucursal; set => sucursal = value; }
    }
}
