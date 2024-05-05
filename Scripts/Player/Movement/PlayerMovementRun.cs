using Godot;
using System;

public partial class PlayerMovementRun : State
{
    public override void Process(float delta) {

		Player.Move(Player.SprintSpeed);

		if (!Player.Body.IsOnFloor()) {
			Fsm.TransitionTo("PlayerMovementInAir");
		}

		if (Input.IsActionJustPressed("jump")) {
			Fsm.TransitionTo("PlayerMovementJump");
		}

		if (Player.Body.Velocity == Vector3.Zero)
			Fsm.TransitionTo("PlayerMovementIdle");

		if (Input.IsActionJustPressed("sprint")) {
			Fsm.TransitionTo("PlayerMovementWalk");
		}
	}
}
