using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistencia;
using EntidadesCompartidas;

namespace Logica
{
    internal class LogicaCategoria : ILogicaCategoria
    {
        #region singleton
        private static LogicaCategoria _instancia = null;

        private LogicaCategoria() { }

        public static LogicaCategoria GetInstancia()
        {
            if (_instancia == null)
                _instancia = new LogicaCategoria();

            return _instancia;
        }
        #endregion

        public Categoria BuscarCategoriaActivas(string pCod, Usuario uLog)
        {
            return (Persistencia.Fabrica.GetPC().BuscarCategoriaActivas(pCod, uLog));
        }

        public void AgregarCategoria(Categoria C, Usuario uLog)
        {
            Persistencia.Fabrica.GetPC().AgregarCategoria(C, uLog);
        }

        public void ModificarCategoria(Categoria C, Usuario uLog)
        {
            Persistencia.Fabrica.GetPC().ModificarCategoria(C, uLog);
        }

        public void EliminarCategoria(Categoria C, Usuario uLog)
        {
            Persistencia.Fabrica.GetPC().EliminarCategoria(C, uLog);
        }

        public List<Categoria> ListarCategoria(Usuario uLog)
        {
            return (Persistencia.Fabrica.GetPC().ListarCategoria(uLog));
        }
    }
}
