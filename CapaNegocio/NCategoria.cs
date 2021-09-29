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
   public class NCategoria
    {
        //Metodo insertar, llama al metodo insertar de DCategoria
        public static string Insertar(string nombre, string descripcion)
        {
            DCategoria obj = new DCategoria();
            obj.Nombre = nombre;
            obj.Descripcion = descripcion;
            return obj.Insertar(obj);

        }

        //Metodo Editar
        public static string Editar(int idcategoria, string nombre, string descripcion)
        {
            DCategoria obj = new DCategoria();
            obj.Idcategoria = idcategoria;
            obj.Nombre = nombre;
            obj.Descripcion = descripcion;
            return obj.Editar(obj);

        }

        //Metodo Eliminar
        public static string Eliminar(int idcategoria)
        {
            DCategoria obj = new DCategoria();
            obj.Idcategoria = idcategoria;
            return obj.Eliminar(obj);

        }

        //Metodo Mostrar
        public static DataTable Mostrar()
        {
            return new DCategoria().Mostrar();

        }

        //Metodo BuscarNombre
        public static DataTable BuscarNombre(string textobuscar)
        {
            DCategoria obj = new DCategoria();
            obj.TextoBuscar = textobuscar;
            return obj.BuscarNombre(obj);
        }
    }
}
