﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsaderoTacoReal
{
    class RegistrarUsuarioM : Conexion
    {
        public int registro(Usuarios usuario)
        {
            MySqlConnection conexion = this.conexion();
            conexion.Open();
            string sql = "INSERT INTO usuarios (usuario, password, nombre, id_tipo)" +
                " VALUES(@usuario, @password, @nombre, @id_tipo)";
            MySqlCommand comando = new MySqlCommand(sql,conexion);
            comando.Parameters.AddWithValue("@usuario",usuario.Usuario);
            comando.Parameters.AddWithValue("@password", usuario.Password);
            comando.Parameters.AddWithValue("@nombre", usuario.Nombre);
            comando.Parameters.AddWithValue("@id_tipo", usuario.Id_tipo);

            int resultado = comando.ExecuteNonQuery();

            return resultado;

        }

        public bool existeUsuario(string usuario)
        {
            MySqlDataReader reader;
            MySqlConnection conexion = this.conexion();
            conexion.Open();
            string sql = "SELECT id FROM usuarios where usuario LIKE @usuario";
            MySqlCommand comando = new MySqlCommand(sql, conexion);
            comando.Parameters.AddWithValue("@usuario", usuario);
            reader = comando.ExecuteReader();

            if (reader.HasRows)
            {
                return true;
            } else
            {
                return false;
            }

        }

        public Usuarios porUsuario(string usuario)
        {
            MySqlDataReader reader;
            MySqlConnection conexion = this.conexion();
            conexion.Open();
            string sql = "SELECT id, password, nombre, id_tipo FROM usuarios where usuario LIKE @usuario";
            MySqlCommand comando = new MySqlCommand(sql, conexion);
            comando.Parameters.AddWithValue("@usuario", usuario);
            reader = comando.ExecuteReader();

            Usuarios usr = null;

            while (reader.Read())
            {
                usr = new Usuarios();
                usr.Id = int.Parse(reader["id"].ToString());
                usr.Password = reader["password"].ToString();
                usr.Nombre = reader["nombre"].ToString();
                usr.Id_tipo = int.Parse(reader["id_tipo"].ToString());
            }
            return usr;
        }

    }
}
