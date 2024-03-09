using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace AsaderoTacoReal
{
    public partial class AdminVentas : Form
    {
        public AdminVentas()
        {
            InitializeComponent();
        }

        private bool flag1, flag2, flag3, flag4, flag5, flag6;

        private void AdminVentas_Load(object sender, EventArgs e)
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
                AdminVentasM _venta = new AdminVentasM();
                _venta.Codigo = txtCodigo.Text;
                _venta.Producto = txtProducto.Text;
                _venta.Cantidad = int.Parse(txtCantidad.Text);
                _venta.Precio = double.Parse(txtPrecio.Text);
                _venta.Precio_total = int.Parse(txtCantidad.Text) * double.Parse(txtPrecio.Text);
                _venta.Fecha = txtFecha.Text;
                _venta.Sucursal = int.Parse(txtSucursal.Text);

                AdminVentasC c = new AdminVentasC();

                if (txtId.Text != "")
                {
                    _venta.Id = int.Parse(txtId.Text);
                    _venta.Precio_total = int.Parse(txtCantidad.Text) * double.Parse(txtPrecio.Text);
                    bandera = c.actualizar(_venta);
                }
                else
                {
                    bandera = c.insertar(_venta);
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
            txtProducto.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtCantidad.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtPrecio.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtPrecioTotal.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            txtFecha.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            txtSucursal.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            bool bandera = false;
            DialogResult resultado = MessageBox.Show("¿Seguro que desea eliminar el registro?", "Salir",
                MessageBoxButtons.YesNoCancel);
            if (resultado == DialogResult.Yes)
            {
                int id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                AdminVentasC c = new AdminVentasC();
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
            List<AdminVentasM> lista = new List<AdminVentasM>();
            AdminVentasC _ventasC = new AdminVentasC();
            dataGridView1.DataSource = _ventasC.consulta(dato);
            btnModificar.Enabled = dataGridView1.Rows.Count == 0 ? false : true;
            btnEliminar.Enabled = dataGridView1.Rows.Count == 0 ? false : true;
        }

        private void limpiar()
        {
            txtCampo.Text = "";
            txtId.Text = "";
            txtCodigo.Text = "";
            txtProducto.Text = "";
            txtCantidad.Text = "";
            txtPrecio.Text = "";
            txtPrecioTotal.Text = "";
            txtFecha.Text = "";
            txtSucursal.Text = "";
                       
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {

            flag1 = string.IsNullOrEmpty(txtCodigo.Text) ? false : true;
            VerificarBoton();
        }

        private void txtProducto_TextChanged(object sender, EventArgs e)
        {

            flag2 = string.IsNullOrEmpty(txtProducto.Text) ? false : true;
            VerificarBoton();
        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            String expresion = @"^[0-9]+$";
            Regex expr = new Regex(expresion);

            if (expr.IsMatch(this.txtCantidad.Text))
            {
                flag3 = true;
                VerificarBoton();
            }
            else
            {
                flag3 = false;
                VerificarBoton();
            }
        }

        private void txtPrecio_TextChanged(object sender, EventArgs e)
        {
            String expresion = @"^[0-9]+$";
            Regex expr = new Regex(expresion);

            if (expr.IsMatch(this.txtPrecio.Text))
            {
                flag4 = true;
                VerificarBoton();
            }
            else
            {
                flag4 = false;
                VerificarBoton();
            }
        }

        private void txtFecha_TextChanged(object sender, EventArgs e)
        {
            flag5 = string.IsNullOrEmpty(txtFecha.Text) ? false : true;
            VerificarBoton();
        }

        private void txtSucursal_TextChanged(object sender, EventArgs e)
        {
            String expresion = @"^[1-3]{1}$";
            Regex expr = new Regex(expresion);

            if (expr.IsMatch(this.txtSucursal.Text))
            {
                flag6 = true;
                VerificarBoton();
            }
            else
            {
                flag6 = false;
                VerificarBoton();
            }
        }

        private void VerificarBoton()
        {
            btnGuardar.Enabled = flag1 && flag2 && flag3 && flag4 && flag5 && flag6 ? true : false;
        }

    }
}
