using Godot;
using System;

public partial class Weapon : Node3D
{
	public Weapon weapon;

	public static bool IsBurst = true;
	public static float Cooldown = 0.11f;
	public static float ReloadSpeed = 0.5f;
	public static Vector2 recoil = new Vector2(0.07f, 0.07f);
}
