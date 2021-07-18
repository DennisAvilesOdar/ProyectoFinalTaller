using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ColegioMocupe.app.Usuario
{
    public partial class Registrar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var dataCombo = new Core().ListarPerfiles();
            cbPerfil.DataSource = dataCombo;
            cbPerfil.DataTextField = "nombre";
            cbPerfil.DataValueField = "id";
            cbPerfil.DataBind();
        }
    }
}