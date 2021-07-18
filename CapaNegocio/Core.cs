using CapaDatos;
using CapaDatos.Interfaz;
using CapaEntidad;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CapaNegocio
{
    public class Core : Controller
    {
        public int RegistrarPerfil(string nombre)
        {
            var obj = ServiceManager<PerfilesDAO>.Provider.SetPerfil(nombre);
            return obj;
        }
        public int RegistrarUsuario(string dni, string nombre, string apellido, string correo, string domicilio, string sexo, string celular, string clave)
        {
            return ServiceManager<UsuarioDAO>.Provider.SetUsuario(dni, nombre, apellido, correo, domicilio, sexo, celular, clave);
        }
        public int RegistrarUsuario(int perfil, string dni, string nombre, string apellido, string correo, string domicilio, string celular, string clave)
        {
            return ServiceManager<UsuarioDAO>.Provider.SetUsuario(perfil, dni, nombre, apellido, correo, domicilio, celular, clave);
        }
        public void RegistarMenu(string nombre, string url, string icono)
        {
            ServiceManager<MenuDAO>.Provider.SetMenu(nombre, url, icono);
        }

        public int IniciarSesion(string dni, string clave)
        {
            return ServiceManager<UsuarioDAO>.Provider.GetInicioSesion(dni, clave);
        }

        public List<MenuDTO> ListarMenus()
        {
            var respuesta = new List<MenuDTO>();
            var listaMenus = ServiceManager<MenuDAO>.Provider.GetMenusVista();

            var padre = (from d in listaMenus
                         where d.padre == "0"
                         orderby d.orden
                         select new MenuDTO
                         {
                             id = d.id,
                             nombre = d.nombre,
                             url = d.url,
                             orden = d.orden,
                             icono = d.icono,
                             padre = d.padre
                         });

            foreach (var item in padre)
            {
                var listaHijos = (from d in listaMenus
                                  where d.padre == item.id.ToString()
                                  orderby d.orden
                                  select new HijoDTO
                                  {
                                      id = d.id,
                                      nombre = d.nombre,
                                      url = d.url,
                                      orden = d.orden,
                                      icono = d.icono,
                                      padre = d.padre
                                  }).ToList();
                item.listaHijos = listaHijos;
                respuesta.Add(item);
            }

            return respuesta;
        }

        public List<MenuDTO> ListarMenusPaginaPrincipal(int id)
        {
            var respuesta = new List<MenuDTO>();
            var listaMenus = ServiceManager<MenuDAO>.Provider.GetMenus(id);

            var padre = (from DataRow d in listaMenus.AsEnumerable()
                         where d["clasepadre"].ToString() == "0"
                         orderby d["ordernpadre"].ToString()
                         select new MenuDTO
                         {
                             id = Convert.ToInt32(d["idpadre"].ToString()),
                             nombre = d["menupadre"].ToString(),
                             url = d["urlpadre"].ToString(),
                             orden = d["ordernpadre"].ToString(),
                             icono = d["iconopadre"].ToString()
                         }).ToList();

            var datosPadre = padre.Select(x => x.id).Distinct();

            foreach (var item in datosPadre)
            {
                var datosMenu = new MenuDTO();
                datosMenu = padre.Select(x => x).Where(x => x.id.ToString() == item.ToString()).First();
                var listaHijos = (from DataRow d in listaMenus.AsEnumerable()
                                  where d["clasehijo"].ToString() == item.ToString()
                                  orderby d["ordenhijo"]
                                  select new HijoDTO
                                  {
                                      nombre = d["menuhijo"].ToString(),
                                      url = d["urlhijo"].ToString(),
                                      orden = d["ordenhijo"].ToString(),
                                      icono = d["iconohijo"].ToString()
                                  }).ToList();
                datosMenu.listaHijos = listaHijos;
                respuesta.Add(datosMenu);
            }

            return respuesta;
        }

        public void ordenarListarMenu(string json)
        {
            var datosJSON = JArray.Parse(json);

            for (var i = 0; i < datosJSON.Count; i++)
            {
                var ids = (int)datosJSON[i]["id"];
                var index = i + 1;
                ServiceManager<MenuDAO>.Provider.SetOrdenMenu(ids, index.ToString(), "0");
                if ((object)datosJSON[i]["children"] != null)
                {
                    for (var j = 0; j < datosJSON[i]["children"].Count(); j++)
                    {
                        var arrayHijo = datosJSON[i]["children"][j];
                        var idHijo = (int)arrayHijo["id"];
                        var idpadre = (string)datosJSON[i]["id"];
                        var indexHijo = j + 1;
                        ServiceManager<MenuDAO>.Provider.SetOrdenMenu(idHijo, indexHijo.ToString(), idpadre);
                    }
                }
            }
        }

        public MenuDTO BuscarMenuId(int id)
        {
            return ServiceManager<MenuDAO>.Provider.GetMenuId(id);
        }

        public void ActualizarMenuId(int id, string nombre, string url, string icono)
        {
            ServiceManager<MenuDAO>.Provider.ActualizarMenuId(id, nombre, url, icono);
        }

        public List<PerfilesDTO> ListarPerfiles()
        {
            return ServiceManager<PerfilesDAO>.Provider.ListarPerfiles();
        }
        public PerfilesDTO BuscarPerfilDTO(int id)
        {
            return ServiceManager<PerfilesDAO>.Provider.BuscarPerfilId(id);
        }

        public void ActualizarPerfil(int id, string nombre)
        {
            ServiceManager<PerfilesDAO>.Provider.ActualizarPerfil(id, nombre);
        }

        public void EliminarPerfil(int id)
        {
            ServiceManager<PerfilesDAO>.Provider.EliminarPerfil(id);
        }
        public void EliminarUsuario(int id)
        {
            ServiceManager<UsuarioDAO>.Provider.DeleteUsuario(id);
        }
        public void EliminarMenu(int id)
        {
            ServiceManager<MenuDAO>.Provider.eliminarMenu(id);
        }
        public void RegistrarMenuPerfil(int idmenuhijo, int idperfil)
        {
            ServiceManager<MenuDAO>.Provider.RegistrarMenuPerfil(idperfil, idmenuhijo);
        }
        public void EliminarMenuPerfil(int idmenuhijo, int idperfil)
        {
            ServiceManager<MenuDAO>.Provider.EliminarMenuPerfil(idperfil, idmenuhijo);
        }
        public List<UsuarioDTO> ListarUsuarioSistema()
        {
            return ServiceManager<UsuarioDAO>.Provider.ListarUsuarioSistema();
        }
        public List<PerfilMenu> ListaPerfilMenu()
        {
            return ServiceManager<PerfilesDAO>.Provider.ListarPerfilMenu();
        }

        public void ListarUsuarioPerfil(int idUsuario)
        {
            var menus = ServiceManager<UsuarioDAO>.Provider.GetMenuUsuario(idUsuario);

            var nuevo = "";
        }
        public List<PlanDTO> ListarPlanEstudio()
        {
            return ServiceManager<PlanDAO>.Provider.GetListado();
        }
        public void InsertarPlanEstudio(string nombre)
        {
            ServiceManager<PlanDAO>.Provider.SetPlan(nombre);
        }
        public PlanDTO BuscarPlanId(int id)
        {
            return ServiceManager<PlanDAO>.Provider.GetPlanId(id);
        }
        public void ActualizarPlan(int id, string nombre)
        {
            ServiceManager<PlanDAO>.Provider.UpdatePlan(id, nombre);
        }
        public void DeletePlan(int id)
        {
            ServiceManager<PlanDAO>.Provider.DeletePlaniId(id);
        }

        public List<CriterioEvaluacionDTO> ListarCriterioEstudio()
        {
            return ServiceManager<CriterioEvaluacionDAO>.Provider.GetListado();
        }
        public void InsertarCriterioEstudio(string nombre)
        {
            ServiceManager<CriterioEvaluacionDAO>.Provider.SetCriterio(nombre);
        }
        public CriterioEvaluacionDTO BuscarCriterioEstudioId(int id)
        {
            return ServiceManager<CriterioEvaluacionDAO>.Provider.GetCriterioId(id);
        }
        public void ActualizarCriterioEstudio(int id, string nombre)
        {
            ServiceManager<CriterioEvaluacionDAO>.Provider.UpdateCriterio(id, nombre);
        }
        public void DeleteCriterioEstudio(int id)
        {
            ServiceManager<CriterioEvaluacionDAO>.Provider.DeleteCriterioId(id);
        }

        public List<GradoDTO> ListarGrado()
        {
            return ServiceManager<GradoDAO>.Provider.GetListado();
        }
        public void InsertarGrado(int nombre)
        {
            ServiceManager<GradoDAO>.Provider.SetGrado(nombre);
        }
        public GradoDTO BuscarGradoId(int id)
        {
            return ServiceManager<GradoDAO>.Provider.GetGradoId(id);
        }
        public void ActualizarGrado(int id, string nombre)
        {
            ServiceManager<GradoDAO>.Provider.UpdateGrado(id, nombre);
        }
        public void DeleteGrado(int id)
        {
            ServiceManager<GradoDAO>.Provider.DeleteGradoId(id);
        }

        public List<SeccionDTO> ListarSeccion()
        {
            return ServiceManager<SeccionDAO>.Provider.GetListado();
        }
        public void InsertarSeccion(string nombre)
        {
            ServiceManager<SeccionDAO>.Provider.SetSeccion(nombre);
        }
        public SeccionDTO BuscarSeccionId(int id)
        {
            return ServiceManager<SeccionDAO>.Provider.GetSeccionId(id);
        }
        public void ActualizarSeccion(int id, string nombre)
        {
            ServiceManager<SeccionDAO>.Provider.UpdateSeccion(id, nombre);
        }
        public void DeleteSeccion(int id)
        {
            ServiceManager<SeccionDAO>.Provider.DeleteSeccioniId(id);
        }

        public List<GradoEstudioDTO> ListarGradoEstudio()
        {
            return ServiceManager<GradoEstudioDAO>.Provider.GetListado();
        }
        public void InsertarGradoEstudio(int nombre)
        {
            ServiceManager<GradoEstudioDAO>.Provider.SetGradoEstudio(nombre);
        }
        public GradoEstudioDTO BuscarGradoEstudioId(int id)
        {
            return ServiceManager<GradoEstudioDAO>.Provider.GetGradoEstudioId(id);
        }
        public void ActualizarGradoEstudio(int id, string nombre)
        {
            ServiceManager<GradoEstudioDAO>.Provider.UpdateGradoEstudio(id, nombre);
        }
        public void DeleteGradoEstudio(int id)
        {
            ServiceManager<GradoEstudioDAO>.Provider.DeleteGradoEstudioiId(id);
        }

        public List<EspecialidadDTO> ListarEspecialidad()
        {
            return ServiceManager<EspecialidadDAO>.Provider.GetListado();
        }
        public void InsertarEspecialidad(int nombre)
        {
            ServiceManager<EspecialidadDAO>.Provider.SetEspecialidad(nombre);
        }
        public EspecialidadDTO BuscarEspecialidadId(int id)
        {
            return ServiceManager<EspecialidadDAO>.Provider.GetEspecialidadId(id);
        }
        public void ActualizarEspecialidad(int id, int nombre)
        {
            ServiceManager<EspecialidadDAO>.Provider.UpdateEspecialidad(id, nombre);
        }
        public void DeleteEspecialidad(int id)
        {
            ServiceManager<EspecialidadDAO>.Provider.DeleteEspecialidadiId(id);
        }

        public List<TipoPagoDTO> ListarTipoPago()
        {
            return ServiceManager<TipoPagoDAO>.Provider.GetListado();
        }
        public void InsertarTipoPago(string nombre)
        {
            ServiceManager<TipoPagoDAO>.Provider.SetTipoPago(nombre);
        }
        public TipoPagoDTO BuscarTipoPagoId(int id)
        {
            return ServiceManager<TipoPagoDAO>.Provider.GetTipoPagoId(id);
        }
        public void ActualizarTipoPago(int id, string nombre)
        {
            ServiceManager<TipoPagoDAO>.Provider.UpdateTipoPago(id, nombre);
        }
        public void DeleteTipoPago(int id)
        {
            ServiceManager<TipoPagoDAO>.Provider.DeleteTipoPagoId(id);
        }
        public List<UsuarioDTO> comboAlumno()
        {
            return ServiceManager<UsuarioDAO>.Provider.comboAlumnos();
        }
        public List<UsuarioDTO> comboApoderado()
        {
            return ServiceManager<UsuarioDAO>.Provider.comboApoderado();
        }
    }
}
