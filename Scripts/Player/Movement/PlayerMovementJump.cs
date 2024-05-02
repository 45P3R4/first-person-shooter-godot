using Godot;
using System;

public partial class PlayerMovementJump : State
{
	public override void Enter()
	{
		Player.Body.Velocity += Vector3.Up * Player.JumpEnergy;
		Player.Body.MoveAndSlide();

		Fsm.TransitionTo("PlayerMovementInAir");
	}
}
