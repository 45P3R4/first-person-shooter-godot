using Godot;
using System;

public partial class Camera : Camera3D
{
	[Export]
	float sensetiveX = 0.005f;

	[Export]
	float sensetiveY = 0.005f;

	Vector3 camRotation;
	
	public override void _Ready()
	{
		camRotation = Rotation;
		Input.MouseMode = Input.MouseModeEnum.Captured;
	}

	public override void _Input(InputEvent @event)
	{
		if (@event is InputEventMouseMotion) {
			InputEventMouseMotion mouseMotion = @event as InputEventMouseMotion;
			Player.Body.RotateY(-mouseMotion.Relative.X * sensetiveX);
			RotateX(-mouseMotion.Relative.Y * sensetiveY);
			camRotation.X = Mathf.Clamp(Rotation.X, Mathf.DegToRad(-90), Mathf.DegToRad(90));
			Rotation = camRotation;
		}
	}
}