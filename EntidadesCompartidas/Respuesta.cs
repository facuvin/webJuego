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
    public class Respuesta
    {
        //Atributos
        private int _codigo;
        private string _texto;
        private bool _correcta;

        //Propiedades
        [DataMember]
        public int Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }

        [DataMember]
        public string Texto
        {
            get { return _texto; }
            set
            {
                if (value =="")
                    throw new Exception("Este campo no puede estar vacio");
                else if (value.Trim().Length > 60)
                    throw new Exception("El texto no puede tener mas de 60 caracteres");
                else
                    _texto = value;
            }
        }

        [DataMember]
        public bool Correcta
        {
            get { return _correcta; }
            set { _correcta = value; }
        }

        //Constructores
        public Respuesta (int pCodigo, string pTexto, bool pCorrecta)
        {
            Codigo = pCodigo;
            Texto = pTexto;
            Correcta = pCorrecta;
        }

        public Respuesta() { }
    }
}
