using CapaEntidad;
using CapaNegocio;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;

namespace ColegioMocupe.services
{
    /// <summary>
    /// Descripción breve de servicios
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [ScriptService]
    public class servicios : System.Web.Services.WebService
    {

        #region Menu
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string ListarMenu()
        {
            var lista = new Core().ListarMenus();
            return JsonConvert.SerializeObject(lista);
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string BuscarMenuId(int id)
        {
            var lista = new Core().BuscarMenuId(id);
            return JsonConvert.SerializeObject(lista);
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void RegistrarMenu(string nombre, string url, string icono)
        {
            new Core().RegistarMenu(nombre, url, icono);
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void ordenarListarMenu(string json)
        {
            new Core().ordenarListarMenu(json);
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void ActualizarMenuId(int id, string nombre, string url, string icono)
        {
            new Core().ActualizarMenuId(id, nombre, url, icono);
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void EliminarMenu(int id)
        {
            new Core().EliminarMenu(id);
        }
        #endregion
        #region perfiles
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string ListarPerfiles()
        {
            var lista = new Core().ListarPerfiles();
            return JsonConvert.SerializeObject(lista);
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string RegistrarPerfil(string perfil)
        {
            var respuesta = new Core().RegistrarPerfil(perfil);

            var data = new { datos = respuesta };
            return JsonConvert.SerializeObject(data);
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string BuscarPerfilId(int id)
        {
            var lista = new Core().BuscarPerfilDTO(id);
            return JsonConvert.SerializeObject(lista);
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void ActualizarPerfil(int id, string nombre)
        {
            new Core().ActualizarPerfil(id, nombre);
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void EliminarPerfil(int id)
        {
            new Core().EliminarPerfil(id);
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void RegistrarMenuPerfil(int idHijoMenu, int idPerfil)
        {
            new Core().RegistrarMenuPerfil(idHijoMenu, idPerfil);
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void EliminarMenuPerfil(int idHijoMenu, int idPerfil)
        {
            new Core().EliminarMenuPerfil(idHijoMenu, idPerfil);
        }
        #endregion
        #region Usuario
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string ListarUsuariosSistema()
        {
            var lista = new Core().ListarUsuarioSistema();
            return JsonConvert.SerializeObject(lista);
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string RegistrarUsuario(string dni, string nombre, string apellido, string correo, string domicilio, string sexo, string celular, string clave)
        {
            var lista = new Core().RegistrarUsuario(dni, nombre, apellido, correo, domicilio, sexo, celular, clave);
            var respuesta = new { data = lista };
            return JsonConvert.SerializeObject(respuesta);
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string RegistrarUsuarioSistema(int perfil,string dni, string nombre, string apellido, string correo, string domicilio, string celular, string clave)
        {
            var lista = new Core().RegistrarUsuario(perfil,dni, nombre, apellido, correo, domicilio, celular, clave);
            var respuesta = new { data = lista };
            return JsonConvert.SerializeObject(respuesta);
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string ListarPerfilMenu()
        {
            var lista = new Core().ListaPerfilMenu();
            return JsonConvert.SerializeObject(lista);
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void DeleteUsuario(int id)
        {
            new Core().EliminarUsuario(id);
        }
        #endregion
        #region PlanEstudio
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string ListarPlanEstudio()
        {
            var lista = new Core().ListarPlanEstudio();
            return JsonConvert.SerializeObject(lista);
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void InsertarPlanEstudio(string nombre)
        {
            new Core().InsertarPlanEstudio(nombre);
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string BuscarPlanId(int id)
        {
            var lista = new Core().BuscarPlanId(id);
            return JsonConvert.SerializeObject(lista);
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void ActualizarPlanEstudio(int id, string nombre)
        {
            new Core().ActualizarPlan(id, nombre);
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void DeletePlanEstudio(int id)
        {
            new Core().DeletePlan(id);
        }
        #endregion
        #region CriterioEstudio
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string ListarCriterioEstudio()
        {
            var lista = new Core().ListarCriterioEstudio();
            return JsonConvert.SerializeObject(lista);
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void InsertarCriterioEstudio(string nombre)
        {
            new Core().InsertarCriterioEstudio(nombre);
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string BuscarCriterioEstudioId(int id)
        {
            var lista = new Core().BuscarCriterioEstudioId(id);
            return JsonConvert.SerializeObject(lista);
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void ActualizarCriterioEstudio(int id, string nombre)
        {
            new Core().ActualizarCriterioEstudio(id, nombre);
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void DeleteCriterioEstudio(int id)
        {
            new Core().DeleteCriterioEstudio(id);
        }
        #endregion
        #region Grado
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string ListarGrado()
        {
            var lista = new Core().ListarGrado();
            return JsonConvert.SerializeObject(lista);
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void InsertarGrado(int nombre)
        {
            new Core().InsertarGrado(nombre);
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string BuscarGradoId(int id)
        {
            var lista = new Core().BuscarGradoId(id);
            return JsonConvert.SerializeObject(lista);
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void ActualizarGrado(int id, string nombre)
        {
            new Core().ActualizarGrado(id, nombre);
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void DeleteGrado(int id)
        {
            new Core().DeleteGrado(id);
        }
        #endregion
        #region Seccion
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string ListarSeccion()
        {
            var lista = new Core().ListarSeccion();
            return JsonConvert.SerializeObject(lista);
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void InsertarSeccion(string nombre)
        {
            new Core().InsertarSeccion(nombre);
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string BuscarSeccionId(int id)
        {
            var lista = new Core().BuscarSeccionId(id);
            return JsonConvert.SerializeObject(lista);
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void ActualizarSeccion(int id, string nombre)
        {
            new Core().ActualizarSeccion(id, nombre);
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void DeleteSeccion(int id)
        {
            new Core().DeleteSeccion(id);
        }
        #endregion
        #region GradoEstudio
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string ListarGradoEstudio()
        {
            var lista = new Core().ListarGradoEstudio();
            return JsonConvert.SerializeObject(lista);
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void InsertarGradoEstudio(int nombre)
        {
            new Core().InsertarGradoEstudio(nombre);
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string BuscarGradoEstudioId(int id)
        {
            var lista = new Core().BuscarGradoEstudioId(id);
            return JsonConvert.SerializeObject(lista);
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void ActualizarGradoEstudio(int id, string nombre)
        {
            new Core().ActualizarGradoEstudio(id, nombre);
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void DeleteGradoEstudio(int id)
        {
            new Core().DeleteGradoEstudio(id);
        }
        #endregion
        #region Especialidad
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string ListarEspecialidad()
        {
            var lista = new Core().ListarEspecialidad();
            return JsonConvert.SerializeObject(lista);
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void InsertarEspecialidad(int nombre)
        {
            new Core().InsertarEspecialidad(nombre);
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string BuscarEspecialidadId(int id)
        {
            var lista = new Core().BuscarEspecialidadId(id);
            return JsonConvert.SerializeObject(lista);
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void ActualizarEspecialidad(int id, int nombre)
        {
            new Core().ActualizarEspecialidad(id, nombre);
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void DeleteEspecialidad(int id)
        {
            new Core().DeleteEspecialidad(id);
        }
        #endregion
        #region TipoPago
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string ListarTipoPago()
        {
            var lista = new Core().ListarTipoPago();
            return JsonConvert.SerializeObject(lista);
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void InsertarTipoPago(string nombre)
        {
            new Core().InsertarTipoPago(nombre);
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string BuscarTipoPagoId(int id)
        {
            var lista = new Core().BuscarTipoPagoId(id);
            return JsonConvert.SerializeObject(lista);
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void ActualizarTipoPago(int id, string nombre)
        {
            new Core().ActualizarTipoPago(id, nombre);
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void DeleteTipoPago(int id)
        {
            new Core().DeleteTipoPago(id);
        }
        #endregion
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void CerrarSesion()
        {
            Session.Abandon();
            Session.Clear();
        }
    }
}
