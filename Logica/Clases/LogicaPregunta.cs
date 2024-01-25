using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    internal class LogicaPregunta : iLogicaPregunta
    {
        #region singleton
        private static LogicaPregunta _instancia = null;

        private LogicaPregunta() { }

        public static LogicaPregunta GetInstancia()
        {
            if (_instancia == null)
                _instancia = new LogicaPregunta();

            return _instancia;
        }
        #endregion
        public Pregunta BuscarPregunta(string pCod, Usuario uLog)
        {
            return (Persistencia.Fabrica.GetPP().BuscarPregunta(pCod, uLog));
        }

        public void AgregarPregunta(Pregunta P, Usuario uLog)
        {
            Persistencia.Fabrica.GetPP().AgregarPregunta(P, uLog);
        }

        public void AsignarPreguntaAJuego(Pregunta P, Juego J, Usuario uLog)
        {
            Persistencia.Fabrica.GetPP().AsignarPreguntaAJuego(P, J, uLog);
        }

        public void QuitarPreguntaAJuego(Pregunta P, Juego J, Usuario uLog)
        {
            Persistencia.Fabrica.GetPP().QuitarPreguntaAJuego(P, J, uLog);
        }

        public List<Pregunta> PreguntasNuncaUsadas(Usuario uLog)
        {
            return (Persistencia.Fabrica.GetPP().PreguntasNuncaUsadas(uLog));
        }
    }
}
