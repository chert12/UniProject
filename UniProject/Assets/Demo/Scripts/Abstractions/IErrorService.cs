using System;

namespace UniProject.Demo
{
    /// <summary>
    /// Define operations to show Error messages
    /// </summary>
    public interface IErrorService
    {
        /// <summary>
        /// Fires when error message should be shown
        /// </summary>
        event Action<string> OnError;

        /// <summary>
        /// Show the error message
        /// </summary>
        /// <param name="error">Error type</param>
        void ShowErrorMessage(ErrorType error);

        /// <summary>
        /// Show the error message
        /// </summary>
        /// <param name="errorMessage">Error message text</param>
        void ShowErrorMessage(string errorMessage);
    }
}