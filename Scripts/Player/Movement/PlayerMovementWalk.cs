using Godot;
using System;

public partial class PlayerMovementWalk : State
{

	[Export]
    float speed;
	Vector2 input_dir;
    Vector3 dir;

	public override void Process(float delta) {
		input_dir = Input.GetVector("left", "right", "up", "down");
		dir = (GlobalTransform.Basis * new Vector3(input_dir.X, 0, input_dir.Y)).Normalized();
        Player.body.Velocity = Vector3.Right * dir.X * speed + Vector3.Back * dir.Z * speed;
		
		Player.body.MoveAndSlide();

		if (!Player.body.IsOnFloor()) {
			fsm.TransitionTo("PlayerMovementInAir");
		}

		if (Input.IsActionJustPressed("jump"))
			fsm.TransitionTo("PlayerMovementJump");

		if(Input.IsActionPressed("sprint"))
			fsm.TransitionTo("PlayerMovementRun");

		if (Input.GetVector("left", "right", "up", "down") == Vector2.Zero)
			fsm.TransitionTo("PlayerMovementIdle");
	}
}
