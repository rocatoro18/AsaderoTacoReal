using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace AsaderoTacoReal
{
    public partial class AdminProductos : Form
    {
        public AdminProductos()
        {
            InitializeComponent();
            cargarTabla(null);
        }

        private bool flag1, flag2, flag3, flag4, flag5, flag6;

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string dato = txtCampo.Text;
            cargarTabla(dato);
        }

        private void cargarTabla(string dato)
        {
            List<ProductosC> lista = new List<ProductosC>();
            CtrlProductos _ctrlProductos = new CtrlProductos();
            dataGridView1.DataSource = _ctrlProductos.consulta(dato);
            btnModificar.Enabled = dataGridView1.Rows.Count == 0 ? false : true;
            btnEliminar.Enabled = dataGridView1.Rows.Count == 0 ? false : true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                bool bandera = false;
                ProductosC _producto = new ProductosC();
                _producto.Codigo = txtCodigo.Text;
                _producto.Nombre = txtNombre.Text;
                _producto.Descripcion = txtDescripcion.Text;
                _producto.Precio_publico = double.Parse(txtPrecio.Text);
                _producto.Existencias = int.Parse(txtExistencias.Text);
                _producto.Sucursal = int.Parse(txtSucursal.Text);

                CtrlProductos ctrl = new CtrlProductos();

                if (txtId.Text != "")
                {
                    _producto.Id = int.Parse(txtId.Text);
                    bandera = ctrl.actualizar(_producto);
                }
                else
                {
                    bandera = ctrl.insertar(_producto);
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

        private void limpiar()
        {
            txtCampo.Text = "";
            txtId.Text = "";
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            txtPrecio.Text = "";
            txtExistencias.Text = "";
            txtSucursal.Text = "";
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            txtId.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtCodigo.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtNombre.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtDescripcion.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtPrecio.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtExistencias.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            txtSucursal.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            bool bandera = false;
            DialogResult resultado = MessageBox.Show("¿Seguro que desea eliminar el registro?", "Salir",
                MessageBoxButtons.YesNoCancel);
            if(resultado == DialogResult.Yes)
            {
                int id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                CtrlProductos _ctrl = new CtrlProductos();
                bandera = _ctrl.eliminar(id);
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

        private void AdminProductos_Load(object sender, EventArgs e)
        {
            cargarTabla(null);
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

        private void txtPrecio_TextChanged(object sender, EventArgs e)
        {
            String expresion = @"^[0-9]+$";
            Regex expr = new Regex(expresion);

            if (expr.IsMatch(this.txtPrecio.Text))
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

        private void txtExistencias_TextChanged(object sender, EventArgs e)
        {
            String expresion = @"^[0-9]+$";
            Regex expr = new Regex(expresion);

            if (expr.IsMatch(this.txtExistencias.Text))
            {
                flag5 = true;
                ValidarBoton();
            }
            else
            {
                flag5 = false;
                ValidarBoton();
            }
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

        private void ValidarBoton()
        {
            btnGuardar.Enabled = flag1 && flag2 && flag3 && flag4 && flag5 && flag6 ? true : false;
        }

    }
}
