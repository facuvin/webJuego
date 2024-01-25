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
    internal class PersistenciaJugada:IPersistenciaJugada
    {
        #region singleton
        private static PersistenciaJugada _instancia = null;

        private PersistenciaJugada() { }

        public static PersistenciaJugada GetInstancia()
        {
            if (_instancia == null)
                _instancia = new PersistenciaJugada();

            return _instancia;
        }
        #endregion

        public void AgregarJugada(Jugada J)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.Cnn());
            SqlCommand oComando = new SqlCommand("AltaJugada", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter _puntaje = new SqlParameter("@Puntaje", J.Puntaje);
            SqlParameter _nomJugador = new SqlParameter("@NomJugador", J.NomJugador);
            SqlParameter _codJ = new SqlParameter("@CodJ", J.Juego.Cod);

            SqlParameter _Retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _Retorno.Direction = ParameterDirection.ReturnValue;

            oComando.Parameters.Add(_puntaje);
            oComando.Parameters.Add(_nomJugador);
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
                if (oAfectados == -2)
                    throw new Exception("Error al dar de alta la jugada");
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

        public List<Jugada> ListarJugadas()
        {
            List<Jugada> _Lista = new List<Jugada>();

            SqlConnection _Conexion = new SqlConnection(Conexion.Cnn());
            SqlCommand _Comando = new SqlCommand("ListarJugadas", _Conexion);
            _Comando.CommandType = CommandType.StoredProcedure;

            SqlDataReader _Reader;
            try
            {
                _Conexion.Open();
                _Reader = _Comando.ExecuteReader();

                while (_Reader.Read())
                {
                    DateTime _fecha = (DateTime)_Reader["FechayHora"];
                    int _puntaje = (int)_Reader["Puntaje"];
                    string _nomJugador = (string)_Reader["NomJugador"];
                    int _codJ = (int)_Reader["CodJ"];
                    Juego j = PersistenciaJuego.GetInstancia().BuscarJuego(_codJ);
                    Jugada J = new Jugada(_nomJugador, _puntaje, _fecha, j);
                    _Lista.Add(J);
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
