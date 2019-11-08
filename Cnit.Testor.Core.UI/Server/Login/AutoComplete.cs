using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.XPath;
using System.Windows.Forms;
using System.Configuration;
using System.Runtime.Serialization.Formatters.Binary;

namespace Cnit.Testor.Core.UI.Server.Login
{
    class AutoComplete
    {
		private List<LoginData> _loginData;
		private string ISOLATED_FILE_NAME = "psw.dat";
		private string USER_FOLDER =
			System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\3898EDAC-84BC-4e44-868B-9DA446F3298D";
		private DirectoryInfo _currentDirectory;
		private FileInfo _currentFile;
        /// <summary>
        /// Возвращает пароль по имени пользователя.
        /// </summary>
        /// <param name="UserName">Имя пользователя</param>
        /// <returns></returns>
		public string GetPassword(string userName, out string server)
		{
			string retValue = String.Empty;
			server = String.Empty;
			try
			{
				var user=_loginData.Where(c => c.UserName == userName);
				if (user.Count() == 0)
					return retValue;
				LoginData data = user.FirstOrDefault();
				retValue = data.Password;
				server = data.Server;
			}
			catch (Exception ex)
			{
				SystemMessage.Log(ex);
			}
			return retValue;
		}
        /// <summary>
        /// Добавление новой записи.
        /// </summary>
        /// <param name="UserName">Имя пользователя</param>
        /// <param name="Password">Пароль</param>
		public void WriteNewEntry(string userName, string password, string server)
		{
			try
			{
				CreateACFile();
				LoginData data = new LoginData();
				var user = _loginData.Where(c => c.UserName == userName);
				if (user.Count() > 0)
					data = user.First();
				else
					_loginData.Add(data);
				data.UserName = userName;
				data.Password = password;
				data.Server = server;
				foreach (var entry in _loginData)
					entry.IsSelected = false;
				data.IsSelected = true;
				Serialize();
			}
			catch (Exception ex)
			{
				SystemMessage.ShowErrorMessage(ex.Message);
			}
		}
        /// <summary>
        /// Проверяет наличие Autocomplete файла,
        /// И если его нет - создаёт.
        /// </summary>
        private void CreateACFile()
        {
			try
			{
				bool isNew = false;
				if (_currentDirectory.GetFiles().Where(c => c.Name.ToLower() == ISOLATED_FILE_NAME).Count() == 0 || isNew)
					RemoveHistory();
			}
			catch (Exception ex)
			{
				SystemMessage.ShowErrorMessage(ex.Message);
			}
        }
        /// <summary>
        /// Добавляет в ComboBox список пользователей.
        /// </summary>
        /// <param name="comboBoxUserName">ComboBox</param>
		public void GetItems(ComboBox comboBoxUserName)
		{
			CreateACFile();
			try
			{
				using (FileStream oStream = _currentFile.Open(FileMode.Open))
				{
					BinaryFormatter bin = new BinaryFormatter();
					_loginData = (List<LoginData>)bin.Deserialize(oStream);
					oStream.Close();
				}
				foreach (var data in _loginData)
				{
					comboBoxUserName.Items.Add(data.UserName);
					if (data.IsSelected)
						comboBoxUserName.SelectedItem = data.UserName;
				}
			}
			catch (Exception ex)
			{
				SystemMessage.ShowErrorMessage(ex.Message);
			}
		}

		private void Serialize()
		{
			Serialize(_loginData);
		}

		private void Serialize(List<LoginData> data)
		{
			try
			{
				using (FileStream oStream = _currentFile.Open(FileMode.OpenOrCreate))
				{
					BinaryFormatter bin = new BinaryFormatter();
					bin.Serialize(oStream, data);
					oStream.Close();
				}
			}
			catch (Exception ex)
			{
				SystemMessage.ShowErrorMessage(ex.Message);
			}
		}

		public void RemoveHistory()
		{
			_loginData = new List<LoginData>();
			Serialize();
		}

		public AutoComplete()
		{
			_currentDirectory = new DirectoryInfo(USER_FOLDER);
			if (!_currentDirectory.Exists)
				Directory.CreateDirectory(_currentDirectory.FullName);
			_currentFile = new FileInfo(_currentDirectory.FullName + @"\" + ISOLATED_FILE_NAME);
			_loginData = new List<LoginData>();
		}
    }
}
