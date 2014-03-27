using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Repositorio
{
    public class ConceptoRepo
    {
        ModeloDominio dominio = new ModeloDominio();

        public void guardarConcepto(Concepto concepto)
        {
            dominio.Add(concepto);
            dominio.SaveChanges();
        }

        public void actualizarConcepto(Concepto concepto)
        {
            dominio.AttachCopy(concepto);
            dominio.SaveChanges();
        }

        public IEnumerable<Concepto> listaConceptos()
        {
            IEnumerable<Concepto> result = dominio.Conceptos.ToList();

            return result;
        }

        public IEnumerable<Concepto> listaConceptosXIdConcepto(int idConcepto)
        {
            IEnumerable<Concepto> result = dominio.Conceptos.Where(c => c.IdConcepto == idConcepto).ToList();

            return result;
        }

        public IEnumerable<Concepto> listaConceptosXIdTipoConcepto(int idTipoConcepto)
        {
            IEnumerable<Concepto> result = dominio.Conceptos.Where(c => c.IdTipoDeConcepto == idTipoConcepto).ToList();

            return result;
        }
    }
}
