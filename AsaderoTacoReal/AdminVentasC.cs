using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsaderoTacoReal
{
    class AdminVentasC : Conexion
    {
        public List<Object> consulta(string dato)
        {                             
            MySqlDataReader reader;
            List<Object> lista = new List<object>();
            string sql;

            
            if (dato == null)
            {
                sql = "SELECT id, codigo, producto, cantidad, precio, precio_total, fecha, sucursal " +
                    "FROM ventas ORDER BY producto ASC";
            }
            else
            {
                sql = "SELECT id, codigo, producto, cantidad, precio, precio_total, fecha, sucursal " +
                    "FROM ventas WHERE codigo LIKE '%" + dato + "%' OR producto LIKE '%" + dato + "%' OR cantidad LIKE '%" + dato + "%' OR precio LIKE '%" + dato + "%' " +
                    "OR precio_total LIKE '%" + dato + "%' OR fecha LIKE '%" + dato + "%' OR sucursal LIKE '%" + dato + "%' ORDER BY producto ASC";
            }
            
            try
            {
                MySqlConnection conexionDB = base.conexion();
                conexionDB.Open();
                MySqlCommand comando = new MySqlCommand(sql, conexionDB);
                reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    AdminVentasM _venta = new AdminVentasM();
                    _venta.Id = int.Parse(reader.GetString(0));
                    _venta.Codigo = reader.GetString(1);
                    _venta.Producto = reader.GetString(2);
                    _venta.Cantidad = int.Parse(reader.GetString(3));
                    _venta.Precio = double.Parse(reader.GetString(4));
                    _venta.Precio_total = double.Parse(reader.GetString(5));
                    _venta.Fecha = reader.GetString(6);
                    _venta.Sucursal = int.Parse(reader.GetString(7));

                    lista.Add(_venta);
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            return lista;
        }

        public bool insertar(AdminVentasM datos)
        {
            bool bandera = false;
            string sql = "INSERT INTO ventas (codigo, producto, cantidad, precio, precio_total, fecha, sucursal ) VALUES " +
                "('" + datos.Codigo + "','" + datos.Producto + "','" + datos.Cantidad + "','" + datos.Precio + "','" + datos.Precio_total + "','" + datos.Fecha + "','" + datos.Sucursal + "')";

            try
            {
                MySqlConnection conexionBD = base.conexion();
                conexionBD.Open();
                MySqlCommand comando = new MySqlCommand(sql, conexionBD);
                comando.ExecuteNonQuery();
                bandera = true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message.ToString());
                bandera = false;
            }
            return bandera;
        }

        public bool actualizar(AdminVentasM datos)
        {
            bool bandera = false;
            string sql = "UPDATE ventas SET codigo='" + datos.Codigo + "', producto='" + datos.Producto + "', cantidad='" + datos.Cantidad + "', precio='" + datos.Precio + "', precio_total='" +
                datos.Precio_total + "', fecha='" + datos.Fecha + "', sucursal='" + datos.Sucursal + "'WHERE id='" + datos.Id + "'";

            try
            {
                MySqlConnection conexionBD = base.conexion();
                conexionBD.Open();
                MySqlCommand comando = new MySqlCommand(sql, conexionBD);
                comando.ExecuteNonQuery();
                bandera = true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message.ToString());
                bandera = false;
            }
            return bandera;
        }

        public bool eliminar(int id)
        {
            bool bandera = false;
            string sql = "DELETE FROM ventas WHERE id='" + id + "'";

            try
            {
                MySqlConnection conexionBD = base.conexion();
                conexionBD.Open();
                MySqlCommand comando = new MySqlCommand(sql, conexionBD);
                comando.ExecuteNonQuery();
                bandera = true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message.ToString());
                bandera = false;
            }
            return bandera;
        }

    }
}
