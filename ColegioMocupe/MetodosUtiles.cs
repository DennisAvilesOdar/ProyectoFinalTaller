using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ColegioMocupe
{
    public class MetodosUtiles
    {
        public static List<MenuDTO> menu(int id)
        {
            return new Core().ListarMenusPaginaPrincipal(id);
        }
    }
}