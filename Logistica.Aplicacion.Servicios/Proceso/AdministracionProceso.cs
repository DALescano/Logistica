using Logistica.Datos.Interfaces;
using Logistica.Dominio.Entidades;
using Logistica.Dominio.RepositorioInterfaces;
using Logistica.Entidades;
using Logistica.Framework;
using Med.Comun.Datos.ICore;

namespace Logistica.Aplicacion.Servicios.Proceso
{
    public class AdministracionProceso
    {

        #region Constructor
        private readonly IContext _context;
        private readonly IUnitOfWorkPEC _work;
        private readonly ICategoriaRepository categoriaRepository;
        private readonly ITypeAdapter _adapter;

        public AdministracionProceso(IUnitOfWorkPEC work
        , ICategoriaRepository categoriaRepository        
        )
        {
            _work = work;
            this.categoriaRepository = categoriaRepository;
            _context = work.Context;
            _adapter = TypeAdapterFactory.Create();
        }
        #endregion

        #region Categoria
        public StatusResponse ModificarCategoria(CategoriaRequest request)
        {
            Categoria categoria = _adapter.ToEntity<CategoriaRequest, Categoria>(request);
            categoriaRepository.Update(categoria);
            var resultado = _work.Save();

            if (resultado <= 0)
            {
                return new StatusResponse() { Message = Mensajes.ErrorGuardar };
            }
            else
            {
                return new StatusResponse() { Success = true, Message = Mensajes.ActualizacionCorrecta };
            }

        }

        public StatusResponse<CategoriaResponse> RegistrarCategoria(CategoriaRequest request)
        {

            Categoria categoria = _adapter.ToEntity<CategoriaRequest, Categoria>(request);
            categoriaRepository.Add(categoria);
            var resultado = _work.Save();

            if (resultado <= 0)
            {
                return new StatusResponse<CategoriaResponse>() { Message = Mensajes.ErrorGuardar };
            }
            else
            {
                return new StatusResponse<CategoriaResponse>() { Success = true, Message = Mensajes.RegistroCorrecto, Data = _adapter.ToDto<Categoria, CategoriaResponse>(categoria) };
            }
        }
        #endregion
    }
}














