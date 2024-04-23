using Godot;
using System;

public partial class PlayerMovementIdle : State
{

	public override void PhysicsProcess(float delta) {

		if (Input.IsActionJustPressed("jump"))
			fsm.TransitionTo("PlayerMovementJump");

		if (Input.GetVector("left", "right", "up", "down") != Vector2.Zero)
			fsm.TransitionTo("PlayerMovementWalk");

		if (!Player.body.IsOnFloor()) {
			fsm.TransitionTo("PlayerMovementInAir");
		}
	}
}
