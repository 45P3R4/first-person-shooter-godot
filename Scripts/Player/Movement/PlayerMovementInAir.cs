using Godot;
using System;

public partial class PlayerMovementInAir : State
{
	public override void Process(float delta)
	{
		Player.Body.Velocity += Vector3.Up * Player.Gravity;
		Player.Body.MoveAndSlide();

		if (Player.Body.IsOnFloor() && Player.Body.Velocity.Y == 0) {
			Fsm.TransitionTo("PlayerMovementLanding");
		}
	}
}
