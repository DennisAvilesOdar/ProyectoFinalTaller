using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Interfaz
{
    public abstract class EspecialidadDAO : ServiceProvider
    {
        public abstract List<EspecialidadDTO> GetListado();
        public abstract EspecialidadDTO GetEspecialidadId(int id);
        public abstract void SetEspecialidad(int nombre);
        public abstract void UpdateEspecialidad(int id, int nombre);
        public abstract void DeleteEspecialidadiId(int id);
    }
}
