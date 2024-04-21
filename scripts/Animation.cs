using Godot;
using player_movement;
using System;

public partial class Animation : Node3D
{
	[Export]
	AnimationTree anim;

	[Export]
	Movement movement;

	float weight = 0;
	float elapsed = 0;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		anim.Set("parameters/idle_walk_run/blend_amount", 0);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		// GD.Print(elapsed);
		switch (movement.Get_state())
		{
			case(Movement.State.Idle):
				anim.Set("parameters/idle_walk_run/blend_amount", -1);
				break;
			case(Movement.State.Walk):
				anim.Set("parameters/idle_walk_run/blend_amount", 0);
				break;
			case(Movement.State.Run):
				anim.Set("parameters/idle_walk_run/blend_amount", 1);
				break;
			case(Movement.State.Jump):
				anim.Set("parameters/idle_walk_run/blend_amount", 0);
				break;
			default:
				anim.Set("parameters/idle_walk_run/blend_amount", 0);
				break;
		}
	}
}
