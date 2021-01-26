using UniProject.Abstractions;
using Zenject;

namespace UniProject.Demo
{
    public class GameService : AService, IGameService
    {

        #region data
        
        private readonly IApplicationService _applicationService;
        
        #endregion


        #region interface

        [Inject]
        public GameService(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }
        
        public void BackToMenu()
        {
            _applicationService.OpenMenu();
        }

        #endregion
        

    }
}