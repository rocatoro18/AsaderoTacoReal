using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsaderoTacoReal
{
    public partial class Menu : Form
    {
        protected int tipo_usuario;
        public Menu()
        {
            InitializeComponent();
            tipo_usuario = Sesion.id_tipo;
        }

        HUB _hub;
        AdminSucursales _sucursales;
        AdminPersonal _personal;
        AdminProductos _productos;
        AdminVentas _ventas;
        Ayuda _Ayuda;

        ReporteDeVentas _ReporteDeVentas;
        ReporteDeInventario _ReporteDeInventario;
        ReporteDePersonal _ReporteDePersonal;
        ReporteDeSucursales _ReporteDeSucursales;

        private void Menu_Load(object sender, EventArgs e)
        {
            this.statusBarPanel1.Text = DateTime.Now.ToLongDateString().ToUpper();
            this.statusBarPanel2.Text = "Bienvenido " + Sesion.nombre;
            timer1.Start();
            if (tipo_usuario == 1)
            {
                this.sucursalesToolStripMenuItem.Enabled = true;
                this.empleadosToolStripMenuItem.Enabled = true;
                this.reporteDeVentasToolStripMenuItem.Enabled = true;
            }
            else
            {
                this.sucursalesToolStripMenuItem.Enabled = false;
                this.empleadosToolStripMenuItem.Enabled = false;
                this.reporteDeVentasToolStripMenuItem.Enabled = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
            this.statusBarPanel3.Text = DateTime.Now.ToLongTimeString();
        }

        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show(this, "¿Desea cerrar la sesión?", "Pregunta", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            if (dr == DialogResult.Yes)
            {
                Sesion sesion = new Sesion();
                this.Hide();
                _hub = new HUB();
                _hub.Visible = true;
            }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show(this, "¿Desea cerrar la aplicación?", "Pregunta", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (dr == DialogResult.Yes)
            {
                this.Dispose();
            }
        }

        private void InicializaMDI(Form F)
        {
            F.MdiParent = this;
            F.Show();
        }

        private void sucursal1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _sucursales = new AdminSucursales();
            this.Text = _sucursales.Text;
            InicializaMDI(_sucursales);
        }

        private void personalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _personal = new AdminPersonal();
            this.Text = _personal.Text;
            InicializaMDI(_personal);
        }

        private void reporteDeVentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            _ReporteDeVentas = new ReporteDeVentas();
            this.Text = _ReporteDeVentas.Text;
            InicializaMDI(_ReporteDeVentas);
            
        }

        private void reporteDeInventarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            _ReporteDeInventario = new ReporteDeInventario();
            this.Text = _ReporteDeInventario.Text;
            InicializaMDI(_ReporteDeInventario);
            
        }

        private void ayudaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _Ayuda = new Ayuda();
            this.Text = _Ayuda.Text;
            InicializaMDI(_Ayuda);
        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _productos = new AdminProductos();
            this.Text = _productos.Text;
            InicializaMDI(_productos);
        }

        private void administradorDeVentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ventas = new AdminVentas();
            this.Text = _ventas.Text;
            InicializaMDI(_ventas);
        }

        private void Menu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void reporteDePersonalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ReporteDePersonal = new ReporteDePersonal();
            this.Text = _ReporteDePersonal.Text;
            InicializaMDI(_ReporteDePersonal);
        }

        private void reporteDeSucursalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ReporteDeSucursales = new ReporteDeSucursales();
            this.Text = _ReporteDeSucursales.Text;
            InicializaMDI(_ReporteDeSucursales);
        }
    }
}
