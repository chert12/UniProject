using System;
using System.Threading.Tasks;
using Unicache;
using UnityEngine;

namespace UniProject.Demo
{
    /// <summary>
    /// Defines operations with cached data
    /// </summary>
    public interface ICacheService
    {
        /// <summary>
        /// Get image from cache. If image does not exist in cache
        /// it will be downloaded from url and than cached.
        /// </summary>
        /// <param name="url">Image url</param>
        /// <returns>Returns image <see cref="Texture2D"/></returns>
        IObservable<Texture2D> GetImage(string url);

        /// <summary>
        /// Returns raw cached data as bytes array
        /// </summary>
        /// <param name="url">Data url</param>
        /// <returns>Returns raw data <see cref="byte"/></returns>
        IObservable<byte[]> GetRawData(string url);
    }
}