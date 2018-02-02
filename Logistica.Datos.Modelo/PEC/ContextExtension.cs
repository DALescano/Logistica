using Med.Comun.Datos.ICore;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace Logistica.Datos.Modelo.PEC
{
    public partial class PECDbContext
    {
        private string _jsonAutenticado;
        private EntityAudit[] _records;


        public void SaveChanges(string jsonAuthN)
        {
            //1. Recuperar Objetos y Token de Usuario

        }

        public void SaveAudit()
        {
            //2. Envia Objetos y Token de Usuario al Proxy de Servicio de Auditoria
            
        }
    }
}
