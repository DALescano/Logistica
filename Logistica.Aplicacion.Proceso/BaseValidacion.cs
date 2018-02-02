
using System.Collections.Generic;

namespace Logistica.Aplicacion.Proceso
{
    //============================================================//
    // Clase de uso Generico , NO agregar mas Propiedades
    //============================================================//

    public abstract class BaseValidacion //: BaseServicio
    {
        protected BaseValidacion()
        {
            Msg = new List<string>();
        }

        protected List<string> Msg { get; set; }
    }
}
