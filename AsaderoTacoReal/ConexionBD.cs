using System;
using System.Windows.Forms;

namespace AsaderoTacoReal
{
    public partial class ConexionBD : Form
    {
        public ConexionBD()
        {
            InitializeComponent();
        }
        private bool flag1;
        private void btnConectar_Click(object sender, EventArgs e)
        {
            try
            {
                Conexion.servidor = txtServidor.Text;
                Conexion.bd = txtBd.Text;
                Conexion.usuario = txtUsuario.Text;
                Conexion.password = txtPassword.Text;

                MessageBox.Show("Parámetros guardados");
                this.Visible = false;
                HUB hub = new HUB();
                hub.Visible = true;
                //Login login = new Login();
                //login.Visible = true;
                //new Menu().Visible = true;
                //new RegistrarUsuario().Visible = true;
            } catch (Exception ex)
            {
                MessageBox.Show("Verifique la información ingresada");
            }

        }
        private void ConexionBD_Load(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            flag1 = string.IsNullOrEmpty(txtPassword.Text) ? false : true;
            ValidarBoton();
        }

        private void ValidarBoton()
        {
            btnConectar.Enabled = flag1 ? true : false;
        }

    }
}
