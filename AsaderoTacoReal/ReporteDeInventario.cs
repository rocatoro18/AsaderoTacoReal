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
    public partial class ReporteDeInventario : Form
    {
        public ReporteDeInventario()
        {
            InitializeComponent();
        }

        private void ReporteDeInventario_Load(object sender, EventArgs e)
        {
            string cadena = "Database=" + Conexion.bd + "; Data Source=" +
                Conexion.servidor + "; User Id=" + Conexion.usuario + "; Password=" + Conexion.password + "";
            MySqlConnection con = new MySqlConnection(cadena);
            try
            {
                con.Open();
                string sql = "SELECT codigo, nombre, descripcion, precio_publico, existencias, sucursal FROM productos";
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;
                cmd.CommandText = sql;
                MySqlDataReader reader = cmd.ExecuteReader();
                List<ReporteInventario> lri = new List<ReporteInventario>();
                while (reader.Read())
                {
                    ReporteInventario ri = new ReporteInventario();
                    ri.Codigo = reader["codigo"].ToString();
                    ri.Nombre = reader["nombre"].ToString();
                    ri.Descripcion = reader["descripcion"].ToString();
                    ri.Precio = double.Parse(reader["precio_publico"].ToString());
                    ri.Existencias = int.Parse(reader["existencias"].ToString());
                    ri.Sucursal = int.Parse(reader["sucursal"].ToString());
                    lri.Add(ri);
                    ri = null;
                }
                reader.Close();
                ReportDataSource rds = new ReportDataSource("ReporteInventario", lri);
                this.reportViewer1.LocalReport.ReportEmbeddedResource = "AsaderoTacoReal.Report1.rdlc";
                this.reportViewer1.LocalReport.DataSources.Clear();
                this.reportViewer1.LocalReport.DataSources.Add(rds);
                this.reportViewer1.RefreshReport();
            } catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            con.Close();
            
            //this.reportViewer1.RefreshReport();
        }

    }
}
