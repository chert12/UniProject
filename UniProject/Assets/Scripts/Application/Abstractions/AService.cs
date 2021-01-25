using System;
using UniRx;
using Zenject;

namespace UniProject.Abstractions
{
    /// <summary>
    /// Abstract service
    /// </summary>
    public abstract class AService : IInitializable, IDisposable
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