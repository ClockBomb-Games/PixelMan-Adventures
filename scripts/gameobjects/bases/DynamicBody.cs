/*
	PixelMan Adventures - An open-source 2D platformer game.
	Copyright (C) 2023 Edgar Lima (RobotoSkunk) <contact@robotoskunk.com>
	Copyright (C) 2023 Repertix

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

using ClockBombGames.PixelMan.Utils;


namespace ClockBombGames.PixelMan.GameObjects
{
	public partial class DynamicBody : CharacterBody2D, IGODynamicBody
	{
		#region Variables

		/// <summary>
		/// If the gravity is inverted.
		/// </summary>
		protected bool invertedGravity = false;

		/// <summary>
		/// The speed to be applied to the body.
		/// </summary>
		protected Vector2 speed = new(144, 304);


		/// <summary>
		/// Gravity force applied to the body.
		/// </summary>
		protected float Gravity
		{
			get
			{
				if (invertedGravity) {
					return -Constants.Gravity;
				} else {
					return Constants.Gravity;
				}
			}
		}

		#endregion


		enum State
		{
			IDLE,
			RUNNING,
			JUMPING,
			FALLING,
		}


		/// <summary>
		/// Process body's movement based on speed and delta.
		/// </summary>
		protected virtual Vector2 ProcessVelocity(float horizontalSpeed, bool hasHorizontalInput, float delta)
		{
			UpDirection = new Vector2(0f, invertedGravity ? 1f : -1f);

			Vector2 velocity = Velocity;

			///// Horizontal movement

			// Apply friction
			float friction = 2f;
			float acceleration = 3f;

			if (IsOnFloor() && !hasHorizontalInput) {
				friction = 4f;
				acceleration = 1f;
			}

			if (Mathf.Abs(Velocity.X) > 16f) {
				velocity.X -= Mathf.Sign(Velocity.X) * friction * speed.X * delta;
			} else {
				velocity.X = 0f;
			}

			// Apply horizontal input
			if (Mathf.Abs(Velocity.X) < speed.X && hasHorizontalInput) {
				velocity.X += Mathf.Pow(horizontalSpeed * delta, 2f) * Mathf.Sign(horizontalSpeed) * acceleration;
			}

			///// Vertical movement
			velocity.Y += Gravity * delta;

			return velocity;
		}

		/// <summary>
		/// Apply the desired velocity to the body.
		/// </summary>
		protected virtual void ApplyVelocity(Vector2 velocity)
		{
			Velocity = new Vector2(
				Mathf.Clamp(velocity.X, -Constants.maxSpeed, Constants.maxSpeed),
				Mathf.Clamp(velocity.Y, -Constants.maxSpeed, Constants.maxSpeed)
			);
		}


		public void AddVelocity(Vector2 velocity)
		{
			Velocity += velocity;
		}

		public virtual void Impulse(float direction, float force)
		{
			Vector2 directionVector = Vector2.Right.Rotated(direction);

			Velocity *= Vector2.One - RSMath.Abs(directionVector);
			Velocity += directionVector * force;
		}

		public virtual void SwitchGravity()
		{
			invertedGravity = !invertedGravity;
		}
	}
}
