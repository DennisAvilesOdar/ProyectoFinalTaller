using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class MenuDTO
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string url { get; set; }
        public string orden { get; set; }
        public string icono { get; set; }
        public string padre { get; set; }
        public List<HijoDTO> listaHijos { get; set; }
    }

    public class HijoDTO
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string url { get; set; }
        public string orden { get; set; }
        public string icono { get; set; }
        public string padre { get; set; }
    }
}
