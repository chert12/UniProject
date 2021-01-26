using System;
using System.Threading.Tasks;
using Unicache;
using Unicache.Plugin;
using UniRx;
using UnityEngine;
using Zenject;
using UniProject.Abstractions;

namespace UniProject.Demo
{
    /// <summary>
    /// Service which stores and return data which should be cached
    /// </summary>
    public class CacheService : AMonoService, ICacheService
    {

        #region data

        private IUnicache _cache;

        #endregion

        #region interface
        
        /// <summary>
        /// Get image from cache. If image does not exist in cache
        /// it will be downloaded from url and than cached.
        /// </summary>
        /// <param name="url">Image url</param>
        /// <returns>Returns image <see cref="Texture2D"/></returns>
        public IObservable<Texture2D> GetImage(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                Debug.LogWarning("Unable fetch image - incorrect url");
                return Observable.Return<Texture2D>(null);
            }

            return _cache.Fetch(url).ByteToTexture2D();
        }

        public IObservable<byte[]> GetRawData(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                Debug.LogWarning("Unable fetch data - incorrect url");
                return Observable.Return<byte[]>(null);
            }

            return _cache.Fetch(url);
        }

        /// <summary>
        /// Initialize instance
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();

            _cache = new FileCache(gameObject);

            _cache.Handler = new SimpleDownloadHandler();
            _cache.UrlLocator = new SimpleUrlLocator();
            _cache.CacheLocator = new SimpleCacheLocator();
        }

        #endregion
        
    }
}
