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
	public static CollisionShape3D Collision;
	public static ShapeCast3D CrouchCast;

	public static float NormalSpeed = 3;
	public static float SprintSpeed = 6;
	public static float CrouchedSpeed = 1.5f;
	public static float Gravity = -0.2f;
	public static float JumpEnergy = 6;
	public static float NormalHeight = 1.8f;
	public static float CrouchedHeight = 0.9f;
	public static float InCrouchSpeed = 5;

	public override void _Ready()
	{
		CrouchCast = GetParent().GetNode<ShapeCast3D>("./CharacterBody3D/CollisionShape3D/CrouchCast");
		Collision = GetParent().GetNode<CollisionShape3D>("CharacterBody3D/CollisionShape3D");
		Animation = GetParent().GetNode<AnimationTree>("CharacterBody3D/AnimationTree");
		CurrentWeapon = GetParent().GetNode<Weapon>("./CharacterBody3D/hands/LowPoly_FPS_MP5/Camera/Arms/Skeleton3D/Cylinder_001/MP5");
		Body = GetParent().GetNode<CharacterBody3D>("./CharacterBody3D");
		Camera = GetParent().GetNode<Camera3D>("./CharacterBody3D/hands/LowPoly_FPS_MP5/Camera");
		Raycast = GetParent().GetNode<RayCast3D>("./CharacterBody3D/hands/LowPoly_FPS_MP5/Camera/RayCast3D");
		MovementStateMachine = GetParent().GetNode<StateMachine>("./PlayerMovementStateMachine");
		WeaponStateMachine = GetParent().GetNode<StateMachine>("./PlayerWeaponStateMachine");
	}

	public static void Move(float speed) {
		Vector2 inputDir = Input.GetVector("left", "right", "up", "down");
		Vector3 dir = (Body.GlobalTransform.Basis * new Vector3(inputDir.X, 0, inputDir.Y)).Normalized();
        Body.Velocity = Vector3.Right * dir.X * speed + Vector3.Back * dir.Z * speed + Vector3.Up * Body.Velocity.Y;
		Body.MoveAndSlide();
	}
}
