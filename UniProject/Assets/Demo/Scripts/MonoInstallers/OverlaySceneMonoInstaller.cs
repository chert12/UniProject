using UniProject.Demo;
using UnityEngine;
using Zenject;

namespace UniProject.Demo
{
    /// <summary>
    /// Defines DI container which stores installations for the whole app
    /// </summary>
    public class OverlaySceneMonoInstaller : MonoInstaller
    {
        /// <summary>
        /// Installing bindings
        /// </summary>
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<OverlayService>().AsSingle();
            Container.BindInterfacesTo<ErrorService>().AsSingle();
            Container.BindInterfacesTo<MessageService>().AsSingle();
        }
    }
}