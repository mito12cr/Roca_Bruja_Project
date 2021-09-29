using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CapaDatos;

namespace CapaNegocio
{
   public class NUsuario
    {
        //Metodo insertar, llama al metodo insertar de DUsuario
        public static string Insertar(string nombre, string apellido, string usuario, string contraseña, string acceso)
        {
            DUsuario obj = new DUsuario();
            obj.Nombre = nombre;
            obj.Apellido = apellido;
            obj.Usuario = usuario;
            obj.Contraseña = contraseña;
            obj.Acceso = acceso;
            return obj.Insertar(obj);

        }

        //Metodo Editar
        public static string Editar(int id_usuario, string nombre, string apellido, string usuario, string contraseña, string acceso)
        {
            DUsuario obj = new DUsuario();
            obj.Id_Usuario = id_usuario;
            obj.Nombre = nombre;
            obj.Apellido = apellido;
            obj.Usuario = usuario;
            obj.Contraseña = contraseña;
            obj.Acceso = acceso;
            return obj.Editar(obj);
        }

        //Metodo Eliminar
        public static string Eliminar(int id_usuario)
        {
            DUsuario obj = new DUsuario();
            obj.Id_Usuario = id_usuario;
            return obj.Eliminar(obj);

        }

        //Metodo Mostrar
        public static DataTable Mostrar()
        {
            return new DUsuario().Mostrar();

        }

        //Metodo BuscarNombre
        public static DataTable BuscarNombre(string textobuscar)
        {
            DUsuario obj = new DUsuario();
            obj.TextoBuscar = textobuscar;
            return obj.BuscarNombre(obj);
        }

        //Metodo Login
        public static DataTable Login(string usuario, string contraseña)
        {
            DUsuario obj = new DUsuario();
            obj.Usuario = usuario;
            obj.Contraseña = contraseña;
            return obj.Login(obj);
        }
    }
}
