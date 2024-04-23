using Godot;
using System;

public partial class PlayerMovementJump : State
{

	[Export]
	float jump_enegry = 5;

	public override void Enter()
	{
		Player.body.Velocity += Vector3.Up * jump_enegry;
		Player.body.MoveAndSlide();

		fsm.TransitionTo("PlayerMovementInAir");
	}
}
