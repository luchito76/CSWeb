using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Excepciones
{
    [Serializable]
    public class CursoExcepcion : Exception
    {
        public CursoExcepcion() { }
        public CursoExcepcion(string mensaje) : base(mensaje) { }
        public CursoExcepcion(string mensaje, Exception inner) : base(mensaje, inner) { }
        protected CursoExcepcion(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
