using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cnit.Testor.Core.Server;

namespace Cnit.Testor.Core
{
    public class SystemMessage
    {
        public static void ShowErrorMessage(Exception ex)
        {
            MessageBox.Show(ex.Message,
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

        public static void ShowServerErrorMessage(string message)
        {
            if (String.IsNullOrEmpty(message))
                SystemMessage.ShowErrorMessage("Ошибка подключения к серверу.");
            else
                SystemMessage.ShowErrorMessage(message);
        }

        public static void ShowErrorMessage(string Message)
        {
            MessageBox.Show(Message,
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

        public static void ShowWarningMessage(string text)
        {
            MessageBox.Show(text, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void Log(Exception ex)
        {
			MessageBox.Show(ex.Message,
				"Error",
				MessageBoxButtons.OK,
				MessageBoxIcon.Error);
        }

        public static void Log(string Message)
        {
			MessageBox.Show(Message,
				"Error",
				MessageBoxButtons.OK,
				MessageBoxIcon.Error);
        }
    }
}
