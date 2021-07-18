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
    public class UsuarioSvc : UsuarioDAO
    {
        public override int SetUsuario(string dni, string nombre, string apellido, string correo, string domicilio, string sexo, string celular, string clave)
        {
            try
            {
                var respuesta = 0;
                var cadena = Constantes.CadenaConexion;
                using (SqlConnection cnx = new SqlConnection(cadena))
                {
                    cnx.Open();
                    using (var comando = new SqlCommand("[dbo].[Set_Usuario]", cnx))
                    {
                        comando.CommandTimeout = 0;
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.Add(new SqlParameter("@dni", dni));
                        comando.Parameters.Add(new SqlParameter("@nombre", nombre));
                        comando.Parameters.Add(new SqlParameter("@apellido", apellido));
                        comando.Parameters.Add(new SqlParameter("@correo", correo));
                        comando.Parameters.Add(new SqlParameter("@domicilio", domicilio));
                        comando.Parameters.Add(new SqlParameter("@sexo", sexo));
                        comando.Parameters.Add(new SqlParameter("@celular", celular));
                        comando.Parameters.Add(new SqlParameter("@clave", clave));

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
        public override int SetUsuario(int perfil, string dni, string nombre, string apellido, string correo, string domicilio, string celular, string clave)
        {
            try
            {
                var respuesta = 0;
                var cadena = Constantes.CadenaConexion;
                using (SqlConnection cnx = new SqlConnection(cadena))
                {
                    cnx.Open();
                    using (var comando = new SqlCommand("[dbo].[Set_Usuario_Sistema]", cnx))
                    {
                        comando.CommandTimeout = 0;
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.Add(new SqlParameter("@dni", dni));
                        comando.Parameters.Add(new SqlParameter("@nombre", nombre));
                        comando.Parameters.Add(new SqlParameter("@apellido", apellido));
                        comando.Parameters.Add(new SqlParameter("@correo", correo));
                        comando.Parameters.Add(new SqlParameter("@domicilio", domicilio));
                        comando.Parameters.Add(new SqlParameter("@celular", celular));
                        comando.Parameters.Add(new SqlParameter("@clave", clave));
                        comando.Parameters.Add(new SqlParameter("@idPerfil", perfil));

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
        public override int GetInicioSesion(string dni, string clave)
        {
            try
            {
                var respuesta = 0;
                var cadena = Constantes.CadenaConexion;
                using (SqlConnection cnx = new SqlConnection(cadena))
                {
                    cnx.Open();
                    using (var comando = new SqlCommand("[dbo].[Get_InicioSesion]", cnx))
                    {
                        comando.CommandTimeout = 0;
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.Add(new SqlParameter("@usuario", dni));
                        comando.Parameters.Add(new SqlParameter("@clave", clave));

                        var reader = comando.ExecuteReader(CommandBehavior.CloseConnection);

                        while (reader.Read())
                        {
                            respuesta = reader.IsDBNull(reader.GetOrdinal("ID_USUARIO")) ? 0 : reader.GetInt32(reader.GetOrdinal("ID_USUARIO"));
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

        public override List<UsuarioDTO> ListarUsuarioSistema()
        {
            try
            {
                var respuesta = new List<UsuarioDTO>();
                var cadena = Constantes.CadenaConexion;
                using (SqlConnection cnx = new SqlConnection(cadena))
                {
                    cnx.Open();
                    using (var comando = new SqlCommand("[dbo].[Get_ListarUsuarios_Sistema]", cnx))
                    {
                        comando.CommandTimeout = 0;
                        comando.CommandType = CommandType.StoredProcedure;

                        var reader = comando.ExecuteReader(CommandBehavior.CloseConnection);

                        while (reader.Read())
                        {
                            var obj = new UsuarioDTO();
                            obj.id = reader.IsDBNull(reader.GetOrdinal("ID_USUARIO")) ? 0 : reader.GetInt32(reader.GetOrdinal("ID_USUARIO"));
                            obj.nombre = reader.IsDBNull(reader.GetOrdinal("nombrecompleto")) ? string.Empty : reader.GetString(reader.GetOrdinal("nombrecompleto"));
                            obj.dni = reader.IsDBNull(reader.GetOrdinal("U_NOMBRE")) ? string.Empty : reader.GetString(reader.GetOrdinal("U_NOMBRE"));
                            obj.celular = reader.IsDBNull(reader.GetOrdinal("PER_TELEFONO")) ? string.Empty : reader.GetString(reader.GetOrdinal("PER_TELEFONO"));
                            obj.correo = reader.IsDBNull(reader.GetOrdinal("PER_EMAIL")) ? string.Empty : reader.GetString(reader.GetOrdinal("PER_EMAIL"));
                            obj.domicilio = reader.IsDBNull(reader.GetOrdinal("PER_DIRECCION")) ? string.Empty : reader.GetString(reader.GetOrdinal("PER_DIRECCION"));
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
        public override UsuarioDTO GetUsuarioSistemaEditar(int id)
        {
            try
            {
                var obj = new UsuarioDTO();
                var cadena = Constantes.CadenaConexion;
                using (SqlConnection cnx = new SqlConnection(cadena))
                {
                    cnx.Open();
                    using (var comando = new SqlCommand("[dbo].[Get_ListarUsuarios_Sistema]", cnx))
                    {
                        comando.CommandTimeout = 0;
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.Add(new SqlParameter("@usuario", id));

                        var reader = comando.ExecuteReader(CommandBehavior.CloseConnection);

                        while (reader.Read())
                        {
                            obj.id = reader.IsDBNull(reader.GetOrdinal("id")) ? 0 : reader.GetInt32(reader.GetOrdinal("id"));
                            obj.nombre = reader.IsDBNull(reader.GetOrdinal("nombre")) ? string.Empty : reader.GetString(reader.GetOrdinal("nombre"));
                            obj.apellido = reader.IsDBNull(reader.GetOrdinal("apellido")) ? string.Empty : reader.GetString(reader.GetOrdinal("apellido"));
                            obj.dni = reader.IsDBNull(reader.GetOrdinal("dni")) ? string.Empty : reader.GetString(reader.GetOrdinal("dni"));
                            obj.celular = reader.IsDBNull(reader.GetOrdinal("celular")) ? string.Empty : reader.GetString(reader.GetOrdinal("celular"));
                            obj.correo = reader.IsDBNull(reader.GetOrdinal("correo")) ? string.Empty : reader.GetString(reader.GetOrdinal("correo"));
                            obj.domicilio = reader.IsDBNull(reader.GetOrdinal("domicilio")) ? string.Empty : reader.GetString(reader.GetOrdinal("domicilio"));
                            obj.clave = reader.IsDBNull(reader.GetOrdinal("clave")) ? string.Empty : reader.GetString(reader.GetOrdinal("sexo"));
                            obj.idPerfil = reader.IsDBNull(reader.GetOrdinal("perfil")) ? 0 : reader.GetInt32(reader.GetOrdinal("perfil"));
                        }
                    }
                }
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override DataTable GetMenuUsuario(int idUsuario)
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

        public override void DeleteUsuario(int id)
        {
            try
            {
                var cadena = Constantes.CadenaConexion;
                using (SqlConnection cnx = new SqlConnection(cadena))
                {
                    cnx.Open();
                    using (var comando = new SqlCommand("[dbo].[Del_Usuario]", cnx))
                    {
                        comando.CommandTimeout = 0;
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.Add(new SqlParameter("@id", id));
                        comando.ExecuteNonQuery();
                        cnx.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override List<UsuarioDTO> comboAlumnos()
        {
            try
            {
                var resultado = new List<UsuarioDTO>();
                var cadena = Constantes.CadenaConexion;
                using (SqlConnection cnx = new SqlConnection(cadena))
                {
                    cnx.Open();
                    using (var comando = new SqlCommand("[dbo].[Get_Combo_Alumnos]", cnx))
                    {
                        comando.CommandTimeout = 0;
                        comando.CommandType = CommandType.StoredProcedure;
                        var reader = comando.ExecuteReader(CommandBehavior.CloseConnection);

                        while (reader.Read())
                        {
                            var obj = new UsuarioDTO();
                            obj.id = reader.IsDBNull(reader.GetOrdinal("ID_USUARIO")) ? 0 : reader.GetInt32(reader.GetOrdinal("ID_USUARIO"));
                            obj.nombre = reader.IsDBNull(reader.GetOrdinal("nombre")) ? string.Empty : reader.GetString(reader.GetOrdinal("nombre"));
                            resultado.Add(obj);
                        }
                    }
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override List<UsuarioDTO> comboApoderado()
        {
            try
            {
                var resultado = new List<UsuarioDTO>();
                var cadena = Constantes.CadenaConexion;
                using (SqlConnection cnx = new SqlConnection(cadena))
                {
                    cnx.Open();
                    using (var comando = new SqlCommand("[dbo].[Get_Combo_Apoderado]", cnx))
                    {
                        comando.CommandTimeout = 0;
                        comando.CommandType = CommandType.StoredProcedure;
                        var reader = comando.ExecuteReader(CommandBehavior.CloseConnection);

                        while (reader.Read())
                        {
                            var obj = new UsuarioDTO();
                            obj.id = reader.IsDBNull(reader.GetOrdinal("ID_USUARIO")) ? 0 : reader.GetInt32(reader.GetOrdinal("ID_USUARIO"));
                            obj.nombre = reader.IsDBNull(reader.GetOrdinal("nombre")) ? string.Empty : reader.GetString(reader.GetOrdinal("nombre"));
                            resultado.Add(obj);
                        }
                    }
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
