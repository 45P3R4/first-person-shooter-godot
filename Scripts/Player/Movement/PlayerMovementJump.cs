using Godot;
using System;

public partial class PlayerMovementJump : State
{
    public override void Process(float delta)
    {
        Player.Body.Velocity += Vector3.Up * Player.JumpEnergy;
		Player.Body.MoveAndSlide();

		Fsm.TransitionTo("PlayerMovementInAir");
    }
}
