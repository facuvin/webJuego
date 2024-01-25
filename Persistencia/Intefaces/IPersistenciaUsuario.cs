using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;

namespace Persistencia
{
    public interface IPersistenciaUsuario
    {
        Usuario Logueo(string pNomUsu, string pPass);
        Usuario BuscarUsuariosActivos(string pUsu, Usuario uLog);
        void AgregarUsuario(Usuario U, Usuario uLog);
        void ModificarUsuario(Usuario U, Usuario uLog);
        void EliminarUsuario(Usuario U, Usuario uLog);
    }
}
