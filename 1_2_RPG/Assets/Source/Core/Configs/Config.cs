// Config.cs
// created by Yaroslav Nevmerzhytskyi

using System;
using System.IO;
using Core.Crypto;
using Core.Observer.Impl;
using Core.Serialization;
using UnityEngine;
using UnityApplication = UnityEngine.Application;

namespace Core.Configs
{
    public abstract class Config<TConfig, TSerializationPolicy, TEncryptionProvider> : Observable
        where TConfig : Config<TConfig, TSerializationPolicy, TEncryptionProvider>, new()
        where TSerializationPolicy : ISerializationPolicy, new()
        where TEncryptionProvider : IEncryptionProvider, new()
    {
        private static readonly String EmbeddedConfigsDirectory = "EmbeddedConfigs";
        private static readonly String ConfigsDirectory = "Configs";
        private static readonly String ResourcesDirectory = "Resources";
        private static readonly String ConfigNotFoundAtPathExceptionMessageFormat = "Can't find config {0} at:{1}";
        private static readonly String ConfigNotFoundExceptionMessageFormat = "Can't find config {0} in Resources folder.";

        public static TConfig Load()
        {
            TConfig config = new TConfig();
            TSerializationPolicy serializationPolicy = new TSerializationPolicy();
            TEncryptionProvider encryptionProvider = new TEncryptionProvider();

            String path = CheckPathAndCreateDirectory(config.GetName(), serializationPolicy.GetExtension());

            if(!File.Exists(path))
            {
                throw new FileNotFoundException(String.Format(ConfigNotFoundAtPathExceptionMessageFormat,config.GetName(), path));
            }

            using(Stream stream = File.OpenRead(path))
            {
                config = serializationPolicy.Restore<TConfig>(stream, encryptionProvider);
                config.OnLoaded();
            }

            return config;
        }

        public static TConfig LoadEmbedded()
        {
            TConfig config = new TConfig();
            TSerializationPolicy serializationPolicy = new TSerializationPolicy();
            TEncryptionProvider encryptionProvider = new TEncryptionProvider();

            String directoryPath = Path.Combine(EmbeddedConfigsDirectory, ConfigsDirectory);
            String path = Path.Combine(directoryPath, config.GetName() ?? String.Empty);

            TextAsset configAsset = (TextAsset)Resources.Load(path);

            if(configAsset == null)
            {
                throw new FileNotFoundException(String.Format(ConfigNotFoundExceptionMessageFormat,config.GetName()));
            }

            config = serializationPolicy.RestoreFromString<TConfig>(configAsset.text, encryptionProvider);
            config.OnLoaded();

            return config;
        }

        public static void Save(TConfig config)
        {
            TSerializationPolicy serializationPolicy = new TSerializationPolicy();
            TEncryptionProvider encryptionProvider = new TEncryptionProvider();

            String path = CheckPathAndCreateDirectory(config.GetName(), serializationPolicy.GetExtension());

            using(Stream stream = File.Open(path, FileMode.Create, FileAccess.Write))
            {
                serializationPolicy.Store(config, stream, encryptionProvider);
            }
        }

#if UNITY_EDITOR

        public static void SaveEmbedded(TConfig config)
        {
            TSerializationPolicy serializationPolicy = new TSerializationPolicy();
            TEncryptionProvider encryptionProvider = new TEncryptionProvider();

            String path = Path.Combine(UnityApplication.dataPath,
                                       Path.Combine(Path.Combine(ResourcesDirectory, EmbeddedConfigsDirectory),
                                                    ConfigsDirectory));
#if UNITY_EDITOR_WIN
            path = path.Replace("/", "\\");
#endif
            if(!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            String configText = serializationPolicy.StoreToString(config, encryptionProvider);
            File.WriteAllText(Path.Combine(path, config.GetName()), configText);
        }

#endif

        private static String CheckPathAndCreateDirectory(String name, String extension)
        {
            String fileName = System.IO.Path.ChangeExtension(name, extension);
            String directoryPath = Path.Combine(UnityApplication.persistentDataPath, ConfigsDirectory);
            String path = Path.Combine(directoryPath, fileName ?? String.Empty);

            if(!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            return path;
        }

        protected abstract String GetName();
        public abstract TConfig LoadDefault();

        public Config()
        {
        }

        protected virtual void OnLoaded()
        {
        }

        public void Save()
        {
            Save((TConfig)this);
        }
    }
}