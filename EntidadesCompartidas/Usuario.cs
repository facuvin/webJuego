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
    public class Usuario
    {
        //Atributos
        private string _nomUsu;
        private string _passw;
        private string _nombreCòmpleto;

        //Propiedades
        [DataMember]
        public string NomUsu
        {
            get { return _nomUsu; }
            set
            {
                if (value == "")
                    throw new Exception("Este campo no puede estar vacio");
                else if (value.Trim().Length > 20)
                    throw new Exception("El nombre de usuario no puede tener mas de 20 caracteres");
                else
                    _nomUsu = value;
            }
        }

        [DataMember]
        public string Passw
        {
            get { return _passw; }
            set
            {
                if (value == "")
                    throw new Exception("Este campo no puede estar vacio");
                else if (value.Trim().Length > 20)
                    throw new Exception("La contraseña no puede tener mas de 20 caracteres");
                else
                    _passw = value;
            }
        }

        [DataMember]
        public string NombreCompleto
        {
            get { return _nombreCòmpleto; }
            set
            {
                if (value == "")
                    throw new Exception("Este campo no puede estar vacio");
                else if (value.Trim().Length > 30)
                    throw new Exception("El nombre no puede tener mas de 30 caracteres");
                else
                    _nombreCòmpleto = value;
            }
        }

        //Constructores
        public Usuario (string pNomUsu, string pPassw, string pNombre)
        {
            NomUsu = pNomUsu;
            Passw = pPassw;
            NombreCompleto = pNombre;
        }

        public Usuario() { }
    }
}
