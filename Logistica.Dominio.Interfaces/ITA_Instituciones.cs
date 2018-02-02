using Med.PEC.Dominio.Entidades;
using Med.PEC.Entidades;
using Med.PEC.Entidades.Maestro.Institucion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Med.PEC.Dominio.Interfaces
{
    public interface ITA_Instituciones
    {
        //ˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆ
        //Metodo         : listarInstituciones
        //Creado por     : Eistein Dolores Tarazona (23/01/2018)
        //Utilizado por  : MED.PEC.APLICACIONES.INTERFACES.IINSTITUCIONES
        //ˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆ
        ///<summary>Permite recuperar datos de la Tabla = maestro.institucion</summary>        
        /// <param name="ent_Instituciones"></param>
        /// <returns></returns>
        List<InstitucionResponse> listarInstituciones(InstitucionParameters ent_Instituciones);
    }
}
