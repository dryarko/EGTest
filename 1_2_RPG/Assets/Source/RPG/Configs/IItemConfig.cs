using System;
using System.Collections.Generic;
using Core.Configs;
using Core.Crypto;
using Core.Serialization;
using RPG.Domain.Items;
using RPG.Domain.Items.Impl;

namespace RPG.Configs
{
    internal class ItemConfig : Config<ItemConfig, JSONNetSerializationPolicy, RAWEncryptionProvider>
    {
        private static readonly String FileName = "Items";

        public Dictionary<Guid, Item> Items;
        
        public ItemConfig()
        {
            Items = new Dictionary<Guid, Item>();
        }
        
        /// <inheritdoc />
        protected override String GetName()
        {
            return FileName;
        }

        /// <inheritdoc />
        public override ItemConfig LoadDefault()
        {
            ItemConfig config = new ItemConfig();

            config.Items.Add(Guid.Parse("c69938a9-f1aa-43d0-8518-8143210b00ce"), 
                new Item("Helmet", "Head armour", Guid.Parse("4d9dc178-4b8d-4579-9e54-2ededbbc9b29"), 2f, "brutal-helm"));
            config.Items.Add(Guid.Parse("fe5fcb20-48fc-420b-a863-f5287496a178"),
                new Item("Vest", "Chest armour", Guid.Parse("4d9dc178-4b8d-4579-9e54-2ededbbc9b29"), 2.3f, "abdominal-armor"));
            config.Items.Add(Guid.Parse("ebdba91c-516c-455d-a742-5ff047c4c6fc"),
                new Item("Boots", "Foot armour", Guid.Parse("4d9dc178-4b8d-4579-9e54-2ededbbc9b29"), 4f, "ballerina-shoes"));
            config.Items.Add(Guid.Parse("c3e55ca4-03d1-47e8-aeb3-bdd8c1ff86f3"),
                new Item("Trousers", "Leg armour", Guid.Parse("4d9dc178-4b8d-4579-9e54-2ededbbc9b29"), 3f, "female-legs"));
            

            return config;
        }
    }
}