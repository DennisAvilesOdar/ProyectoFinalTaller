using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ColegioMocupe
{
    public partial class Principal : System.Web.UI.MasterPage
    {
        protected List<MenuDTO> Is_Menu;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] != null)
            {
                if (Session["usuario"].ToString() != "0")
                {
                    var usuario = Convert.ToInt32(Session["usuario"].ToString());
                    Is_Menu = MetodosUtiles.menu(usuario);
                }
                else
                {
                    Response.Redirect("~/View/Home/index");
                }
            }
            else
            {
                Response.Redirect("~/View/Home/index");
            }
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.Clear();
            Response.Redirect("~/View/Home/index");
        }
    }
}