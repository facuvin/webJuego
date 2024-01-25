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
    internal class PersistenciaPregunta:IPersistenciaPregunta
    {
        #region singleton
        private static PersistenciaPregunta _instancia = null;

        private PersistenciaPregunta() { }

        public static PersistenciaPregunta GetInstancia()
        {
            if (_instancia == null)
                _instancia = new PersistenciaPregunta();

            return _instancia;
        }
        #endregion

        public Pregunta BuscarPregunta(string pCod, Usuario uLog)
        {
            Pregunta _unaP = null;

            SqlConnection _cnn = new SqlConnection(Conexion.Cnn(uLog));

            SqlCommand _comando = new SqlCommand("BuscarPregunta", _cnn);
            _comando.CommandType = System.Data.CommandType.StoredProcedure;
            _comando.Parameters.AddWithValue("@codP", pCod);

            try
            {
                _cnn.Open();
                SqlDataReader _lector = _comando.ExecuteReader();
                if (_lector.HasRows)
                {
                    _lector.Read();
                    int _puntaje = (int)_lector["Puntaje"];
                    string _texto = (string)_lector["Texto"];
                    string _codCat = (string)_lector["CodCat"];
                    Categoria c = PersistenciaCategoria.GetInstancia().BuscarCategoriaTodas(_codCat);
                    List<Respuesta> _listaR = PersistenciaRespuesta.GetInstancia().ListarRespuestasDePregunta(pCod);
                    _unaP = new Pregunta(pCod, _puntaje, _texto, c, _listaR);
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
            return _unaP;
        }

        public void AgregarPregunta(Pregunta P, Usuario uLog)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.Cnn(uLog));
            SqlCommand oComando = new SqlCommand("AltaPregunta", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter _codP = new SqlParameter("@CodP", P.Codigo);
            SqlParameter _puntaje = new SqlParameter("@Puntaje", P.Puntaje);
            SqlParameter _texto = new SqlParameter("@Texto", P.Texto);
            SqlParameter _codCat = new SqlParameter("@CodCat", P.Categoria.Codigo);

            SqlParameter _Retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _Retorno.Direction = ParameterDirection.ReturnValue;

            oComando.Parameters.Add(_codP);
            oComando.Parameters.Add(_puntaje);
            oComando.Parameters.Add(_texto);
            oComando.Parameters.Add(_codCat);
            oComando.Parameters.Add(_Retorno);

            int oAfectados = 0;
            SqlTransaction _transaccion = null;

            try
            {
                oConexion.Open();
                _transaccion = oConexion.BeginTransaction();
                oComando.Transaction = _transaccion;

                oComando.ExecuteNonQuery();
                oAfectados = (int)oComando.Parameters["@Retorno"].Value;
                if (oAfectados == -1)
                    throw new Exception("La categoria no existe");
                if (oAfectados == -2)
                    throw new Exception("Ya existe el codigo de pregunta");
                if (oAfectados == -3)
                    throw new Exception("Error al agregar pregunta");

                //doy de alta las respuestas  de la pregunta
                foreach (Respuesta unaR in P.Respuestas)
                {
                    PersistenciaRespuesta.GetInstancia().AgregarRespuesta(P.Codigo, unaR, _transaccion);
                }

                _transaccion.Commit();
            }
            catch (Exception ex)
            {
                _transaccion.Rollback();
                throw ex;
            }
            finally
            {
                oConexion.Close();
            }
        }

        public void AsignarPreguntaAJuego(Pregunta P, Juego J, Usuario uLog)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.Cnn(uLog));
            SqlCommand oComando = new SqlCommand("AsignarPreguntaAJuego", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter _codJ = new SqlParameter("@codJ", J.Cod);
            SqlParameter _codP = new SqlParameter("@codP", P.Codigo);

            SqlParameter _Retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _Retorno.Direction = ParameterDirection.ReturnValue;

            oComando.Parameters.Add(_codJ);
            oComando.Parameters.Add(_codP);
            oComando.Parameters.Add(_Retorno);

            int oAfectados = 0;

            try
            {
                oConexion.Open();

                oComando.ExecuteNonQuery();
                oAfectados = (int)oComando.Parameters["@Retorno"].Value;
                if (oAfectados == -1)
                    throw new Exception("El juego no existe");
                if (oAfectados == -2)
                    throw new Exception("La pregunta no existe");
                if (oAfectados == -3)
                    throw new Exception("Error al asignar pregunta");
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

        public void QuitarPreguntaAJuego(Pregunta P, Juego J, Usuario uLog)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.Cnn(uLog));
            SqlCommand oComando = new SqlCommand("QuitarPreguntaAJuego", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter _codJ = new SqlParameter("@codJ", J.Cod);
            SqlParameter _codP = new SqlParameter("@codP", P.Codigo);

            SqlParameter _Retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _Retorno.Direction = ParameterDirection.ReturnValue;

            oComando.Parameters.Add(_codJ);
            oComando.Parameters.Add(_codP);
            oComando.Parameters.Add(_Retorno);

            int oAfectados = 0;

            try
            {
                oConexion.Open();

                oComando.ExecuteNonQuery();
                oAfectados = (int)oComando.Parameters["@Retorno"].Value;
                if (oAfectados == -1)
                    throw new Exception("El juego no existe");
                if (oAfectados == -2)
                    throw new Exception("La pregunta no existe");
                if (oAfectados == -3)
                    throw new Exception("Error al asignar pregunta");
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

        internal List<Pregunta> ListarPreguntasDeJuego(int codJ)//para mapeo de juegos
        {
            List<Pregunta> _Lista = new List<Pregunta>();

            SqlConnection _Conexion = new SqlConnection(Conexion.Cnn());
            SqlCommand _Comando = new SqlCommand("ListarPreguntasDeJuego", _Conexion);
            _Comando.CommandType = CommandType.StoredProcedure;

            _Comando.Parameters.AddWithValue("@codJ", codJ);

            SqlDataReader _Reader;
            try
            {
                _Conexion.Open();
                _Reader = _Comando.ExecuteReader();

                while (_Reader.Read())
                {
                    string _codP = (string)_Reader["CodP"];
                    int _puntaje = (int)_Reader["Puntaje"];
                    string _texto = (string)_Reader["Texto"];
                    string _codCat = (string)_Reader["CodCat"];
                    Categoria c = PersistenciaCategoria.GetInstancia().BuscarCategoriaTodas(_codCat);
                    List<Respuesta> _listaR = PersistenciaRespuesta.GetInstancia().ListarRespuestasDePregunta(_codP);
                    Pregunta p = new Pregunta(_codP, _puntaje, _texto, c, _listaR);
                    _Lista.Add(p);
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

        public List<Pregunta> PreguntasNuncaUsadas(Usuario uLog)
        {
            List<Pregunta> _Lista = new List<Pregunta>();

            SqlConnection _Conexion = new SqlConnection(Conexion.Cnn(uLog));
            SqlCommand _Comando = new SqlCommand("PreguntasNuncaUsadas", _Conexion);
            _Comando.CommandType = CommandType.StoredProcedure;

            SqlDataReader _Reader;
            try
            {
                _Conexion.Open();
                _Reader = _Comando.ExecuteReader();

                while (_Reader.Read())
                {
                    string _codP = (string)_Reader["CodP"];
                    int _puntaje = (int)_Reader["Puntaje"];
                    string _texto = (string)_Reader["Texto"];
                    string _codCat = (string)_Reader["CodCat"];
                    Categoria c = PersistenciaCategoria.GetInstancia().BuscarCategoriaTodas(_codCat);
                    List<Respuesta> _listaR = PersistenciaRespuesta.GetInstancia().ListarRespuestasDePregunta(_codP);
                    Pregunta p = new Pregunta(_codP, _puntaje, _texto, c, _listaR);
                    _Lista.Add(p);
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
