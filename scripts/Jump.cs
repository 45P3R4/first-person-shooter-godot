using Godot;
using System;

public partial class Jump : State
{
	[Export]
	float jump_enegry = 5;

	public override void Enter()
	{
		fsm.body.Velocity += Vector3.Up * jump_enegry;
		fsm.body.MoveAndSlide();
	}
}
