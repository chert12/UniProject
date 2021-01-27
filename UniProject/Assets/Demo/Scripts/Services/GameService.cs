using System;
using UniProject.Abstractions;
using UniRx;
using Zenject;

namespace UniProject.Demo
{
    public class GameService : AService, IGameService
    {

        #region data
        
        private readonly IApplicationService _applicationService;
        private readonly IOverlayService _overlayService;
        
        #endregion


        #region interface

        [Inject]
        public GameService(IApplicationService applicationService, IOverlayService overlayService)
        {
            _applicationService = applicationService;
            _overlayService = overlayService;
        }

        public override void Initialize()
        {
            base.Initialize();

            // Simulate loading
            Observable.Timer(TimeSpan.FromSeconds(1))
                .Subscribe(_ => _overlayService.SetLoading(false))
                .AddTo(Disposer);
        }

        public void BackToMenu()
        {
            _applicationService.OpenMenu();
        }

        #endregion
        

    }
}