using Godot;
using System;

public partial class test : CharacterBody3D
{
	[Export]
	RayCast3D raycast;

    public override void _PhysicsProcess(double delta)
    {
        if (Input.IsActionJustPressed("fire")){
			if(raycast.IsColliding()){
				raycast.GetColliderRid();
			}
		}
    }
}
