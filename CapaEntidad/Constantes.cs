using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public static class Constantes
    {
        public static string host { get; set; }
        public static string baseDatos { get; set; }

        public static string CadenaConexion
        {
            get
            {
                return string.Format("Server={0};Initial Catalog={1};persist security info=True;Integrated Security=SSPI;"
                    , host, baseDatos);
            }
        }
    }
}
