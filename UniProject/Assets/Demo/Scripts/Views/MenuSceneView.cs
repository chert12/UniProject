using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UniProject.Demo
{
    public class MenuSceneView : ADisposableView
    {
        #region data

        [SerializeField] private Text _textBestScore;
        [SerializeField] private Button _buttonStartGame;
        [SerializeField] private Button _buttonExitApp;

        private IMenuService _menuService;
        private IMenuViewModel _menuViewModel;
        private IErrorService _errorService;

        #endregion

        #region implementation

        protected override void Start()
        {
            base.Start();

            _textBestScore.text = _menuViewModel.BestScore.ToString();

            _buttonStartGame.OnClickAsObservable()
                .Subscribe(_ => _menuService.StartGame())
                .AddTo(Disposer);

            _buttonExitApp.OnClickAsObservable()
                .Subscribe(_ => _menuService.ExitApplication())
                .AddTo(Disposer);

            Observable.EveryUpdate().Subscribe(_ =>
                {
                    if (Input.GetKeyDown(KeyCode.L))
                    {
                        _errorService.ShowErrorMessage("Error message112");
                    }
                })
                .AddTo(Disposer);
        }

        [Inject]
        private void Resolve(IMenuService menuService, IMenuViewModel menuViewModel, IErrorService errorService)
        {
            _menuService = menuService;
            _menuViewModel = menuViewModel;
            _errorService = errorService;
        }

        #endregion
    }
}