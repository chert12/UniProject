using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UniProject.Demo
{
    /// <summary>
    /// Defines view element for showing UI messages. See also
    /// <seealso cref="Mapstar.Vr.Services.MessageService"/>
    /// </summary>
    public class MessagePopUpView : APopupView
    {

        #region data

        [SerializeField] private Text _textMessage;
        [SerializeField] private Text _textTitle;
        [SerializeField] private Text _textSubmit;
        [SerializeField] private Text _textCancel;
        [SerializeField] private Button _buttonCancel;
        [SerializeField] private Button _buttonSubmit;

        private IMessageService _messageService;

        private const string BaseTextTitle = "Info";
        private const string BaseTextSubmit = "Accept";
        private const string BaseTextCancel = "Cancel";

        #endregion

        #region interface

        /// <summary>
        /// Start is called on the frame when a script is enabled just before any of the Update methods are called the first time.
        /// </summary>
        protected override void Start()
        {
            base.Start();

            Observable.FromEvent<MessageData>(h => _messageService.OnMessagePushed += h,
                    h => _messageService.OnMessagePushed -= h)
                .Subscribe(messageData =>
                {
                    _textMessage.text = messageData.Message;
                    _textTitle.text = string.IsNullOrEmpty(messageData.Title) ? BaseTextTitle : messageData.Title;
                    _textSubmit.text = string.IsNullOrEmpty(messageData.SubmitButtonText) ? BaseTextSubmit : messageData.SubmitButtonText;
                    _textCancel.text = string.IsNullOrEmpty(messageData.CancelButtonText) ? BaseTextCancel : messageData.CancelButtonText;
                    _buttonCancel.gameObject.SetActive(messageData.IsTwoButtons);

                    _buttonSubmit.onClick.RemoveAllListeners();
                    _buttonSubmit.onClick.AddListener(() =>
                    {
                        Close();
                        messageData.OnSubmitClicked?.Invoke();
                    });

                    _buttonCancel.onClick.RemoveAllListeners();
                    _buttonCancel.onClick.AddListener(() =>
                    {
                        Close();
                        messageData.OnCancelClicked?.Invoke();
                    });
                    
                    Open();
                })
                .AddTo(Disposer);
        }

        #endregion

        #region implementation

        [Inject]
        private void Init(IMessageService messageService)
        {
            _messageService = messageService;
        }

        #endregion

    }
}