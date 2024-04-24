using Godot;
using System;

public partial class Camera : Node3D
{
	[Export]
	Camera3D cam;

	[Export]
	float sensetiveX = 1;

	[Export]
	float sensetiveY = 1;

	Vector3 camRotation;
	
	public override void _Ready()
	{
		camRotation = cam.Rotation;
		Input.MouseMode = Input.MouseModeEnum.Captured;
	}

	public override void _PhysicsProcess(double delta)
	{
		
	}
	public override void _Input(InputEvent @event)
	{
		if (@event is InputEventMouseMotion) {
			InputEventMouseMotion mouseMotion = @event as InputEventMouseMotion;
			Player.Body.RotateY(-mouseMotion.Relative.X * sensetiveX);
			cam.RotateX(-mouseMotion.Relative.Y * sensetiveY);
			camRotation.X = Mathf.Clamp(cam.Rotation.X, Mathf.DegToRad(-90), Mathf.DegToRad(90));
			cam.Rotation = camRotation;
		}
	}
}