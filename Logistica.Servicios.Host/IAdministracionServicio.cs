
using Logistica.Entidades;
using Logistica.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Logistica.Servicios.Host
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IAdministracionServicio" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IAdministracionServicio
    {
        #region Categoria
        [OperationContract]
        StatusResponse ModificarCategoria(CategoriaRequest request);
        [OperationContract]
        StatusResponse<CategoriaResponse> RegistrarCategoria(CategoriaRequest request);
        #endregion

    }
}
