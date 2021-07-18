using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ColegioMocupe
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            var usu = txtDni.Text;
            var clave = txtClave.Text;
            Session["usuario"] = new Core().IniciarSesion(usu,clave);
            Response.Redirect("~/View/Principal/Default.aspx");
        }
    }
}