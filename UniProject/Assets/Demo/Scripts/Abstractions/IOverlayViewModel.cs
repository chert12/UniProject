using System;

namespace UniProject.Demo
{
    public interface IOverlayViewModel
    {
        bool IsLoadingMenuActivated { get; }
        
        event Action<bool> OnLoadingStatusChanged;
    }
}