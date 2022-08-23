// ISerializationPolicy.cs
// created by Yaroslav Nevmerzhytskiy

using System;
using System.IO;
using Core.Crypto;

namespace Core.Serialization
{
    /// <summary>
    /// Policy that provides serialisation functionality. Use implementation of a particular Policy.
    /// </summary>
    public interface ISerializationPolicy
    {
        /// <summary>
        /// Stores serialised Config into a Stream with encryption, defined by the provider
        /// </summary>
        /// <param name="config">Instance of the Config to serialise</param>
        /// <param name="stream">Output stream</param>
        /// <param name="encryptionProvider">Implementation of IEncryptionProvider that provides encryption functionality</param>
        /// <typeparam name="TConfig">Type of the Config</typeparam>
        void Store<TConfig>(TConfig config, Stream stream, IEncryptionProvider encryptionProvider);
        
        /// <summary>
        /// Restores serialised config from a Stream
        /// </summary>
        /// <param name="stream">Input stream</param>
        /// <param name="encryptionProvider">Implementation of IEncryptionProvider that provides encryption functionality</param>
        /// <typeparam name="TConfig">Type of the Config</typeparam>
        /// <returns>Restored Config</returns>
        TConfig Restore<TConfig>(Stream stream, IEncryptionProvider encryptionProvider);
        
        /// <summary>
        /// Stores serialised Config into a String with encryption, defined by the provider
        /// </summary>
        /// <param name="config">Instance of the Config to serialise</param>
        /// <param name="encryptionProvider">Implementation of IEncryptionProvider that provides encryption functionality</param>
        /// <typeparam name="TConfig">Type of the Config</typeparam>
        /// <returns>Serialised String</returns>
        String StoreToString<TConfig>(TConfig config, IEncryptionProvider encryptionProvider);
        
        /// <summary>
        /// Restores serialised Config from a String
        /// </summary>
        /// <param name="config">Input String to deserialise</param>
        /// <param name="encryptionProvider">Implementation of IEncryptionProvider that provides encryption functionality</param>
        /// <typeparam name="TConfig">Type of the Config</typeparam>
        /// <returns>Restored Config</returns>
        TConfig RestoreFromString<TConfig>(String config, IEncryptionProvider encryptionProvider);

        /// <summary>
        /// Extension of the serialised file
        /// </summary>
        /// <returns>Extension</returns>
        String GetExtension();
    }
}