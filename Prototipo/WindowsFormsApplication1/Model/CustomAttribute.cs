using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketSystem.Model
{
    [AttributeUsage(AttributeTargets.All, Inherited = true, AllowMultiple = true)]
    public class CustomAttribute : Attribute
    {
        //L'operazione alla quale viene attaccato questo attributo custom
        //può essere svolta sul campo specificato in _campo.
        private String _campo;

        //La statistica corrente deve essere del tipo specificato in _tipo
        private String _tipo;

        public CustomAttribute(String campo, String tipo)
        {
            if (campo == null)
                throw new ArgumentException("campo == null");
            if (tipo == null)
                throw new ArgumentException("tipo == null");

            _campo = campo;
            _tipo = tipo;
        }

        public String Campo
        {
            get { return _campo; }
            set { _campo = value; }
        }

        public String Tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }
    }
}
