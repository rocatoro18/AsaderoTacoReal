using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace AsaderoTacoReal
{
    class AdminPersonalC : Conexion
    {
        public List<Object> consulta(string dato)
        {
            MySqlDataReader reader;
            List<Object> lista = new List<object>();
            string sql;

            if (dato == null)
            {
                sql = "SELECT id, codigo, nombre, apellidos, edad, rol, sucursal, rfc, telefono, correo " +
                    "FROM personal ORDER BY apellidos ASC";
            }
            else
            {
                sql = "SELECT id, codigo, nombre, apellidos, edad, rol, sucursal, rfc, telefono, correo " +
                    "FROM personal WHERE codigo LIKE '%" + dato + "%' OR nombre LIKE '%" + dato + "%' OR apellidos LIKE '%" + dato + "%' OR edad LIKE '%" + dato + "%' " +
                    "OR rol LIKE '%" + dato + "%' OR sucursal LIKE '%" + dato + "%' OR rfc LIKE '%" + dato + "%' OR telefono LIKE '%" + dato + "%' OR correo LIKE '%" + dato + "%' ORDER BY apellidos ASC";
            }

            try
            {
                MySqlConnection conexionDB = base.conexion();
                conexionDB.Open();
                MySqlCommand comando = new MySqlCommand(sql, conexionDB);
                reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    AdminPersonalM _personal = new AdminPersonalM();
                    _personal.Id = int.Parse(reader.GetString(0));
                    _personal.Codigo = reader.GetString(1);
                    _personal.Nombre = reader.GetString(2);
                    _personal.Apellidos = reader.GetString(3);
                    _personal.Edad = int.Parse(reader.GetString(4));
                    _personal.Rol = reader.GetString(5);
                    _personal.Sucursal = reader.GetString(6);
                    _personal.Rfc = reader.GetString(7);
                    _personal.Telefono = reader.GetString(8);
                    _personal.Correo = reader.GetString(9);

                    lista.Add(_personal);
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            return lista;
        }

        public bool insertar(AdminPersonalM datos)
        {
            bool bandera = false;
            string sql = "INSERT INTO personal (codigo, nombre, apellidos, edad, rol, sucursal, rfc, telefono, correo ) VALUES " +
                "('" + datos.Codigo + "','" + datos.Nombre + "','" + datos.Apellidos + "','" + datos.Edad + "','" + datos.Rol + "','" + datos.Sucursal + "','" + datos.Rfc + "','" + datos.Telefono + "','" + datos.Correo + "')";

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

        public bool actualizar(AdminPersonalM datos)
        {
            bool bandera = false;
            string sql = "UPDATE personal SET codigo='" + datos.Codigo + "', nombre='" + datos.Nombre + "', apellidos='" + datos.Apellidos + "', edad='" + datos.Edad + "', rol='" +
                datos.Rol + "', sucursal='" + datos.Sucursal + "', rfc='" + datos.Rfc + "', telefono='" + datos.Telefono + "', correo='" + datos.Correo + "'WHERE id='" + datos.Id + "'";

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
            string sql = "DELETE FROM personal WHERE id='" + id + "'";

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
