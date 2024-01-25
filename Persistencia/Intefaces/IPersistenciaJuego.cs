using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;

namespace Persistencia
{
    public interface IPersistenciaJuego
    {
        Juego BuscarJuego(int pCod);
        void AgregarJuego(Juego J, Usuario uLog);
        void ModificarJuego(Juego J, Usuario uLog);
        void EliminarJuego(Juego J, Usuario uLog);
        List<Juego> ListarJuegosConPreguntas();
        List<Juego> JuegosSinPreguntas(Usuario uLog);
        List<Juego> JuegosSinJugadas(Usuario uLog);
    }
}
