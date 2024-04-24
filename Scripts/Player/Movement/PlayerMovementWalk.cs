using Godot;
using System;

public partial class PlayerMovementWalk : State
{

	[Export]
    float speed;
	Vector2 inputDir;
    Vector3 dir;

	public override void Process(float delta) {
		inputDir = Input.GetVector("left", "right", "up", "down");
		dir = (GlobalTransform.Basis * new Vector3(inputDir.X, 0, inputDir.Y)).Normalized();
        Player.Body.Velocity = Vector3.Right * dir.X * speed + Vector3.Back * dir.Z * speed;
		
		Player.Body.MoveAndSlide();

		if (!Player.Body.IsOnFloor()) {
			Fsm.TransitionTo("PlayerMovementInAir");
		}

		if (Input.IsActionJustPressed("jump"))
			Fsm.TransitionTo("PlayerMovementJump");

		if(Input.IsActionPressed("sprint"))
			Fsm.TransitionTo("PlayerMovementRun");

		if (Input.GetVector("left", "right", "up", "down") == Vector2.Zero)
			Fsm.TransitionTo("PlayerMovementIdle");
	}
}
