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
    internal class PersistenciaCategoria: IPersistenciaCategoria
    {
        #region singleton
        private static PersistenciaCategoria _instancia = null;

        private PersistenciaCategoria() { }

        public static PersistenciaCategoria GetInstancia()
        {
            if (_instancia == null)
                _instancia = new PersistenciaCategoria();

            return _instancia;
        }
        #endregion

        internal Categoria BuscarCategoriaTodas(string pCod)
        {
            Categoria _unaC = null;

            SqlConnection _cnn = new SqlConnection(Conexion.Cnn());

            SqlCommand _comando = new SqlCommand("CategoriaBuscarTodas", _cnn);
            _comando.CommandType = System.Data.CommandType.StoredProcedure;
            _comando.Parameters.AddWithValue("@Codigo", pCod);

            try
            {
                _cnn.Open();
                SqlDataReader _lector = _comando.ExecuteReader();
                if (_lector.HasRows)
                {
                    _lector.Read();
                    _unaC = new Categoria(pCod, (string)_lector["Nombre"]);
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
            return _unaC;
        }

        public Categoria BuscarCategoriaActivas(string pCod, Usuario uLog)
        {
            Categoria _unaC = null;

            SqlConnection _cnn = new SqlConnection(Conexion.Cnn(uLog));

            SqlCommand _comando = new SqlCommand("CategoriaBuscarActivas", _cnn);
            _comando.CommandType = System.Data.CommandType.StoredProcedure;
            _comando.Parameters.AddWithValue("@Codigo", pCod);

            try
            {
                _cnn.Open();
                SqlDataReader _lector = _comando.ExecuteReader();
                if (_lector.HasRows)
                {
                    _lector.Read();
                    _unaC = new Categoria(pCod, (string)_lector["Nombre"]);
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
            return _unaC;
        }

        public void AgregarCategoria(Categoria C, Usuario uLog)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.Cnn(uLog));
            SqlCommand oComando = new SqlCommand("AltaCategoria", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter _codCat = new SqlParameter("@CodCat", C.Codigo);
            SqlParameter _nombre = new SqlParameter("@Nombre", C.Nombre);

            SqlParameter _Retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _Retorno.Direction = ParameterDirection.ReturnValue;

            oComando.Parameters.Add(_codCat);
            oComando.Parameters.Add(_nombre);
            oComando.Parameters.Add(_Retorno);

            int oAfectados = 0;

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();
                oAfectados = (int)oComando.Parameters["@Retorno"].Value;
                if (oAfectados == -1)
                    throw new Exception("La categoria ya existe");
                if (oAfectados == -2)
                    throw new Exception("Error al dar de alta la categoria");
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

        public void ModificarCategoria(Categoria C, Usuario uLog)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.Cnn(uLog));
            SqlCommand oComando = new SqlCommand("ModificarCategoria", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter _codCat = new SqlParameter("@CodCat", C.Codigo);
            SqlParameter _nombre = new SqlParameter("@Nombre", C.Nombre);

            SqlParameter _Retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _Retorno.Direction = ParameterDirection.ReturnValue;

            oComando.Parameters.Add(_codCat);
            oComando.Parameters.Add(_nombre);
            oComando.Parameters.Add(_Retorno);

            int oAfectados = 0;

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();
                oAfectados = (int)oComando.Parameters["@Retorno"].Value;
                if (oAfectados == -1)
                    throw new Exception("La categoria no existe");
                if (oAfectados == -2)
                    throw new Exception("Error al intentar modificar la categoria");
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

        public void EliminarCategoria(Categoria C, Usuario uLog)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.Cnn(uLog));
            SqlCommand oComando = new SqlCommand("BajaCategoria", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter _nomUsu = new SqlParameter("@CodCat", C.Codigo);

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
                    throw new Exception("La categoria no existe");
                if (oAfectados == -2)
                    throw new Exception("Error al intentar eliminar Categoria");
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

        public List<Categoria> ListarCategoria(Usuario uLog)
        {
            List<Categoria> _Lista = new List<Categoria>();

            SqlConnection _Conexion = new SqlConnection(Conexion.Cnn(uLog));
            SqlCommand _Comando = new SqlCommand("ListarCategoria", _Conexion);
            _Comando.CommandType = CommandType.StoredProcedure;

            SqlDataReader _Reader;
            try
            {
                _Conexion.Open();
                _Reader = _Comando.ExecuteReader();

                while (_Reader.Read())
                {
                    string _codCat = (string)_Reader["CodCat"];
                    string _nombre = (string)_Reader["Nombre"];
                    Categoria c = new Categoria(_codCat, _nombre);
                    _Lista.Add(c);
                }

                _Reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                _Conexion.Close();
            }

            return _Lista;
        }
    }


}
