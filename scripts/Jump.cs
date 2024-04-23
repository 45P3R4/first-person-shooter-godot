using Godot;
using System;

public partial class Jump : State
{
	PlayerSingleton s;

	[Export]
	float jump_enegry = 5;

	public override void Enter()
	{
		PlayerSingleton.body.Velocity += Vector3.Up * jump_enegry;
		PlayerSingleton.body.MoveAndSlide();

		fsm.TransitionTo("InAir");
	}
}
