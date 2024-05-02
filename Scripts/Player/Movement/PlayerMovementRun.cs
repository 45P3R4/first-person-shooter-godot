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

		if (Input.GetVector("left", "right", "up", "down") == Vector2.Zero) {
			Fsm.TransitionTo("PlayerMovementIdle");
		}

		if (!Input.IsActionPressed("sprint")) {
			Fsm.TransitionTo("PlayerMovementWalk");
		}
	}
}
