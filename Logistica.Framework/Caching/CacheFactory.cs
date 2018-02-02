
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistica.Framework
{
    public class CacheFactory 
    {
        #region Members

        static ICacheFactory _currentCacheFactory = null;

        #endregion
                

        /// <summary>
        /// Set the  cache to use
        /// </summary>
        /// <param name="logFactory">Cache Factory to use</param>
        public static void SetCurrent(ICacheFactory cacheFactory)
        {
            _currentCacheFactory = cacheFactory;
        }

        /// <summary>
        /// Createt a new <paramref name="Microsoft.Samples.NLayerApp.Infrastructure.Crosscutting.Logging.ILog"/>
        /// </summary>
        /// <returns>Created ILog</returns>
        public static ICache Create()
        {
            return (_currentCacheFactory != null) ? _currentCacheFactory.Create() : null;
        }
    }
}
