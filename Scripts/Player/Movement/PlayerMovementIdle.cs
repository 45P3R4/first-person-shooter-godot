using Godot;
using System;

public partial class PlayerMovementIdle : State
{

	public override void PhysicsProcess(float delta) {

		if (Input.IsActionJustPressed("jump"))
			Fsm.TransitionTo("PlayerMovementJump");

		if (Input.GetVector("left", "right", "up", "down") != Vector2.Zero)
			Fsm.TransitionTo("PlayerMovementWalk");

		if (!Player.Body.IsOnFloor()) {
			Fsm.TransitionTo("PlayerMovementInAir");
		}
	}
}
