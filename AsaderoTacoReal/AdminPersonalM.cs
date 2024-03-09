using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsaderoTacoReal
{
    class AdminPersonalM
    {
        private int id;
        private string codigo;
        private string nombre;
        private string apellidos;
        private int edad;
        private string rol;
        private string sucursal;
        private string rfc;
        private string telefono;
        private string correo;

        public int Id { get => id; set => id = value; }
        public string Codigo { get => codigo; set => codigo = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellidos { get => apellidos; set => apellidos = value; }
        public int Edad { get => edad; set => edad = value; }
        public string Rol { get => rol; set => rol = value; }
        public string Sucursal { get => sucursal; set => sucursal = value; }
        public string Rfc { get => rfc; set => rfc = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Correo { get => correo; set => correo = value; }

    }
}
