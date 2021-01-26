using System;
using UniProject.Abstractions;
using UnityEngine;

namespace UniProject.Demo
{
    public class OverlayService : AService, IOverlayService, IOverlayViewModel
    {
        
        #region data

        private bool _isLoadingMenuActivated;

        public bool IsLoadingMenuActivated => _isLoadingMenuActivated;

        #endregion
        
        #region interface
        
        public event Action<bool> OnLoadingStatusChanged;
        
        public void SetLoading(bool enable)
        {
            _isLoadingMenuActivated = enable;
            OnLoadingStatusChanged?.Invoke(_isLoadingMenuActivated);
        }
        
        #endregion
    }
}