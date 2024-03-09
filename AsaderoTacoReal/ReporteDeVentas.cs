using Microsoft.Reporting.WinForms;
using MySql.Data.MySqlClient;
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
    public partial class ReporteDeVentas : Form
    {
        public ReporteDeVentas()
        {
            InitializeComponent();
        }

        private void ReporteDeVentas_Load(object sender, EventArgs e)
        {
            string cadena = "Database=" + Conexion.bd + "; Data Source=" +
                Conexion.servidor + "; User Id=" + Conexion.usuario + "; Password=" + Conexion.password + "";
            MySqlConnection con = new MySqlConnection(cadena);
            try
            {
                con.Open();
                string sql = "SELECT codigo, producto, cantidad, precio, precio_total, fecha, sucursal FROM ventas";
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;
                cmd.CommandText = sql;
                MySqlDataReader reader = cmd.ExecuteReader();
                List<ReporteVentas> lrv = new List<ReporteVentas>();
                while (reader.Read())
                {
                    ReporteVentas rv = new ReporteVentas();
                    rv.Codigo = reader["codigo"].ToString();
                    rv.Producto = reader["producto"].ToString();
                    rv.Cantidad = int.Parse(reader["cantidad"].ToString());
                    rv.Precio = double.Parse(reader["precio"].ToString());
                    rv.Precio_total = double.Parse(reader["precio_total"].ToString());
                    rv.Fecha = reader["fecha"].ToString();
                    rv.Sucursal = int.Parse(reader["sucursal"].ToString());
                    lrv.Add(rv);
                    rv = null;
                }
                reader.Close();
                ReportDataSource rds = new ReportDataSource("ReporteVentas", lrv);
                this.reportViewer1.LocalReport.ReportEmbeddedResource = "AsaderoTacoReal.Report2.rdlc";
                this.reportViewer1.LocalReport.DataSources.Clear();
                this.reportViewer1.LocalReport.DataSources.Add(rds);
                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            con.Close();
            //this.reportViewer1.RefreshReport();
            
        }
    }
}
