using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UniProject.Demo
{
    /// <summary>
    /// Defines view element for showing Error messages. See also
    /// <seealso cref="Mapstar.Vr.Services.ErrorService"/>
    /// </summary>
    public class ErrorPopUpView : APopupView
    {

        #region data

        [SerializeField] private Text _textErrorMessage;
        private IErrorService _errorService;

        #endregion

        #region interface
        
        /// <summary>
        /// Start is called on the frame when a script is enabled just before any of the Update methods are called the first time.
        /// </summary>
        protected override void Start()
        {
            base.Start();

            Observable.FromEvent<string>(h => _errorService.OnError += h,
                    h => _errorService.OnError -= h)
                .Subscribe(message =>
                {
                    _textErrorMessage.text = message;
                    Open();
                })
                .AddTo(Disposer);
        }

        #endregion

        #region implementation

        [Inject]
        private void Resolve(IErrorService errorService)
        {
            _errorService = errorService;
        }

        #endregion

    }
}