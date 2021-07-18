using CapaDatos.Interfaz;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Servicios
{
    public class MenuSvc : MenuDAO
    {
        public override DataTable GetMenus(int idUsuario)
        {
            try
            {
                var cadena = Constantes.CadenaConexion;
                using (SqlConnection cnx = new SqlConnection(cadena))
                {
                    cnx.Open();
                    using (var comando = new SqlCommand("[dbo].[Get_Menu_por_Perfil]", cnx))
                    {
                        comando.CommandTimeout = 0;
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.Add(new SqlParameter("@idUsuario", idUsuario));
                        SqlDataAdapter da = new SqlDataAdapter(comando);
                        DataTable table = new DataTable();
                        da.Fill(table);
                        cnx.Close();
                        da.Dispose();
                        return table;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override List<MenuDTO> GetMenusVista()
        {
            try
            {
                var datos = new List<MenuDTO>();
                var cadena = Constantes.CadenaConexion;
                using (SqlConnection cnx = new SqlConnection(cadena))
                {
                    cnx.Open();
                    using (var comando = new SqlCommand("select * from menu", cnx))
                    {
                        comando.CommandTimeout = 0;
                        comando.CommandType = CommandType.Text;

                        var reader = comando.ExecuteReader(CommandBehavior.CloseConnection);

                        while (reader.Read())
                        {
                            MenuDTO listMenu = new MenuDTO();
                            listMenu.id = reader.IsDBNull(reader.GetOrdinal("ID_MENU")) ? 0 : reader.GetInt32(reader.GetOrdinal("ID_MENU"));
                            listMenu.nombre = reader.IsDBNull(reader.GetOrdinal("M_NOMBRE")) ? string.Empty : reader.GetString(reader.GetOrdinal("M_NOMBRE"));
                            listMenu.url = reader.IsDBNull(reader.GetOrdinal("url")) ? string.Empty : reader.GetString(reader.GetOrdinal("url"));
                            listMenu.orden = reader.IsDBNull(reader.GetOrdinal("M_ORDEN")) ? string.Empty : reader.GetString(reader.GetOrdinal("M_ORDEN"));
                            listMenu.icono = reader.IsDBNull(reader.GetOrdinal("icono")) ? string.Empty : reader.GetString(reader.GetOrdinal("icono"));
                            listMenu.padre = reader.IsDBNull(reader.GetOrdinal("padre")) ? string.Empty : reader.GetString(reader.GetOrdinal("padre"));
                            datos.Add(listMenu);
                        }
                    }
                }
                return datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override MenuDTO GetMenuId(int id)
        {
            try
            {
                MenuDTO listMenu = new MenuDTO();
                var cadena = Constantes.CadenaConexion;
                using (SqlConnection cnx = new SqlConnection(cadena))
                {
                    cnx.Open();
                    using (var comando = new SqlCommand("[dbo].[Get_MenuId]", cnx))
                    {
                        comando.CommandTimeout = 0;
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.Add(new SqlParameter("@id", id));

                        var reader = comando.ExecuteReader(CommandBehavior.CloseConnection);

                        while (reader.Read())
                        {
                            listMenu.id = reader.IsDBNull(reader.GetOrdinal("id_menu")) ? 0 : reader.GetInt32(reader.GetOrdinal("id_menu"));
                            listMenu.nombre = reader.IsDBNull(reader.GetOrdinal("m_nombre")) ? string.Empty : reader.GetString(reader.GetOrdinal("m_nombre"));
                            listMenu.url = reader.IsDBNull(reader.GetOrdinal("url")) ? string.Empty : reader.GetString(reader.GetOrdinal("url"));
                            listMenu.orden = reader.IsDBNull(reader.GetOrdinal("m_orden")) ? string.Empty : reader.GetString(reader.GetOrdinal("m_orden"));
                            listMenu.icono = reader.IsDBNull(reader.GetOrdinal("icono")) ? string.Empty : reader.GetString(reader.GetOrdinal("icono"));
                            listMenu.padre = reader.IsDBNull(reader.GetOrdinal("padre")) ? string.Empty : reader.GetString(reader.GetOrdinal("padre"));
                        }
                    }
                }
                return listMenu;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override void SetMenu(string nombre, string url, string icono)
        {
            try
            {
                var cadena = Constantes.CadenaConexion;
                using (SqlConnection cnx = new SqlConnection(cadena))
                {
                    cnx.Open();
                    using (var comando = new SqlCommand("[dbo].[Set_Menu]", cnx))
                    {
                        comando.CommandTimeout = 0;
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.Add(new SqlParameter("@nombre", nombre));
                        comando.Parameters.Add(new SqlParameter("@url", url));
                        comando.Parameters.Add(new SqlParameter("@icono", icono));

                        comando.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override void SetOrdenMenu(int id, string orden, string padre)
        {
            try
            {
                var cadena = Constantes.CadenaConexion;
                using (SqlConnection cnx = new SqlConnection(cadena))
                {
                    cnx.Open();
                    using (var comando = new SqlCommand("[dbo].[Set_OrdenMenu]", cnx))
                    {
                        comando.CommandTimeout = 0;
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.Add(new SqlParameter("@id", id));
                        comando.Parameters.Add(new SqlParameter("@orden", orden));
                        comando.Parameters.Add(new SqlParameter("@padre", padre));

                        comando.ExecuteNonQuery();
                    }
                    cnx.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override void ActualizarMenuId(int id, string nombre, string url, string icono)
        {
            try
            {
                var cadena = Constantes.CadenaConexion;
                using (SqlConnection cnx = new SqlConnection(cadena))
                {
                    cnx.Open();
                    using (var comando = new SqlCommand("[dbo].[Upd_MenuId]", cnx))
                    {
                        comando.CommandTimeout = 0;
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.Add(new SqlParameter("@id", id));
                        comando.Parameters.Add(new SqlParameter("@nombre", nombre));
                        comando.Parameters.Add(new SqlParameter("@url", url));
                        comando.Parameters.Add(new SqlParameter("@icono", icono));

                        comando.ExecuteNonQuery();
                    }
                    cnx.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override void eliminarMenu(int id)
        {
            try
            {
                var cadena = Constantes.CadenaConexion;
                using (SqlConnection cnx = new SqlConnection(cadena))
                {
                    cnx.Open();
                    using (var comando = new SqlCommand("[dbo].[Del_Menu]", cnx))
                    {
                        comando.CommandTimeout = 0;
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.Add(new SqlParameter("@id", id));

                        comando.ExecuteNonQuery();
                    }
                    cnx.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override void RegistrarMenuPerfil(int perfil, int menu)
        {
            try
            {
                var cadena = Constantes.CadenaConexion;
                using (SqlConnection cnx = new SqlConnection(cadena))
                {
                    cnx.Open();
                    using (var comando = new SqlCommand("[dbo].[Set_Menu_Perfil]", cnx))
                    {
                        comando.CommandTimeout = 0;
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.Add(new SqlParameter("@idHijoMenu", menu));
                        comando.Parameters.Add(new SqlParameter("@idPerfil", perfil));

                        comando.ExecuteNonQuery();
                    }
                    cnx.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override void EliminarMenuPerfil(int perfil, int menu)
        {
            try
            {
                var cadena = Constantes.CadenaConexion;
                using (SqlConnection cnx = new SqlConnection(cadena))
                {
                    cnx.Open();
                    using (var comando = new SqlCommand("[dbo].[Del_MenuPerfil]", cnx))
                    {
                        comando.CommandTimeout = 0;
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.Add(new SqlParameter("@idHijoMenu", menu));
                        comando.Parameters.Add(new SqlParameter("@idPerfil", perfil));

                        comando.ExecuteNonQuery();
                    }
                    cnx.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
