using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AsaderoTacoReal
{
    class RegistrarUsuariosC
    {
        public string ctrlRegistro(Usuarios usuario)
        {
            RegistrarUsuarioM registrarUsuarioM = new RegistrarUsuarioM();
            string respuesta = "";

            if (string.IsNullOrEmpty(usuario.Usuario) || string.IsNullOrEmpty(usuario.Password) || string.IsNullOrEmpty(usuario.ConPassword) || string.IsNullOrEmpty(usuario.Nombre))
            {
                respuesta = "Debe llenar todos los campos";
            } else
            {
                if (usuario.Password == usuario.ConPassword)
                {
                    if (registrarUsuarioM.existeUsuario(usuario.Usuario))
                    {
                        respuesta = "El usuario ya existe";
                    } else
                    {
                        usuario.Password = generarClaveSHA1(usuario.Password);
                        usuario.Id_tipo = 2;
                        registrarUsuarioM.registro(usuario);
                    }
                }
                else
                {
                    respuesta = "Las contraseñas no coinciden";
                }
            }

            return respuesta;

        }

        public string ctrlLogin(string usuario, string password)
        {
            RegistrarUsuarioM registrarUsuarioM = new RegistrarUsuarioM();
            string respuesta = "";
            Usuarios datosUsuario = null;
            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(password))
            {
                respuesta = "Debe llenar todos los campos";
            } else
            {
                datosUsuario = registrarUsuarioM.porUsuario(usuario);

                if(datosUsuario == null)
                {
                    respuesta = "El usuario no existe";
                } else
                {
                    if(datosUsuario.Password != generarClaveSHA1(password))
                    {
                        respuesta = "El usuario y/o contraseña no coinciden";
                    }
                    else
                    {
                        Sesion.id = datosUsuario.Id;
                        Sesion.usuario = usuario;
                        Sesion.nombre = datosUsuario.Nombre;
                        Sesion.id_tipo = datosUsuario.Id_tipo;
                    }
                }

            }
            return respuesta;
        }

        private string generarClaveSHA1(string cadena)
        {

            UTF8Encoding enc = new UTF8Encoding();
            byte[] data = enc.GetBytes(cadena);
            byte[] result;

            SHA1CryptoServiceProvider sha = new SHA1CryptoServiceProvider();

            result = sha.ComputeHash(data);


            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {

                // Convertimos los valores en hexadecimal
                // cuando tiene una cifra hay que rellenarlo con cero
                // para que siempre ocupen dos dígitos.
                if (result[i] < 16)
                {
                    sb.Append("0");
                }
                sb.Append(result[i].ToString("x"));
            }

            //Devolvemos la cadena con el hash en mayúsculas para que quede más chuli :)
            return sb.ToString();
        }

    }
}
