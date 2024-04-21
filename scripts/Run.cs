using Godot;
using System;

public partial class Run : State
{
		[Export]
        float speed;

		[Export]
		CharacterBody3D body;

		Vector2 input_dir;
        Vector3 dir;
        Vector3 velocity;

	public override void PhysicsProcess(float delta) {

		input_dir = Input.GetVector("left", "right", "up", "down");
		dir = (GlobalTransform.Basis * new Vector3(input_dir.X, 0, input_dir.Y)).Normalized();
        velocity.X = dir.X * speed;
        velocity.Z = dir.Z * speed;

		body.Velocity = velocity;
        body.MoveAndSlide();

		if (Input.GetVector("left", "right", "up", "down") == Vector2.Zero)
			fsm.TransitionTo("Idle");

		if(!Input.IsActionPressed("sprint"))
			fsm.TransitionTo("Walk");
	}
}
