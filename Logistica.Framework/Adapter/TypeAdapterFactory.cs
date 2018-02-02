using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistica.Framework
{
    public class TypeAdapterFactory
    {
        #region Members

        static ITypeAdapterFactory _currentFactory = null;

        #endregion


        /// <summary>
        /// Set the  cache to use
        /// </summary>
        /// <param name="logFactory">Cache Factory to use</param>
        public static void SetCurrent(ITypeAdapterFactory typeAdapterFactory)
        {
            _currentFactory = typeAdapterFactory;
        }

        /// <summary>
        /// Createt a new <paramref name="Microsoft.Samples.NLayerApp.Infrastructure.Crosscutting.Logging.ILog"/>
        /// </summary>
        /// <returns>Created ILog</returns>
        public static ITypeAdapter Create()
        {
            return (_currentFactory != null) ? _currentFactory.Create() : null;
        }
    }
}
