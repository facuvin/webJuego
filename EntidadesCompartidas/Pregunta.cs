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
    public class Pregunta
    {
        //Atributos
        private string _codigo;
        private int _puntaje;
        private string _texto;
        private Categoria _categoria;
        private List<Respuesta> _respuestas;

        //Propiedades
        [DataMember]
        public string Codigo
        {
            get { return _codigo; }
            set
            {
                if (!(System.Text.RegularExpressions.Regex.IsMatch(value.Trim(), "[A-Za-z0-9]{5}")))
                    throw new Exception("El codigo debe ser de 4 letras");
                else
                    _codigo = value;
            }
        }

        [DataMember]
        public int Puntaje
        {
            get { return _puntaje; }
            set
            {
                if (value < 1 || value > 10)//de 1 a 10
                    throw new Exception("El puntaje debe ser entre 1 y 10 puntos");
                else
                    _puntaje = value;
            }
        }

        [DataMember]
        public string Texto
        {
            get { return _texto; }
            set
            {
                if (value == "")
                    throw new Exception("Este campo no puede estar vacio");
                else if (value.Trim().Length > 60)
                    throw new Exception("El texto no puede tener mas de 60 caracteres");
                else
                    _texto = value;
            }
        }

        [DataMember]
        public Categoria Categoria
        {
            get { return _categoria; }
            set
            {
                if (value == null)
                    throw new Exception("Es obligatoria la categoria");
                _categoria = value;
            }
        }

        [DataMember]
        public List<Respuesta> Respuestas
        {
            get { return _respuestas; }
            set
            {
                if (value == null)
                    throw new Exception("No se admite pregunta sin respuestas");
                if (value.Count < 2)
                    throw new Exception("Debe haber al menos 2 posibles respuestas");
                _respuestas = value;
            }
        }

        //Constructores
        public Pregunta(string pCodigo, int pPuntaje, string pTexto, Categoria pCategoria, List<Respuesta> pRespuestas)
        {
            Codigo = pCodigo;
            Puntaje = pPuntaje;
            Texto = pTexto;
            Categoria = pCategoria;
            Respuestas = pRespuestas;
        }

        public Pregunta() { }
    }
}