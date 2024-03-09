using System;
using System.Windows.Forms;

namespace AsaderoTacoReal
{
    public partial class RegistrarUsuario : Form
    {
        public RegistrarUsuario()
        {
            InitializeComponent();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            Usuarios usuario = new Usuarios();
            usuario.Usuario = txtUsuario.Text;
            usuario.Password = txtPassword.Text;
            usuario.ConPassword = txtConPassword.Text;
            usuario.Nombre = txtNombre.Text;
            try
            {
                RegistrarUsuariosC registrar = new RegistrarUsuariosC();
                string respuesta = registrar.ctrlRegistro(usuario);

                if (respuesta.Length > 0)
                {
                    MessageBox.Show(respuesta, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Usuario registrado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    HUB hub = new HUB();
                    hub.Visible = true;
                    this.Visible = false;
                }
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

        }

        private void RegistrarUsuario_Load(object sender, EventArgs e)
        {

        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            HUB hub = new HUB();
            hub.Visible = true;
            this.Visible = false;
        }
    }
}
