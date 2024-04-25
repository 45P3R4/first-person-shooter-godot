using Godot;
using System;

public partial class Player : Node3D
{
	public Player Instance;

	public static CharacterBody3D Body;
	public static float Speed = 3;
	public static float SprintSpeed = 6;
	public static float Gravity = -0.2f;
	public static float JumpEnergy = 6;

	public override void _Ready()
	{
		if (Instance != null)
		{
			QueueFree();
			return;
		}
		Instance = this;

		Body = GetNode<CharacterBody3D>("/root/Node3D/Player/CharacterBody3D");
	}
}
