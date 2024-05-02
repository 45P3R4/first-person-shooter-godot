using Godot;
using System;

public partial class PlayerMovementRun : State
{
    public override void Enter()
    {
        Player.WeaponStateMachine.Locked = true;
    }

    public override void Process(float delta) {

		Player.Move(Player.SprintSpeed);

		if (!Player.Body.IsOnFloor()) {
			Player.WeaponStateMachine.Locked = false;
			Fsm.TransitionTo("PlayerMovementInAir");
		}

		if (Input.IsActionJustPressed("jump")) {
			Player.WeaponStateMachine.Locked = false;
			Fsm.TransitionTo("PlayerMovementJump");
		}

		if (Input.GetVector("left", "right", "up", "down") == Vector2.Zero) {
			Player.WeaponStateMachine.Locked = false;
			Fsm.TransitionTo("PlayerMovementIdle");
		}

		if (!Input.IsActionPressed("sprint")) {
			Player.WeaponStateMachine.Locked = false;
			Fsm.TransitionTo("PlayerMovementWalk");
		}
	}
}
