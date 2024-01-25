using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    internal class LogicaJugada : iLogicaJugada
    {
        #region singleton
        private static LogicaJugada _instancia = null;

        private LogicaJugada() { }

        public static LogicaJugada GetInstancia()
        {
            if (_instancia == null)
                _instancia = new LogicaJugada();

            return _instancia;
        }
        #endregion

        public void AgregarJugada(Jugada J)
        {
            Persistencia.Fabrica.GetPJugada().AgregarJugada(J);
        }

        public List<Jugada> ListarJugadas()
        {
            return (Persistencia.Fabrica.GetPJugada().ListarJugadas());
        }
    }
}
