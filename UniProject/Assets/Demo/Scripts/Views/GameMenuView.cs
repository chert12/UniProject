using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UniProject.Demo
{
    public class GameMenuView : ADisposableView
    {
        
        #region data
        
        [SerializeField] private Button _buttonBackToMenu;
        private IGameService _gameService;
        
        #endregion
        
        #region implementation
        
        protected override void Start()
        {
            base.Start();

            _buttonBackToMenu.OnClickAsObservable()
                .Subscribe(_ => _gameService.BackToMenu())
                .AddTo(Disposer);
        }

        [Inject]
        private void Resolve(IGameService gameService)
        {
            _gameService = gameService;
        }
        
        
        #endregion
    }
}