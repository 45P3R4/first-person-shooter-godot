using Godot;
using System;

public partial class LowPoly_FPS_MP5 : Node3D
{
	float rot_x;
	float rot_y;

	float speed = 5;

	Vector3 s;
	Transform3D t = Transform3D.Identity;
	
	public override void _Input(InputEvent @event)
	{
		if (@event is InputEventMouseMotion) {
			InputEventMouseMotion mouseMotion = @event as InputEventMouseMotion;
			rot_x = mouseMotion.Relative.X;
			rot_y = mouseMotion.Relative.Y;
		}
	}

    public override void _PhysicsProcess(double delta)
    {
		s = Vector3.Up * 180 + Vector3.Back * rot_x/3 + Vector3.Right * rot_y/3;

    }
}
