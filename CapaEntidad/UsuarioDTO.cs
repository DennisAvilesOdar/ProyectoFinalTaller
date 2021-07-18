using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class UsuarioDTO
    {
        public int id { get; set; }
        public int idPerfil { get; set; }
        public string dni { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string correo { get; set; }
        public string domicilio { get; set; }
        public string sexo { get; set; }
        public string celular { get; set; }
        public string clave { get; set; }
    }
}
