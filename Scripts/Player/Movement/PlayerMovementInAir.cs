using Godot;
using System;

public partial class PlayerMovementInAir : State
{

	public override void PhysicsProcess(float delta)
	{
		Player.Body.Velocity += Vector3.Up * Player.Gravity;
		Player.Body.MoveAndSlide();

		if (Player.Body.IsOnFloor()) {
			Fsm.TransitionTo("PlayerMovementLanding");
		}
	}
}
