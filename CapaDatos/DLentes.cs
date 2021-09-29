using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data;
using System.Data.SqlClient;


namespace CapaDatos
{
  public  class DLentes
    {
        private int _IdLentes;
        private string _Nombre;
        private string _Descripcion;
        private int _Existencias;
        private string _Estado;
        private byte[] _Imagen;
        private int _Id_Categoria;
        private string _TextoBuscar;

        public int IdLentes
        {
            get{return _IdLentes;}
            set{_IdLentes = value;}
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

        public int Existencias
        {
            get{return _Existencias;}
            set{_Existencias = value;}
        }

        public string Estado
        {
            get{return _Estado;}
            set{_Estado = value;}
        }

        public byte[] Imagen
        {
            get{return _Imagen;}
            set{_Imagen = value;}
        }

        public int Id_Categoria
        {
            get{return _Id_Categoria;}
            set{_Id_Categoria = value;}
        }

        public string TextoBuscar
        {
            get{return _TextoBuscar;}
            set{_TextoBuscar = value;}
        }

        public DLentes()
        {
        }

        public DLentes(int id_lentes, string nombre, string descripcion, int existencias, string estado, byte[] imagen, int id_categoria)
        {
            this.IdLentes = id_lentes;
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.Existencias = existencias;
            this.Estado = estado;
            this.Imagen = imagen;
            this.Id_Categoria = id_categoria;
        }

        //Metodo Insertar Lentes
        public string Insertar(DLentes Lentes)
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
                sqlcmd.CommandText = "spInsertar_Lentes";
                sqlcmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdLentes = new SqlParameter();
                ParIdLentes.ParameterName = "@id_lentes";
                ParIdLentes.SqlDbType = SqlDbType.Int;
                ParIdLentes.Direction = ParameterDirection.Output;
                sqlcmd.Parameters.Add(ParIdLentes);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 50;
                ParNombre.Value = Lentes.Nombre;
                sqlcmd.Parameters.Add(ParNombre);

                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 50;
                ParDescripcion.Value = Lentes.Descripcion;
                sqlcmd.Parameters.Add(ParDescripcion);                

                SqlParameter ParExistencias = new SqlParameter();
                ParExistencias.ParameterName = "@existencias";
                ParExistencias.SqlDbType = SqlDbType.Int;
                ParExistencias.Value = Lentes.Existencias;
                sqlcmd.Parameters.Add(ParExistencias);

                SqlParameter ParEstado = new SqlParameter();
                ParEstado.ParameterName = "@Estado";
                ParEstado.SqlDbType = SqlDbType.VarChar;
                ParEstado.Size = 15;
                ParEstado.Value = Lentes.Estado;
                sqlcmd.Parameters.Add(ParEstado);

                SqlParameter ParImagen = new SqlParameter();
                ParImagen.ParameterName = "@imagen";
                ParImagen.SqlDbType = SqlDbType.Image;
                ParImagen.Value = Lentes.Imagen;
                sqlcmd.Parameters.Add(ParImagen);

                SqlParameter ParIdCategoria = new SqlParameter();
                ParIdCategoria.ParameterName = "@id_categoria";
                ParIdCategoria.SqlDbType = SqlDbType.Int;
                ParIdCategoria.Value = Lentes.Id_Categoria;
                sqlcmd.Parameters.Add(ParIdCategoria);

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

        //Metodo Insertar Editar
        public string Editar(DLentes Lentes)
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
                sqlcmd.CommandText = "spEditar_Lentes";
                sqlcmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdLentes = new SqlParameter();
                ParIdLentes.ParameterName = "@id_lentes";
                ParIdLentes.SqlDbType = SqlDbType.Int;
                ParIdLentes.Value = Lentes.IdLentes;
                sqlcmd.Parameters.Add(ParIdLentes);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 50;
                ParNombre.Value = Lentes.Nombre;
                sqlcmd.Parameters.Add(ParNombre);

                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 50;
                ParDescripcion.Value = Lentes.Descripcion;
                sqlcmd.Parameters.Add(ParDescripcion);

                SqlParameter ParExistencias = new SqlParameter();
                ParExistencias.ParameterName = "@existencias";
                ParExistencias.SqlDbType = SqlDbType.Int;
                ParExistencias.Value = Lentes.Existencias;
                sqlcmd.Parameters.Add(ParExistencias);

                SqlParameter ParEstado = new SqlParameter();
                ParEstado.ParameterName = "@Estado";
                ParEstado.SqlDbType = SqlDbType.VarChar;
                ParEstado.Size = 15;
                ParEstado.Value = Lentes.Estado;
                sqlcmd.Parameters.Add(ParEstado);

                SqlParameter ParImagen = new SqlParameter();
                ParImagen.ParameterName = "@imagen";
                ParImagen.SqlDbType = SqlDbType.Image;
                ParImagen.Value = Lentes.Imagen;
                sqlcmd.Parameters.Add(ParImagen);

                SqlParameter ParIdCategoria = new SqlParameter();
                ParIdCategoria.ParameterName = "@id_categoria";
                ParIdCategoria.SqlDbType = SqlDbType.Int;
                ParIdCategoria.Value = Lentes.Id_Categoria;
                sqlcmd.Parameters.Add(ParIdCategoria);

                //Ejecutamos el comando
                rpta = sqlcmd.ExecuteNonQuery() == 1 ? "OK" : "No Se Editó el registro";


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
        public string Eliminar(DLentes Lentes)
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
                sqlcmd.CommandText = "spEliminar_Lentes";
                sqlcmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdlentes = new SqlParameter();
                ParIdlentes.ParameterName = "@id_lentes";
                ParIdlentes.SqlDbType = SqlDbType.Int;
                ParIdlentes.Value = Lentes.IdLentes;
                sqlcmd.Parameters.Add(ParIdlentes);

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
            DataTable DTresultado = new DataTable("dbo.Lentes");
            SqlConnection sqlcon = new SqlConnection();
            try
            {
                sqlcon.ConnectionString = Conexion.Cn;
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;
                sqlcmd.CommandText = "spMostrar_Lentes";
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

        //Metodo Buscar Por Nombre
        public DataTable BuscarNombre(DLentes Lentes)
        {
            DataTable DTresultado = new DataTable("Lentes");
            SqlConnection sqlcon = new SqlConnection();
            try
            {
                sqlcon.ConnectionString = Conexion.Cn;
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;
                sqlcmd.CommandText = "spbuscar_lentes_nombre";
                sqlcmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Lentes.TextoBuscar;
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
