using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Interfaz
{
    public abstract class PerfilesDAO : ServiceProvider
    {
        public abstract List<PerfilesDTO> ListarPerfiles();
        public abstract PerfilesDTO BuscarPerfilId(int id);
        public abstract List<PerfilMenu> ListarPerfilMenu();
        public abstract int SetPerfil(string nombre);
        public abstract void ActualizarPerfil(int id, string nombre);
        public abstract void EliminarPerfil(int id);
    }
}
