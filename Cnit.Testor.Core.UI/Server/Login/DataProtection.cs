using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace Cnit.Testor.Core.UI.Server.Login
{
    public class DataProtection
    {
        static byte[] s_aditionalEntropy = { 9, 8, 7, 6, 5 };
        static string dataPath = Application.StartupPath + "/";
        /// <summary>
        /// Зашифровать строку.
        /// </summary>
        /// <param name="Password">Строка для шифрования</param>
        /// <returns>Зашифрованная строка</returns>
        internal static string EncryptString(string Password)
        {
            byte[] encryptedData = Protect(Encoding.Unicode.GetBytes(Password));
            return Convert.ToBase64String(encryptedData, Base64FormattingOptions.None);
        }
        /// <summary>
        /// Расшифровать строку.
        /// </summary>
        /// <param name="Password">Зашифрованная строка</param>
        /// <returns>Расшифрованная строка</returns>
        internal static string DecryptString(string cryptedPassword)
        {
            byte[] unCryptedBytes = Unprotect(Convert.FromBase64String(cryptedPassword));
            return Encoding.Unicode.GetString(unCryptedBytes);
        }


        private static byte[] Protect(byte[] data)
        {
            try
            {
                return ProtectedData.Protect(data, s_aditionalEntropy, DataProtectionScope.CurrentUser);
            }
            catch (CryptographicException ex)
            {
                SystemMessage.Log(ex);
                return null;
            }
        }

        private static byte[] Unprotect(byte[] data)
        {
            try
            {

                return ProtectedData.Unprotect(data, s_aditionalEntropy, DataProtectionScope.CurrentUser);
            }
            catch (CryptographicException ex)
            {
                SystemMessage.Log(ex);
                return null;
            }
        }
    }
}
