
using System.Collections.Generic;
using System.Linq;
using Logistica.Aplicacion.Proceso;
using Logistica.Dominio.RepositorioInterfaces;
using Logistica.Entidades;
using Logistica.Framework;
using Logistica.Datos.Interfaces;

namespace Logistica.Aplicacion.Servicios.Validacion
{
    public class AdministracionValidacion : BaseValidacion
    {
        #region Categoria
        public StatusResponse ValidarRegistrarCategoria(CategoriaRequest request)
        {
            var errores = ValidationManager.ValidateEntity(request);
            if (errores.Any())
            {
                return new StatusResponse { Success = false, Messages = errores };
            }
            else
            {
                return new StatusResponse { Success = true };
            }
        }

        public StatusResponse ValidarModificarCategoria(CategoriaRequest request)
        {
            var errores = ValidationManager.ValidateEntity(request);
            if (errores.Any())
            {
                return new StatusResponse { Success = false, Messages = errores };
            }
            else
            {
                return new StatusResponse { Success = true };
            }
        }
        #endregion
    }
}











