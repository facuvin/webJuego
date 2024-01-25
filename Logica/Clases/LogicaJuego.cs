using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    internal class LogicaJuego : ILogicaJuego
    {
        #region singleton
        private static LogicaJuego _instancia = null;

        private LogicaJuego() { }

        public static LogicaJuego GetInstancia()
        {
            if (_instancia == null)
                _instancia = new LogicaJuego();

            return _instancia;
        }
        #endregion

        public Juego BuscarJuego(int pCod)
        {
            return (Persistencia.Fabrica.GetPJuego().BuscarJuego(pCod));
        }

        public void AgregarJuego(Juego J, Usuario uLog)
        {
            Persistencia.Fabrica.GetPJuego().AgregarJuego(J, uLog);
        }

        public void ModificarJuego(Juego J, Usuario uLog)
        {
            Persistencia.Fabrica.GetPJuego().ModificarJuego(J, uLog);
        }

        public void EliminarJuego(Juego J, Usuario uLog)
        {
            Persistencia.Fabrica.GetPJuego().EliminarJuego(J, uLog);
        }

        public List<Juego> ListarJuegosConPreguntas()
        {
            return (Persistencia.Fabrica.GetPJuego().ListarJuegosConPreguntas());
        }

        public List<Juego> ListarJuegosSinPreguntas(Usuario uLog)
        {
            return (Persistencia.Fabrica.GetPJuego().JuegosSinPreguntas(uLog));
        }

        public List<Juego> ListarJuegosSinJugadas(Usuario uLog)
        {
            return (Persistencia.Fabrica.GetPJuego().JuegosSinJugadas(uLog));
        }
    }
}
