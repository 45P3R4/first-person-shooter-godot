using Godot;
using System;

public partial class Run : State
{
		[Export]
        float speed;

		Vector2 input_dir;
        Vector3 dir;

	public override void PhysicsProcess(float delta) {
		input_dir = Input.GetVector("left", "right", "up", "down");
		dir = (GlobalTransform.Basis * new Vector3(input_dir.X, 0, input_dir.Y)).Normalized();
		fsm.body.Velocity = Vector3.Right * dir.X * speed + Vector3.Back * dir.Z * speed;

		fsm.body.MoveAndSlide();

		if (!fsm.body.IsOnFloor()) {
			fsm.TransitionTo("InAir");
		}

		if (Input.IsActionJustPressed("jump"))
			fsm.TransitionTo("Jump");

		if (Input.GetVector("left", "right", "up", "down") == Vector2.Zero)
			fsm.TransitionTo("Idle");

		if(!Input.IsActionPressed("sprint"))
			fsm.TransitionTo("Walk");
	}
}
