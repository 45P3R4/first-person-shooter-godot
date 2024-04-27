using Godot;
using System;

public partial class PlayerMovementRun : State
{
	Vector2 inputDir;
    Vector3 dir;

    public override void Start()
    {
        Player.WeaponStateMachine.Locked = true;
    }

    public override void Process(float delta) {

		inputDir = Input.GetVector("left", "right", "up", "down");
		dir = (Player.Body.GlobalTransform.Basis * new Vector3(inputDir.X, 0, inputDir.Y)).Normalized();
		Player.Body.Velocity = Vector3.Right * dir.X * Player.SprintSpeed + Vector3.Back * dir.Z * Player.SprintSpeed;

		Player.Body.MoveAndSlide();

		if (!Player.Body.IsOnFloor()) 
			Fsm.TransitionTo("PlayerMovementInAir");

		if (Input.IsActionJustPressed("jump"))
			Fsm.TransitionTo("PlayerMovementJump");

		if (Input.GetVector("left", "right", "up", "down") == Vector2.Zero)
			Fsm.TransitionTo("PlayerMovementIdle");

		if (!Input.IsActionPressed("sprint"))
			Fsm.TransitionTo("PlayerMovementWalk");
	}
}
