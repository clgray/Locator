using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Compression;
using System.Runtime.Serialization.Formatters.Binary;
using Cnit.Testor.Core.Server;

namespace Cnit.Testor.Core.Packaging
{
    public static class DataCompressor
    {
		public static byte[] CompressData<T>(T data)
        {
            byte[] retValue;
            byte[] buffer;
            BinaryFormatter bin = new BinaryFormatter();
            using (MemoryStream stream = new MemoryStream())
            {
                bin.Serialize(stream, data);
                buffer = stream.ToArray();
                stream.Close();
            }
            using (MemoryStream ms = new MemoryStream())
            {
                using (DeflateStream deflate = new DeflateStream(ms, CompressionMode.Compress, true))
                    deflate.Write(buffer, 0, buffer.Length);
                ms.Position = 0;
                using (MemoryStream outStream = new MemoryStream())
                {
                    retValue = new byte[ms.Length];
                    ms.Read(retValue, 0, retValue.Length);
                }
            }
            return retValue;
        }

        public static T DecompressData<T>(byte[] data)
        {
            T retValue = default(T);
            byte[] buffer;
            using (MemoryStream ms = new MemoryStream(data))
            {
                buffer = new byte[ms.Length];
                int read;
                using (MemoryStream objStream = new MemoryStream())
                {
                    using (DeflateStream deflate = new DeflateStream(ms, CompressionMode.Decompress))
                    {
                        while ((read = deflate.Read(buffer, 0, buffer.Length)) != 0)
                            objStream.Write(buffer, 0, read);
                    }
                    objStream.Position = 0;
                    BinaryFormatter bin = new BinaryFormatter();
                    retValue = (T)bin.Deserialize(objStream);
                }
            }
            return retValue;
        }
    }
}
