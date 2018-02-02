using Logistica.Aplicacion.Interfaces;
using Logistica.Aplicacion.Servicios.Proceso;
using Logistica.Aplicacion.Servicios.Validacion;
using Logistica.Datos.Interfaces;
using Logistica.Dominio.Entidades;
using Logistica.Dominio.RepositorioInterfaces;
using Logistica.Entidades;
using Logistica.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Logistica.Aplicacion.Servicios
{
    public class AdministracionAplicacion : IAdministracionAplicacion
    {
        readonly ICategoriaRepository categoriaRepository;
        private readonly ITypeAdapter _adapter;
        readonly AdministracionValidacion administracionValidacion;
        readonly AdministracionProceso administracionProceso;

        public AdministracionAplicacion(
            AdministracionValidacion administracionValidacion,
            AdministracionProceso administracionProceso,
            ICategoriaRepository categoriaRepository
            )
        {
            this.categoriaRepository = categoriaRepository;
            this.administracionProceso = administracionProceso;
            this.administracionValidacion = administracionValidacion;
            //instancia el mapper
            _adapter = TypeAdapterFactory.Create();
        }

        #region Categoria
        public StatusResponse ModificarCategoria(CategoriaRequest request)
        {
            var validate = administracionValidacion.ValidarModificarCategoria(request);
            if (!validate.Success)
                return validate;

            var proceso = administracionProceso.ModificarCategoria(request);
            return proceso;
        }

        public StatusResponse<CategoriaResponse> RegistrarCategoria(CategoriaRequest request)
        {
            var validate = administracionValidacion.ValidarRegistrarCategoria(request);
            if (!validate.Success)
                return new StatusResponse<CategoriaResponse>() { Success = false, Messages = validate.Messages };

            var proceso = administracionProceso.RegistrarCategoria(request);
            return proceso;
        }
        #endregion

    }
}
