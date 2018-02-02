using Med.PEC.Aplicacion.Interfaces;
using Med.PEC.Datos.Interfaces;
using Med.PEC.Dominio.Entidades;
using Med.PEC.Dominio.RepositorioInterfaces;
using Med.PEC.Entidades;
using Med.PEC.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Med.PEC.Aplicacion.Servicios
{
    public class PortalAplicacion : IPortalAplicacion
    {
        readonly IUnitOfWorkPEC _work;
        readonly IUbigeoRepository ubigeoRepository;
        readonly IColegioRepository colegioRepository;
        readonly ITipo_GestionRepository tipoGestionRepository;
        //readonly ITipo_NivelEducativoRepository tipo_NivelEducativoRepository;
        readonly ITipo_OcupacionRepository tipoOcupacionRepository;
        readonly ITipo_InstitucionRepository tipoInstitucionRepository;
        readonly ICarreraRepository carreraRepository;
        readonly IFamilia_CarreraRepository familia_CarreraRepository;
        readonly IInstitucionRepository institucionRepository;
        readonly ITipo_FinanciamientoRepository tipoFinanciamientoRepository;
        readonly IVista_InstitucionRepository vista_InstitucionRepository;
        private readonly ITypeAdapter _adapter;
        public PortalAplicacion(
            IUnitOfWorkPEC _work,
            IUbigeoRepository ubigeoRepository,
            IColegioRepository colegioRepository,
            ITipo_GestionRepository tipoGestionRepository,
            //ITipo_NivelEducativoRepository tipo_NivelEducativoRepository,
            ITipo_OcupacionRepository tipoOcupacionRepository,
            ITipo_InstitucionRepository tipoInstitucionRepository,
            ICarreraRepository carreraRepository,
            IFamilia_CarreraRepository familia_CarreraRepository,
            IInstitucionRepository institucionRepository,
            ITipo_FinanciamientoRepository tipoFinanciamientoRepository,
            IVista_InstitucionRepository vista_InstitucionRepository
            )
        {
            this._work = _work;
            this.ubigeoRepository = ubigeoRepository;
            this.colegioRepository = colegioRepository;
            this.tipoGestionRepository = tipoGestionRepository;
            //this.tipo_NivelEducativoRepository = tipo_NivelEducativoRepository;
            this.tipoOcupacionRepository = tipoOcupacionRepository;
            this.tipoInstitucionRepository = tipoInstitucionRepository;
            this.carreraRepository = carreraRepository;
            this.familia_CarreraRepository = familia_CarreraRepository;
            this.institucionRepository = institucionRepository;
            this.tipoFinanciamientoRepository = tipoFinanciamientoRepository;
            this.vista_InstitucionRepository = vista_InstitucionRepository;
            //instancia el mapper
            _adapter = TypeAdapterFactory.Create();
        }

        #region Recomendador Paso 1
        public StatusResponse<Dictionary<string, string>> ListarDepartamento()
        {
            return new StatusResponse<Dictionary<string, string>> { Data = ubigeoRepository.ListarDepartamentos(), Success = true };
        }

        public StatusResponse<Dictionary<string, string>> ListarProvincia(string coddep)
        {
            return new StatusResponse<Dictionary<string, string>> { Data = ubigeoRepository.ListarProvincia(coddep), Success = true };
        }

        public StatusResponse<Dictionary<string, string>> ListarDistrito(string codpro)
        {
            return new StatusResponse<Dictionary<string, string>> { Data = ubigeoRepository.ListarDistritos(codpro), Success = true };
        }
        #endregion

        #region Recomendador Paso 2
        public StatusResponse<ColegioListarResponse> ListarColegio(ColegioFilter filtro)
        {
            var pagedResponse = SpecificationFilter.Apply(filtro, colegioRepository.Query(true));

            var listResponse = _adapter.ToDto<colegio, ColegioResponse>(pagedResponse.Data.ToList());

            var data = new ColegioListarResponse() { Colegios = listResponse, Row = pagedResponse.TotalRows, Total = pagedResponse.TotalPages };

            return new StatusResponse<ColegioListarResponse>() { Success = true, Data = data };
        }

        public StatusResponse<Dictionary<int, string>> ListarTipoGestion()
        {
            return new StatusResponse<Dictionary<int, string>> { Data = tipoGestionRepository.Query(false).ToDictionary(x => x.ID_TIPO_GESTION, x => x.NOMBRE), Success = true };
        }

        public StatusResponse<List<TipoNivelEducativoResponse>> ListarTipoNivelEducativo()
        {
            //var list = new List<TipoNivelEducativoResponse>();
            //list.Add(new TipoNivelEducativoResponse() { IdTipoNivelEducativo = 1, Nombre = "1" });
            //list.Add(new TipoNivelEducativoResponse() { IdTipoNivelEducativo = 2, Nombre = "2" });
            //list.Add(new TipoNivelEducativoResponse() { IdTipoNivelEducativo = 3, Nombre = "3" });
            //list.Add(new TipoNivelEducativoResponse() { IdTipoNivelEducativo = 4, Nombre = "4" });
            //list.Add(new TipoNivelEducativoResponse() { IdTipoNivelEducativo = 5, Nombre = "5" });
            //return new StatusResponse<List<TipoNivelEducativoResponse>> { Data = list, Success = true };
            return null;
        }
        #endregion

        #region Recomendador Paso 3
        public StatusResponse<Dictionary<int, string>> ListarTipoOcupacion()
        {
            return new StatusResponse<Dictionary<int, string>> { Data = tipoOcupacionRepository.Query(false).ToDictionary(x => x.ID_TIPO_OCUPACION, x => x.NOMBRE), Success = true };
        }

        public StatusResponse<Dictionary<int, string>> ListarTipoInstitucion()
        {
            return new StatusResponse<Dictionary<int, string>> { Data = tipoInstitucionRepository.Query(false).ToDictionary(x => x.ID_TIPO_INSTITUCION, x => x.NOMBRE), Success = true };
        }
        #endregion

        #region Recomendador Paso 4
        public StatusResponse<Dictionary<int, string>> ListarFamiliaCarrera()
        {
            //return new StatusResponse<Dictionary<int, string>> { Data = carreraRepository.Query(false).ToDictionary(x => x.ID_CARRERA, x => x.NOMBRE), Success = true };
            return new StatusResponse<Dictionary<int, string>> { Data = familia_CarreraRepository.Query(false).OrderBy( x => x.NOMBRE).ToDictionary(x => x.ID_FAMILIA_CARRERA, x => x.NOMBRE), Success = true };
        }

        public StatusResponse<Dictionary<string, string>> ListarInstitucion()
        {
            //return new StatusResponse<Dictionary<string, string>> { Data = institucionRepository.Query(false).ToDictionary(x => x.ID_INSTITUCION, x => x.NOMBRE_LARGO), Success = true };
            return new StatusResponse<Dictionary<string, string>> { Data = institucionRepository.Query(false).Take(20).ToDictionary(x => x.ID_INSTITUCION, x => x.NOMBRE_LARGO), Success = true };
        }

        public StatusResponse<Dictionary<int, string>> ListarTipoFinanciamiento()
        {
            return new StatusResponse<Dictionary<int, string>> { Data = tipoFinanciamientoRepository.Query(false).ToDictionary(x => x.ID_TIPO_FINANCIAMIENTO, x => x.NOMBRE), Success = true };
        }
        #endregion

        #region Recomendador Resultados
        public StatusResponse<InstitucionListarResponse> ListarResultadosInstitucion(VistaInstitucionFilter filtro)
        {
            //var pagedResponse = SpecificationFilter.Apply(filtro, vista_InstitucionRepository.Query(true));
            var idsTipoLocalidad = new List<int>() { 2, 4, 9, 10, 16, 17, 25, 31 };
            var pagedResponse = vista_InstitucionRepository.Query(true)
                                .Where(
                                    x =>
                                    x.ID_TIPO_INSTITUCION == filtro.IdTipoInstitucion &&
                                    (x.ID_TIPO_LOCALIDAD == 9 || x.ID_TIPO_LOCALIDAD == 16 || x.ID_TIPO_LOCALIDAD == 17 || x.ID_TIPO_LOCALIDAD == 25 || x.ID_TIPO_LOCALIDAD == 31)
                                    &&
                                    //2:Campus Universitario, 4:Local Universitario,9:Sede,10:Local Administrativo,16:Sede única,17:Sede Principal,25:Campus Principal,31:Ciudad Universitaria
                                    (
                                        (filtro.IdFamiliaCarrera == 0 && filtro.IdInstitucion == 0) ||
                                        (filtro.IdFamiliaCarrera > 0 && x.ID_FAMILIA_CARRERA == filtro.IdFamiliaCarrera)
                                    )
                                )
                                .OrderBy( x => x.NOMBRE_INSTITUCION);

            var listResponse = _adapter.ToDto<vista_institucion, VistaInstitucionResponse>(pagedResponse.ToList());

            //var data = new InstitucionListarResponse() { Instituciones = listResponse, Row = pagedResponse.TotalRows, Total = pagedResponse.TotalPages };
            var data = new InstitucionListarResponse() { Instituciones = listResponse, Row = 100, Total = 10 };

            return new StatusResponse<InstitucionListarResponse>() { Success = true, Data = data };
        }
        #endregion
    }
}
