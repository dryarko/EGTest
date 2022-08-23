// Player.cs
// Created by Yaroslav Nevmerzhytskyi

using System;
using Core.Domain.Impl;

namespace RPG.Domain.Player.Impl
{
	[Serializable]
	public sealed class Player : DomainObject, IPlayer
	{
		public String Name { get; set; }
		public Int32 Level { get; set; }
		public Int32 Score { get; set; }

		public Player()
		{
		}

		public Player(String name, Int32 level, Int32 score)
		{
			Name = name;
			Level = level;
			Score = score;
		}
	}
}