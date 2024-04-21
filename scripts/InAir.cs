using Godot;
using System;

public partial class InAir : State
{
	[Export]
	float gravity = -1;
	public override void PhysicsProcess(float delta)
	{
		fsm.body.Velocity += Vector3.Up * gravity;
		fsm.body.MoveAndSlide();

		if (fsm.body.IsOnFloor()) {
			fsm.TransitionTo("Idle");
		}
	}
}
