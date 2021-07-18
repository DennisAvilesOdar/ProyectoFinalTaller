using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ColegioMocupe.View.Estudio
{
    public partial class matricula : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var objCore = new Core();

            cbAlumno.DataSource = objCore.comboAlumno();
            cbAlumno.DataValueField = "id";
            cbAlumno.DataTextField = "nombre";
            cbAlumno.DataBind();

            cbApoderado.DataSource = objCore.comboApoderado();
            cbApoderado.DataValueField = "id";
            cbApoderado.DataTextField = "nombre";
            cbApoderado.DataBind();

        }
    }
}