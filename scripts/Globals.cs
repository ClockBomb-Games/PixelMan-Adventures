/*
	PixelMan Adventures - An open-source 2D platformer game.
	Copyright (C) 2023 Edgar Lima (RobotoSkunk) <contact@robotoskunk.com>

	This program is free software: you can redistribute it and/or modify
	it under the terms of the GNU Affero General Public License as published
	by the Free Software Foundation, either version 3 of the License, or
	(at your option) any later version.

	This program is distributed in the hope that it will be useful,
	but WITHOUT ANY WARRANTY; without even the implied warranty of
	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
	GNU Affero General Public License for more details.

	You should have received a copy of the GNU Affero General Public License
	along with this program.  If not, see <https://www.gnu.org/licenses/>.
*/


using System;

using Godot;


namespace ClockBombGames.PixelMan
{
	[Flags]
	public enum CollisionLayers {
		Default = 1 << 0,
		Player = 1 << 1,
		Killzone = 1 << 2,
		Platform = 1 << 3,
	}

	public static class Constants
	{
		static float gravity = 0f;

		/// <summary>
		/// The size of the grid in pixels.
		/// </summary>
		public readonly static int gridSize = 16;

		/// <summary>
		/// The max speed of every object in the game.
		/// </summary>
		public readonly static float maxSpeed = 16f * 40f;


		/// <summary>
		/// The default gravity of the game.
		/// </summary>
		public static float Gravity
		{
			get
			{
				if (gravity == 0f) {
					gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();
				}

				return gravity;
			}
		}
	}

	public static class Globals
	{
		// Private variables
		static Director director = null;
		static int avatarIndex = 0;


		/// <summary>
		/// The director of the game.
		/// </summary>
		public static Director Director
		{
			get => director;
		}

		/// <summary>
		/// Shorthand of <code>Globals.Director.Avatars</code>
		/// </summary>
		public static SpriteFrames[] Avatars
		{
			get => director.Avatars;
		}

		/// <summary>
		/// The index of the current avatar.
		/// </summary>
		public static int AvatarIndex
		{
			get => avatarIndex;
			set {
				if (value < 0) {
					value = 0;
				} else if (value >= Avatars.Length) {
					value = Avatars.Length - 1;
				}

				avatarIndex = value;
			}
		}

		/// <summary>
		/// The current avatar of the player.
		/// </summary>
		public static SpriteFrames Avatar
		{
			get => Avatars[AvatarIndex];
		}


		/// <summary>
		/// Tells the director that the player died.
		/// </summary>
		public static void PlayerDied()
		{
			director.TriggerPlayerDeath();
		}


		/// <summary>
		/// Sets the director of the game.
		/// </summary>
		public static void SetDirector(this Director director)
		{
			Globals.director = director;
		}
	}
}
