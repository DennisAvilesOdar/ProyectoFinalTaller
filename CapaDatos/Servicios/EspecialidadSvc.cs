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
    public class EspecialidadSvc : EspecialidadDAO
    {
        public override List<EspecialidadDTO> GetListado()
        {
            try
            {
                var respuesta = new List<EspecialidadDTO>();
                var cadena = Constantes.CadenaConexion;
                using (SqlConnection cnx = new SqlConnection(cadena))
                {
                    cnx.Open();
                    using (var comando = new SqlCommand("[dbo].[Get_Especialidad_Listado]", cnx))
                    {
                        comando.CommandTimeout = 0;
                        comando.CommandType = CommandType.StoredProcedure;

                        var reader = comando.ExecuteReader(CommandBehavior.CloseConnection);

                        while (reader.Read())
                        {
                            var obj = new EspecialidadDTO();
                            obj.ID_ESPECIALIDAD = reader.IsDBNull(reader.GetOrdinal("ID_ESPECIALIDAD")) ? 0 : reader.GetInt32(reader.GetOrdinal("ID_ESPECIALIDAD"));
                            obj.ESP_NOMBRE = reader.IsDBNull(reader.GetOrdinal("ESP_NOMBRE")) ? 0 : reader.GetInt32(reader.GetOrdinal("ESP_NOMBRE"));
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
        public override EspecialidadDTO GetEspecialidadId(int id)
        {
            try
            {
                var obj = new EspecialidadDTO();
                var cadena = Constantes.CadenaConexion;
                using (SqlConnection cnx = new SqlConnection(cadena))
                {
                    cnx.Open();
                    using (var comando = new SqlCommand("[dbo].[Get_Especialidad_Id]", cnx))
                    {
                        comando.CommandTimeout = 0;
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.Add(new SqlParameter("@id", id));

                        var reader = comando.ExecuteReader(CommandBehavior.CloseConnection);

                        while (reader.Read())
                        {
                            obj.ID_ESPECIALIDAD = id;
                            obj.ESP_NOMBRE = reader.IsDBNull(reader.GetOrdinal("ESP_NOMBRE")) ? 0 : reader.GetInt32(reader.GetOrdinal("ESP_NOMBRE"));
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
        public override void SetEspecialidad(int nombre)
        {
            try
            {
                var obj = new PlanDTO();
                var cadena = Constantes.CadenaConexion;
                using (SqlConnection cnx = new SqlConnection(cadena))
                {
                    cnx.Open();
                    using (var comando = new SqlCommand("[dbo].[Set_Especialidad]", cnx))
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
        public override void UpdateEspecialidad(int id, int nombre)
        {
            try
            {
                var obj = new PlanDTO();
                var cadena = Constantes.CadenaConexion;
                using (SqlConnection cnx = new SqlConnection(cadena))
                {
                    cnx.Open();
                    using (var comando = new SqlCommand("[dbo].[Upd_Especialidad]", cnx))
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
        public override void DeleteEspecialidadiId(int id)
        {
            try
            {
                var obj = new PlanDTO();
                var cadena = Constantes.CadenaConexion;
                using (SqlConnection cnx = new SqlConnection(cadena))
                {
                    cnx.Open();
                    using (var comando = new SqlCommand("[dbo].[Del_Especialidad]", cnx))
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
