using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;

namespace Logica
{
    public interface ILogicaCategoria
    {
        Categoria BuscarCategoriaActivas(string pCod, Usuario uLog);

        void AgregarCategoria(Categoria C, Usuario uLog);

        void ModificarCategoria(Categoria C, Usuario uLog);

        void EliminarCategoria(Categoria C, Usuario uLog);

        List<Categoria> ListarCategoria(Usuario uLog);
    }
}
