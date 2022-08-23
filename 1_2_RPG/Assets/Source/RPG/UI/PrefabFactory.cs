// GameConfig.cs
// created by Yaroslav Nevmerzhytskyi

using System;
using RPG.Configuration;
using UnityEngine;

namespace RPG.UI
{
	internal sealed class PrefabFactory
	{
		private static readonly String ConfigurationFilePath = "Configuration/PrefabConfiguration";

		public readonly PrefabConfiguration PrefabConfiguration;
		
		internal PrefabFactory()
		{
			PrefabConfiguration = Resources.Load<PrefabConfiguration>(ConfigurationFilePath);
		}
	}
}