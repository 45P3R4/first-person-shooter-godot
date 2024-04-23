using Godot;
using System;

public partial class InAir : State
{
	PlayerSingleton s;

	[Export]
	float gravity = -1;
	public override void PhysicsProcess(float delta)
	{
		PlayerSingleton.body.Velocity += Vector3.Up * PlayerSingleton.gravity;
		PlayerSingleton.body.MoveAndSlide();

		if (PlayerSingleton.body.IsOnFloor()) {
			fsm.TransitionTo("Idle");
		}
	}
}
