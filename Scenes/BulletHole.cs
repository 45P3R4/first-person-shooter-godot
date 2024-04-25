using Godot;
using System;

public partial class BulletHole : Node3D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		timer(30);
	}

	private async void timer(float time) 
	{
		await ToSignal(GetTree().CreateTimer(time), SceneTreeTimer.SignalName.Timeout);
	}
}
