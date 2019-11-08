using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Threading;
using System.Reflection;
using System.IO;
using System.Security.Cryptography;
using System.Runtime.Remoting;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.Net;
using Cnit.Testor.Core.UI.Server.Login;
using System.ServiceModel.Security;
using Cnit.Testor.Core.Server;
using System.Drawing.Printing;

namespace Cnit.Testor.Core.UI
{
	public partial class LoginForm : Form
	{
		private const int SEND_TIMEOUT = 240;
		private bool _isProcessing = false;
		private AutoComplete _autoComplete;
		public static bool hasPassword = false;
		public static string settingsUserName, settingsPassword, settingsServer;

		public static string UserName
		{
			get;
			set;
		}

		public LoginForm()
		{
			InitializeComponent();
			comboBoxServer.Items[0] = ConfigurationManager.AppSettings["server"];
		}

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}

		private void buttonOk_Click(object sender, EventArgs e)
		{
			if (comboBoxUserName.Text.Trim() == String.Empty)
			{
				MessageBox.Show("Введите имя пользователя", "Ошибка",
					MessageBoxButtons.OK, MessageBoxIcon.Warning);
				comboBoxUserName.Focus();
				return;
			}
			else if (comboBoxServer.Text.Trim() == String.Empty)
			{
				MessageBox.Show("Выберите сервер для подключения", "Ошибка",
					 MessageBoxButtons.OK, MessageBoxIcon.Warning);
				comboBoxUserName.Focus();
				return;
			}

			LoginForm.settingsUserName = comboBoxUserName.Text.Trim();
			LoginForm.settingsServer = comboBoxServer.Text.Trim();

			UserName = settingsUserName;

			if (textBoxPassword.Text != "          ")
				settingsPassword = textBoxPassword.Text.Trim();
			if (!checkBoxSavePassword.Checked)
				_autoComplete.WriteNewEntry(settingsUserName.Trim(), String.Empty, comboBoxServer.Text.Trim());
			else
				_autoComplete.WriteNewEntry(settingsUserName.Trim(), settingsPassword, comboBoxServer.Text.Trim());
			buttonCancel.Enabled = false;
			buttonOk.Enabled = false;
			textBoxPassword.Enabled = false;
			comboBoxUserName.Enabled = false;
			checkBoxSavePassword.Enabled = false;
			comboBoxServer.Enabled = false;
			linkLabelClearn.Enabled = false;
			_isProcessing = true;
			IServerProvider wp = null;
			if (settingsServer.ToLower() == "sql")
			{
				try
				{
					string connString = TestorSecurityProvider.ConnectionString;
				}
				catch (NullReferenceException)
				{
					SystemMessage.ShowServerErrorMessage("Строка подключения к базе данных не задана");
					_isProcessing = false;
					InitForm();
					return;
				}
				wp = new WebServerProvider(settingsUserName);
			}
			LoginProvider provider = LoginProvider.Login(settingsUserName, settingsPassword, settingsServer, SEND_TIMEOUT, wp,
				new LoginProvider.LoginResultDelegate((hasPassword, errorMessage) =>
			{
				this.Invoke((Action)(() =>
				{
					_isProcessing = false;
					if (!hasPassword)
					{
						SystemMessage.ShowErrorMessage(errorMessage);
						InitForm();
					}
					else
						this.DialogResult = DialogResult.OK;
				}));
			}));
		}

		public void InitForm()
		{
			buttonCancel.Enabled = true;
			buttonOk.Enabled = true;
			textBoxPassword.Enabled = true;
			comboBoxUserName.Enabled = true;
			checkBoxSavePassword.Enabled = true;
			comboBoxServer.Enabled = true;
			linkLabelClearn.Enabled = true;
			comboBoxUserName_SelectedIndexChanged(this, new EventArgs());
		}

		public static bool RemoteCertificateValidationCallback(Object sender, X509Certificate certificate, X509Chain chain,
			SslPolicyErrors sslPolicyErrors)
		{
			return true;
		}

		private void comboBoxUserName_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				if (comboBoxUserName.Text != String.Empty)
				{
					string server = String.Empty;
					settingsPassword = _autoComplete.GetPassword(comboBoxUserName.Text, out server);
					if (settingsPassword != String.Empty)
					{
						textBoxPassword.Text = "          ";
						checkBoxSavePassword.Checked = true;
					}
					else
					{
						textBoxPassword.Text = String.Empty;
						checkBoxSavePassword.Checked = false;
					}
					if (server != String.Empty)
					{
						comboBoxServer.SelectedIndex = -1;
						comboBoxServer.Text = server;
					}
				}
			}
			catch
			{
				textBoxPassword.Text = String.Empty;
				checkBoxSavePassword.Checked = false;
			}
		}

		internal static bool Login()
		{
			LoginForm form = new LoginForm();
			return form.ShowDialog() == DialogResult.OK;
		}

		private void comboBoxUserName_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == 13)
			{
				buttonOk_Click(sender, e);
			}
		}

		private void textBoxPassword_KeyPress(object sender, KeyPressEventArgs e)
		{
			comboBoxUserName_KeyPress(sender, e);
		}

		private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (_isProcessing)
			{
				e.Cancel = true;
			}
		}

		private void linkLabelClearn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if (MessageBox.Show("Вы действительно хотите очистить сохранённые логины и пароли?", "Очистка истории",
				MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
				return;
			try
			{
				_autoComplete.RemoveHistory();
				checkBoxSavePassword.Checked = false;
				comboBoxUserName.Items.Clear();
				comboBoxUserName.Text = String.Empty;
				textBoxPassword.Text = String.Empty;
				if (comboBoxServer.Items.Count != 0)
					comboBoxServer.SelectedIndex = 0;
				MessageBox.Show("История успешно удалена");
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				return;
			}
		}

		private void LoginForm_Load(object sender, EventArgs e)
		{
			if (comboBoxServer.Items.Count != 0)
				comboBoxServer.SelectedIndex = 0;
			comboBoxUserName.Items.Clear();
			try
			{
				settingsPassword = String.Empty;
				_autoComplete = new AutoComplete();
				_autoComplete.GetItems(this.comboBoxUserName);
			}
			catch (Exception ex)
			{
				SystemMessage.Log(ex);
			}
		}
	}
}
