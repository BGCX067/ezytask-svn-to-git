using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Windows.Controls;

namespace ezytask.utilities
{
    public class TextBoxTraceListener : TraceListener
    {
        /// <summary>
        /// textbox to dump the messages to.
        /// </summary>
        private TextBox m_TextBox;

        /// <summary>
        /// private .ctor
        /// </summary>
        private TextBoxTraceListener() { }

        /// <summary>
        /// public .ctor
        /// </summary>
        /// <param name="tBox">textbox to dump the messages to.</param>
        public TextBoxTraceListener(TextBox tBox)
        {
            m_TextBox = tBox;
        }

        /// <summary>
        /// write to textbox log
        /// </summary>
        /// <param name="message"> the message </param>
        public override void Write(string message)
        {
            m_TextBox.Dispatcher.Invoke(new Action(delegate{
                m_TextBox.Text += message;
            }));
        }

        /// <summary>
        /// write to textbox log
        /// </summary>
        /// <param name="message"> the message </param>
        public override void WriteLine(string message)
        {
            message = message + Environment.NewLine;
            Write(message);
        }
    }
}
