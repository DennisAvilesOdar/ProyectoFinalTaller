using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class PerfilesDTO
    {
        public int id { get; set; }
        public string nombre { get; set; }
    }

    public class PerfilMenu
    {
        public int cod_perfil { get; set; }
        public int cod_menu { get; set; }
    }
}
