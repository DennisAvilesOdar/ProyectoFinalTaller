using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Interfaz
{
    public abstract class CriterioEvaluacionDAO : ServiceProvider
    {
        public abstract List<CriterioEvaluacionDTO> GetListado();
        public abstract CriterioEvaluacionDTO GetCriterioId(int id);
        public abstract void SetCriterio(string nombre);
        public abstract void UpdateCriterio(int id, string nombre);
        public abstract void DeleteCriterioId(int id);
    }
}
