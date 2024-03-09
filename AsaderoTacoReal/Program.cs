using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsaderoTacoReal
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Splash()); 
            //Application.Run(new ConexionBD());
            //Application.Run(new AdminProductos());
            //Application.Run(new AdminSucursales());
            //Application.Run(new AdminPersonal());
            //Application.Run(new AdminVentas());
        }
    }
}
