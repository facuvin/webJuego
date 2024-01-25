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
    public class Categoria
    {
        //Atributos
        private string _codigo;
        private string _nombre;

        //Propiedades
        [DataMember]
        public string Codigo
        {
            get { return _codigo; }
            set
            {
                if (value == "")
                    throw new Exception("Este campo no puede estar vacio");
                else if (!(System.Text.RegularExpressions.Regex.IsMatch(value.Trim(), "[A-Za-z]{4}")))
                    throw new Exception("El codigo debe ser de 4 letras");
                else
                    _codigo = value;
            }
        }

        [DataMember]
        public string Nombre
        {
            get { return _nombre; }
            set
            {
                if (value == "")
                    throw new Exception("Este campo no puede estar vacio");
                else if (value.Trim().Length > 20)
                    throw new Exception("El codigo no puede tener mas de 20 caracteres");
                else
                    _nombre = value;
            }
        }

        //Constructores
        public Categoria (string pCodigo, string pNombre)
        {
            Codigo = pCodigo;
            Nombre = pNombre;
        }

        public Categoria() { }
    }
}
