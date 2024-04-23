using Godot;
using System;

public partial class PlayerMovementInAir : State
{

	public override void PhysicsProcess(float delta)
	{
		Player.body.Velocity += Vector3.Up * Player.gravity;
		Player.body.MoveAndSlide();

		if (Player.body.IsOnFloor()) {
			fsm.TransitionTo("PlayerMovementIdle");
		}
	}
}
