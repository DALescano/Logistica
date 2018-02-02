
using Med.Comun.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistica.Framework
{
    public static class StatusResponseAdapter
    {
        /// <summary>
        /// Convierte un StatusResponse para ser enviado en un servicio WCF
        /// </summary>
        /// <param name="statusResponse"></param>
        /// <returns></returns>
        public static StatusResponse Adapt(StatusResponse statusResponse)
        {
            return new StatusResponse() { Message = statusResponse.Message, Messages = statusResponse.Messages, Success = statusResponse.Success };
        }
        /*public static StatusApiResponse Adapt(StatusResponse statusResponse)
        {
            return new StatusApiResponse() { Message = statusResponse.Message, Messages = statusResponse.Messages, Success = statusResponse.Success };
        }*/


    }
}
