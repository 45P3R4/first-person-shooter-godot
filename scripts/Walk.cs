using Godot;
using System;

public partial class Walk : State
{
	PlayerSingleton s;

	[Export]
    float speed;
	Vector2 input_dir;
    Vector3 dir;

	public override void Process(float delta) {
		input_dir = Input.GetVector("left", "right", "up", "down");
		dir = (GlobalTransform.Basis * new Vector3(input_dir.X, 0, input_dir.Y)).Normalized();
        PlayerSingleton.body.Velocity = Vector3.Right * dir.X * speed + Vector3.Back * dir.Z * speed;
		
		PlayerSingleton.body.MoveAndSlide();

		if (!PlayerSingleton.body.IsOnFloor()) {
			fsm.TransitionTo("InAir");
		}

		if (Input.IsActionJustPressed("jump"))
			fsm.TransitionTo("Jump");

		if(Input.IsActionPressed("sprint"))
			fsm.TransitionTo("Run");

		if (Input.GetVector("left", "right", "up", "down") == Vector2.Zero)
			fsm.TransitionTo("Idle");
	}
}
