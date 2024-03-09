using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsaderoTacoReal
{
    class AdminSucursalesC : Conexion
    {
        public List<Object> consulta(string dato)
        {
            MySqlDataReader reader;
            List<Object> lista = new List<object>();
            string sql;

            if (dato == null)
            {
                sql = "SELECT id, codigo, nombre, direccion, telefono, encargado " +
                    "FROM sucursales ORDER BY nombre ASC";
            }
            else
            {
                sql = "SELECT id, codigo, nombre, direccion, telefono, encargado " +
                    "FROM sucursales WHERE codigo LIKE '%" + dato + "%' OR nombre LIKE '%" + dato + "%' OR direccion LIKE '%" + dato + "%' OR telefono LIKE '%" + dato + "%' " +
                    "OR encargado LIKE '%" + dato + "%' ORDER BY nombre ASC";
            }

            try
            {
                MySqlConnection conexionDB = base.conexion();
                conexionDB.Open();
                MySqlCommand comando = new MySqlCommand(sql, conexionDB);
                reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    AdminSucursalesM _sucursal = new AdminSucursalesM();
                    _sucursal.Id = int.Parse(reader.GetString(0));
                    _sucursal.Codigo = reader.GetString(1);
                    _sucursal.Nombre = reader.GetString(2);
                    _sucursal.Direccion = reader.GetString(3);
                    _sucursal.Telefono = reader.GetString(4);
                    _sucursal.Encargado = reader.GetString(5);

                    lista.Add(_sucursal);
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            return lista;
        }

        public bool insertar(AdminSucursalesM datos)
        {
            bool bandera = false;
            string sql = "INSERT INTO sucursales (codigo, nombre, direccion, telefono, encargado ) VALUES " +
                "('" + datos.Codigo + "','" + datos.Nombre + "','" + datos.Direccion + "','" + datos.Telefono + "','" + datos.Encargado + "')";

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

        public bool actualizar(AdminSucursalesM datos)
        {
            bool bandera = false;
            string sql = "UPDATE sucursales SET codigo='" + datos.Codigo + "', nombre='" + datos.Nombre + "', direccion='" + datos.Direccion + "', telefono='" + datos.Telefono + "', encargado='" +
                datos.Encargado + "'WHERE id='" + datos.Id + "'";

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
            string sql = "DELETE FROM sucursales WHERE id='" + id + "'";

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
