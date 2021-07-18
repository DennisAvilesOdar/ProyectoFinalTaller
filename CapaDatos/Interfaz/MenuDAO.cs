using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Interfaz
{
    public abstract class MenuDAO : ServiceProvider
    {
        public abstract DataTable GetMenus(int idUsuario);
        public abstract MenuDTO GetMenuId(int id);
        public abstract void ActualizarMenuId(int id, string nombre, string url, string icono);
        public abstract void SetMenu(string nombre, string url, string icono);
        public abstract void SetOrdenMenu(int id, string orden, string padre);
        public abstract void eliminarMenu(int id);
        public abstract void RegistrarMenuPerfil(int perfil, int menu);
        public abstract void EliminarMenuPerfil(int perfil, int menu);
        public abstract List<MenuDTO> GetMenusVista();
    }
}
