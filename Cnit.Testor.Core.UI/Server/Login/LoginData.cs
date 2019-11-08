using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cnit.Testor.Core.UI.Server.Login
{
	[Serializable]
	internal class LoginData
	{
		private string _server;
		private string _userName;
		private string _password;
		private bool _isSelected;

		public string Server
		{
			get
			{
				return DataProtection.DecryptString(_server);
			}
			set
			{
				_server = DataProtection.EncryptString(value);
			}
		}

		public string UserName
		{
			get
			{
				return DataProtection.DecryptString(_userName);
			}
			set
			{
				_userName = DataProtection.EncryptString(value);
			}
		}

		public string Password
		{
			get
			{
				return DataProtection.DecryptString(_password);
			}
			set
			{
				_password = DataProtection.EncryptString(value);
			}
		}

		public bool IsSelected
		{
			get
			{
				return _isSelected;
			}
			set
			{
				_isSelected = value;
			}
		}
	}
}
