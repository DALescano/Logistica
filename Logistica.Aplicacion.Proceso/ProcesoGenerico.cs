using System;
using System.Collections.Generic;
using System.Linq;
using Logistica.Entidades;
using Med.Comun.Core;

namespace Logistica.Aplicacion.Proceso
{
    //============================================================//
    // Clase de uso Generico , NO agregar mas Propiedades
    //============================================================//

    public abstract class ProcesoGenerico<T> where T : class
    {
        private readonly List<string> _list;
        private readonly StatusResponse _status;

        protected ProcesoGenerico()
        {
            _status = new StatusResponse();
            _list = new List<string>(); //Default
            Autenticado = new AutenticadoRequest(); //Default

        }

        public AutenticadoRequest Autenticado { get; set; }

        protected StatusResponse Status
        {
            get
            {
                return _status;
            }
        }

        #region abstract

        protected abstract StatusResponse Modificar(T request);

        protected abstract StatusResponse Registrar(T request);

        #endregion abstract

        #region virtual

        protected virtual StatusResponse Anular(T request)
        {
            return _status;
        }

        protected virtual StatusResponse Aprobar(T request)
        {
            return _status;
        }

        protected virtual StatusResponse Eliminar(T request)
        {
            return _status;
        }

        protected virtual StatusResponse Observar(T request)
        {
            return _status;
        }

        protected virtual StatusResponse Solicitar(T request)
        {
            return _status;
        }

        protected virtual List<string> Validar(T request)
        {
            return _list; // Default
        }

        protected virtual List<string> ValidarAnulacion(T request)
        {
            return _list; // Default
        }

        protected virtual List<string> ValidarAprobacion(T request)
        {
            return _list; // Default
        }

        protected virtual List<string> ValidarEliminacion(T request)
        {
            return _list; // Default
        }

        protected virtual List<string> ValidarObservacion(T request)
        {
            return _list; // Default
        }

        protected virtual List<string> ValidarSolicitud(T request)
        {
            return _list; // Default
        }

        #endregion virtual

        #region public

        public StatusResponse EjecutaAnular(T request)
        {
            return Execute(() => ValidarAnulacion(request), () => Anular(request));
        }

        public StatusResponse EjecutaAprobar(T request)
        {
            return Execute(() => ValidarAprobacion(request), () => Aprobar(request));
        }

        public StatusResponse EjecutaEliminar(T request)
        {
            return Execute(() => ValidarEliminacion(request), () => Eliminar(request));
        }

        public StatusResponse EjecutaModificar(T request)
        {
            return Execute(() => Validar(request), () => Modificar(request));
        }

        public StatusResponse EjecutaObservar(T request)
        {
            return Execute(() => ValidarObservacion(request), () => Observar(request));
        }

        public StatusResponse EjecutaRegistrar(T request)
        {
            return Execute(() => Validar(request), () => Registrar(request));
        }

        public StatusResponse EjecutaSolicitar(T request)
        {
            return Execute(() => ValidarSolicitud(request), () => Solicitar(request));
        }

        #endregion public

        #region private methods

        private StatusResponse Execute(Func<List<string>> funcToVal, Func<StatusResponse> funcToRun)
        {
            var errors = funcToVal();

            if (errors.Any())
            {
                _status.Success = false;
                _status.Messages = errors;

                return _status;
            }
            _status.Success = true;

            return funcToRun();
        }

        #endregion private methods
    }
}
