using Med.Comun.Core.EventLog;
using Med.Comun.Core.Pagination;
using System;
using System.Collections.Generic;
using Logistica.Entidades;
using Logistica.Framework;

namespace Logistica.Aplicacion.Interfaces
{
	public interface IAdministracionAplicacion
	{
        #region Categoria
        StatusResponse ModificarCategoria(CategoriaRequest request);
        StatusResponse<CategoriaResponse> RegistrarCategoria(CategoriaRequest request);
        #endregion
    }
}
