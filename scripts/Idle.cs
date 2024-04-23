using Godot;
using System;

public partial class Idle : State
{
	PlayerSingleton s;

	public override void PhysicsProcess(float delta) {

		if (Input.IsActionJustPressed("jump"))
			fsm.TransitionTo("Jump");

		if (Input.GetVector("left", "right", "up", "down") != Vector2.Zero)
			fsm.TransitionTo("Walk");

		if (!PlayerSingleton.body.IsOnFloor()) {
			fsm.TransitionTo("InAir");
		}
	}
}
