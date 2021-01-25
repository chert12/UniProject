using System;
using UniRx;
using UnityEngine;
using Zenject;

namespace UniProject.Abstractions
{
    /// <summary>
    /// Abstract service based on MonoBehaviour
    /// </summary>
    public abstract class AMonoService: MonoBehaviour, 
        IInitializable, 
        IDisposable
    {
        protected CompositeDisposable Disposer { get; private set; }

        /// <summary>
        /// Initialize instance
        /// </summary>
        public virtual void Initialize()
        {
            Disposer = new CompositeDisposable();
        }

        /// <summary>
        /// Dispose instance
        /// </summary>
        public virtual void Dispose()
        {
            Disposer?.Dispose();
        }
    }
}