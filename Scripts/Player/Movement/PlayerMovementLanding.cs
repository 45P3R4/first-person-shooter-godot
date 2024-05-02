using Godot;
using System;

public partial class PlayerMovementLanding : State
{
    public override void Process(float delta)
	{
		Player.Body.Velocity = Vector3.Zero;
		Fsm.TransitionTo("PlayerMovementIdle");
	}
}
