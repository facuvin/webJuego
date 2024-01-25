using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EntidadesCompartidas;
using System.Data;
using System.Data.SqlClient;

namespace Persistencia
{
    internal class PersistenciaUsuario: IPersistenciaUsuario
    {
        #region singleton
        private static PersistenciaUsuario _instancia = null;

        private PersistenciaUsuario() { }

        public static PersistenciaUsuario GetInstancia()
        {
            if (_instancia == null)
                _instancia = new PersistenciaUsuario();

            return _instancia;
        }
        #endregion

        public Usuario Logueo(string pNomUsu, string pPass)
        {
            Usuario _unU = null;

            SqlConnection _cnn = new SqlConnection(Conexion.Cnn());

            SqlCommand _comando = new SqlCommand("Logueo", _cnn);
            _comando.CommandType = CommandType.StoredProcedure;
            _comando.Parameters.AddWithValue("@NomUsu", pNomUsu);
            _comando.Parameters.AddWithValue("@Passw", pPass);

            try
            {
                _cnn.Open();
                SqlDataReader _lector = _comando.ExecuteReader();
                if (_lector.HasRows)
                {
                    _lector.Read();
                    _unU = new Usuario(pNomUsu, pPass, (string)_lector["Nombre"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                _cnn.Close();
            }
            return _unU;
        }

        public Usuario BuscarUsuariosActivos(string pUsu, Usuario uLog)
        {
            Usuario _unU = null;

            SqlConnection _cnn = new SqlConnection(Conexion.Cnn(uLog));

            SqlCommand _comando = new SqlCommand("UsuariosBuscarActivos", _cnn);
            _comando.CommandType = System.Data.CommandType.StoredProcedure;
            _comando.Parameters.AddWithValue("@NomUsu", pUsu);

            try
            {
                _cnn.Open();
                SqlDataReader _lector = _comando.ExecuteReader();
                if (_lector.HasRows)
                {
                    _lector.Read();
                    _unU = new Usuario(pUsu, (string)_lector["Passw"], (string)_lector["Nombre"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                _cnn.Close();
            }
            return _unU;
        }

        internal Usuario BuscarUsuariosTodos(string pUsu)
        {
            Usuario _unU = null;

            SqlConnection _cnn = new SqlConnection(Conexion.Cnn());

            SqlCommand _comando = new SqlCommand("UsuariosBuscarTodos", _cnn);
            _comando.CommandType = System.Data.CommandType.StoredProcedure;
            _comando.Parameters.AddWithValue("@NomUsu", pUsu);

            try
            {
                _cnn.Open();
                SqlDataReader _lector = _comando.ExecuteReader();
                if (_lector.HasRows)
                {
                    _lector.Read();
                    _unU = new Usuario(pUsu, (string)_lector["Passw"], (string)_lector["Nombre"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                _cnn.Close();
            }
            return _unU;
        }

        public void AgregarUsuario(Usuario U, Usuario uLog)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.Cnn(uLog));
            SqlCommand oComando = new SqlCommand("AltaUsuario", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter _nomUsu = new SqlParameter("@NomUsu", U.NomUsu);
            SqlParameter _passw = new SqlParameter("@Passw", U.Passw);
            SqlParameter _nombre = new SqlParameter("@Nombre", U.NombreCompleto);

            SqlParameter _Retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _Retorno.Direction = ParameterDirection.ReturnValue;

            oComando.Parameters.Add(_nomUsu);
            oComando.Parameters.Add(_passw);
            oComando.Parameters.Add(_nombre);
            oComando.Parameters.Add(_Retorno);

            int oAfectados = 0;

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();
                oAfectados = (int)oComando.Parameters["@Retorno"].Value;
                if (oAfectados == -1)
                    throw new Exception("El usuario ya existe");
                if (oAfectados == -2)
                    throw new Exception("Error al dar de alta el usuario");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oConexion.Close();
            }
        }

        public void ModificarUsuario(Usuario U, Usuario uLog)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.Cnn(uLog));
            SqlCommand oComando = new SqlCommand("ModificarUsuario", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter _nomUsu = new SqlParameter("@NomUsu", U.NomUsu);
            SqlParameter _passw = new SqlParameter("@Passw", U.Passw);
            SqlParameter _nombre = new SqlParameter("@Nombre", U.NombreCompleto);

            SqlParameter _Retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _Retorno.Direction = ParameterDirection.ReturnValue;

            oComando.Parameters.Add(_nomUsu);
            oComando.Parameters.Add(_passw);
            oComando.Parameters.Add(_nombre);
            oComando.Parameters.Add(_Retorno);

            int oAfectados = 0;

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();
                oAfectados = (int)oComando.Parameters["@Retorno"].Value;
                if (oAfectados == -1)
                    throw new Exception("El usuario no existe");
                if (oAfectados == -2)
                    throw new Exception("Error al modificar el usuario");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oConexion.Close();
            }
        }

        public void EliminarUsuario(Usuario U, Usuario uLog)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.Cnn(uLog));
            SqlCommand oComando = new SqlCommand("BajaUsuario", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter _nomUsu = new SqlParameter("@NomUsu", U.NomUsu);

            SqlParameter _Retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _Retorno.Direction = ParameterDirection.ReturnValue;

            oComando.Parameters.Add(_nomUsu);
            oComando.Parameters.Add(_Retorno);

            int oAfectados = 0;

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();
                oAfectados = (int)oComando.Parameters["@Retorno"].Value;
                if (oAfectados == -1)
                    throw new Exception("El usuario no existe");
                if (oAfectados == -2)
                    throw new Exception("Error al intentar eliminar usuario");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oConexion.Close();
            }
        }
    }
}
