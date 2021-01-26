using UniRx;
using UnityEngine;
using Zenject;

namespace UniProject.Demo
{
    /// <summary>
    /// Base UI view with <see cref="CompositeDisposable"/>
    /// </summary>
    public abstract class ADisposableView : MonoBehaviour
    {
        protected CompositeDisposable Disposer { get; private set; }

        protected virtual void Start()
        {
            Disposer = new CompositeDisposable();
        }

        protected virtual void OnDestroy()
        {
            Disposer?.Dispose();
        }
    }
}