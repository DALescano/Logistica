using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistica.Framework
{
    public interface ICache
    {
        /// <summary>
        /// Limpiar todo el cache 
        /// </summary>
        void Clear();

        /// <summary>
        /// Tries to the get cached entry by key.
        /// </summary>
        /// <param name="key">The cache key.</param>
        /// <param name="value">The retrieved value.</param>
        /// <returns>A value of <c>true</c> if entry was found in the cache, <c>false</c> otherwise.</returns>
        T GetItem<T>(string key) where T : class;

        /// <summary>
        /// Adds the specified entry to the cache.
        /// </summary>
        /// <param name="key">The entry key.</param>
        /// <param name="value">The entry value.</param>
        /// <param name="dependentEntitySets">The list of dependent entity sets.</param>
        /// <param name="slidingExpiration">Obtiene o establece un valor que indica si se debe expulsar una entrada de caché si no se ha accedido en un intervalo de tiempo especificado.</param>
        /// <param name="absoluteExpiration">The absolute expiration.</param>
        void PutItem(string key, object value, int slidingExpiration, int absoluteExpiration);

        /// <summary>
        /// Adds the specified entry to the cache.
        /// </summary>
        /// <param name="key">The entry key.</param>
        /// <param name="value">The entry value.</param>
        /// <param name="dependentEntitySets">The list of dependent entity sets.</param>
         void PutItem(string key, object value);

        /// <summary>
        /// Invalidates all cache entries which are dependent on any of the specified entity sets.
        /// </summary>
        /// <param name="entitySets">The entity sets.</param>
        void InvalidateSets(IEnumerable<string> entitySets);

        /// <summary>
        /// Invalidates cache entry with a given key.
        /// </summary>
        /// <param name="key">The cache key.</param>
        void InvalidateItem(string key);
    }
}
