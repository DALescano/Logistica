using Logistica.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistica.Aplicacion.Servicios
{
    public class SeguridadProceso
    {
        ICache cache;
        public SeguridadProceso()
        {
            cache = CacheFactory.Create();
        }


        public bool MaximoIntentos(string nombreusuario)
        {


            //validar si el usuario tiene intentos
            var intentoactual = cache.GetItem<object>(nombreusuario);

            if (intentoactual == null)
            {
                cache.PutItem(nombreusuario, 1);
                return false;
            }
            else
            {
                LimpiarIntentos(nombreusuario);
                intentoactual = ((int)intentoactual) + 1;
                cache.PutItem(nombreusuario, intentoactual);

                if (((int)intentoactual) == 3) //numero de intentos
                {
                    //cambiar activo.
                    LimpiarIntentos(nombreusuario);
                    return true;
                }
            }
            return false;


        }

        public void LimpiarIntentos(string nombreusuario)
        {
            cache.InvalidateItem(nombreusuario);
        }

    }
}
