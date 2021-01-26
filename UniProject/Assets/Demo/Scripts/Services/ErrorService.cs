using System;
using System.Collections.Generic;
using UniProject.Abstractions;

namespace UniProject.Demo
{
    /// <summary>
    /// Service to show Error messages on the scene
    /// </summary>
    public class ErrorService : AService, IErrorService
    {

        #region data

        private Dictionary<ErrorType, string> _errorMessages;

        #endregion

        #region interface

        /// <summary>
        /// Fires when error message should be shown
        /// </summary>
        public event Action<string> OnError;

        /// <summary>
        /// Initialize instance
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();

            InitErrorMessages();
        }

        /// <summary>
        /// Show the error message
        /// </summary>
        /// <param name="error">Error type</param>
        public void ShowErrorMessage(ErrorType error)
        {
            OnError?.Invoke(_errorMessages[error]);
        }

        /// <summary>
        /// Show the error message
        /// </summary>
        /// <param name="errorMessage">Error message text</param>
        public void ShowErrorMessage(string errorMessage)
        {
            if (string.IsNullOrEmpty(errorMessage))
            {
                throw new ArgumentNullException("errorMessage");
            }
            OnError?.Invoke(errorMessage);
        }

        #endregion

        #region implementation

        private void InitErrorMessages()
        {
            _errorMessages = new Dictionary<ErrorType, string>();
            //TODO init dictionary with error types here
        }

        #endregion
    }
}
