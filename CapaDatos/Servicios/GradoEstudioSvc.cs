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
    public class GradoEstudioSvc : GradoEstudioDAO
    {
        public override List<GradoEstudioDTO> GetListado()
        {
            try
            {
                var respuesta = new List<GradoEstudioDTO>();
                var cadena = Constantes.CadenaConexion;
                using (SqlConnection cnx = new SqlConnection(cadena))
                {
                    cnx.Open();
                    using (var comando = new SqlCommand("[dbo].[Get_Grado_Estudio_Listado]", cnx))
                    {
                        comando.CommandTimeout = 0;
                        comando.CommandType = CommandType.StoredProcedure;

                        var reader = comando.ExecuteReader(CommandBehavior.CloseConnection);

                        while (reader.Read())
                        {
                            var obj = new GradoEstudioDTO();
                            obj.ID_GRADO_ESTUDIO = reader.IsDBNull(reader.GetOrdinal("ID_GRADO_ESTUDIO")) ? 0 : reader.GetInt32(reader.GetOrdinal("ID_GRADO_ESTUDIO"));
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
        public override GradoEstudioDTO GetGradoEstudioId(int id)
        {
            try
            {
                var obj = new GradoEstudioDTO();
                var cadena = Constantes.CadenaConexion;
                using (SqlConnection cnx = new SqlConnection(cadena))
                {
                    cnx.Open();
                    using (var comando = new SqlCommand("[dbo].[Get_Grado_Estudio_Id]", cnx))
                    {
                        comando.CommandTimeout = 0;
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.Add(new SqlParameter("@id", id));

                        var reader = comando.ExecuteReader(CommandBehavior.CloseConnection);

                        while (reader.Read())
                        {
                            obj.ID_GRADO_ESTUDIO = id;
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
        public override void SetGradoEstudio(int nombre)
        {
            try
            {
                var obj = new PlanDTO();
                var cadena = Constantes.CadenaConexion;
                using (SqlConnection cnx = new SqlConnection(cadena))
                {
                    cnx.Open();
                    using (var comando = new SqlCommand("[dbo].[Set_GradoEstudio]", cnx))
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
        public override void UpdateGradoEstudio(int id, string nombre)
        {
            try
            {
                var obj = new PlanDTO();
                var cadena = Constantes.CadenaConexion;
                using (SqlConnection cnx = new SqlConnection(cadena))
                {
                    cnx.Open();
                    using (var comando = new SqlCommand("[dbo].[Upd_Grado_Estudio]", cnx))
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
        public override void DeleteGradoEstudioiId(int id)
        {
            try
            {
                var obj = new PlanDTO();
                var cadena = Constantes.CadenaConexion;
                using (SqlConnection cnx = new SqlConnection(cadena))
                {
                    cnx.Open();
                    using (var comando = new SqlCommand("[dbo].[Del_Grado_Estudio]", cnx))
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
