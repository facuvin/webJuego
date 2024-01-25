using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    public class Fabrica
    {
        public static IPersistenciaUsuario GetPU()
        {
            return PersistenciaUsuario.GetInstancia();
        }

        public static IPersistenciaCategoria GetPC()
        {
            return PersistenciaCategoria.GetInstancia();
        }

        public static IPersistenciaJugada GetPJugada()
        {
            return PersistenciaJugada.GetInstancia();
        }

        public static IPersistenciaJuego GetPJuego()
        {
            return PersistenciaJuego.GetInstancia();
        }

        public static IPersistenciaPregunta GetPP()
        {
            return PersistenciaPregunta.GetInstancia();
        }
    }
}
