using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CapaDatos;

namespace CapaDatos
{
   public class DCategoria
    {
        private int _Idcategoria;
        private string _Nombre;
        private string _Descripcion;

        private string _TextoBuscar;

        public int Idcategoria
        {
            get{return _Idcategoria;}
            set{_Idcategoria = value;}
        }

        public string Nombre
        {
            get{return _Nombre;}
            set{_Nombre = value;}
        }

        public string Descripcion
        {
            get{return _Descripcion;}
            set{_Descripcion = value;}
        }

        public string TextoBuscar
        {
            get{return _TextoBuscar;}
            set{_TextoBuscar = value;}
        }
        
        // Fin 

        // Constructor vacio
        public DCategoria()
        {
        }

        //Constructor con parametros
        public DCategoria(int idcategoria, string nombre, string descripcion, string textobuscar)
        {
            this.Idcategoria = idcategoria;
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.TextoBuscar = textobuscar;
        }

        //Metodo Insertar
        public string Insertar(DCategoria Categoria)
        {
            string rpta = "";
            SqlConnection sqlcon = new SqlConnection();
            try
            {

                sqlcon.ConnectionString = Conexion.Cn;
                sqlcon.Open();

                //Establecer el comando
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;
                sqlcmd.CommandText = "spInsertar_Categoria";
                sqlcmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdcategoria = new SqlParameter();
                ParIdcategoria.ParameterName = "@idcategoria";
                ParIdcategoria.SqlDbType = SqlDbType.Int;
                ParIdcategoria.Direction = ParameterDirection.Output;
                sqlcmd.Parameters.Add(ParIdcategoria);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 50;
                ParNombre.Value = Categoria.Nombre;
                sqlcmd.Parameters.Add(ParNombre);

                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 50;
                ParDescripcion.Value = Categoria.Descripcion;
                sqlcmd.Parameters.Add(ParDescripcion);

                //Ejecutamos el comando
                rpta = sqlcmd.ExecuteNonQuery() == 1 ? "OK" : "No Se ingreso el registro";


            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (sqlcon.State == ConnectionState.Open) sqlcon.Close();
            }

            return rpta;

        }

        //Metodo Editar
        public string Editar(DCategoria Categoria)
        {
            string rpta = "";
            SqlConnection sqlcon = new SqlConnection();
            try
            {

                sqlcon.ConnectionString = Conexion.Cn;
                sqlcon.Open();

                //Establecer el comando
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;
                sqlcmd.CommandText = "spEditar_Categoria";
                sqlcmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdcategoria = new SqlParameter();
                ParIdcategoria.ParameterName = "@idcategoria";
                ParIdcategoria.SqlDbType = SqlDbType.Int;
                ParIdcategoria.Value = Categoria.Idcategoria;
                sqlcmd.Parameters.Add(ParIdcategoria);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 50;
                ParNombre.Value = Categoria.Nombre;
                sqlcmd.Parameters.Add(ParNombre);

                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 50;
                ParDescripcion.Value = Categoria.Descripcion;
                sqlcmd.Parameters.Add(ParDescripcion);

                //Ejecutamos el comando
                rpta = sqlcmd.ExecuteNonQuery() == 1 ? "OK" : "No Se Actualizó el registro";


            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (sqlcon.State == ConnectionState.Open) sqlcon.Close();
            }

            return rpta;
        }

        //Metodo Eliminar
        public string Eliminar(DCategoria Categoria)
        {
            string rpta = "";
            SqlConnection sqlcon = new SqlConnection();
            try
            {

                sqlcon.ConnectionString = Conexion.Cn;
                sqlcon.Open();

                //Establecer el comando
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;
                sqlcmd.CommandText = "spEliminar_Categoria";
                sqlcmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdcategoria = new SqlParameter();
                ParIdcategoria.ParameterName = "@idcategoria";
                ParIdcategoria.SqlDbType = SqlDbType.Int;
                ParIdcategoria.Value = Categoria.Idcategoria;
                sqlcmd.Parameters.Add(ParIdcategoria);

                //Ejecutamos el comando
                rpta = sqlcmd.ExecuteNonQuery() == 1 ? "OK" : "No Se Eliminó el registro";


            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (sqlcon.State == ConnectionState.Open) sqlcon.Close();
            }

            return rpta;
        }

        //Metodo Buscar
        public DataTable Mostrar()
        {
            DataTable DTresultado = new DataTable("dbo.categoria");
            SqlConnection sqlcon = new SqlConnection();
            try
            {
                sqlcon.ConnectionString = Conexion.Cn;
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;
                sqlcmd.CommandText = "spMostrar_Categoria";
                sqlcmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlcmd);
                sqlDat.Fill(DTresultado);
            }
            catch (Exception ex)
            {
                DTresultado = null;
            }

            return DTresultado;
        }

        //Metodo Buscar Nombre
        public DataTable BuscarNombre(DCategoria Categoria)
        {
            DataTable DTresultado = new DataTable("categoria");
            SqlConnection sqlcon = new SqlConnection();
            try
            {
                sqlcon.ConnectionString = Conexion.Cn;
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;
                sqlcmd.CommandText = "spBuscar_Categoria";
                sqlcmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Categoria.TextoBuscar;
                sqlcmd.Parameters.Add(ParTextoBuscar);

                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlcmd);
                sqlDat.Fill(DTresultado);
            }
            catch (Exception ex)
            {
                DTresultado = null;
            }

            return DTresultado;
        }
    }
}
