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
    internal class PersistenciaRespuesta
    {
        #region singleton
        private static PersistenciaRespuesta _instancia = null;

        private PersistenciaRespuesta() { }

        public static PersistenciaRespuesta GetInstancia()
        {
            if (_instancia == null)
                _instancia = new PersistenciaRespuesta();

            return _instancia;
        }
        #endregion

        internal void AgregarRespuesta(string codP, Respuesta R, SqlTransaction trn)
        {
            SqlCommand oComando = new SqlCommand("AltaRespuesta ", trn.Connection);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter _codP = new SqlParameter("@CodP", codP);
            SqlParameter _correcta = new SqlParameter("@Correcta", R.Correcta);
            SqlParameter _texto = new SqlParameter("@Texto", R.Texto);

            SqlParameter _Retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _Retorno.Direction = ParameterDirection.ReturnValue;

            oComando.Parameters.Add(_codP);
            oComando.Parameters.Add(_correcta);
            oComando.Parameters.Add(_texto);
            oComando.Parameters.Add(_Retorno);

            int oAfectados = 0;

            try
            {
                oComando.Transaction = trn;
                oComando.ExecuteNonQuery();
                oAfectados = (int)oComando.Parameters["@Retorno"].Value;
                if (oAfectados == -1)
                    throw new Exception("El codigo de pregunta no existe");
                if (oAfectados == -2)
                    throw new Exception("Error al agregar respuesta");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<Respuesta> ListarRespuestasDePregunta(string codP)
        {
            List<Respuesta> _Lista = new List<Respuesta>();

            SqlConnection _Conexion = new SqlConnection(Conexion.Cnn());
            SqlCommand _Comando = new SqlCommand("ListarRespuestasDePregunta", _Conexion);
            _Comando.CommandType = CommandType.StoredProcedure;

            _Comando.Parameters.AddWithValue("@CodP", codP);

            SqlDataReader _Reader;
            try
            {
                _Conexion.Open();
                _Reader = _Comando.ExecuteReader();

                while (_Reader.Read())
                {
                    int _codR = (int)_Reader["CodR"];
                    bool _correcta = (bool)_Reader["Correcta"];
                    string _texto = (string)_Reader["Texto"];
                    Respuesta r = new Respuesta(_codR, _texto, _correcta);
                    _Lista.Add(r);
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
