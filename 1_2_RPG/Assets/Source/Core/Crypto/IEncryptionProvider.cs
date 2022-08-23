// IEncryptionProvider.cs
// created by Yaroslav Nevmerzhytskyi

using System;
using System.IO;

namespace Core.Crypto
{
    /// <summary>
    /// Provides Encryption functionality
    /// </summary>
    public interface IEncryptionProvider
    {
        /// <summary>
        /// Encrypts the data provided by the Stream
        /// </summary>
        /// <param name="source">Stream to encrypt</param>
        /// <returns>Encrypted Stream</returns>
        Stream Encrypt(Stream source);
        
        /// <summary>
        /// Encrypts the data provided by the Stream
        /// </summary>
        /// <param name="source">Encrypted Stream</param>
        /// <returns>Decrypted Stream</returns>
        Stream Decrypt(Stream source);
        
        /// <summary>
        /// Encrypts the source String
        /// </summary>
        /// <param name="source">String to encrypt</param>
        /// <returns>Encrypted String</returns>
        String EncryptToString(String source);
        
        /// <summary>
        /// Decrypts an encrypted String
        /// </summary>
        /// <param name="source">Encrypted String</param>
        /// <returns>Decrypted String</returns>
        String DecryptFromString(String source);
    }
}