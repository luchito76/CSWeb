using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Repositorio;

namespace Negocio
{
    public class ConceptoNego
    {
        ConceptoRepo conceptoRepo = new ConceptoRepo();

        public void guardarConcepto(Concepto concepto)
        {
            conceptoRepo.guardarConcepto(concepto);
        }

        public void actualizarConcepto(Concepto concepto)
        {
            conceptoRepo.actualizarConcepto(concepto);
        }

        public IEnumerable<Concepto> listaConceptos()
        {
            return conceptoRepo.listaConceptos();
        }

        public IEnumerable<Concepto> listaConceptosXIdConcepto(int idConcepto)
        {
            return conceptoRepo.listaConceptosXIdConcepto(idConcepto);
        }

        public IEnumerable<Concepto> listaConceptosXIdTipoConcepto(int idTipoConcepto)
        {
            return conceptoRepo.listaConceptosXIdTipoConcepto(idTipoConcepto);
        }
    }
}
