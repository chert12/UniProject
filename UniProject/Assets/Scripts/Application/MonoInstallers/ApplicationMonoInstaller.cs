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
        private const string PROJECT_CONTEXT_NAME = "ProjectContext";

        /// <summary>
        /// Installing bindings
        /// </summary>
        public override void InstallBindings()
        {
            name = PROJECT_CONTEXT_NAME;

            Container.BindInterfacesTo<ApplicationService>().AsSingle();
            //TODO install binding here
        }
    }
}