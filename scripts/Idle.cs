using Godot;
using System;

public partial class Idle : State
{
	public override void PhysicsProcess(float delta) {

		if (Input.IsActionJustPressed("jump"))
			fsm.TransitionTo("Jump");

		if (Input.GetVector("left", "right", "up", "down") != Vector2.Zero)
			fsm.TransitionTo("Walk");

		if (!fsm.body.IsOnFloor()) {
			fsm.TransitionTo("InAir");
		}
	}
}
