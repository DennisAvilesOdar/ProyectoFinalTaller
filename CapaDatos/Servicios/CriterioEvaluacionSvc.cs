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
    public class CriterioEvaluacionSvc : CriterioEvaluacionDAO
    {
        public override List<CriterioEvaluacionDTO> GetListado()
        {
            try
            {
                var respuesta = new List<CriterioEvaluacionDTO>();
                var cadena = Constantes.CadenaConexion;
                using (SqlConnection cnx = new SqlConnection(cadena))
                {
                    cnx.Open();
                    using (var comando = new SqlCommand("[dbo].[Get_Criterio_Evaluacion_listado]", cnx))
                    {
                        comando.CommandTimeout = 0;
                        comando.CommandType = CommandType.StoredProcedure;

                        var reader = comando.ExecuteReader(CommandBehavior.CloseConnection);

                        while (reader.Read())
                        {
                            var obj = new CriterioEvaluacionDTO();
                            obj.ID_CRITERIO_EVAL = reader.IsDBNull(reader.GetOrdinal("ID_CRITERIO_EVAL")) ? 0 : reader.GetInt32(reader.GetOrdinal("ID_CRITERIO_EVAL"));
                            obj.CE_NOMBRE = reader.IsDBNull(reader.GetOrdinal("CE_NOMBRE")) ? String.Empty : reader.GetString(reader.GetOrdinal("CE_NOMBRE"));
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
        public override CriterioEvaluacionDTO GetCriterioId(int id)
        {
            try
            {
                var obj = new CriterioEvaluacionDTO();
                var cadena = Constantes.CadenaConexion;
                using (SqlConnection cnx = new SqlConnection(cadena))
                {
                    cnx.Open();
                    using (var comando = new SqlCommand("[dbo].[Get_Criterio_Evaluacion_Id]", cnx))
                    {
                        comando.CommandTimeout = 0;
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.Add(new SqlParameter("@id", id));

                        var reader = comando.ExecuteReader(CommandBehavior.CloseConnection);

                        while (reader.Read())
                        {
                            obj.ID_CRITERIO_EVAL = id;
                            obj.CE_NOMBRE = reader.IsDBNull(reader.GetOrdinal("CE_NOMBRE")) ? String.Empty : reader.GetString(reader.GetOrdinal("CE_NOMBRE"));
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
        public override void SetCriterio(string nombre)
        {
            try
            {
                var cadena = Constantes.CadenaConexion;
                using (SqlConnection cnx = new SqlConnection(cadena))
                {
                    cnx.Open();
                    using (var comando = new SqlCommand("[dbo].[Set_Criterio_Evaluacion]", cnx))
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
        public override void UpdateCriterio(int id, string nombre)
        {
            try
            {
                var cadena = Constantes.CadenaConexion;
                using (SqlConnection cnx = new SqlConnection(cadena))
                {
                    cnx.Open();
                    using (var comando = new SqlCommand("[dbo].[Udp_Criterio_Evaluacion]", cnx))
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
        public override void DeleteCriterioId(int id)
        {
            try
            {
                var cadena = Constantes.CadenaConexion;
                using (SqlConnection cnx = new SqlConnection(cadena))
                {
                    cnx.Open();
                    using (var comando = new SqlCommand("[dbo].[Del_Criterio_Evaluacion]", cnx))
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
