using Godot;
using System;

public partial class Player : Node3D
{
	public Player Instance;

	public static CharacterBody3D body;
	public static float gravity = -0.5f;

	public override void _Ready()
	{
		if (Instance != null)
		{
			QueueFree();
			return;
		}
		Instance = this;

		body = GetNode<CharacterBody3D>("/root/Node3D/Player/CharacterBody3D");
	}
}
