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


namespace RobotoSkunk.PixelMan.GameObjects
{
	public partial class Player : CharacterBody2D
	{
		[Export] private AnimatedSprite2D animator;
		[Export] private Vector2 speed = new(0, 0);
		[Export] private float gravity = 140f;

		readonly private float maxJumpTriggerTime = 0.1f;
		readonly private float maxHangCornerTime = 0.1f;

		private float jumpTriggerTime = 0f;
		private float hangCornerTime = 0f;

		private float horizontalInput = 0f;
		private bool pressedJump = false;


		public override void _Process(double delta)
		{
			horizontalInput = Input.GetAxis("left", "right");
			pressedJump = Input.IsActionJustPressed("jump");

			
		}

		public override void _PhysicsProcess(double delta)
		{
			if (pressedJump) {
				jumpTriggerTime = maxJumpTriggerTime;
			} else {
				jumpTriggerTime -= (float)delta;
			}


			// Vector2 velocity = Velocity;


		}
	}
}
