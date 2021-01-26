using System;
using UniProject.Abstractions;

namespace UniProject.Demo
{
    /// <summary>
    /// Service to show UI messages on the scene
    /// </summary>
    public class MessageService : AService, IMessageService
    {
        /// <summary>
        /// Fires when new message pushed
        /// </summary>
        public event Action<MessageData> OnMessagePushed;

        /// <summary>
        /// Show new message on the scene
        /// </summary>
        /// <param name="message">Message data</param>
        public void Show(MessageData message)
        {
            if (message is null)
            {
                throw new ArgumentNullException("message");
            }

            OnMessagePushed?.Invoke(message);
        }
    }
}
