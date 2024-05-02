using Godot;
using GodotPlugins.Game;
using System;

public partial class PlayerWeaponFire : State
{
	float maxRecoil = 0;

	Vector2 Recoil = Vector2.Zero;

    public override void Enter()
    {
		Player.CurrentWeapon.Shoot();
		Fsm.TransitionTo("PlayerWeaponCooldown");
    }
}
