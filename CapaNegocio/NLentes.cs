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
    public class NLentes
    {
        //Metodo insertar, llama al metodo insertar de DLentes
        public static string Insertar(string nombre, string descripcion,int existencias, string estado, byte[] imagen, int id_categoria)
        {
            DLentes obj = new DLentes();
            obj.Nombre = nombre;
            obj.Descripcion = descripcion;
            obj.Existencias = existencias;
            obj.Estado = estado;
            obj.Imagen = imagen;
            obj.Id_Categoria = id_categoria;
            return obj.Insertar(obj);

        }

        //Metodo Editar
        public static string Editar(int idlentes, string nombre, string descripcion, int existencias, string estado, byte[] imagen, int id_categoria)
        {
            DLentes obj = new DLentes();
            obj.IdLentes = idlentes;
            obj.Nombre = nombre;
            obj.Descripcion = descripcion;
            obj.Existencias = existencias;
            obj.Estado = estado;
            obj.Imagen = imagen;
            obj.Id_Categoria = id_categoria;
            return obj.Editar(obj);
        }

        //Metodo Eliminar
        public static string Eliminar(int idlentes)
        {
            DLentes obj = new DLentes();
            obj.IdLentes = idlentes;
            return obj.Eliminar(obj);

        }

        //Metodo Mostrar
        public static DataTable Mostrar()
        {
            return new DLentes().Mostrar();

        }

        //Metodo BuscarNombre
        public static DataTable BuscarNombre(string textobuscar)
        {
            DLentes obj = new DLentes();
            obj.TextoBuscar = textobuscar;
            return obj.BuscarNombre(obj);
        }
    }
}
