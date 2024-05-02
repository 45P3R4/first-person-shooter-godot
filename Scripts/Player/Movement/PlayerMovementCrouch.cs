using Godot;
using System;

public partial class PlayerMovementCrouch : State
{
    public override void Process(float delta)
    {
		if (!Input.IsActionPressed("crouch"))
			if (!Player.CrouchCast.IsColliding())
				Fsm.TransitionTo("PlayerMovementCrouchOut");

		Player.Move(Player.CrouchedSpeed);

		Player.Body.Velocity += Vector3.Up * Player.Gravity;
    }
}
