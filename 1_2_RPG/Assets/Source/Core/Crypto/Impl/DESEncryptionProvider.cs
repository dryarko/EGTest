// DESEncryptionProvider.cs
// created by Yaroslav Nevmerzhytskyi

using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Core.Extensions;

namespace Core.Crypto
{
    /// <summary>
    /// Provider that utilises DES encryption algorithm
    /// </summary>
    public sealed class DESEncryptionProvider : IEncryptionProvider
    {
        private readonly String GuidK = "6b11d00c-1011-4aad-9afc-664e8bad49f6";
        private readonly String GuidV = "8432c151-05e0-4db0-8a86-b98f668700df";
        private readonly Byte[] _k;
        private readonly Byte[] _v;

        public DESEncryptionProvider()
        {
            _k = new List<Byte>(Encoding.UTF8.GetBytes(GuidK)).GetRange(0, 8).ToArray();
            _v = new List<Byte>(Encoding.UTF8.GetBytes(GuidV)).GetRange(0, 8).ToArray();
        }

        /// <inheritdoc />
        public Stream Encrypt(Stream source)
        {
            return new CryptoStream(source, DES.Create().CreateEncryptor(_k, _v),
                                    CryptoStreamMode.Write);
        }

        /// <inheritdoc />
        public Stream Decrypt(Stream source)
        {
            return new CryptoStream(source, DES.Create().CreateDecryptor(_k, _v),
                                    CryptoStreamMode.Read);
        }

        /// <inheritdoc />
        public String EncryptToString(String source)
        {
            using(Stream stringStream = new MemoryStream().GetStreamFromString(source))
            {
                using(CryptoStream cryptoStream = new CryptoStream(stringStream, DES.Create().CreateEncryptor(_k, _v),
                                                                   CryptoStreamMode.Write))
                {
                    using(StreamReader reader = new StreamReader(cryptoStream))
                    {
                        return reader.ReadToEnd();
                    }
                }
            }
        }

        /// <inheritdoc />
        public String DecryptFromString(String source)
        {
            using(Stream stringStream = new MemoryStream().GetStreamFromString(source))
            {
                using(CryptoStream cryptoStream = new CryptoStream(stringStream, DES.Create().CreateDecryptor(_k, _v),
                                                                   CryptoStreamMode.Read))
                {
                    using(StreamReader reader = new StreamReader(cryptoStream))
                    {
                        return reader.ReadToEnd();
                    }
                }
            }
        }
    }
}