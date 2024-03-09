using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace AsaderoTacoReal
{
    public partial class AdminSucursales : Form
    {
        public AdminSucursales()
        {
            InitializeComponent();
        }

        private bool flag1, flag2, flag3, flag4, flag5;

        private void AdminSucursales_Load(object sender, EventArgs e)
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
                AdminSucursalesM _sucursal = new AdminSucursalesM();
                _sucursal.Codigo = txtCodigo.Text;
                _sucursal.Nombre = txtNombre.Text;
                _sucursal.Direccion = txtDescripcion.Text;
                _sucursal.Telefono = txtTelefono.Text;
                _sucursal.Encargado = txtEncargado.Text;


                AdminSucursalesC c = new AdminSucursalesC();

                if (txtId.Text != "")
                {
                    _sucursal.Id = int.Parse(txtId.Text);
                    bandera = c.actualizar(_sucursal);
                }
                else
                {
                    bandera = c.insertar(_sucursal);
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

        private void btnModificar_Click(object sender, EventArgs e)
        {
            txtId.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtCodigo.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtNombre.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtDescripcion.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtTelefono.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtEncargado.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            bool bandera = false;
            DialogResult resultado = MessageBox.Show("¿Seguro que desea eliminar el registro?", "Salir",
                MessageBoxButtons.YesNoCancel);
            if (resultado == DialogResult.Yes)
            {
                int id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                AdminSucursalesC c = new AdminSucursalesC();
                bandera = c.eliminar(id);
                if (bandera)
                {
                    MessageBox.Show("Registro eliminado");
                    limpiar();
                    cargarTabla(null);
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void cargarTabla(string dato)
        {
            List<AdminSucursalesM> lista = new List<AdminSucursalesM>();
            AdminSucursalesC _sucursalesC = new AdminSucursalesC();
            dataGridView1.DataSource = _sucursalesC.consulta(dato);
            btnModificar.Enabled = dataGridView1.Rows.Count == 0 ? false : true;
            btnEliminar.Enabled = dataGridView1.Rows.Count == 0 ? false : true;
        }

        private void limpiar()
        {
            txtCampo.Text = "";
            txtId.Text = "";
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            txtTelefono.Text = "";
            txtEncargado.Text = "";
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

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {
            flag3 = string.IsNullOrEmpty(txtDescripcion.Text) ? false : true;
            ValidarBoton();
        }

        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {
            String expresion = @"^\d{10}$";
            Regex expr = new Regex(expresion);

            if (expr.IsMatch(this.txtTelefono.Text))
            {
                this.lbTelefono.Visible = false;
                flag4 = true;
                ValidarBoton();
            }
            else
            {
                flag4 = false;
                this.lbTelefono.Visible = true;
                ValidarBoton();
            }
        }

        private void txtEncargado_TextChanged(object sender, EventArgs e)
        {
            flag5 = string.IsNullOrEmpty(txtEncargado.Text) ? false : true;
            ValidarBoton();
        }

        private void ValidarBoton()
        {
            btnGuardar.Enabled = flag1 && flag2 && flag3 && flag4 && flag5 ? true: false;
        }

    }
}
