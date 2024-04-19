using Godot;
using System;

namespace player_camera {

	public partial class Camera : Node3D
	{
		[Export]
		Camera3D cam;
		[Export]
		Node3D body;

		[Export]
		float sensetive_x = 1;
		[Export]
		float sensetive_y = 1;

		Vector3 cam_rotation;

		// Called when the node enters the scene tree for the first time.
		public override void _Ready()
		{
			cam_rotation = cam.Rotation;
			Input.MouseMode = Input.MouseModeEnum.Captured;
		}

		// Called every frame. 'delta' is the elapsed time since the previous frame.
		public override void _PhysicsProcess(double delta)
		{
			
		}

		public override void _Input(InputEvent @event)
		{
			if (@event is InputEventMouseMotion) {
				InputEventMouseMotion mouseMotion = @event as InputEventMouseMotion;
				body.RotateY(-mouseMotion.Relative.X * sensetive_x);
				cam.RotateX(-mouseMotion.Relative.Y * sensetive_y);

				cam_rotation.X = Mathf.Clamp(cam.Rotation.X, Mathf.DegToRad(-90), Mathf.DegToRad(90));
				cam.Rotation = cam_rotation;
			}
		}
	}
}
