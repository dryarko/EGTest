// JSONSerializationPolicy.cs
// created by Yaroslav Nevmerzhytskyi

using System;
using System.IO;
using Core.Crypto;
using Newtonsoft.Json;

namespace Core.Serialization
{
    /// <summary>
    /// JSON serialization policy that uses Newtonsoft JSON implementation
    /// </summary>
    public class JSONNetSerializationPolicy : ISerializationPolicy
    {
        public JSONNetSerializationPolicy()
        {
        }
        
        /// <inheritdoc />
        public void Store<TConfig>(TConfig config, Stream stream, IEncryptionProvider encryptionProvider)
        {
            using(Stream cryptoStream = encryptionProvider.Encrypt(stream))
            {
                using(TextWriter writer = new StreamWriter(cryptoStream))
                {
                    writer.Write(JsonConvert.SerializeObject(config));
                }
            }
        }

        /// <inheritdoc />
        public TConfig Restore<TConfig>(Stream stream, IEncryptionProvider encryptionProvider)
        {
            using(Stream cryptoStream = encryptionProvider.Encrypt(stream))
            {
                using(TextReader reader = new StreamReader(cryptoStream))
                {
                    return JsonConvert.DeserializeObject<TConfig>(reader.ReadToEnd());
                }
            }
        }

        /// <inheritdoc />
        public String StoreToString<TConfig>(TConfig config, IEncryptionProvider encryptionProvider)
        {
            return encryptionProvider.EncryptToString(JsonConvert.SerializeObject(config));
        }

        /// <inheritdoc />
        public TConfig RestoreFromString<TConfig>(String config, IEncryptionProvider encryptionProvider)
        {
            String decryptedString = encryptionProvider.DecryptFromString(config);
            return (TConfig)JsonConvert.DeserializeObject(decryptedString);
        }

        /// <inheritdoc />
        public String GetExtension()
        {
            return "json";
        }
    }
}