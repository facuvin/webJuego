using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using EntidadesCompartidas;
using Logica;

namespace ServicioPF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Servicio" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Servicio.svc o Servicio.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Servicio : IServicio
    {
        #region Categoria

        Categoria IServicio.BuscarCategoriaActivas(string pCod, Usuario uLog)
        {
            return (Fabrica.GetLC().BuscarCategoriaActivas(pCod, uLog));
        }

        void IServicio.AgregarCategoria(Categoria C, Usuario uLog)
        {
            Fabrica.GetLC().AgregarCategoria(C, uLog);
        }

        void IServicio.ModificarCategoria(Categoria C, Usuario uLog)
        {
            Fabrica.GetLC().ModificarCategoria(C, uLog);
        }

        void IServicio.EliminarCategoria(Categoria C, Usuario uLog)
        {
            Fabrica.GetLC().EliminarCategoria(C, uLog);
        }

        List<Categoria> IServicio.ListarCategoria(Usuario uLog)
        {
            return (Fabrica.GetLC().ListarCategoria(uLog));
        }

        #endregion

        #region Juego

        Juego IServicio.BuscarJuego(int pCod)
        {
            return (Fabrica.GetLJuego().BuscarJuego(pCod));
        }

        void IServicio.AgregarJuego(Juego J, Usuario uLog)
        {
            Fabrica.GetLJuego().AgregarJuego(J, uLog);
        }

        void IServicio.ModificarJuego(Juego J, Usuario uLog)
        {
            Fabrica.GetLJuego().ModificarJuego(J, uLog);
        }

        void IServicio.EliminarJuego(Juego J, Usuario uLog)
        {
            Fabrica.GetLJuego().EliminarJuego(J, uLog);
        }

        List<Juego> IServicio.ListarJuegosConPreguntas()
        {
            return (Fabrica.GetLJuego().ListarJuegosConPreguntas());
        }

        List<Juego> IServicio.ListarJuegosSinPreguntas(Usuario uLog)
        {
            return (Fabrica.GetLJuego().ListarJuegosSinPreguntas(uLog));
        }

        List<Juego> IServicio.ListarJuegosSinJugadas(Usuario uLog)
        {
            return (Fabrica.GetLJuego().ListarJuegosSinJugadas(uLog));
        }

        #endregion

        #region Jugada

        void IServicio.AgregarJugada(Jugada J)
        {
            Fabrica.GetLJugada().AgregarJugada(J);
        }

        List<Jugada> IServicio.ListarJugadas()
        {
            return (Fabrica.GetLJugada().ListarJugadas());
        }
        #endregion

        #region Pregunta

        Pregunta IServicio.BuscarPregunta(string pCod, Usuario uLog)
        {
            return (Fabrica.GetLP().BuscarPregunta(pCod, uLog));
        }

        void IServicio.AgregarPregunta(Pregunta P, Usuario uLog)
        {
            Fabrica.GetLP().AgregarPregunta(P, uLog);
        }

        void IServicio.AsignarPreguntaAJuego(Pregunta P, Juego J, Usuario uLog)
        {
            Fabrica.GetLP().AsignarPreguntaAJuego(P, J, uLog);
        }

        void IServicio.QuitarPreguntaAJuego(Pregunta P, Juego J, Usuario uLog)
        {
            Fabrica.GetLP().QuitarPreguntaAJuego(P, J, uLog);
        }

        List<Pregunta> IServicio.PreguntasNuncaUsadas(Usuario uLog)
        {
            return (Fabrica.GetLP().PreguntasNuncaUsadas(uLog));
        }

        #endregion

        #region Usuario

        Usuario IServicio.Logueo(string pNomUsu, string pPass)
        {
            return (Fabrica.GetLU().Logueo(pNomUsu, pPass));
        }

        Usuario IServicio.BuscarUsuariosActivos(string pUsu, Usuario uLog)
        {
            return (Fabrica.GetLU().BuscarUsuariosActivos(pUsu, uLog));
        }

        void IServicio.AgregarUsuario(Usuario U, Usuario uLog)
        {
            Fabrica.GetLU().AgregarUsuario(U, uLog);
        }

        void IServicio.ModificarUsuario(Usuario U, Usuario uLog)
        {
            Fabrica.GetLU().ModificarUsuario(U, uLog);
        }

        void IServicio.EliminarUsuario(Usuario U, Usuario uLog)
        {
            Fabrica.GetLU().EliminarUsuario(U, uLog);
        }

        #endregion
    }
}
