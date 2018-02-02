using Logistica.Aplicacion.Interfaces;
using System.Collections.Generic;
using Logistica.Entidades;
using Logistica.Framework;

namespace Logistica.Servicios.Host
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "AdministracionServicio" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione AdministracionServicio.svc o AdministracionServicio.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class AdministracionServicio : IAdministracionServicio
    {
        private readonly IAdministracionAplicacion administracionAplicacion;

        public AdministracionServicio(IAdministracionAplicacion administracionAplicacion)
        {
            this.administracionAplicacion = administracionAplicacion;
        }

        public StatusResponse ModificarCategoria(CategoriaRequest request)
        {
            return administracionAplicacion.ModificarCategoria(request);
        }

        public StatusResponse<CategoriaResponse> RegistrarCategoria(CategoriaRequest request)
        {
            return administracionAplicacion.RegistrarCategoria(request);
        }
    }
}
