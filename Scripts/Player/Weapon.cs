using Godot;
using System;

public partial class Weapon : Node3D
{
	public Weapon weapon;

	public static float Cooldown = 0.1f;
	public static float ReloadSpeed = 0.5f;
}
