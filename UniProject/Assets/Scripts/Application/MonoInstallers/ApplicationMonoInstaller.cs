using UniProject.Demo;
using UnityEngine;
using Zenject;

namespace UniProject.Di
{
    /// <summary>
    /// Defines DI container which stores installations for the whole app
    /// </summary>
    public class ApplicationMonoInstaller : MonoInstaller
    {
        private const string ProjectContextName = "ProjectContext";

        /// <summary>
        /// Installing bindings
        /// </summary>
        public override void InstallBindings()
        {
            name = ProjectContextName;

            Container.BindInterfacesTo<ApplicationService>().AsSingle();
            Container.BindInterfacesTo<CacheService>().FromNewComponentOnNewGameObject().AsSingle();
            //TODO install binding here
        }
    }
}