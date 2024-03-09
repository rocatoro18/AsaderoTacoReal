using MySql.Data.MySqlClient;
using System;


namespace AsaderoTacoReal
{
    class Conexion
    {
        static public String servidor;
        static public String bd;
        static public String usuario;
        static public String password;
        public MySqlConnection conexion()
        {
            string _servidor = servidor;
            string _bd = bd;
            string _usuario = usuario;
            string _password = password;

            string cadenaConexion = "Database=" + _bd + "; Data Source=" +
                _servidor + "; User Id=" + _usuario + "; Password=" + _password + "";

            try
            {
                MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);

                return conexionBD;

            } catch (MySqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return null;
            }

        }

    }
}
