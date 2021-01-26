using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using Zenject;

namespace UniProject.Demo
{
    public class LoadingPopup : APopupView
    {
        private IOverlayViewModel _overlayViewModel;

        [Inject]
        private void Resolve(IOverlayViewModel overlayViewModel)
        {
            _overlayViewModel = overlayViewModel;
        }
        
        
        protected override void Start()
        {
            base.Start();

            Observable.FromEvent<bool>(h => _overlayViewModel.OnLoadingStatusChanged += h,
                    h => _overlayViewModel.OnLoadingStatusChanged -= h)
                .Subscribe(isOpen =>
                {
                    if (isOpen)
                    {
                        Open();
                    }
                    else
                    {
                        Close();
                    }
                })
                .AddTo(Disposer);
        }
    }
}
