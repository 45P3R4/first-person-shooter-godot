using Godot;
using System;

public partial class PlayerMovementLanding : State
{
    public override void Enter()
	{
		Player.Body.Velocity = Vector3.Zero;
		Fsm.TransitionTo("PlayerMovementIdle");
	}
}
