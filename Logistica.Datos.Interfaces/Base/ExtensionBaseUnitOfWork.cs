using Med.Comun.Datos.ICore;
using Newtonsoft.Json;

namespace Logistica.Datos.Interfaces
{
    public static class ExtensionBaseUnitOfWork
    {
        public static int Save(this IBaseUnitOfWork baseUnitOfWork, dynamic medatada)
        {
            return baseUnitOfWork.Save(JsonConvert.SerializeObject(medatada));
        }
    }
}
