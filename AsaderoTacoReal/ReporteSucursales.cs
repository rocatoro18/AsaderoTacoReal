﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsaderoTacoReal
{
    class ReporteSucursales
    {
        private string codigo;
        private string nombre;
        private string direccion;
        private string telefono;
        private string encargado;

        public string Codigo { get => codigo; set => codigo = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Encargado { get => encargado; set => encargado = value; }
    }
}
