using System;
using UniProject.Abstractions;
using UniRx;
using UnityEngine;
using Zenject;

namespace UniProject.Demo
{
    public class MenuService : AService, IMenuService, IMenuViewModel
    {

        #region data
        
        public int BestScore { get; private set; }
        
        private readonly IApplicationService _applicationService;
        private readonly IOverlayService _overlayService;
            
        #endregion

        #region interface
        
        [Inject]
        public MenuService(IApplicationService applicationService, IOverlayService overlayService)
        {
            _applicationService = applicationService;
            _overlayService = overlayService;
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
            _overlayService.SetLoading(true);

            Observable.Timer(TimeSpan.FromSeconds(1))
                .Subscribe(_ => _applicationService.StartGame())
                .AddTo(Disposer);
        }

        public void ExitApplication()
        {
            Application.Quit();
        }
        
        #endregion
        
    }
}