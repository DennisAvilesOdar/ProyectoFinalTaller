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
    public class SeccionSvc : SeccionDAO
    {
        public override List<SeccionDTO> GetListado()
        {
            try
            {
                var respuesta = new List<SeccionDTO>();
                var cadena = Constantes.CadenaConexion;
                using (SqlConnection cnx = new SqlConnection(cadena))
                {
                    cnx.Open();
                    using (var comando = new SqlCommand("[dbo].[Get_Seccion_Listado]", cnx))
                    {
                        comando.CommandTimeout = 0;
                        comando.CommandType = CommandType.StoredProcedure;

                        var reader = comando.ExecuteReader(CommandBehavior.CloseConnection);

                        while (reader.Read())
                        {
                            var obj = new SeccionDTO();
                            obj.ID_SECCION = reader.IsDBNull(reader.GetOrdinal("ID_SECCION")) ? 0 : reader.GetInt32(reader.GetOrdinal("ID_SECCION"));
                            obj.SEC_NOMBRE = reader.IsDBNull(reader.GetOrdinal("SEC_NOMBRE")) ? String.Empty : reader.GetString(reader.GetOrdinal("SEC_NOMBRE"));
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
        public override SeccionDTO GetSeccionId(int id)
        {
            try
            {
                var obj = new SeccionDTO();
                var cadena = Constantes.CadenaConexion;
                using (SqlConnection cnx = new SqlConnection(cadena))
                {
                    cnx.Open();
                    using (var comando = new SqlCommand("[dbo].[Get_Seccion_Id]", cnx))
                    {
                        comando.CommandTimeout = 0;
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.Add(new SqlParameter("@id", id));

                        var reader = comando.ExecuteReader(CommandBehavior.CloseConnection);

                        while (reader.Read())
                        {
                            obj.ID_SECCION = id;
                            obj.SEC_NOMBRE = reader.IsDBNull(reader.GetOrdinal("SEC_NOMBRE")) ? String.Empty : reader.GetString(reader.GetOrdinal("SEC_NOMBRE"));
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
        public override void SetSeccion(string nombre)
        {
            try
            {
                var obj = new PlanDTO();
                var cadena = Constantes.CadenaConexion;
                using (SqlConnection cnx = new SqlConnection(cadena))
                {
                    cnx.Open();
                    using (var comando = new SqlCommand("[dbo].[Set_Seccion]", cnx))
                    {
                        comando.CommandTimeout = 0;
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.Add(new SqlParameter("@nombre", nombre));
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
        public override void UpdateSeccion(int id, string nombre)
        {
            try
            {
                var obj = new PlanDTO();
                var cadena = Constantes.CadenaConexion;
                using (SqlConnection cnx = new SqlConnection(cadena))
                {
                    cnx.Open();
                    using (var comando = new SqlCommand("[dbo].[Upd_Seccion]", cnx))
                    {
                        comando.CommandTimeout = 0;
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.Add(new SqlParameter("@id", id));
                        comando.Parameters.Add(new SqlParameter("@nombre", nombre));
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
        public override void DeleteSeccioniId(int id)
        {
            try
            {
                var obj = new PlanDTO();
                var cadena = Constantes.CadenaConexion;
                using (SqlConnection cnx = new SqlConnection(cadena))
                {
                    cnx.Open();
                    using (var comando = new SqlCommand("[dbo].[Del_Seccion]", cnx))
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
    }
}
