using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Interfaz
{
    public abstract class UsuarioDAO : ServiceProvider
    {
        public abstract int SetUsuario(string dni, string nombre, string apellido, string correo, string domicilio, string sexo, string celular, string clave);
        public abstract int SetUsuario(int perfil, string dni, string nombre, string apellido, string correo, string domicilio, string celular, string clave);
        public abstract int GetInicioSesion(string dni, string clave);
        public abstract DataTable GetMenuUsuario(int idUsuario);
        public abstract UsuarioDTO GetUsuarioSistemaEditar(int id);
        public abstract List<UsuarioDTO> ListarUsuarioSistema();
        public abstract void DeleteUsuario(int id);
        public abstract List<UsuarioDTO> comboAlumnos();
        public abstract List<UsuarioDTO> comboApoderado();
    }
}
