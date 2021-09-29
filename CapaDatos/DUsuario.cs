using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DUsuario
    {
        private int _Id_Usuario;
        private string _Nombre;
        private string _Apellido;
        private string _Usuario;
        private string _Contraseña;
        private string _Acceso;
        private string _TextoBuscar;

        public int Id_Usuario
        {
            get { return _Id_Usuario; }
            set { _Id_Usuario = value; }
        }

        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        public string Apellido
        {
            get { return _Apellido; }
            set { _Apellido = value; }
        }

        public string Usuario
        {
            get { return _Usuario; }
            set { _Usuario = value; }
        }

        public string Contraseña
        {
            get { return _Contraseña; }
            set { _Contraseña = value; }
        }

        public string Acceso
        {
            get { return _Acceso; }
            set { _Acceso = value; }
        }

        public string TextoBuscar
        {
            get { return _TextoBuscar; }
            set { _TextoBuscar = value; }
        }


        public DUsuario()
        {
        }

        public DUsuario(int id_usuario, string nombre, string apellido, string usuario, string contraseña, string acceso, string textobuscar)
        {
            this.Id_Usuario = id_usuario;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Usuario = usuario;
            this.Contraseña = contraseña;
            this.Acceso = acceso;
            this.TextoBuscar = textobuscar;
        }


        //Metodo Insertar Usuarios
        public string Insertar(DUsuario Usuario)
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
                sqlcmd.CommandText = "spInsertar_Usuario";
                sqlcmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdUsuario = new SqlParameter();
                ParIdUsuario.ParameterName = "@id_usuario";
                ParIdUsuario.SqlDbType = SqlDbType.Int;
                ParIdUsuario.Direction = ParameterDirection.Output;
                sqlcmd.Parameters.Add(ParIdUsuario);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 20;
                ParNombre.Value = Usuario.Nombre;
                sqlcmd.Parameters.Add(ParNombre);

                SqlParameter ParApellido = new SqlParameter();
                ParApellido.ParameterName = "@apellido";
                ParApellido.SqlDbType = SqlDbType.VarChar;
                ParApellido.Size = 20;
                ParApellido.Value = Usuario.Apellido;
                sqlcmd.Parameters.Add(ParApellido);

                SqlParameter ParUsuario = new SqlParameter();
                ParUsuario.ParameterName = "@usuario";
                ParUsuario.SqlDbType = SqlDbType.VarChar;
                ParUsuario.Size = 20;
                ParUsuario.Value = Usuario.Usuario;
                sqlcmd.Parameters.Add(ParUsuario);

                SqlParameter ParContraseña = new SqlParameter();
                ParContraseña.ParameterName = "@contraseña";
                ParContraseña.SqlDbType = SqlDbType.VarChar;
                ParContraseña.Size = 20;
                ParContraseña.Value = Usuario.Contraseña;
                sqlcmd.Parameters.Add(ParContraseña);

                SqlParameter ParAcceso = new SqlParameter();
                ParAcceso.ParameterName = "@acceso";
                ParAcceso.SqlDbType = SqlDbType.VarChar;
                ParAcceso.Size = 20;
                ParAcceso.Value = Usuario.Acceso;
                sqlcmd.Parameters.Add(ParAcceso);

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
        public string Editar(DUsuario Usuario)
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
                sqlcmd.CommandText = "spEditar_Usuario";
                sqlcmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdUsuario = new SqlParameter();
                ParIdUsuario.ParameterName = "@id_usuario";
                ParIdUsuario.SqlDbType = SqlDbType.Int;
                ParIdUsuario.Value = Usuario.Id_Usuario;
                sqlcmd.Parameters.Add(ParIdUsuario);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 20;
                ParNombre.Value = Usuario.Nombre;
                sqlcmd.Parameters.Add(ParNombre);

                SqlParameter ParApellido = new SqlParameter();
                ParApellido.ParameterName = "@apellido";
                ParApellido.SqlDbType = SqlDbType.VarChar;
                ParApellido.Size = 20;
                ParApellido.Value = Usuario.Apellido;
                sqlcmd.Parameters.Add(ParApellido);

                SqlParameter ParUsuario = new SqlParameter();
                ParUsuario.ParameterName = "@usuario";
                ParUsuario.SqlDbType = SqlDbType.VarChar;
                ParUsuario.Size = 20;
                ParUsuario.Value = Usuario.Usuario;
                sqlcmd.Parameters.Add(ParUsuario);

                SqlParameter ParContraseña = new SqlParameter();
                ParContraseña.ParameterName = "@contraseña";
                ParContraseña.SqlDbType = SqlDbType.VarChar;
                ParContraseña.Size = 20;
                ParContraseña.Value = Usuario.Contraseña;
                sqlcmd.Parameters.Add(ParContraseña);

                SqlParameter ParAcceso = new SqlParameter();
                ParAcceso.ParameterName = "@acceso";
                ParAcceso.SqlDbType = SqlDbType.VarChar;
                ParAcceso.Size = 20;
                ParAcceso.Value = Usuario.Acceso;
                sqlcmd.Parameters.Add(ParAcceso);

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
        public string Eliminar(DUsuario Usuario)
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
                sqlcmd.CommandText = "spEliminar_Usuario";
                sqlcmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdUsuario = new SqlParameter();
                ParIdUsuario.ParameterName = "@id_usuario";
                ParIdUsuario.SqlDbType = SqlDbType.Int;
                ParIdUsuario.Value = Usuario.Id_Usuario;
                sqlcmd.Parameters.Add(ParIdUsuario);

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
            DataTable DTresultado = new DataTable("dbo.Usuario");
            SqlConnection sqlcon = new SqlConnection();
            try
            {
                sqlcon.ConnectionString = Conexion.Cn;
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;
                sqlcmd.CommandText = "spMostrar_Usuario";
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
        public DataTable BuscarNombre(DUsuario Usuario)
        {
            DataTable DTresultado = new DataTable("Usuario");
            SqlConnection sqlcon = new SqlConnection();
            try
            {
                sqlcon.ConnectionString = Conexion.Cn;
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;
                sqlcmd.CommandText = "spBuscar_Usuario_Apellido";
                sqlcmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textoBuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 20;
                ParTextoBuscar.Value = Usuario.TextoBuscar;
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

        //Metodo Login 
        public DataTable Login(DUsuario Usuario)
        {
            DataTable DTresultado = new DataTable("Usuario");
            SqlConnection sqlcon = new SqlConnection();
            try
            {
                sqlcon.ConnectionString = Conexion.Cn;
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;
                sqlcmd.CommandText = "spLoguear";
                sqlcmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParUsuario = new SqlParameter();
                ParUsuario.ParameterName = "@usuario";
                ParUsuario.SqlDbType = SqlDbType.VarChar;
                ParUsuario.Size = 20;
                ParUsuario.Value = Usuario.Usuario;
                sqlcmd.Parameters.Add(ParUsuario);


                SqlParameter ParContraseña = new SqlParameter();
                ParContraseña.ParameterName = "@contraseña";
                ParContraseña.SqlDbType = SqlDbType.VarChar;
                ParContraseña.Size = 20;
                ParContraseña.Value = Usuario.Contraseña;
                sqlcmd.Parameters.Add(ParContraseña);

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
