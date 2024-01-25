using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Fabrica
    {
        public static ILogicaUsuario GetLU()
        {
            return LogicaUsuario.GetInstancia();
        }

        public static ILogicaCategoria GetLC()
        {
            return LogicaCategoria.GetInstancia();
        }

        public static iLogicaJugada GetLJugada()
        {
            return LogicaJugada.GetInstancia();
        }

        public static ILogicaJuego GetLJuego()
        {
            return LogicaJuego.GetInstancia();
        }

        public static iLogicaPregunta GetLP()
        {
            return LogicaPregunta.GetInstancia();
        }
    }
}
