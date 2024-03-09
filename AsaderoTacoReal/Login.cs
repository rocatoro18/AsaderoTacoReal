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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string Usuario = txtUsuario.Text;
            string Password = txtPassword.Text;

            try
            {
                RegistrarUsuariosC registrarUsuariosC = new RegistrarUsuariosC();
                string respuesta = registrarUsuariosC.ctrlLogin(Usuario,Password);
                if(respuesta.Length > 0)
                {
                    MessageBox.Show(respuesta,"Aviso",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                else
                {
                    Menu menu = new Menu();
                    menu.Visible = true;
                    this.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            HUB hub = new HUB();
            hub.Visible = true;
            this.Visible = false;
        }
    }
}
