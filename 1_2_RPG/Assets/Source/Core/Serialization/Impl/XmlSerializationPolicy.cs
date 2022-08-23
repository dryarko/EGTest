// XmlSerializationPolicy.cs
// created by Yaroslav Nevmerzhytskyi

using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using Core.Crypto;

namespace Core.Serialization
{
    /// <summary>
    /// XML serialization policy
    /// </summary>
    public sealed class XmlSerializationPolicy : ISerializationPolicy
    {
        public XmlSerializationPolicy()
        {
        }

        /// <inheritdoc />
        public void Store<TConfig>(TConfig config, Stream stream, IEncryptionProvider encryptionProvider)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(TConfig));
            using(Stream cryptoStream = encryptionProvider.Encrypt(stream))
            {
                serializer.Serialize(cryptoStream, config);
            }
        }

        /// <inheritdoc />
        public TConfig Restore<TConfig>(Stream stream, IEncryptionProvider encryptionProvider)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(TConfig));
            using(Stream cryptoStream = encryptionProvider.Decrypt(stream))
            {
                return (TConfig)serializer.Deserialize(cryptoStream);
            }
        }

        /// <inheritdoc />
        public String StoreToString<TConfig>(TConfig config, IEncryptionProvider encryptionProvider)
        {
            StringBuilder builder = new StringBuilder();

            using(TextWriter writer = new StringWriter(builder))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(TConfig));
                serializer.Serialize(writer, config);

                return encryptionProvider.EncryptToString(builder.ToString());
            }
        }

        /// <inheritdoc />
        public TConfig RestoreFromString<TConfig>(String config, IEncryptionProvider encryptionProvider)
        {
            using(TextReader reader = new StringReader(encryptionProvider.DecryptFromString(config)))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(TConfig));

                return (TConfig)serializer.Deserialize(reader);
            }
        }

        /// <inheritdoc />
        public String GetExtension()
        {
            return "xml";
        }
    }
}