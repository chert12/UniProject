using System;

namespace UniProject.Demo
{
    /// <summary>
    /// Defines message data structure
    /// </summary>
    public class MessageData
    {
        public string Message { get; private set; }
        public string Title { get; private set; }
        public string SubmitButtonText { get; private set; }
        public string CancelButtonText { get; private set; }
        public bool IsTwoButtons { get; private set; }
        public Action OnSubmitClicked { get; private set; }
        public Action OnCancelClicked { get; private set; }

        /// <summary>
        /// Create new instance of <see cref="MessageData"/>
        /// </summary>
        /// <param name="message">Message text</param>
        /// <param name="title">Title text</param>
        /// <param name="onSubmitClicked">Action for submit button</param>
        /// <param name="onCancelClicked">Action for cancel button</param>
        /// <param name="submitButtonText">Submit button text</param>
        /// <param name="cancelButtonText">Cancel button text</param>
        /// <param name="isTwoButtons">Is submit and cancel button needed</param>
        public MessageData(string message,
            string title = null,
            Action onSubmitClicked = null,
            Action onCancelClicked = null,
            string submitButtonText = null,
            string cancelButtonText = null,
            bool isTwoButtons = false)
        {
            Message = message;
            Title = title;
            OnSubmitClicked = onSubmitClicked;
            OnCancelClicked = onCancelClicked;
            IsTwoButtons = isTwoButtons;
            SubmitButtonText = submitButtonText;
            CancelButtonText = cancelButtonText;
        }
    }
}
