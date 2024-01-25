using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    internal class LogicaUsuario : ILogicaUsuario
    {
        #region singleton
        private static LogicaUsuario _instancia = null;

        private LogicaUsuario() { }

        public static LogicaUsuario GetInstancia()
        {
            if (_instancia == null)
                _instancia = new LogicaUsuario();

            return _instancia;
        }
        #endregion

        public Usuario Logueo(string pNomUsu, string pPass)
        {
            return (Persistencia.Fabrica.GetPU().Logueo(pNomUsu, pPass));
        }

        public Usuario BuscarUsuariosActivos(string pUsu, Usuario uLog)
        {
            return (Persistencia.Fabrica.GetPU().BuscarUsuariosActivos(pUsu, uLog));
        }

        public void AgregarUsuario(Usuario U, Usuario uLog)
        {
            Persistencia.Fabrica.GetPU().AgregarUsuario(U, uLog);
        }

        public void ModificarUsuario(Usuario U, Usuario uLog)
        {
            Persistencia.Fabrica.GetPU().ModificarUsuario(U, uLog);
        }

        public void EliminarUsuario(Usuario U, Usuario uLog)
        {
            Persistencia.Fabrica.GetPU().EliminarUsuario(U, uLog);
        }
    }
}
