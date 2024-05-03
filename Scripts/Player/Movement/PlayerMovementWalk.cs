using Godot;
using System;

public partial class PlayerMovementWalk : State
{
	public override void Process(float delta) {
		
		Player.Move(Player.NormalSpeed);

		if (!Player.Body.IsOnFloor())
			Fsm.TransitionTo("PlayerMovementInAir");

		if (Input.IsActionJustPressed("jump"))
			Fsm.TransitionTo("PlayerMovementJump");

		if (Input.IsActionJustPressed("crouch"))
			Fsm.TransitionTo("PlayerMovementCrouchIn");

		if(Input.IsActionJustPressed("sprint") && !Player.IsAiming && !Player.IsReloading)
			Fsm.TransitionTo("PlayerMovementRun");

		if (Input.GetVector("left", "right", "up", "down") == Vector2.Zero)
			Fsm.TransitionTo("PlayerMovementIdle");
	}
}
