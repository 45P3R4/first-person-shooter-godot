using Godot;
using System;

public partial class Fire : State
{
	[Export]
	RayCast3D raycast;

	public override void _PhysicsProcess(double delta)
	{
		if (Input.IsActionJustPressed("fire")){
			if(raycast.IsColliding()){
				if (raycast.GetCollider() is Enemy e) {
					e.TakeDamage(10);
				}
				
			}
		}
	}	
}
