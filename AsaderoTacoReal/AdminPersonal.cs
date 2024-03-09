using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace AsaderoTacoReal
{
    public partial class AdminPersonal : Form
    {
        public AdminPersonal()
        {
            InitializeComponent();
        }

        private bool flag1, flag2, flag3, flag4, flag5, flag6, flag7, flag8, flag9;

        private void AdminPersonal_Load(object sender, EventArgs e)
        {
            cargarTabla(null);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string dato = txtCampo.Text;
            cargarTabla(dato);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                bool bandera = false;
                AdminPersonalM _personal = new AdminPersonalM();
                _personal.Codigo = txtCodigo.Text;
                _personal.Nombre = txtNombre.Text;
                _personal.Apellidos = txtApellidos.Text;
                _personal.Edad = int.Parse(txtEdad.Text);
                _personal.Rol = txtRol.Text;
                _personal.Sucursal = txtSucursal.Text;
                _personal.Rfc = txtRfc.Text;
                _personal.Telefono = txtTelefono.Text;
                _personal.Correo = txtCorreo.Text;

                AdminPersonalC c = new AdminPersonalC();

                if (txtId.Text != "")
                {
                    _personal.Id = int.Parse(txtId.Text);
                    bandera = c.actualizar(_personal);
                }
                else
                {
                    bandera = c.insertar(_personal);
                }

                if (bandera)
                {
                    MessageBox.Show("Registro guardado");
                    limpiar();
                    cargarTabla(null);
                }
            } catch (Exception ex)
            {
                MessageBox.Show("Datos incorrectos, verificar datos ingresados");
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            txtId.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtCodigo.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtNombre.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtApellidos.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtEdad.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtRol.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            txtSucursal.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            txtRfc.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            txtTelefono.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            txtCorreo.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            bool bandera = false;
            DialogResult resultado = MessageBox.Show("¿Seguro que desea eliminar el registro?", "Salir",
                MessageBoxButtons.YesNoCancel);
            if (resultado == DialogResult.Yes)
            {
                int id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                AdminPersonalC c = new AdminPersonalC();
                bandera = c.eliminar(id);
                if (bandera)
                {
                    MessageBox.Show("Registro eliminado");
                    limpiar();
                    cargarTabla(null);
                }
            }
        }

        private void cargarTabla(string dato)
        {
            List<AdminPersonalM> lista = new List<AdminPersonalM>();
            AdminPersonalC _personal = new AdminPersonalC();
            dataGridView1.DataSource = _personal.consulta(dato);
            btnModificar.Enabled = dataGridView1.Rows.Count == 0 ? false : true;
            btnEliminar.Enabled = dataGridView1.Rows.Count == 0 ? false : true;
        }

        private void limpiar()
        {
            txtCampo.Text = "";
            txtId.Text = "";
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtApellidos.Text = "";
            txtEdad.Text = "";
            txtRol.Text = "";
            txtSucursal.Text = "";
            txtRfc.Text = "";
            txtTelefono.Text = "";
            txtCorreo.Text = "";
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            flag1 = string.IsNullOrEmpty(txtCodigo.Text) ? false : true;
            ValidarBoton();
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            flag2 = string.IsNullOrEmpty(txtNombre.Text) ? false : true;
            ValidarBoton();
        }

        private void txtApellidos_TextChanged(object sender, EventArgs e)
        {
            flag3 = string.IsNullOrEmpty(txtApellidos.Text) ? false : true;
            ValidarBoton();
        }

        private void txtEdad_TextChanged(object sender, EventArgs e)
        {
            String expresion = @"^[0-9]{2}$";
            Regex expr = new Regex(expresion);

            if (expr.IsMatch(this.txtEdad.Text))
            {
                flag4 = true;
                ValidarBoton();
            }
            else
            {
                flag4 = false;
                ValidarBoton();
            }
        }

        private void txtRol_TextChanged(object sender, EventArgs e)
        {
            flag5 = string.IsNullOrEmpty(txtRol.Text) ? false : true;
            ValidarBoton();
        }

        private void txtSucursal_TextChanged(object sender, EventArgs e)
        {
            String expresion = @"^[1-3]{1}$";
            Regex expr = new Regex(expresion);

            if (expr.IsMatch(this.txtSucursal.Text))
            {
                flag6 = true;
                ValidarBoton();
            }
            else
            {
                flag6 = false;
                ValidarBoton();
            }
        }

        private void txtRfc_TextChanged(object sender, EventArgs e)
        {
            String expresion = @"^[A-Z]{4}\d{6}[\w]{3}$";
            Regex expr = new Regex(expresion);

            if (expr.IsMatch(this.txtRfc.Text))
            {
                this.lbRFC.Visible = false;
                flag7 = true;
                ValidarBoton();
            }
            else
            {
                flag7 = false;
                this.lbRFC.Visible = true;
                ValidarBoton();
            }
        }

        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {
            String expresion = @"^\d{10}$";
            Regex expr = new Regex(expresion);

            if (expr.IsMatch(this.txtTelefono.Text))
            {
                this.lbTelefono.Visible = false;
                flag8 = true;
                ValidarBoton();
            }
            else
            {
                flag8 = false;
                this.lbTelefono.Visible = true;
                ValidarBoton();
            }
        }

        private void txtCorreo_TextChanged(object sender, EventArgs e)
        {
            String expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            Regex expr = new Regex(expresion);

            if (expr.IsMatch(this.txtCorreo.Text))
            {
                this.lbCorreo.Visible = false;
                flag9 = true;
                ValidarBoton();
            }
            else
            {
                flag9 = false;
                this.lbCorreo.Visible = true;
                ValidarBoton();
            }
        }

        private void ValidarBoton()
        {
            btnGuardar.Enabled = flag1 && flag2 && flag3 && flag4 && flag5 && flag6 && flag7 && flag8 && flag9 ? true : false;
        }
    }
}
