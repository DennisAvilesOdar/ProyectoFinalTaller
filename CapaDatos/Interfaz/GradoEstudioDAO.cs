using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Interfaz
{
    public abstract class GradoEstudioDAO : ServiceProvider
    {
        public abstract List<GradoEstudioDTO> GetListado();
        public abstract GradoEstudioDTO GetGradoEstudioId(int id);
        public abstract void SetGradoEstudio(int nombre);
        public abstract void UpdateGradoEstudio(int id, string nombre);
        public abstract void DeleteGradoEstudioiId(int id);
    }
}
