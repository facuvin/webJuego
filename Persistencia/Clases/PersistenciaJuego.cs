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
    internal class PersistenciaJuego: IPersistenciaJuego
    {
        #region singleton
        private static PersistenciaJuego _instancia = null;

        private PersistenciaJuego() { }

        public static PersistenciaJuego GetInstancia()
        {
            if (_instancia == null)
                _instancia = new PersistenciaJuego();

            return _instancia;
        }
        #endregion

        public Juego BuscarJuego (int pCod)
        {
            Juego _unJ = null;

            SqlConnection _cnn = new SqlConnection(Conexion.Cnn());

            SqlCommand _comando = new SqlCommand("BuscarJuego", _cnn);
            _comando.CommandType = System.Data.CommandType.StoredProcedure;
            _comando.Parameters.AddWithValue("@CodJ", pCod);

            try
            {
                _cnn.Open();
                SqlDataReader _lector = _comando.ExecuteReader();
                if (_lector.HasRows)
                {
                    _lector.Read();
                    string _usu = (string)_lector["NomUsu"];
                    string _dificultad = (string)_lector["Dificultad"];
                    Usuario u= PersistenciaUsuario.GetInstancia().BuscarUsuariosTodos(_usu);
                    List<Pregunta> _listaP = PersistenciaPregunta.GetInstancia().ListarPreguntasDeJuego(pCod);
                    _unJ = new Juego(pCod, (DateTime)_lector["FechaCreado"], _dificultad, u, _listaP);
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
            return _unJ;
        }

        public void AgregarJuego(Juego J, Usuario uLog)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.Cnn(uLog));
            SqlCommand oComando = new SqlCommand("AltaJuego", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter _dificultad = new SqlParameter("@Dificultad", J.Dificultad);
            SqlParameter _nomUsu = new SqlParameter("@NomUsu", J.Usuario.NomUsu);

            SqlParameter _Retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _Retorno.Direction = ParameterDirection.ReturnValue;

            oComando.Parameters.Add(_dificultad);
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
                    throw new Exception("Error al dar de alta el juego");
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

        public void ModificarJuego(Juego J, Usuario uLog)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.Cnn(uLog));
            SqlCommand oComando = new SqlCommand("ModificarJuego", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter _dificultad = new SqlParameter("@Dificultad", J.Dificultad);
            SqlParameter _codJ = new SqlParameter("@CodJ", J.Cod);
            SqlParameter _nomUsu = new SqlParameter("@NomUsu", J.Usuario.NomUsu);

            SqlParameter _Retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _Retorno.Direction = ParameterDirection.ReturnValue;

            oComando.Parameters.Add(_codJ);
            oComando.Parameters.Add(_dificultad);
            oComando.Parameters.Add(_nomUsu);
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
                    throw new Exception("Error al intentar modificar el juego");
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

        public void EliminarJuego(Juego J, Usuario uLog)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.Cnn(uLog));
            SqlCommand oComando = new SqlCommand("BajaJuego", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter _codJ = new SqlParameter("@CodJ", J.Cod);

            SqlParameter _Retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _Retorno.Direction = ParameterDirection.ReturnValue;

            oComando.Parameters.Add(_codJ);
            oComando.Parameters.Add(_Retorno);

            int oAfectados = 0;

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();
                oAfectados = (int)oComando.Parameters["@Retorno"].Value;
                if (oAfectados == -1)
                    throw new Exception("El juego no existe");
                if (oAfectados == -1)
                    throw new Exception("Tiene jugadas asociadas. No se puede eliminar");
                if (oAfectados == -3)
                    throw new Exception("Error al intentar eliminar juego");
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

        public List<Juego> ListarJuegosConPreguntas()
        {
            List<Juego> _Lista = new List<Juego>();

            SqlConnection _Conexion = new SqlConnection(Conexion.Cnn());
            SqlCommand _Comando = new SqlCommand("ListarJuegosConPreguntas", _Conexion);
            _Comando.CommandType = CommandType.StoredProcedure;

            SqlDataReader _Reader;
            try
            {
                _Conexion.Open();
                _Reader = _Comando.ExecuteReader();

                while (_Reader.Read())
                {
                    int _codJ = (int)_Reader["CodJ"];
                    DateTime _fechaCreado = (DateTime)_Reader["FechaCreado"];
                    string _dificultad = (string)_Reader["Dificultad"];
                    string _nomUsu = (string)_Reader["NomUsu"];
                    Usuario u = PersistenciaUsuario.GetInstancia().BuscarUsuariosTodos(_nomUsu);
                    List<Pregunta> _listaP = PersistenciaPregunta.GetInstancia().ListarPreguntasDeJuego(_codJ);
                    Juego j = new Juego(_codJ, _fechaCreado, _dificultad, u, _listaP);
                    _Lista.Add(j);
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

        public List<Juego> JuegosSinPreguntas(Usuario uLog)
        {
            List<Juego> _Lista = new List<Juego>();

            SqlConnection _Conexion = new SqlConnection(Conexion.Cnn(uLog));
            SqlCommand _Comando = new SqlCommand("JuegosSinPreguntas", _Conexion);
            _Comando.CommandType = CommandType.StoredProcedure;

            SqlDataReader _Reader;
            try
            {
                _Conexion.Open();
                _Reader = _Comando.ExecuteReader();

                while (_Reader.Read())
                {
                    int _codJ = (int)_Reader["CodJ"];
                    DateTime _fechaCreado = (DateTime)_Reader["FechaCreado"];
                    string _dificultad = (string)_Reader["Dificultad"];
                    string _nomUsu = (string)_Reader["NomUsu"];
                    Usuario u = PersistenciaUsuario.GetInstancia().BuscarUsuariosTodos(_nomUsu);
                    List<Pregunta> _listaP = PersistenciaPregunta.GetInstancia().ListarPreguntasDeJuego(_codJ);
                    Juego j = new Juego(_codJ, _fechaCreado,_dificultad, u, _listaP);
                    _Lista.Add(j);
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

        public List<Juego> JuegosSinJugadas(Usuario uLog)
        {
            List<Juego> _Lista = new List<Juego>();

            SqlConnection _Conexion = new SqlConnection(Conexion.Cnn(uLog));
            SqlCommand _Comando = new SqlCommand("JuegosSinJugadas", _Conexion);
            _Comando.CommandType = CommandType.StoredProcedure;

            SqlDataReader _Reader;
            try
            {
                _Conexion.Open();
                _Reader = _Comando.ExecuteReader();

                while (_Reader.Read())
                {
                    int _codJ = (int)_Reader["CodJ"];
                    DateTime _fechaCreado = (DateTime)_Reader["FechaCreado"];
                    string _dificultad = (string)_Reader["Dificultad"];
                    string _nomUsu = (string)_Reader["NomUsu"];
                    Usuario u = PersistenciaUsuario.GetInstancia().BuscarUsuariosTodos(_nomUsu);
                    List<Pregunta> _listaP = PersistenciaPregunta.GetInstancia().ListarPreguntasDeJuego(_codJ);
                    Juego j = new Juego(_codJ, _fechaCreado,_dificultad, u, _listaP);
                    _Lista.Add(j);
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
