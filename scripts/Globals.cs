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


using Godot;


namespace RobotoSkunk.PixelMan
{
	public static class Constants
	{
		public readonly static int gridSize = 16;
		public readonly static float maxSpeed = 640; // 16 pixels * 40 Unity units


		static float gravity = 0f;
		public static float Gravity
		{
			get
			{
				if (gravity == 0f) {
					gravity = (float)ProjectSettings.GetSetting("physics/2d/default_gravity");
				}

				return gravity;
			}
		}
	}

	public static class Globals
	{
		static Director director = null;
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
		/// Sets the director of the game.
		/// </summary>
		public static void SetDirector(this Director director)
		{
			Globals.director = director;
		}
	}
}