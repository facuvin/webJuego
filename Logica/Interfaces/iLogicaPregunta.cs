using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;

namespace Logica
{
    public interface iLogicaPregunta
    {
        Pregunta BuscarPregunta(string pCod, Usuario uLog);

        void AgregarPregunta(Pregunta P, Usuario uLog);

        void AsignarPreguntaAJuego(Pregunta P, Juego J, Usuario uLog);

        void QuitarPreguntaAJuego(Pregunta P, Juego J, Usuario uLog);

        List<Pregunta> PreguntasNuncaUsadas(Usuario uLog);
    }
}
