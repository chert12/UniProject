using UniProject.Abstractions;
using UnityEngine;
using Zenject;

namespace UniProject.Demo
{
    public class MenuService : AService, IMenuService, IMenuViewModel
    {

        #region data
        
        public int BestScore { get; private set; }
        
        private IApplicationService _applicationService;

        #endregion

        #region interface
        
        [Inject]
        public MenuService(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        public override void Initialize()
        {
            base.Initialize();

            if (PlayerPrefs.HasKey(Constants.BestScorePlayerPrefsName))
            {
                BestScore = PlayerPrefs.GetInt(Constants.BestScorePlayerPrefsName);
            }
            else
            {
                BestScore = 0;
            }

        }

        public void StartGame()
        {
            _applicationService.StartGame();
        }

        public void ExitApplication()
        {
            Application.Quit();
        }
        
        #endregion
        
    }
}