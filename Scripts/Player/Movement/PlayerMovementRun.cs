using Godot;
using System;

public partial class PlayerMovementRun : State
{
	Vector2 inputDir;
    Vector3 dir;

    public override void Enter()
    {
        Player.WeaponStateMachine.Locked = true;
    }

    public override void Process(float delta) {

		inputDir = Input.GetVector("left", "right", "up", "down");
		dir = (Player.Body.GlobalTransform.Basis * new Vector3(inputDir.X, 0, inputDir.Y)).Normalized();
		Player.Body.Velocity = Vector3.Right * dir.X * Player.SprintSpeed + Vector3.Back * dir.Z * Player.SprintSpeed;

		Player.Body.MoveAndSlide();

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
