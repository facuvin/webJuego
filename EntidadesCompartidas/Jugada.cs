using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ServiceModel;
using System.Runtime.Serialization;

namespace EntidadesCompartidas
{
    [DataContract]
    public class Jugada
    {
        //Atributos
        private string _nomJugador;
        private int _puntaje;
        private DateTime _fechayHora;
        private Juego _juego;

        //Propiedades
        [DataMember]
        public string NomJugador
        {
            get { return _nomJugador; }
            set
            {
                if (value == "")
                    throw new Exception("Este campo no puede estar vacio");
                else if (value.Trim().Length > 30)
                    throw new Exception("El nombre no puede tener mas de 30 caracteres");
                else
                    _nomJugador = value;
            }
        }

        [DataMember]
        public int Puntaje
        {
            get { return _puntaje; }
            set
            {
                if (value < 0)
                    throw new Exception("El puntaje no puede ser negativo");
                _puntaje = value;
            }
        }

        [DataMember]
        public DateTime FechayHora
        {
            get { return _fechayHora; }
            set
            {
                    _fechayHora = value;
            }
        }

        [DataMember]
        public Juego Juego
        {
            get { return _juego; }
            set
            {
                if (value == null)
                    throw new Exception("Es necesario un juego para la jugada");
                _juego = value;
            }
        }

        //Constructores
        public Jugada (string pNomJugador, int pPuntaje, DateTime pFechayHora, Juego pJuego)
        {
            NomJugador = pNomJugador;
            Puntaje = pPuntaje;
            FechayHora = pFechayHora;
            Juego = pJuego;
        }

        public Jugada() { }
    }
}
