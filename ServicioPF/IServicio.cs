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
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IServicio" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServicio
    {
        #region Categoria

        [OperationContract]
        Categoria BuscarCategoriaActivas(string pCod, Usuario uLog);


        [OperationContract]
        void AgregarCategoria(Categoria C, Usuario uLog);


        [OperationContract]
        void ModificarCategoria(Categoria C, Usuario uLog);


        [OperationContract]
        void EliminarCategoria(Categoria C, Usuario uLog);


        [OperationContract]
        List<Categoria> ListarCategoria(Usuario uLog);

        #endregion

        #region Juego

        [OperationContract]
        Juego BuscarJuego(int pCod);

        [OperationContract]
        void AgregarJuego(Juego J, Usuario uLog);

        [OperationContract]
        void ModificarJuego(Juego J, Usuario uLog);

        [OperationContract]
        void EliminarJuego(Juego J, Usuario uLog);

        [OperationContract]
        List<Juego> ListarJuegosConPreguntas();

        [OperationContract]
        List<Juego> ListarJuegosSinPreguntas(Usuario uLog);

        [OperationContract]
        List<Juego> ListarJuegosSinJugadas(Usuario uLog);

        #endregion

        #region Jugada

        [OperationContract]
        void AgregarJugada(Jugada J);

        [OperationContract]
        List<Jugada> ListarJugadas();
        #endregion

        #region Pregunta

        [OperationContract]
        Pregunta BuscarPregunta(string pCod, Usuario uLog);

        [OperationContract]
        void AgregarPregunta(Pregunta P, Usuario uLog);

        [OperationContract]
        void AsignarPreguntaAJuego(Pregunta P, Juego J, Usuario uLog);

        [OperationContract]
        void QuitarPreguntaAJuego(Pregunta P, Juego J, Usuario uLog);

        [OperationContract]
        List<Pregunta> PreguntasNuncaUsadas(Usuario uLog);

        #endregion

        #region Usuario

        [OperationContract]
        Usuario Logueo(string pNomUsu, string pPass);

        [OperationContract]
        Usuario BuscarUsuariosActivos(string pUsu, Usuario uLog);

        [OperationContract]
        void AgregarUsuario(Usuario U, Usuario uLog);

        [OperationContract]
        void ModificarUsuario(Usuario U, Usuario uLog);

        [OperationContract]
        void EliminarUsuario(Usuario U, Usuario uLog);

        #endregion
    }
}
