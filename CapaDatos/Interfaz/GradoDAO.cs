using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Interfaz
{
    public abstract class GradoDAO : ServiceProvider
    {
        public abstract List<GradoDTO> GetListado();
        public abstract GradoDTO GetGradoId(int id);
        public abstract void SetGrado(int nombre);
        public abstract void UpdateGrado(int id, string nombre);
        public abstract void DeleteGradoId(int id);
    }
}
