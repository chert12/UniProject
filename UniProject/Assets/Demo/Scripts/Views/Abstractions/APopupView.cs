using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UniProject.Demo
{
    /// <summary>
    /// Base UI popup view
    /// </summary>
    public abstract class APopupView : ADisposableView
    {

        #region data

        /// <summary>
        /// Fires when popup opens
        /// </summary>
        public event Action OnOpen;

        /// <summary>
        /// Fires when popup closes
        /// </summary>
        public event Action OnClose;

        private Animator _animator;
        [SerializeField] protected Button _closeButton;

        protected IMessageService MessageService;
        protected IErrorService ErrorService;
        protected ICacheService CacheService;
        protected bool IsPopupOpened;
        private const string AnimatorStateVariableName = "state";

        #endregion

        #region interface

        /// <summary>
        /// Initialize instance
        /// </summary>
        /// <param name="errorService">Error service implementation</param>
        /// <param name="alertService">Alert service implementation</param>
        /// <param name="cacheService">Cache service implementation</param>
        /// <param name="messageService">Message service implementation</param>
        [Inject]
        private void Init(IErrorService errorService, ICacheService cacheService, IMessageService messageService)
        {
            ErrorService = errorService;
            MessageService = messageService;
            CacheService = cacheService;
        }

        /// <summary>
        /// Start is called on the frame when a script is enabled just before any of the Update methods are called the first time.
        /// </summary>
        protected override void Start()
        {
            base.Start();
            
            _animator = GetComponent<Animator>();

            if (_closeButton != null)
            {
                _closeButton.OnClickAsObservable()
                    .Subscribe(_ => Close())
                    .AddTo(Disposer);
            }
        }

        /// <summary>
        /// Use this to close popup view
        /// </summary>
        public virtual void Close()
        {
            IsPopupOpened = false;
            _animator.enabled = true;
            _animator.SetInteger(AnimatorStateVariableName, 0);
            OnClose?.Invoke();
        }

        /// <summary>
        /// Use this to open popup view
        /// </summary>
        public virtual void Open()
        {
            IsPopupOpened = true;
            _animator.SetInteger(AnimatorStateVariableName, 1);

            Observable.Timer(TimeSpan.FromSeconds(0.5f)).Subscribe(_ =>
                {
                    if (IsPopupOpened)
                    {
                        _animator.enabled = false;
                    }
                })
                .AddTo(Disposer);

            OnOpen?.Invoke();
        }
        
        #endregion

    }
}