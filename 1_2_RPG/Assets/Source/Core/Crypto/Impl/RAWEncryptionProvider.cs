// RAWEncryptionProvider.cs
// created by Yaroslav Nevmerzhytskyi

using System;
using System.IO;

namespace Core.Crypto
{
    /// <summary>
    /// Provider that doesn't apply any encryption to the data
    /// </summary>
    public sealed class RAWEncryptionProvider : IEncryptionProvider
    {
        public RAWEncryptionProvider()
        {
        }

        /// <inheritdoc />
        public Stream Encrypt(Stream source)
        {
            return source;
        }

        /// <inheritdoc />
        public Stream Decrypt(Stream source)
        {
            return source;
        }

        /// <inheritdoc />
        public String EncryptToString(String source)
        {
            return source;
        }

        /// <inheritdoc />
        public String DecryptFromString(String source)
        {
            return source;
        }
    }
}