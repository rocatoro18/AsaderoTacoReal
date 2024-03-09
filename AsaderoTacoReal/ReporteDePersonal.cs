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
    public partial class ReporteDePersonal : Form
    {
        public ReporteDePersonal()
        {
            InitializeComponent();
        }

        private void ReporteDePersonal_Load(object sender, EventArgs e)
        {
            string cadena = "Database=" + Conexion.bd + "; Data Source=" +
               Conexion.servidor + "; User Id=" + Conexion.usuario + "; Password=" + Conexion.password + "";
            MySqlConnection con = new MySqlConnection(cadena);
            try
            {
                con.Open();
                string sql = "SELECT codigo, nombre, apellidos, edad, rol, sucursal, rfc, telefono, correo FROM personal";
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;
                cmd.CommandText = sql;
                MySqlDataReader reader = cmd.ExecuteReader();
                List<ReportePersonal> lrp = new List<ReportePersonal>();
                while (reader.Read())
                {
                    ReportePersonal rp = new ReportePersonal();
                    rp.Codigo = reader["codigo"].ToString();
                    rp.Nombre = reader["nombre"].ToString();
                    rp.Apellidos = reader["apellidos"].ToString();
                    rp.Edad = int.Parse(reader["edad"].ToString());
                    rp.Rol = reader["rol"].ToString();
                    rp.Sucursal = reader["sucursal"].ToString();
                    rp.Rfc = reader["rfc"].ToString();
                    rp.Telefono = reader["telefono"].ToString();
                    rp.Correo = reader["correo"].ToString();
                    lrp.Add(rp);
                    rp = null;
                }
                reader.Close();
                ReportDataSource rds = new ReportDataSource("ReportePersonal", lrp);
                this.reportViewer1.LocalReport.ReportEmbeddedResource = "AsaderoTacoReal.Report3.rdlc";
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
