using Godot;
using System;

public partial class Player : Node3D
{
	public Player Instance;

	public static Weapon CurrentWeapon;
	
	public static  StateMachine WeaponStateMachine;
	public static StateMachine MovementStateMachine;

	public static CharacterBody3D Body;
	public static RayCast3D Raycast;
	public static Camera3D Camera;
	public static AnimationTree Animation;

	public static float Speed = 3;
	public static float SprintSpeed = 6;
	public static float Gravity = -0.2f;
	public static float JumpEnergy = 6;

	public override void _Ready()
	{
		Animation = GetParent().GetNode<AnimationTree>("CharacterBody3D/AnimationTree");
		CurrentWeapon = GetParent().GetNode<Weapon>("./CharacterBody3D/hands/LowPoly_FPS_MP5/Camera/Arms/Skeleton3D/Cylinder_001/MP5");
		Body = GetParent().GetNode<CharacterBody3D>("./CharacterBody3D");
		Camera = GetParent().GetNode<Camera3D>("./CharacterBody3D/hands/LowPoly_FPS_MP5/Camera");
		Raycast = GetParent().GetNode<RayCast3D>("./CharacterBody3D/hands/LowPoly_FPS_MP5/Camera/RayCast3D");
		MovementStateMachine = GetParent().GetNode<StateMachine>("./PlayerMovementStateMachine");
		WeaponStateMachine = GetParent().GetNode<StateMachine>("./PlayerWeaponStateMachine");
	}
}
