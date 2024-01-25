using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;

namespace Persistencia
{
    public interface IPersistenciaCategoria
    {
        Categoria BuscarCategoriaActivas(string pCod, Usuario uLog);
        void AgregarCategoria(Categoria C, Usuario uLog);
        void ModificarCategoria(Categoria C, Usuario uLog);
        void EliminarCategoria(Categoria C, Usuario uLog);
        List<Categoria> ListarCategoria(Usuario uLog);

    }
}
