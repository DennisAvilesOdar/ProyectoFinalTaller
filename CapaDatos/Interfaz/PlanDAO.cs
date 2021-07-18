using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Interfaz
{
    public abstract class PlanDAO : ServiceProvider
    {
        public abstract List<PlanDTO> GetListado();
        public abstract PlanDTO GetPlanId(int id);
        public abstract void SetPlan(string nombre);
        public abstract void UpdatePlan(int id, string nombre);
        public abstract void DeletePlaniId(int id);
    }
}
