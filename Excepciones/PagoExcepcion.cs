using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Excepciones
{
    [Serializable]
    public class PagoExcepcion : Exception
    {
        public PagoExcepcion() { }
        public PagoExcepcion(string mensaje) : base(mensaje) { }
        public PagoExcepcion(string mensaje, Exception inner) : base(mensaje, inner) { }
        protected PagoExcepcion(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
