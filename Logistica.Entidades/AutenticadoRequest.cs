
using System;

namespace Logistica.Entidades
{
    public class AutenticadoRequest
    {
        public int IdSesion { get; set; }

        public long IdUsuario { get; set; }

        public string NroDocumento { get; set; }

        public string UserName { get; set; }
    }
}
