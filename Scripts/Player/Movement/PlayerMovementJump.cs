using Godot;
using System;

public partial class PlayerMovementJump : State
{

	[Export]
	float jumpEnegry = 5;

	public override void Process(float delta)
	{
		Player.Body.Velocity += Vector3.Up * jumpEnegry;
		Player.Body.MoveAndSlide();

		Fsm.TransitionTo("PlayerMovementInAir");
	}
}
