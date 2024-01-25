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
    public class Juego
    {
        //Atributos
        private int _cod;
        private DateTime _fechaCreado;
        private Usuario _usuario;
        private string _dificultad;
        private List<Pregunta> _preguntas;

        //Propiedades
        [DataMember]
        public int Cod
        {
            get { return _cod; }
            set { _cod = value; }
        }

        [DataMember]
        public DateTime FechaCreado
        {
            get { return _fechaCreado; }
            set{ _fechaCreado = value;}
        }

        [DataMember]
        public string Dificultad
        {
            get { return _dificultad; }
            set
            {
                if (value.Trim().ToUpper() != "FACIL" && value.Trim().ToUpper() != "MEDIO" && value.Trim().ToUpper() != "DIFICIL")
                    throw new Exception("La dificultad solo puede ser FACIL, MEDIO o DIFICIL");
                else
                    _dificultad = value;
            }
        }

        [DataMember]
        public Usuario Usuario
        {
            get { return _usuario; }
            set
            {
                if (value == null)
                    throw new Exception("Es necesario un usuario para crear el juego");
                else
                    _usuario = value;
            }
        }

        [DataMember]
        public List<Pregunta> Preguntas
        {
            get { return _preguntas; }
            set { _preguntas = value; }
        }

        //Constructores
        public Juego (int pCod, DateTime pFecha, string pDificultad, Usuario pUsu, List<Pregunta> pPreguntas)
        {
            _cod = pCod;
            FechaCreado = pFecha;
            Dificultad = pDificultad;
            Usuario = pUsu;
            Preguntas = pPreguntas;
        }

        public Juego() { }
    }
}
