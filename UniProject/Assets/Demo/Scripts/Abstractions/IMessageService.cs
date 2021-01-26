using System;

namespace UniProject.Demo
{
    /// <summary>
    /// Define operations to show messages to user
    /// </summary>
    public interface IMessageService
    {
        /// <summary>
        /// Fires when new message pushed
        /// </summary>
        event Action<MessageData> OnMessagePushed;

        /// <summary>
        /// Show new message on the scene
        /// </summary>
        /// <param name="message">Message data</param>
        void Show(MessageData message);
    }
}