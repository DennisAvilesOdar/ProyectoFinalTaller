using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Interfaz
{
    public abstract class SeccionDAO : ServiceProvider
    {
        public abstract List<SeccionDTO> GetListado();
        public abstract SeccionDTO GetSeccionId(int id);
        public abstract void SetSeccion(string nombre);
        public abstract void UpdateSeccion(int id, string nombre);
        public abstract void DeleteSeccioniId(int id);
    }
}
