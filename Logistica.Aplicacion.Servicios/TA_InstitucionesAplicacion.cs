using Med.PEC.Aplicacion.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Med.PEC.Entidades;
using Med.PEC.Dominio.Interfaces;
using Med.PEC.Entidades.Maestro.Institucion;
using Med.PEC.Datos.DataAccess;

namespace Med.PEC.Aplicacion.Servicios
{



    public class TA_InstitucionesAplicacion : IInstituciones
    {
       // readonly ITA_Instituciones _Instituciones;
       /* public TA_InstitucionesAplicacion(ITA_Instituciones instituciones)
        {
            _Instituciones = instituciones;
        }*/
        //ˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆ
        //Metodo         : listarInstituciones
        //Creado por     : Eistein Dolores Tarazona (23/01/2018)
        //Utilizado por  : MED.PEC.APLICACIONES.SERVICIOS.INSTITUCIONES
        //ˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆ
        ///<summary>Permite recuperar datos de la Tabla = maestro.institucion</summary>        
        /// <param name="ent_Instituciones"></param>
        /// <returns></returns>
        public List<InstitucionResponse> listarInstituciones(InstitucionParameters ent_Instituciones)
        {
            //return null;
            return new TA_Instituciones().listarInstituciones(ent_Instituciones);
        }
    }
}
