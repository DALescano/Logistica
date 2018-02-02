
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using DO = Med.PEC.Dominio.Interfaces;
using System.Data.SqlClient;
using Med.PEC.Entidades.Maestro.Institucion;
using Med.PEC.Entidades;
using System.Data;

namespace Med.PEC.Datos.DataAccess
{
    public class TA_Instituciones : DO.ITA_Instituciones
    {
        string conexion = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        public List<InstitucionResponse> listarInstituciones(InstitucionParameters ent_Instituciones)
        {
            List<InstitucionResponse> Query = null;

            using (SqlConnection cn = new SqlConnection(conexion))
            {
                using (SqlCommand cmd = new SqlCommand("maestro.USP_INSTITUCION_RESULTADOS_LISTAR", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID_TIPO_INSTITUCION", ent_Instituciones.IdTipoInstitucion);
                    cmd.Parameters.AddWithValue("@ID_FAMILIA_CARRERA", ent_Instituciones.IdFamiliaCarrera);
                    cmd.Parameters.AddWithValue("@ID_INSTITUCION", ent_Instituciones.IdInstitucion);
                    cmd.Parameters.AddWithValue("@ID_UBIGEO_DISTRITO", ent_Instituciones.IdUbigeoDistrito);
                    cmd.Parameters.AddWithValue("@ID_UBIGEO_PROVINCIA", ent_Instituciones.IdUbigeoProvincia);
                    cmd.Parameters.AddWithValue("@ID_UBIGEO_DEPARTAMENTO", ent_Instituciones.IdUbigeoDepartamento);
                    cmd.Parameters.AddWithValue("@PRESUPUESTO_APROXIMADO", ent_Instituciones.PresupuetoAproximado);
                    /*cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID_TIPO_INSTITUCION", 1);
                    cmd.Parameters.AddWithValue("@ID_FAMILIA_CARRERA", 341);
                    cmd.Parameters.AddWithValue("@ID_INSTITUCION", 0);
                    cmd.Parameters.AddWithValue("@ID_UBIGEO_DISTRITO", "150117");
                    cmd.Parameters.AddWithValue("@ID_UBIGEO_PROVINCIA", "1501");
                    cmd.Parameters.AddWithValue("@ID_UBIGEO_DEPARTAMENTO", "15");
                    cmd.Parameters.AddWithValue("@PRESUPUESTO_APROXIMADO", 0);*/
                    cn.Open();
                    DataTable tb = new DataTable();

                    SqlDataAdapter daa = new SqlDataAdapter(cmd);
                    daa.Fill(tb);

                    SqlDataReader rd = cmd.ExecuteReader();
                    if (rd.HasRows)
                    {
                        Query = new List<InstitucionResponse>();
                        while (rd.Read())
                        {
                            InstitucionResponse ent = new InstitucionResponse()
                            {
                                ID_INSTITUCION = rd["ID_INSTITUCION"].ToString(),
                                ID_TIPO_INSTITUCION = rd["ID_TIPO_INSTITUCION"].ToString(),
                                NOMBRE_INSTITUCION = rd["NOMBRE_INSTITUCION"].ToString(),
                                NOMBRE_TIPO_LOCALIDAD = rd["NOMBRE_TIPO_LOCALIDAD"].ToString(),
                                ID_TIPO_LOCALIDAD = rd["ID_TIPO_LOCALIDAD"].ToString(),
                                LOCALIDAD_ID_UBIGEO = rd["LOCALIDAD_ID_UBIGEO"].ToString(),
                                UBIGEO_NOMBRE = rd["UBIGEO_NOMBRE"].ToString(),
                                ID_TIPO_GESTION = rd["ID_TIPO_GESTION"].ToString(),
                                NOMBRE_TIPO_GESTION = rd["NOMBRE_TIPO_GESTION"].ToString(),
                                NOMBRE_CARRERA = rd["NOMBRE_CARRERA"].ToString(),
                                ID_FAMILIA_CARRERA = rd["ID_FAMILIA_CARRERA"].ToString(),
                                PENSION_MENSUAL = rd["PENSION_MENSUAL"].ToString(),
                                COSTO_TOTAL_ANUAL = rd["COSTO_TOTAL_ANUAL"].ToString(),
                                ANIOS_DURACION = rd["ANIOS_DURACION"].ToString(),
                                INGRESO_PROMEDIO_MENSUAL = rd["INGRESO_PROMEDIO_MENSUAL"].ToString(),
                                PAGINA_WEB = rd["PAGINA_WEB"].ToString()
                            };
                            Query.Add(ent);
                        }

                    }
                }
            }
            return Query;
        }
    }
}
