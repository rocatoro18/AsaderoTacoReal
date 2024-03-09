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
    public partial class ReporteDeSucursales : Form
    {
        public ReporteDeSucursales()
        {
            InitializeComponent();
        }

        private void ReporteDeSucursales_Load(object sender, EventArgs e)
        {
            string cadena = "Database=" + Conexion.bd + "; Data Source=" +
                Conexion.servidor + "; User Id=" + Conexion.usuario + "; Password=" + Conexion.password + "";
            MySqlConnection con = new MySqlConnection(cadena);
            try
            {
                con.Open();
                string sql = "SELECT codigo, nombre, direccion, telefono, encargado FROM sucursales";
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;
                cmd.CommandText = sql;
                MySqlDataReader reader = cmd.ExecuteReader();
                List<ReporteSucursales> lrs = new List<ReporteSucursales>();
                while (reader.Read())
                {
                    ReporteSucursales rs = new ReporteSucursales();
                    rs.Codigo = reader["codigo"].ToString();
                    rs.Nombre = reader["nombre"].ToString();
                    rs.Direccion = reader["direccion"].ToString();
                    rs.Telefono = reader["telefono"].ToString();
                    rs.Encargado = reader["encargado"].ToString();
                    lrs.Add(rs);
                    rs = null;
                }
                reader.Close();
                ReportDataSource rds = new ReportDataSource("ReporteSucursales", lrs);
                this.reportViewer1.LocalReport.ReportEmbeddedResource = "AsaderoTacoReal.Report4.rdlc";
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
