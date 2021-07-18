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
    public class PerfilesSvc : PerfilesDAO
    {
        public override List<PerfilesDTO> ListarPerfiles()
        {
            try
            {
                var respuesta = new List<PerfilesDTO>(); ;
                var cadena = Constantes.CadenaConexion;
                using (SqlConnection cnx = new SqlConnection(cadena))
                {
                    cnx.Open();
                    using (var comando = new SqlCommand("select * from perfil", cnx))
                    {
                        comando.CommandTimeout = 0;
                        comando.CommandType = CommandType.Text;

                        var reader = comando.ExecuteReader(CommandBehavior.CloseConnection);

                        while (reader.Read())
                        {
                            PerfilesDTO obj = new PerfilesDTO();
                            obj.id = reader.IsDBNull(reader.GetOrdinal("id_perfil")) ? 0 : reader.GetInt32(reader.GetOrdinal("id_perfil"));
                            obj.nombre = reader.IsDBNull(reader.GetOrdinal("pe_nperfil")) ? string.Empty : reader.GetString(reader.GetOrdinal("pe_nperfil"));
                            respuesta.Add(obj);
                        }

                    }
                }

                return respuesta;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override int SetPerfil(string nombre)
        {
            try
            {
                var respuesta = 0;
                var cadena = Constantes.CadenaConexion;
                using (SqlConnection cnx = new SqlConnection(cadena))
                {
                    cnx.Open();
                    using (var comando = new SqlCommand("[dbo].[Set_Perfil]", cnx))
                    {
                        comando.CommandTimeout = 0;
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.Add(new SqlParameter("@nombre", nombre));

                        var reader = comando.ExecuteReader(CommandBehavior.CloseConnection);

                        while (reader.Read())
                        {
                            respuesta = reader.IsDBNull(reader.GetOrdinal("respuesta")) ? 0 : reader.GetInt32(reader.GetOrdinal("respuesta"));
                        }

                    }
                }

                return respuesta;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override PerfilesDTO BuscarPerfilId(int id)
        {
            try
            {
                var respuesta = new PerfilesDTO();
                var cadena = Constantes.CadenaConexion;
                using (SqlConnection cnx = new SqlConnection(cadena))
                {
                    cnx.Open();
                    using (var comando = new SqlCommand("select * from perfil where id_perfil = @id", cnx))
                    {
                        comando.CommandTimeout = 0;
                        comando.CommandType = CommandType.Text;
                        comando.Parameters.Add(new SqlParameter("@id", id));

                        var reader = comando.ExecuteReader(CommandBehavior.CloseConnection);

                        while (reader.Read())
                        {

                            respuesta.id = reader.IsDBNull(reader.GetOrdinal("id_perfil")) ? 0 : reader.GetInt32(reader.GetOrdinal("id_perfil"));
                            respuesta.nombre = reader.IsDBNull(reader.GetOrdinal("pe_nperfil")) ? string.Empty : reader.GetString(reader.GetOrdinal("pe_nperfil"));
                        }

                    }
                }

                return respuesta;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override void ActualizarPerfil(int id, string nombre)
        {
            try
            {
                var respuesta = new PerfilesDTO();
                var cadena = Constantes.CadenaConexion;
                using (SqlConnection cnx = new SqlConnection(cadena))
                {
                    cnx.Open();
                    using (var comando = new SqlCommand("[dbo].[Upd_PerfilId]", cnx))
                    {
                        comando.CommandTimeout = 0;
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.Add(new SqlParameter("@id", id));
                        comando.Parameters.Add(new SqlParameter("@nombre", nombre));
                        comando.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override void EliminarPerfil(int id)
        {
            try
            {
                var cadena = Constantes.CadenaConexion;
                using (SqlConnection cnx = new SqlConnection(cadena))
                {
                    cnx.Open();
                    using (var comando = new SqlCommand("[dbo].[Del_Perfil]", cnx))
                    {
                        comando.CommandTimeout = 0;
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.Add(new SqlParameter("@id", id));
                        comando.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override List<PerfilMenu> ListarPerfilMenu()
        {
            try
            {
                var respuesta = new List<PerfilMenu>();
                var cadena = Constantes.CadenaConexion;
                using (SqlConnection cnx = new SqlConnection(cadena))
                {
                    cnx.Open();
                    using (var comando = new SqlCommand("select COD_PERFIL,COD_MENU from PERFIL_MENU", cnx))
                    {
                        comando.CommandTimeout = 0;
                        comando.CommandType = CommandType.Text;

                        var reader = comando.ExecuteReader(CommandBehavior.CloseConnection);

                        while (reader.Read())
                        {
                            var obj = new PerfilMenu();
                            obj.cod_perfil = reader.IsDBNull(reader.GetOrdinal("COD_PERFIL")) ? 0 : reader.GetInt32(reader.GetOrdinal("COD_PERFIL"));
                            obj.cod_menu = reader.IsDBNull(reader.GetOrdinal("COD_MENU")) ? 0 : reader.GetInt32(reader.GetOrdinal("COD_MENU"));
                            respuesta.Add(obj);
                        }
                    }
                }

                return respuesta;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
